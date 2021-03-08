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
            _ColumnChangeRequest = _currentLocationCoordinates.Column + 1;

            if (_gameCoordinatesAll[_currentLocationCoordinates.Row, _ColumnChangeRequest] == "yes")
            {
                _currentLocationCoordinates.Column += 1;
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
        #endregion
    }
}
