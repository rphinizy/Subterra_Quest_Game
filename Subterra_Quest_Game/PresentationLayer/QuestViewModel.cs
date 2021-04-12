using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subterra_Quest_Game.Models;

namespace Subterra_Quest_Game.PresentationLayer
{
    public class QuestViewModel : ObservableObject
    {
        private string _questInformation;
        private List<Quest> _quests;

        public List<Quest> Quests
        {
            get { return _quests; }
            set { _quests = value; }
        }

        public string QuestInformation
        {
            get { return _questInformation; }
            set
            {
                _questInformation = value;
                OnPropertyChanged(nameof(QuestInformation));
            }
        }
    }
}
