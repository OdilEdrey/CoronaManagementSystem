using System.ComponentModel.DataAnnotations;

namespace CoronaManagement.Models
{
    public class  CoronaDetails
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<VaccinationDates> VaccinationDates { get; set; }
        public virtual ICollection<VaccinationInfo> VaccinationInfo { get; set; }
        public DateTime? DateOfPositiveTest { get; set;}
        public DateTime? RecoveryDate { get; set;}
    }
}
