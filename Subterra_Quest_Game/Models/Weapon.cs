using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
     public class Weapon :GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public enum AttackList
        {
            bite,
            claw,
            thump,
            antler
        }

        public AttackList Item { get; set; }

        public Weapon(int id, string name, int value, AttackList item, string description, int experience, string useMessage, string itemIcon, int minDamage, int maxDamage)
                    : base(id, name, value, description, experience, useMessage, itemIcon)

        {
            Item = item;
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }
        public override string InformationString()
        {
            return $"{Name}: {Description}\nDamage: {MinimumDamage}-{MaximumDamage}";
        }
    }
}
