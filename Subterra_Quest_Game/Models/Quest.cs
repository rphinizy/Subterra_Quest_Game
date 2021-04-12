using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class Quest
    {
        public enum QuestStatus
        {
            Unassigned,
            Incomplete,
            Complete
        }
        private int _id;
        private string _name;
        private string _description;
        private QuestStatus _status;
        private string _statusDetail;
        private int _experiencePoints;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public QuestStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string StatusDetail
        {
            get { return _statusDetail; }
            set { _statusDetail = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public Quest()
        {

        }
        public Quest(int id, string name, QuestStatus status)
        {
            _id = id;
            _name = name;
            _status = status;
        }
    }
}
