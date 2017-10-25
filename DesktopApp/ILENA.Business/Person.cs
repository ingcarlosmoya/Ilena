using ILENA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Business
{
    public static class Person
    {
        public static List<PatientResult> GetPeople()
        {
            var patients = Data.Officer.GetPatients();

            List<PatientResult> patientsResult = new List<PatientResult>();
            foreach (var patient in patients)
            {
                patientsResult.Add(Evaluation.MapPatientToPatientResult(patient));
            }

            return patientsResult;
        }
    }
}
