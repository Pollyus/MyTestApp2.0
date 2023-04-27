using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestsGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? xmlReport { get; set; }

        [InverseProperty(nameof(Test.TestsGroup))]
        public virtual ICollection<Test> Tests { get; set; }

        public int TeamLeaderId { get; set; }
        [ForeignKey(nameof(TeamLeaderId))]
        [InverseProperty("TestsGroups")]
        public TeamLeader TeamLeader { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("TestsGroups")]
        public Project Project { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("TestsGroups")]
        public User User { get; set; }
    }
}
