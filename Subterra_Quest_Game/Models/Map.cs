using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Subterra_Quest_Game.Models
{
    public class Map

   
    {

        #region ENUMERABLES
      

        
        #endregion
        #region FIELDS
        private Location[,] _mapLocations;
        private int _rowCoordinate;
        private int _columnCoordinate;
        private int _rowChangeRequest;
        private int _ColumnChangeRequest;
        private GameMapCoordinates _currentLocationCoordinates;
        private List<GameItem> _standardGameItems;

        private string[,] _gameCoordinatesAll = new string[6, 15] {{"no","no","no","no","no","no","no","no","no","no","no","no","no","no","no"},
                                                                   {"no","yes","yes","no","no","no","no","no","no","yes","yes","no","no","no","no"},
                                                                   {"no","yes","yes","yes","yes","yes","yes","yes","yes","yes","yes","yes","yes","yes","no"},
                                                                   {"no","no","no","no","no","yes","yes","no","no","no","no","no","yes","no","no"},
                                                                   {"no","no","yes","no","no","no","no","no","no","no","no","no","no","no","no"},
                                                                   {"no","no","no","no","no","no","no","no","no","no","no","no","no","no","no"} };
        #endregion

        #region PROPERTIES
        
        public Location[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }

        public Location CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        }

        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Map(int rows, int columns)
        {
            _rowCoordinate = rows;
            _columnCoordinate = columns;
            _mapLocations = new Location[rows, columns];
    }

        #endregion

        #region METHODS
       public void MoveNorth()
        {
            _rowChangeRequest = _currentLocationCoordinates.Row - 1;
            
            if (_gameCoordinatesAll[_rowChangeRequest, _currentLocationCoordinates.Column]=="yes")
            {
                _currentLocationCoordinates.Row -= 1;

            }
        }
        public void MoveEast()
        {
            if (CurrentLocation.Accessible == true)
            
            {
                _ColumnChangeRequest = _currentLocationCoordinates.Column + 1;

                if (_gameCoordinatesAll[_currentLocationCoordinates.Row, _ColumnChangeRequest] == "yes")
                {
                    _currentLocationCoordinates.Column += 1;
                }
            }
        }
        public void MoveSouth()
        {
            {
                _rowChangeRequest = _currentLocationCoordinates.Row + 1;

                if (_gameCoordinatesAll[_rowChangeRequest, _currentLocationCoordinates.Column] == "yes")
                {
                    _currentLocationCoordinates.Row += 1;

                }
            }

        }

        public void MoveWest()
        {
            {
                _ColumnChangeRequest = _currentLocationCoordinates.Column - 1;

                if (_gameCoordinatesAll[_currentLocationCoordinates.Row, _ColumnChangeRequest] == "yes")
                {
                    _currentLocationCoordinates.Column -= 1;

                }
            }

        }

        public void MoveStart()
        {
            _currentLocationCoordinates.Row = 1;
            _currentLocationCoordinates.Column = 1;
        }

        public void OpenLocationsByRareItem(int RareItemID)
        {
           Location mapLocation = new Location();

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 15; column++)
                {
                    mapLocation = _mapLocations[row, column];

                    if (mapLocation != null && mapLocation.RequiredRareItemID == RareItemID)
                    {
                        _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column].Accessible = true;
                        mapLocation = _mapLocations[row, column];
                        _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column].Message=($"{mapLocation.Name} is now accessible.");
                        _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column].Description= ($"The figure regards you warmly. \n\n Welcome to {mapLocation.Name}, friend!");

                    }
                }
             
            }
   
        }
        #endregion
    }
}
