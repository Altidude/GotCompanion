using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotCompanion
{
    public class Event
    {
        public string Text = "";
        public Faction Player;

        public Event(Faction faction, string text)
        {
            Text = text;

            if (faction == null)
            {
                Player = new Faction();
                Player.name = "All Players";
            }
            else
            {
                Player = faction;
            }

            
        }
    }
}
