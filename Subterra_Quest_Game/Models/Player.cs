using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Subterra_Quest_Game.Models
{
    public class Player : Character
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

        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;

        #region FIELDS

       
        private string _form;
        private string _formImg;
        private string _playerMessage;
        private int _stamina;
        private int _strength;
        private int _defense;
        private int _experience;
        private int _statPoints;

        private int _skillLevel;
        private Weapon _currentWeapon;
        private BattleModeName _battleMode;


        protected ColorType _color;
        private List<Location> _locationsVisited;
        private List<GameItem> _itemPickedUp;

        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _food;
        private ObservableCollection<GameItem> _rareItem;
        private ObservableCollection<GameItem> _weapons;

        #endregion

        #region PROPERTIES


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

        public int SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value;
                OnPropertyChanged(nameof(SkillLevel));
            }
        }

        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }

        public BattleModeName BattleMode
        {
            get { return _battleMode; }
            set { _battleMode = value; }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public List<GameItem> ItemPickedUp
        {
            get { return _itemPickedUp; }
            set { _itemPickedUp = value; }
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
        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _itemPickedUp = new List<GameItem>();
            _food = new ObservableCollection<GameItem>();
            _rareItem = new ObservableCollection<GameItem>();
            _weapons = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS

        public void UpdateInventoryCategories()
        {
           Food.Clear();
           RareItem.Clear();
            Weapons.Clear();
     

            foreach (var gameItem in _inventory)
            {
                if (gameItem is Food) Food.Add(gameItem);
                if (gameItem is RareItem) RareItem.Add(gameItem);
                if (gameItem is Weapon) Weapons.Add(gameItem);

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

        public bool HasPickedUp(GameItem item)
        {
            return _itemPickedUp.Contains(item);
        }
        #endregion

        #region BATTLE METHODS
        public int Attack()
        {
            int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        public int Retreat()
        {
            int hitPoints = _skillLevel * MAXIMUM_RETREAT_DAMAGE;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        public int Defend()
        {
            int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel) - DEFENDER_DAMAGE_ADJUSTMENT;

            if (hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else if (hitPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        public override string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}.";
        }

        #endregion
    }




}
