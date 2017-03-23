using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Song
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        public int Price { get; set; }
        public String Format { get; set; }
        public String Path { get; set; }


    }
}
