using System.ComponentModel.DataAnnotations;

namespace CoronaManagement.Models
{
    public class VaccinationInfo
    {
        [Key]
        public int Id { get; set; }
        public string ManufacturerOfFirstVaccination { get; set; }
        public string ManufacturerOfSecondtVaccination { get; set; }
        public string ManufacturerOfThirdVaccination { get; set; }
        public string ManufacturerOfFourthVaccination { get; set; }
    }
}
