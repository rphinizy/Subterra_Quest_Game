using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Subterra_Quest_Game.Models
{
    public class Location : ObservableObject
    {
        #region FIELDS

        private int _id;
        private string _name;
        private string _modifyForm;
        private string _modifyFormImg;
        private string _modifyPlayerMessage;
        private string _modifyLocationMessage;
        private string _modifyChamberColor;
        private string _modifyMapLocatorTop;
        private string _modifyMapLocatorLeft;
        private string _description;
        private string _message;
        private bool _accessible;
        private int _modifiyExperiencePoints;
        private int _requiredRareItemID;
        private ObservableCollection<GameItem> _gameItems;
        private ObservableCollection<NPC> _npcs;
        #endregion

        #region PROPERTIES


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }
        public string ModifyForm
        {
            get { return _modifyForm; }
            set { _modifyForm = value; }
        }
        public string ModifyFormImg
        {
            get { return _modifyFormImg; }
            set { _modifyFormImg = value; }
        }
        public string ModifyPlayerMessage
        {
            get { return _modifyPlayerMessage; }
            set { _modifyPlayerMessage = value; }
        }
        public string ModifyLocationMessage
        {
            get { return _modifyLocationMessage; }
            set { _modifyLocationMessage = value; }
        }
        public string ModifyChamberColor
        {
            get { return _modifyChamberColor; }
            set { _modifyChamberColor = value; }
        }
        public string ModifyMapLocatorTop
        {
            get { return _modifyMapLocatorTop; }
            set { _modifyMapLocatorTop = value; }
        }
        public string ModifyMapLocatorLeft
        {
            get { return _modifyMapLocatorLeft; }
            set { _modifyMapLocatorLeft = value; }
        }
        public int ModifiyExperiencePoints
        {
            get { return _modifiyExperiencePoints; }
            set { _modifiyExperiencePoints = value; }
        }

        public int RequiredRareItemID
        {
            get { return _requiredRareItemID; }
            set { _requiredRareItemID = value; }
        }

        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        public ObservableCollection<NPC> NPCS
        {
            get { return _npcs; }
            set { _npcs = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }


        #endregion

        #region METHODS

        //public override string ToString()
        //{
           // return _name;
        //}

        //
        // code with a for each loop to search each item in player inventory and compare to map location required itemID.
        public bool IsAccessibleByItemPossesion(int playerHasRareItem)
        {
            
            //change to player inventory list when inventory is completed. 
            return playerHasRareItem == _requiredRareItemID ? true : false;
        }
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();

            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }

        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {

                _gameItems.Add(selectedGameItem);
            }

            UpdateLocationGameItems();
        }


        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        #endregion
    }
}
