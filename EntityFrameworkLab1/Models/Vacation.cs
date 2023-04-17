using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkLab1.Models
{
    public class Vacation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationId { get; set; }
        [StringLength(25)]
        [DisplayName("Vacation")]
        public string VacationType { get; set; }
        [DisplayName("Start of vacation")]
        public DateTime VacationStart { get; set; }
        [DisplayName("End of vacation")]
        public DateTime VacationEnd { get; set; }
        [DisplayName("Apply date")]
        public DateTime ApplyDate { get; set; }
        [ForeignKey("Employees")]
        [DisplayName("Employee")]
        public int FK_EmpId { get; set; }
        public virtual Employee? Employees { get; set; }
    }
}
