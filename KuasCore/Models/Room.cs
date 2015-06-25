using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Room
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string maxpeople { get; set; }

        public string weekdaysprice { get; set; }

        public string holidayprice { get; set; }

        public string statue { get; set; }

        public override string ToString()
        {
            return "Room: Id = " + Id + ", Name = " + Name + ", maxpeople = " + maxpeople + ", weekdaysprice = " + weekdaysprice + ", holidayprice = " + holidayprice + ", statue = " + statue + ".";
        }
    }
}
