using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Models
{
    public class Country
    {
        public Country()
        {
           Authors = new List<Author>();     
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
