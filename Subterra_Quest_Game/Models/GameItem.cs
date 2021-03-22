using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
   public class GameItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }

        public string UseMessage { get; set; }

        public string ItemIcon { get; set; }

        public virtual string InformationString()
        {
            return $"{Name}: {Description} \nValue:{Value}";
        }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }
        public GameItem(int id, string name, int value, string description, int experience, string useMessage = "", string itemIcon ="")
        {
            ID = id;
            Name = name;
            Value = value;
            Description = description;
            Experience = experience;
            UseMessage = useMessage;
            ItemIcon = itemIcon;
        }

        public GameItem(string name, int value, string description)
        {
            
            Name = name;
            Value = value;
            Description = description;
        }
    }
}
