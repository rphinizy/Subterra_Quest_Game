using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class Character : ObservableObject
    {
        #region ENUMERABLES

        public enum RaceType
        {
            Human, 
            Mole, 
            Bunny, 
            Worm, 
            Geode, 
            Gardner
        }

        #endregion

        #region FIELDS

        protected int _healthPoints;
        protected string _name;
        protected int _locationId;
        protected RaceType _race;

        #endregion

        #region PROPERTIES

        public int HealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int locationId, int healthPoints)
        {
            _name = name;
            _race = race;
            _locationId = locationId;
            _healthPoints = healthPoints;
        }

        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}.";
        }

        #endregion
    }
}
