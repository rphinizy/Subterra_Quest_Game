using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    class RareItem : GameItem
    {
        public enum RareList
        {
           Antlers,
           MoleHair, 
           RabbitFoot,
           BeetleJuice
        }

        public RareList Item { get; set; }

        public RareItem (int id, string name, int value, RareList item, string description, int experience, string useMessage, string itemIcon ="")
                    :base(id, name, value, description, experience, useMessage, itemIcon)

        {
            Item = item;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nValue: {Value}";
        }

    }
}
