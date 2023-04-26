using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Body { get; set; }
        public DateTime CreateDate { get; set; }


        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
