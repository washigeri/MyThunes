using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyThunes.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public DateTime BuyDate { get; set; }
        public int TotalPrice { get; set; }
        //[ForeignKey("ApplicationUser")]
        //public int UserID { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public  List<Album> Content { get; set; }

    }
}
