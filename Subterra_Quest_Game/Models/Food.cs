using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class Food : GameItem
    {

        public enum UseActionType
        {
            HEALPLAYER,
            POISONPLAYER
        }

        public UseActionType UseAction { get; set; }
       

       public Food(int id, string name, int health, UseActionType useAction, string description, int experience, string useMessage, string itemIcon)
           : base(id, name, health, description, experience, useMessage, itemIcon)

        {
            UseAction = useAction;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nHeals for: {Value}";
        }
    }

   
}
