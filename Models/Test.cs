using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Namespace { get; set; }
        public string Pipeline { get; set; }
        public string Job { get; set; }
        public string? xmlReport { get; set; }
        
        public int UserId { get; set; }
        public int TestGroupId { get; set; }
        public virtual TestsGroup TestsGroup { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
