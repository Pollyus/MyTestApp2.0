using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string? Body { get; set; }
        public DateTime CreateDate { get; set; }


        public int TestId { get; set; }
        [ForeignKey(nameof(TestId))]
        [InverseProperty("Comments")]
        public virtual Test Test { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Comments")]
        public virtual User User { get; set; }
    }
}
