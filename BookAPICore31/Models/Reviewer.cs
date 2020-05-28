using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPICore31.Models
{
    public class Reviewer
    {
        public Reviewer()
        {
            Reviews = new List<Review>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
