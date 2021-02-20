using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneLibrary
{
    public class Location
    {
        public string Place { get; set; }
        public int Items { get; set; }
        public string Description { get; set; }
        public Location() { } //allows you to create an empty object

        public Location(string description, string place, int items)
        {
            Place = place;
            Items = items;
            Description = description;
        }
        public override string ToString()
        {
            return string.Format("{0}\nYou will need {1} items to get out of {2}. Click P to pick up items.",
                Description,
                Items,
                Place);

        }
    }
}
