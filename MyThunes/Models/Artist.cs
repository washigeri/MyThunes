using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThunes.Models
{
   public class Artist
    {
        //[Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public String Photo { get; set; }
    }
}
