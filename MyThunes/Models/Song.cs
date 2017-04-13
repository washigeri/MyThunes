using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThunes.Models
{
    public class Song
    {

        [Key]
        public int ID { get; set; }
        [Display(Name = "Titre")]
        public String Name { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Date de sortie"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Genre")]
        public String Genre { get; set; }
        [Display(Name = "Prix")]
        public Decimal Price { get; set; }
        [Display(Name = "Format")]
        public String Format { get; set; }
        [Display(Name = "Chemin")]
        public String Path { get; set; }
        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }



    }
}
