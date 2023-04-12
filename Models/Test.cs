using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Test
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Namespace { get; set; }
        public int Pipeline { get; set; }
        public int Job { get; set; }
        public string? xmlReport { get; set; }
        public int UserId { get; set; }
    }
}
