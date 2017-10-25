using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILENA.Model;

namespace ILENA.Data
{
    public static class Officer
    {
        public static void SaveMovements(List<Movement> movements )
        {
            using (var context = new ILENAContext())
            {
                context.Movements.AddRange(movements);
                context.SaveChanges();
            }
        }

        public static Patient GetPatientByGuid(Guid patientGuid)
        {
            Patient patient;
            using (var context = new ILENAContext())
            {
                patient = context.Patients.Where(e => e.Id == patientGuid).FirstOrDefault();
            }
            return patient;
        }

        public static List<Evaluation> GetEvaluationsByPatientGuid(Guid patientGuid)
        {
            List<Model.Evaluation> evaluations;
            using (var context = new ILENAContext())
            {
                evaluations = context.Evaluations.Where(e => e.PatientId == patientGuid).ToList();
            }
            return evaluations;
        }

        public static Evaluation GetEvaluationByPatientGuid(Guid patientGuid, string categoryName)
        {
            Evaluation evaluation;
            using (var context = new ILENAContext())
            {
                evaluation = context.Evaluations.Where(
                    e => e.PatientId == patientGuid
                    && e.CategoryName.Contains(categoryName)).FirstOrDefault();
            }
            return evaluation;
        }


        public static List<Movement> GetMovementsByRoutineGuid(Guid routineGuid)
        {
            List<Model.Movement> movements;
            using (var context = new ILENAContext())
            {
                movements = context.Movements.Where(m => m.Routine.Id == routineGuid).Include(m => m.Vectors).ToList();
            }

            return movements;
        }

        public static List<Evaluation> GetEvaluationResultsByCategory(string categoryName)
        {
            List<Evaluation> results;
            using (var context = new ILENAContext())
            {
                results = context.Evaluations.Where(m => m.CategoryName == categoryName).ToList();
            }

            return results;
        }

        public static Model.Routine GetRoutineByGuid(Guid routineGuid)
        {
            Model.Routine routine;
            using (var context = new ILENAContext())
            {
                routine = context.Routines.FirstOrDefault(r => r.Id == routineGuid);
            }

            return routine;
        }

        public static void SaveRoutine(Model.Routine routine)
        {
            using (var context = new ILENAContext())
            {
                context.Routines.Add(routine);
                context.SaveChanges();
            }
        }

        public static void SavePatient(Model.Patient patient)
        {
            using (var context = new ILENAContext())
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }
        }

        public static void SaveEvaluation(Evaluation evaluation)
        {
            using (var context = new ILENAContext())
            {
                context.Evaluations.Add(evaluation);
                context.SaveChanges();
            }
        }

        public static List<Patient> GetPatients()
        {
            using (var context = new ILENAContext())
            {
                return context.Patients.ToList();
            }
        }
    }
}
