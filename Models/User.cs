namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int GroupId { get; set; }
        public int TeamLeaderId { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public virtual ICollection<Comment> Comments { get; set;}
    }
}