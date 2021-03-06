﻿using System;
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
        public String Name { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        public Decimal Price { get; set; }
        public String Format { get; set; }
        public String Path { get; set; }
        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }



    }
}
