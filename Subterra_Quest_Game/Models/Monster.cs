using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    class Monster : NPC, Ispeak, IBattle
    {
        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;
        public List<string> Messages { get; set; }
        public int SkillLevel { get; set; }
        public BattleModeName BattleMode { get; set; }

        public Weapon CurrentWeapon { get; set; }

        protected override string InformationText()
        {
           return $"{Name} - {Description}";
        }
        public override string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}.";
        }


        public Monster()
        {

        }
        public Monster(int id, string name, RaceType race, int locationId, int healthpoints, string description, int skillLevel, List<string> messages, Weapon currentWeapon)
              : base(id, name, race, locationId, healthpoints, description)
        {
            SkillLevel = skillLevel;
            Messages = messages;
            CurrentWeapon = currentWeapon;
        }

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        public int Attack()
        {
            int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * SkillLevel;

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
            int hitPoints = SkillLevel * MAXIMUM_RETREAT_DAMAGE;

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
            int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * SkillLevel) - DEFENDER_DAMAGE_ADJUSTMENT;

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


    }
}
