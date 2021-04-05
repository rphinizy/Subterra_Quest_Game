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

                //
                // update health
                //
                //_player.Health += _currentLocation.ModifyHealth;

                // CurrentLocation = _gameMap.CurrentLocation;
            }
            _player.Form = _currentLocation.ModifyForm;
            _player.FormImg = _currentLocation.ModifyFormImg;
            _player.PlayerMessage = _currentLocation.ModifyPlayerMessage;
            
            
            
            
        }

        public void MoveNorth()
        {
            _gameMap.MoveNorth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
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
        }

        
            
        public void MoveSouth()
        {
            _gameMap.MoveSouth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();




        }
        public void MoveWest()
        {
            
            _gameMap.MoveWest();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
        }

        public void MoveStart()
        {
            _gameMap.MoveStart();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
            CheckPlayerExperience();
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
            CheckPlayerExperience();
        }

        private void FoodUse(Food food)
        {
          
            switch (food.UseAction)
            {
                case Food.UseActionType.HEALPLAYER:
                    _player.HealthPoints += food.Value;
                    break;
                case Food.UseActionType.POISONPLAYER:
                    _player.HealthPoints -= food.Value;
                    break;
            }
            _player.PlayerMessage = _currentGameItem.UseMessage;
            _player.RemoveGameItemFromInventory(_currentGameItem);
            //CheckPlayerExperience();
        }

        private void RareItemUse(RareItem rareItem)
        {
            //_currentLocation.Description = "The figure watches as you fiddle with the curious item";
            _gameMap.OpenLocationsByRareItem(rareItem.ID);
            // add bool property to player rare item for equiped item or not. 
            _player.PlayerMessage = _currentLocation.Message;
            _player.RemoveGameItemFromInventory(_currentGameItem);
            
            OnPlayerMove();
            CheckPlayerExperience();
        }


        //private void OnPlayerPutDown(GameItem gameItem)
        //{
        //_player.Wealth -= gameItem.Value;
        //}

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
                int playerHitPoints = 0;
                int battleNpcHitPoints = 0;
                string battleInformation = "";

                //
                // calculate hit points if the player and NPC have weapons
                //
                if (_player.CurrentWeapon != null)
                {
                    playerHitPoints = CalculatePlayerHitPoints();
                }
                else
                {
                    battleInformation = "It appears you are entering into battle without a weapon." + Environment.NewLine;
                }

                if (battleNpc.CurrentWeapon != null)
                {
                    battleNpcHitPoints = CalculateNpcHitPoints(battleNpc);
                }
                else
                {
                    battleInformation = $"It appears you are entering into battle with {_currentNpc.Name} who has no weapon." + Environment.NewLine;
                }

                //
                // build out the text for the current location information
                //
                battleInformation +=
                    $"Player: {_player.BattleMode}     Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpcHitPoints}" + Environment.NewLine;

                //
                // determine results of battle
                //
                if (playerHitPoints >= battleNpcHitPoints)
                {
                    battleInformation += $"You have slain {_currentNpc.Name}.";
                    _currentLocation.NPCS.Remove(_currentNpc);
                }
                else
                {
                    battleInformation += $"You have been slain by {_currentNpc.Name}.";
                    //_player.Lives--;
                }

                CurrentLocationInformation = battleInformation;
                if (_player.HealthPoints <= 0) OnPlayerDies("You have been slain and have no lives left.");
            }
            else
            {
                CurrentLocationInformation = "The current NPC will is not battle ready. Seems you are a bit jumpy and your experience suffers.";
                //_player.ExperiencePoints -= 10;
            }

        }
        private BattleModeName NpcBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.RETREAT;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.DEFEND;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.RETREAT;
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
