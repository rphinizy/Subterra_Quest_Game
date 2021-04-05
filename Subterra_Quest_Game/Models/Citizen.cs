using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class Citizen : NPC, Ispeak
    {
        
        public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
        public override string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I am a {_race}.";
        }

        public Citizen()
        {

        }

        public Citizen(int id,string name, RaceType race, int locationId, int healthpoints, string description, List<string> messages)
              : base(id, name, race, locationId, healthpoints, description)
        {
            Messages = messages;
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
    }
}
