using CoronaManagement.Models;

namespace CoronaManagement.Services
{
    public interface IPatientServise
    {
        /// <summary>
        /// get list of all patients
        /// </summary>
        /// <returns></returns>
        List<Patient> GetPatientsList();

        /// <summary>
        /// get patient details by patient id
        /// </summary>
        /// <param name="patId"></param>
        /// <returns></returns>
        Patient GetPatientDetailsById(string patientId);

        /// <summary>
        ///  add edit patient
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        ResponseModel AddPaient(Patient patient);

        /// <summary>
        ///  get num of not vaccinated patients 
        /// </summary>
        /// <returns></returns>
        int GetNotVaccinated();

        /// <summary>
        ///  get num of active patients 
        /// </summary>
        /// <returns></returns>
        int GetActivePatient(DateTime dateTime);
    }
}
