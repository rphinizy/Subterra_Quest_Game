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
        private GameItem _currentGameItem;

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
                OnPropertyChanged(nameof(CurrentLocation));
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

        #endregion
        private void InitializeView()
        {

            _player.UpdateInventoryCategories();

            
        }

        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        
        // private bool PlayerCanAccessLocation(Location nextLocation) // finish coding the player inventory. Need to be able to search through items to determine if nect location is accessible
        //{

        // if (Player.Inventory.Contains( == (_gameMap.CurrentLocation.RequiredRareItemID))
        //{

        // return true;
        // }
        //else
        //{
        //return false;
        //}
        // }



        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>

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

        private void OnPlayerMove()
        {

            // 
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentLocation))
            //{
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                // 
                // update experience points
                //
                // _player.ExperiencePoints += _currentLocation.ModifiyExperiencePoints;

                //
                // update health
                //
                //_player.Health += _currentLocation.ModifyHealth;

                // CurrentLocation = _gameMap.CurrentLocation;
            //}
            _player.Form = _currentLocation.ModifyForm;
            _player.FormImg = _currentLocation.ModifyFormImg;
            _player.PlayerMessage = _currentLocation.ModifyPlayerMessage;
            
            
        }

        public void MoveNorth()
        {
            _gameMap.MoveNorth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
        }
        public void MoveEast()
        {
            if (_gameMap.CurrentLocation.Accessible == true)
            {
                //_gameMap.CurrentLocation.Accessible = true;
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;

            }
            
            OnPlayerMove();
        }

        
            
        public void MoveSouth()
        {
            _gameMap.MoveSouth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
        }
        public void MoveWest()
        {
            
            _gameMap.MoveWest();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
        }

        public void MoveStart()
        {
            _gameMap.MoveStart();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
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
        }

        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.Experience += gameItem.Experience;
            
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
                    break;
                case Food.UseActionType.POISONPLAYER:
                    _player.Health -= food.Value;
                    break;
            }

            _player.RemoveGameItemFromInventory(_currentGameItem);
            _player.PlayerMessage = "You used an item!";
        }

        private void RareItemUse(RareItem rareItem)
        {
            

            _gameMap.OpenLocationsByRareItem(rareItem.ID);
            // add bool property to player rare item for equiped item or not. 
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

        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        private void ResetPlayer()
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
