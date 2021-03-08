using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class Player : ObservableObject
    {
        #region ENUMS

       // public enum PlayerForms { Beetle, Mole, Bunny, Jackalope }

        #endregion

        #region FIELDS

        private string _name;
        private string _form;
        private string _formImg;
        private int _health;
        private int _stamina;
        private int _strength;
        private int _defense;
        private int _experience;
        private int _statPoints;
        //private PlayerForms _formOf;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Form
        {
            get { return _form; }
            set
            {
                _form = value;
                OnPropertyChanged(nameof(Form));
            }
        }
        public string FormImg
        {
            get { return _formImg; }
            set
            {
                _formImg = value;
                OnPropertyChanged(nameof(FormImg));
            }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public int Stamina
        {
            get { return _stamina; }
            set { _stamina = value;
                OnPropertyChanged(nameof(Stamina));
            }
        }

        public int Strength
        {
            get { return _strength; }
            set { _strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        public int Defense
        {
            get { return _defense; }
            set { _defense = value;
                OnPropertyChanged(nameof(Defense));
            }
        }

        public int Experience
        {
            get { return _experience; }
            set { _experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }

        public int StatPoints
        {
            get { return _statPoints; }
            set { _statPoints = value;
                  OnPropertyChanged(nameof(StatPoints));
            }
        }

        //public PlayerForms FormOf
        //{
            //get { return _formOf; }
           // set { _formOf = value;
                //OnPropertyChanged(nameof(FormOf));
            //}
        //}


        #endregion
    }


}
