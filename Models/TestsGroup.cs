using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestsGroup
    {
        public int Id { get; set; }
        public string? xmlReport { get; set; }
        public int TestId { get; set; }
        public virtual ICollection<Test> Tests { get; set;}

    }
}
