

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class TeamLeader
    {
        public int Id { get; set; }
        public int? Access { get; set; }

        
        public virtual List<TestsGroup> TestsGroups { get; set; }
        
        public virtual List<User> Users { get; set; }
    }
}
