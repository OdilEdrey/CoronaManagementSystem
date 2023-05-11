using System.ComponentModel.DataAnnotations;

namespace CoronaManagement.Models
{
    public class VaccinationDates
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateOfFirstVaccination { get; set; }
        public DateTime? DateOfSecondtVaccination { get; set; }
        public DateTime? DateOfThirdVaccination { get; set; }
        public DateTime? DateOfFourthVaccination { get; set; }
    }
}
