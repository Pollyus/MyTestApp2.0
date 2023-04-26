
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }


        public virtual List<TestsGroup> TestsGroups { get; set; }
    }
}
