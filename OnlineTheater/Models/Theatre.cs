using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTheater.Models
{
    public class Theatre
    {
        [Key]
        public int TheatreId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual ICollection<Play> Plays { get; set; }
        public Theatre()
        {
            Plays = new List<Play>();

        }
    }
}