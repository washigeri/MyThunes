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
        [Required, Display(Name = "Nom"), StringLength(60)]
        public String Name { get; set; }
        [Display(Name = "Jaquette")]
        public String Cover { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        [Display(Name ="Artiste")]
        public virtual Artist Artist { get; set; }
        [Display(Name = "Titres")]
        public virtual ICollection<Song> Songs { get; set; }
        public String Genre { get; set; }
        [Display(Name = "Prix")]
        public Decimal Price { get; set; }
        [Display(Name = "Notes")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
