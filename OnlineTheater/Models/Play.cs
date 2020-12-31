
using OnlineTheater.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTheater.Models
{
    public class Play
    {
        [Key]
        public int PlayId { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string PlayName { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public Language Language { get; set; }
        public virtual ICollection<Theatre> Theatres { get; set; }
        public Play()
        {
            Theatres = new List<Theatre>();
        }

    }
}