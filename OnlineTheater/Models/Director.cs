using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTheater.Models
{
    public class Director
    {
        [Key]
        [Required]
        public int DirectorId { get; set; }
        [Display(Name ="Name")]
        public string DirectorName { get; set; }
        [Display(Name = "Surname")]
        public string DirectorLastName { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
    }
}