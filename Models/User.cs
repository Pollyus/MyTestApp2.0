using System.Text.Json.Serialization;

namespace Models
{
    public class User: BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
        public int TeamLeaderId { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public virtual ICollection<Comment> Comments { get; set;}
    }
}