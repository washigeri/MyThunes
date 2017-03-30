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

        //[Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        public int Price { get; set; }
        public String Format { get; set; }
        public String Path { get; set; }
        //[ForeignKey("Album")]
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }



    }
}
