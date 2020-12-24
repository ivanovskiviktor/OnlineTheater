using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTheater.Models
{
    public class ReservePlay
    {
        public List<Theatre> allTheatres { get; set; }
        public SelectList FilteredPlays { get; set; }
    }
}