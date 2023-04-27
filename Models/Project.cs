
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        [InverseProperty(nameof(TestsGroup.Project))]
        public virtual List<TestsGroup> TestsGroups { get; set; }
    }
}
