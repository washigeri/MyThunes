using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThunes.Models
{
    public class Review
    {
        //[Key]
        public int ID { get; set; }
        public int Note { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        //[ForeignKey("Album")]
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }
        //[ForeignKey("ApplicationUser")]
        //public int UserID { get; set; }
        //public virtual ApplicationUser Author { get; set; }

    }

}
