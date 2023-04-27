using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        //[JsonIgnore]
        public string Password { get; set; }
        public string Email { get; set; }


        
        public int TeamLeaderId { get; set; }
        [ForeignKey(nameof(TeamLeaderId))]
        [InverseProperty("Users")]
        public TeamLeader TeamLeader { get; set; }

        [InverseProperty(nameof(Comment.User))]
        public virtual List<Comment> Comments { get; set; }

        //public int TestId{ get; set; }
        //[ForeignKey(nameof(TestId))]
        //[InverseProperty("Users")]
        //public Test Test { get; set; }

        //public int GroupId { get; set; }
        //[ForeignKey(nameof(GroupId))]
        //[InverseProperty("Users")]
        //public TestsGroup TestsGroup { get; set; }

        [InverseProperty(nameof(Test.User))]
        public virtual ICollection<Test> Tests { get; set; }

        [InverseProperty(nameof(TestsGroup.User))]
        public virtual ICollection<TestsGroup> TestsGroups { get; set; }

    }
}