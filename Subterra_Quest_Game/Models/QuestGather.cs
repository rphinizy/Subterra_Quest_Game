using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class QuestGather : Quest
    {
        private int _id;
        private string _name;
        private string _description;
        private QuestStatus _status;
        private string _statusDetail;
        private int _experiencePoints;
        private List<GameItem> _requiredGameItem;

        public List<GameItem> RequiredGameItem
        {
            get { return _requiredGameItem; }
            set { _requiredGameItem = value; }
        }


        public QuestGather()
        {

        }

        public QuestGather(int id, string name, QuestStatus status, List<GameItem> requiredGameItemQuantities)
            : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredGameItem = requiredGameItemQuantities;
        }

        public List<GameItem> GameItemNotCompleted(List<GameItem> inventory)
        {
            List<GameItem> gameItemToComplete = new List<GameItem>();

            foreach (var missionGameItem in _requiredGameItem)
            {
              // GameItem inventoryItemMatch = inventory.FirstOrDefault(gi => gi.GameItem.ID == missionGameItem.GameItem.ID);
               // if (inventoryItemMatch == null)
               // {
                    //gameItemToComplete.Add(missionGameItem);
                //}
                //else
                //{
                    //if (inventoryItemMatch.Quantity < missionGameItem.Quantity)
                    //{
                       // gameItemToComplete.Add(missionGameItem);
                    //}
                //}
            }

            return gameItemToComplete;
        }
    }
}
