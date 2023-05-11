using CoronaManagement.DAL;
using CoronaManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace CoronaManagement.Services
{
    public class PatientService : IPatientServise
    {
        private readonly CoronaDbContext _context;

        public PatientService(CoronaDbContext context)
        {
            _context = context;

        }
        public Patient GetPatientDetailsById(string patientId)
        {
            Patient patient;
            try
            {
                patient = _context.Patient.Find(patientId);
            }
            catch (Exception)
            {

                throw;
            }

            return patient;
        }

        public List<Patient> GetPatientsList()
        {
            List<Patient> patients;
            try
            {
                patients = _context.Patient.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return patients;
        }

        /// <summary>
        ///  add patient
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        public ResponseModel AddPaient(Patient patientModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Add<Patient>(patientModel);
                model.Messsage = "Patient Inserted Successfully";

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public int GetNotVaccinated() => _context.Patient.Where(p => p.IsVaccinated == false).Count();

        public int GetActivePatient(DateTime date) => _context.Patient.SelectMany(p => p.CoronaDetails).Count(cd => cd.DateOfPositiveTest == date);
        
    }
}
