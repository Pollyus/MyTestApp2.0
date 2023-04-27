using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Namespace { get; set; }
        public string Pipeline { get; set; }
        public string Job { get; set; }
        public string? xmlReport { get; set; }
        
        
        public int GroupId { get; set; }
        [ForeignKey(nameof(GroupId))]
        [InverseProperty("Tests")]
        public TestsGroup TestsGroup { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Tests")]
        public virtual User User { get; set; }

        [InverseProperty(nameof(Comment.Test))]
        public virtual List<Comment> Comments { get; set; }
    }
}
