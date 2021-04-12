using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Subterra_Quest_Game.Models;
using System.Windows.Threading;
using Subterra_Quest_Game.DataLayer;
using System.Windows;

namespace Subterra_Quest_Game.PresentationLayer
{
    public class GameInterfaceViewModel : ObservableObject
    {
        #region CONSTANTANTS

        const string TAB = "\t";
        const string NEW_LINE = "\n";

        #endregion
        #region FIELDS
        private Player _player;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationInformation;
        private GameItem _currentGameItem;

        private NPC _currentNpc;

        private Random random = new Random();

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        // public string MessageDisplay
        //{
        // get { return _currentLocation.Message; }
        // }

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public NPC CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }


      
        public GameInterfaceViewModel()
        {

        }

        public GameInterfaceViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();
        }

        public void InitialLocation()
        {
            _player.PlayerMessage ="\n Welcome to the subterranean world of creepy crawlies. \n  Start your new life as a fierce ground beetle and fight monsters \n     for experience and loot as you make your way to Mole-City! ";
        }
        #endregion
        private void InitializeView()
        {

            _player.UpdateInventoryCategories();

            
        }


        #region MOVEMETHODS
      
        public void DEFStatPointClick()
        {
            if (Player.StatPoints > 0)
            {
                Player.Defense = Player.Defense + 1;
                Player.StatPoints = Player.StatPoints - 1;
            }
        }
        public void STRStatPointClick()
        {
            if (Player.StatPoints > 0)
            {
                Player.Strength = Player.Strength + 1;
                Player.StatPoints = Player.StatPoints - 1;
            }
        }

        private void CheckPlayerExperience()
        {
          
            if (_player.SkillLevel == 1)
            {
                if (_player.Experience >= 100)
                {
                    Player.StatPoints += 1;
                    _player.SkillLevel += 1;
                }

            }
            if (_player.SkillLevel == 2)
            {
                if (Player.Experience >= 200)
                {
                    Player.StatPoints += 1;
                   _player.SkillLevel += 1;
                }

            }
            if (_player.SkillLevel == 3)
            {
                if (_player.Experience >= 300)
                {
                   Player.StatPoints += 1;
                    _player.SkillLevel += 1;
                }

            }
            if (_player.SkillLevel == 4)
            {
                if (_player.Experience >= 500)
                {
                   Player.StatPoints += 1;
                   _player.SkillLevel += 1;
                }

            }
            if (_player.SkillLevel == 5)
            {
                if (_player.Experience >= 600)
                {
                    Player.StatPoints += 1;
                    _player.SkillLevel += 1;
                }

            }
            if (_player.SkillLevel == 6)
            {
                if (_player.Experience >= 800)
                {
                    Player.StatPoints += 1;
                    _player.SkillLevel += 1;
                }

            }
        }
        private void OnPlayerMove()
        {
            CheckPlayerExperience();
           // _player.UpdateInventoryCategories();
            // 
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                // 
                // update experience points
                //
                 _player.Experience += _currentLocation.ModifiyExperiencePoints;

            }
            //changes player form based on location. Form property bound in xaml
            _player.Form = _currentLocation.ModifyForm;

            //changes player form source image based on current location. player icon img xaml src is bound to FormImg property
            _player.FormImg = _currentLocation.ModifyFormImg;

            //changes player message base on current location. Message property bound in xaml
            _player.PlayerMessage = _currentLocation.ModifyPlayerMessage;

            //changes the current location description to the modified message. xaml bound to Description Property
            _currentLocation.Description = _currentLocation.ModifyLocationMessage;
          
            




        }

        public void MoveNorth()
        {
            _gameMap.MoveNorth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
            _player.UpdateMissionStatus();
        }
        public void MoveEast()
        {
            if (_gameMap.CurrentLocation.Accessible == true)
            {
                
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;

            }
            
            OnPlayerMove();
            CheckPlayerExperience();
            _player.UpdateMissionStatus();
        }

        
            
        public void MoveSouth()
        {
            _gameMap.MoveSouth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
            
            _player.UpdateMissionStatus();




        }
        public void MoveWest()
        {
            
            _gameMap.MoveWest();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
            _player.UpdateMissionStatus();
        }

        public void MoveStart()
        {
            _gameMap.MoveStart();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
            _player.UpdateMissionStatus();
        }

        public void OpenQuestView()
        {
            QuestView questView = new QuestView(InitializeQuestViewModel());

            questView.Show();
        }

        /// <summary>
        /// initialize all property values for the mission status view model
        /// </summary>
        /// <returns>mission status view model</returns>
        private QuestViewModel InitializeQuestViewModel()
        {
           QuestViewModel questViewModel = new QuestViewModel();

            questViewModel.QuestInformation = GenerateQuestInformation();

           questViewModel.Quests = new List<Quest>(_player.Quests);
            foreach (Quest quest in questViewModel.Quests)
            {
                if (quest is QuestTravel)
                    quest.StatusDetail = GenerateQuestTravelDetail((QuestTravel)quest);

                if (quest is QuestEngage)
                    quest.StatusDetail = GenerateQuestEngageDetail((QuestEngage)quest);
            }

            return questViewModel;
        }

        /// <summary>
        /// generate the mission status information text based on percentage of missions completed
        /// </summary>
        /// <returns>mission status information text</returns>
        private string GenerateQuestInformation()
        {
            string missionStatusInformation;

            double totalMissions = _player.Quests.Count();
            double missionsCompleted = _player.Quests.Where(m => m.Status == Quest.QuestStatus.Complete).Count();

            int percentMissionsCompleted = (int)((missionsCompleted / totalMissions) * 100);
            missionStatusInformation = $"Missions Complete: {percentMissionsCompleted}%" + NEW_LINE;

            if (percentMissionsCompleted == 0)
            {
                missionStatusInformation += "Looks like you are just starting out. No missions complete at this point and you better get on it!";
            }
            else if (percentMissionsCompleted <= 33)
            {
                missionStatusInformation += "Well, you have some of your missions complete, but this is just a start. You have your work cut out for you for sure.";
            }
            else if (percentMissionsCompleted <= 66)
            {
                missionStatusInformation += "You are making great progress with your missions. Keep at it.";
            }
            else if (percentMissionsCompleted == 100)
            {
                missionStatusInformation += "Congratulations, you have completed all missions assigned to you.";
            }

            return missionStatusInformation;
        }

        /// <summary>
        /// generate the text for an engage mission detail
        /// </summary>
        /// <param name="mission">the mission</param>
        /// <returns>mission detail text</returns>
        private string GenerateQuestEngageDetail(QuestEngage quest)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            sb.AppendLine("All Required NPCs");
            foreach (var location in quest.RequiredNpcs)
            {
                sb.AppendLine(TAB + location.Name);
            }

            if (quest.Status == Quest.QuestStatus.Incomplete)
            {
                sb.AppendLine("NPCs Yet to Engage");
                foreach (var location in quest.NpcsNotCompleted(_player.NpcsEngaged))
                {
                    sb.AppendLine(TAB + location.Name);
                }
            }

            sb.Remove(sb.Length - 2, 2); // remove the last two characters that generate a blank line

            return sb.ToString(); ;
        }

        /// <summary>
        /// generate the text for a travel mission detail
        /// </summary>
        /// <param name="mission">the mission</param>
        /// <returns>mission detail text</returns>
        private string GenerateQuestTravelDetail(QuestTravel quest)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();

            sb.AppendLine("All Required Locations");
            foreach (var location in quest.RequiredLocations)
            {
                sb.AppendLine(TAB + location.Name);
            }

            if (quest.Status == Quest.QuestStatus.Incomplete)
            {
                sb.AppendLine("Locations Yet to Visit");
                foreach (var location in quest.LocationsNotCompleted(_player.LocationsVisited))
                {
                    sb.AppendLine(TAB + location.Name);
                }
            }

            sb.Remove(sb.Length - 2, 2); // remove the last two characters that generate a blank line

            return sb.ToString(); ;
        }

        #endregion

        #region ACTION METHODS
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }

            CheckPlayerExperience();
           // _player.UpdateInventoryCategories();
        }
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                //OnPlayerPutDown(selectedGameItem);
            }
            CheckPlayerExperience();
            //_player.UpdateInventoryCategories();
        }

        private void OnPlayerPickUp(GameItem selectedGameItem)
        {
            if (!_player.HasPickedUp(selectedGameItem))
            {
                _player.ItemPickedUp
                    .Add(selectedGameItem);
                _player.Experience += selectedGameItem.Experience;
                CheckPlayerExperience();
            }

        }

       
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case Food food:
                    FoodUse(food);
                    break;
                case RareItem rareItem:
                    RareItemUse(rareItem);
                    break;
                default:
                    break;
            }
        }

        private void FoodUse(Food food)
        {
          
            switch (food.UseAction)
            {
                case Food.UseActionType.HEALPLAYER:
                    _player.Health += food.Value;
                    _player.RemoveGameItemFromInventory(_currentGameItem);
                    break;
                case Food.UseActionType.POISONPLAYER:
                    _player.Health -= food.Value;
                    _player.RemoveGameItemFromInventory(_currentGameItem);
                    break;
            }
            if (_currentGameItem !=null)
            {
                _player.PlayerMessage = _currentGameItem.UseMessage;
                _player.RemoveGameItemFromInventory(_currentGameItem);
            }
            
        }

        private void RareItemUse(RareItem rareItem)
        {
           
            if (_currentLocation.Accessible == false)
            {
                _player.PlayerMessage = _currentGameItem.UseMessage;
                _gameMap.OpenLocationsByRareItem(rareItem.ID);
                _player.RemoveGameItemFromInventory(_currentGameItem);
            }
            else
            {
                _player.PlayerMessage = "\nYou cannot use that item here!";
            }
        }

        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }

        public void OnPlayerTalkTo()
        {
            if (CurrentNpc != null && CurrentNpc is Ispeak)
            {
                Ispeak speakingNpc = CurrentNpc as Ispeak;
                CurrentLocationInformation = speakingNpc.Speak();
            }
            CheckPlayerExperience();
            _player.NpcsEngaged.Add(_currentNpc);
            _player.UpdateMissionStatus();
        }

        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
            CheckPlayerExperience();
        }

        /// <summary>
        /// handle the defend event in the view.
        /// </summary>
        public void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.DEFEND;
            Battle();
            CheckPlayerExperience();
        }

        /// <summary>
        /// handle the retreat event in the view.
        /// </summary>
        public void OnPlayerRetreat()
        {
            _player.BattleMode = BattleModeName.RETREAT;
            Battle();
            CheckPlayerExperience();
        }

        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        private void ResetPlayer()
        {
            Environment.Exit(0);
        }
        #endregion

        #region BATTLE METHODS
        private void Battle()
        {
            //
            // check to see if an NPC can battle
            //
            if (_currentNpc is IBattle)
            {
                IBattle battleNpc = _currentNpc as IBattle;
                int playerHitPoints = _player.Health;
                int battleNpcHitPoints =_currentNpc.Health;
                string battleInformation = "";

                //
                // calculate hit points if the player and NPC have weapons
                //
               
               
                playerHitPoints = CalculatePlayerHitPoints();
               
               

              
                
                battleNpcHitPoints = CalculateNpcHitPoints(battleNpc);
                
                

                //
                // build out the text for the current location information
                //
                battleInformation +=
                    $"Player: {_player.BattleMode}     Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpcHitPoints}" + Environment.NewLine;

                //
                // determine results of battle
                //
                if (_currentNpc.Health <= 0)
                {
                    battleInformation += $"You have slain {_currentNpc.Name}.";
                    _currentLocation.NPCS.Remove(_currentNpc);
                    _player.Experience += 25;
                }
                //else
                //{
                    //battleInformation += $"You have been slain by {_currentNpc.Name}.";
                    //_player.Lives--;
                //}

                CurrentLocationInformation = battleInformation;
                if (_player.Health <= 0) OnPlayerDies("You have been slain and have no lives left.");
            }
            else
            {
                CurrentLocationInformation = "The current NPC will is not battle ready. Seems you are a bit jumpy and your experience suffers.";
                //_player.ExperiencePoints -= 10;
            }

        }

        private BattleModeName NpcBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.ATTACK;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
            }
            return npcBattleResponse;
        }

        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;

            switch (_player.BattleMode)
            {
                case BattleModeName.ATTACK:
                    playerHitPoints = _player.Attack();
                    _currentNpc.Health -= playerHitPoints;
                    break;
                case BattleModeName.DEFEND:
                    playerHitPoints = _player.Defend();
                    break;
                case BattleModeName.RETREAT:
                    playerHitPoints = _player.Retreat();
                    break;
            }

            return playerHitPoints;
        }

        private int CalculateNpcHitPoints(IBattle battleNpc)
        {
            int battleNpcHitPoints = 0;

            switch (NpcBattleResponse())
            {
                case BattleModeName.ATTACK:
                    battleNpcHitPoints = battleNpc.Attack();
                    _player.Health -=battleNpcHitPoints;
                    break;
                case BattleModeName.DEFEND:
                    battleNpcHitPoints = battleNpc.Defend();
                    break;
                case BattleModeName.RETREAT:
                    battleNpcHitPoints = battleNpc.Retreat();
                    break;
            }

            return battleNpcHitPoints;
        }

        #endregion

        #region HELPER METHODS
        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
        #endregion

    }
}
