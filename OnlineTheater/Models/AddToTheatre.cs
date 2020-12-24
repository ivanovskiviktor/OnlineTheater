using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTheater.Models
{
    public class AddToTheatre
    {
        public List<Play> Plays { get; set; }
        public int selectedPlay { get; set; }
        public int selectedTheatre { get; set; }
        public AddToTheatre()
        {
            Plays = new List<Play>();    
           
        }
    }
}