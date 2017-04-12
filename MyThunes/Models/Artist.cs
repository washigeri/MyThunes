using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyThunes.Models
{
    public class Artist
    {
        [Key]
        public int ID { get; set; }
        [StringLength(60), Required, Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Albums")]
        public virtual ICollection<Album> Albums { get; set; }
        public String Photo { get; set; }
    }
}