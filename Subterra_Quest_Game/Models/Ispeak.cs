using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subterra_Quest_Game.Models
{
    interface Ispeak
    {
        List<string> Messages { get; set; }

        string Speak();
    }
}
