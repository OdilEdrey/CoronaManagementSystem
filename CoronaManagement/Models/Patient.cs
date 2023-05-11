using System.ComponentModel.DataAnnotations;

namespace CoronaManagement.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LestName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CellphoneNumber { get; set; }
        public string PhoneNumber{ get; set; }
        public bool IsVaccinated { get; set; } = false;
        public virtual ICollection<CoronaDetails> CoronaDetails { get; set; }
    }
}
