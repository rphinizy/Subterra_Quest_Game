using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public abstract class Character : ObservableObject
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

        protected int _id;
        protected int _health;
        protected string _name;
        protected int _locationId;
        protected RaceType _race;

        //need to add id for NPC's for addition to map. 

        protected Random random = new Random();

        #endregion

        #region PROPERTIES

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value;
                OnPropertyChanged(nameof(Health));
            }
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

        public string Greeting
        {
            get
            {
                return DefaultGreeting();
            }
        }
        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(int id, string name, RaceType race, int locationId, int health)
        {
            _id = id;
            _name = name;
            _race = race;
            _locationId = locationId;
            _health = health;
        }

        public Character(string name, RaceType race, int health)
        {
          
            _name = name;
            _race = race;
            _health = health;
        }
        #endregion

        #region METHODS
        public abstract string DefaultGreeting();

        #endregion
    }
}
