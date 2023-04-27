

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class TeamLeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Access { get; set; }

        [InverseProperty(nameof(TestsGroup.TeamLeader))]
        public virtual List<TestsGroup> TestsGroups { get; set; }

        [InverseProperty(nameof(User.TeamLeader))]
        public virtual List<User> Users { get; set; }
    }
}
