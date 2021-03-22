using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Subterra_Quest_Game.Models
{
    public class Player : ObservableObject
    {
        #region ENUMS

        public enum ColorType
        {
            Red,
            Blue,
            Green,
            Yellow,
            MediumPurple,
            HotPink

        }

        #endregion

        #region FIELDS

        private string _name;
        private string _form;
        private string _formImg;
        private string _playerMessage;
        private int _health;
        private int _stamina;
        private int _strength;
        private int _defense;
        private int _experience;
        private int _statPoints;
        protected ColorType _color;
        private List<Location> _locationsVisited;

        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _food;
        private ObservableCollection<GameItem> _rareItem;

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
            set { _form = value;
                 OnPropertyChanged(nameof(Form));
            }
        }
        public string FormImg
        {
            get { return _formImg; }
            set { _formImg = value;
                 OnPropertyChanged(nameof(FormImg));
            }
        }

        public string PlayerMessage
        {
            get { return _playerMessage; }
            set { _playerMessage = value;
                 OnPropertyChanged(nameof(PlayerMessage));
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

        public ColorType Color
        {
            get { return _color; }
            set { _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItem> Food
        {
            get { return _food; }
            set { _food = value; }
        }

        public ObservableCollection<GameItem> RareItem
        {
            get { return _rareItem; }
            set { _rareItem = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _food = new ObservableCollection<GameItem>();
            _rareItem = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        public void UpdateInventoryCategories()
        {
           Food.Clear();
           RareItem.Clear();
     

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Food) Food.Add(gameItem);
                if (gameItem is RareItem) RareItem.Add(gameItem);
                
            }
        }

        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }


        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }
        #endregion
    }




}
