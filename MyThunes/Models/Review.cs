using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyThunes.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required, Range(0,10)]
        public int Note { get; set; }

        [Display(Name = "Avis"), StringLength(500)]
        public string Comment { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [ForeignKey("Album"), Display(Name = "Album")]
        public int AlbumID { get; set; }

        public virtual Album Album { get; set; }

        [Required, Display(Name = "Auteur")]
        public int UserID { get; set; }
    }
}