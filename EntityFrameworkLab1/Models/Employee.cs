using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLab1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [StringLength(30)]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [StringLength(30)]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public ICollection<Vacation>? Vacations { get; set; }
    }
}
