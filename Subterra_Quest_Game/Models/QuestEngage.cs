using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
     public class QuestEngage :Quest
    {
        private int _id;
        private string _name;
        //private string _description;
        private QuestStatus _status;
        //private string _statusDetail;
        //private int _experiencePoints;
        private List<NPC> _requiredNpcs;

        public List<NPC> RequiredNpcs
        {
            get { return _requiredNpcs; }
            set { _requiredNpcs = value; }
        }

        public QuestEngage()
        {

        }

        public QuestEngage(int id, string name, QuestStatus status, List<NPC> requiredNpcs)
            : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredNpcs = requiredNpcs;
        }

        public List<NPC> NpcsNotCompleted(List<NPC> NpcsEngaged)
        {
            List<NPC> npcsToComplete = new List<NPC>();

                foreach (var requiredNpc in _requiredNpcs)
                {
                    if (!NpcsEngaged.Any(l => l.ID == requiredNpc.ID))
                    {
                        npcsToComplete.Add(requiredNpc);
                    }
                }
            return npcsToComplete;
        }
    }
}
