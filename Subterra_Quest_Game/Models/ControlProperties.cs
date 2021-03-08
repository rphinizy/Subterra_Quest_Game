using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    public class ControlProperties : ObservableObject
    {
        public enum MapButtonText
        {
            Enter,
            Next,
        }
        private MapButtonText _mapButtonText;

        public MapButtonText ButtonText
        {
            get { return _mapButtonText; }
            set { _mapButtonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }
    }
}
