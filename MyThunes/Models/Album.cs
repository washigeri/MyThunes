using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThunes.Models
{
    public class Album
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Cover { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public String Genre { get; set; }
        public Decimal Price { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
