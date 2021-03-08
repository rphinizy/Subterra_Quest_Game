using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Subterra_Quest_Game.Models;
using Subterra_Quest_Game.DataLayer;

namespace Subterra_Quest_Game.PresentationLayer
{
    public class GameInterfaceViewModel:ObservableObject
    {
        #region FIELDS
        private Player _player;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
        //private Location _northLocation, eastLocation, _southLocation, _westLocation;
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

        public string MessageDisplay
        {
            get { return FormatMessagesForViewer(); }
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
            
        }

        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>();

            for (int index = 0; index < _messages.Count; index++)
            {
                lifoMessages.Add(_messages[index]);
            }

            return string.Join("\n\n", lifoMessages);
        }

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        public void HPStatPointClick()
        {
            if (Player.StatPoints > 0)
            {
                Player.Health = Player.Health + 1;
                Player.StatPoints = Player.StatPoints - 1;
            }
        }
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
            _player.Form = _currentLocation.ModifyForm;
            _player.FormImg = _currentLocation.ModifyFormImg;
        }

        public void MoveNorth()
        {
            _gameMap.MoveNorth();
            CurrentLocation = _gameMap.CurrentLocation;
            OnPlayerMove();
        }
        public void MoveEast()
        {
            _gameMap.MoveEast();
            CurrentLocation = _gameMap.CurrentLocation;
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


    }
}
