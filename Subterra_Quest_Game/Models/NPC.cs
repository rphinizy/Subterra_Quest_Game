using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }

            set
            {

            }
        }

        public NPC(int id, string name, RaceType race, int locationId, int health, string description)
            : base(id, name, race, locationId, health)
        {
            ID = id;
            Name = name;
            Race = race;
            LocationId = locationId;
            Health = health;
            Description = description;
        }

        public NPC()
        {

        }

        protected abstract string InformationText();
    }
}
