using CoronaManagement.Models;
using CoronaManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoronaManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PatientController : ControllerBase
    {
        private readonly IPatientServise _patientService;
        public PatientController(IPatientServise service)
        {
            _patientService = service;
        }
    
       // [HttpGet(Name = "GetAllPatient")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllPatients()
        {
            try
            {
                List<Patient> patients = _patientService.GetPatientsList();
                if (patients == null) { return NotFound(); };
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // [HttpGet(Name = "GetPatientDetailsById")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPatientDetailsById(string patientId)
        {
            try
            {
                Patient patients = _patientService.GetPatientDetailsById(patientId);
                if (patients == null) { return NotFound(); };
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // [HttpGet(Name = "AddPatients")]

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddPatients(Patient patientModel)
        {
            try
            {
                ResponseModel model = _patientService.AddPaient(patientModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // [HttpGet(Name = "GetNotVaccinated")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetNotVaccinated(Patient patientModel)
        {
            try
            {
                int NumOfUnVaccinated = _patientService.GetNotVaccinated();
                return Ok(NumOfUnVaccinated);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // [HttpGet(Name = "GetActivePatient")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetActivePatient(DateTime date)
        {
            DateTime currentdate = DateTime.Now.Date;
            TimeSpan diff = currentdate - date;

            if (diff.TotalDays < 30)
            {
                try
                {
                    int NumOfUnVaccinated = _patientService.GetActivePatient(date);
                    return Ok(NumOfUnVaccinated);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest();

        }
    }
}
