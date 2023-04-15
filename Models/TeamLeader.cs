

namespace Models
{
    public class TeamLeader
    {
        public int Id { get; set; }
        public int TesterId { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
