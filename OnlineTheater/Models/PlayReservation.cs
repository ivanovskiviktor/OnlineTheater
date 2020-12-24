using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTheater.Models
{
    public class PlayReservation
    {
        [Key]
        public int reservationID { get; set; }
        public virtual Theatre theatre { get; set; }
        public virtual Play selectedPlay { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}