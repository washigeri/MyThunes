using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Album
    {
        public String Name { get; set; }
        public String Cover { get; set; }
        public DateTime Date { get; set; }
        //public Artist Musician { get; set; }
        //public List<Title> Titles { get; set; }
        public String Genre { get; set; }
        public Decimal Price { get; set; }
        //public List<Review> Reviews { get; set; }
    }
}
