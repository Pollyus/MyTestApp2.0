using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TestId { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
