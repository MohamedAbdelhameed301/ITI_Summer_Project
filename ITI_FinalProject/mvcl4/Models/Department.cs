using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvcl4.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [DisplayName("Department Name")] //name for ui

        public string DeptName { get; set; }

        public virtual List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return DeptName;
        }

    }
}
