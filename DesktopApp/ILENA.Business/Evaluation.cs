using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILENA.Model;

namespace ILENA.Business
{
    public static class Evaluation
    {
        public static Model.EvaluationResult GetEvaluationsByPatientGuid(Guid patientGuid)
        {
            var evaluationResult = new Model.EvaluationResult();
            Model.Patient patient = Data.Officer.GetPatientByGuid(patientGuid);

            if (patient != null)
            {
                evaluationResult.Patient = MapPatientToPatientResult(patient);
                var evaluations = Data.Officer.GetEvaluationsByPatientGuid(patientGuid);
                evaluationResult.Routines = MapRoutinesToRoutinesResult(evaluations);
            }

            return evaluationResult;

        }

        private static List<RoutineResult> MapRoutinesToRoutinesResult(List<Model.Evaluation> evaluations)
        {
            List<RoutineResult> routinesResult = new List<RoutineResult>();
            foreach (var evaluation in evaluations)
            {
                var routineResult = new RoutineResult()
                {
                    Name = evaluation.GetName(),
                    Pain = evaluation.Pain ? "Yes" : "No",
                    Angle = evaluation.Angle,
                    Result = evaluation.Result,
                };

                var anglesAndLabels = GetRoutinesResults(evaluation);
                routineResult.Angles = anglesAndLabels.Values.ToList();
                routineResult.Labels = anglesAndLabels.Keys.ToList();
                routineResult.Mean = evaluation.Mean;
                routineResult.Median = evaluation.Median;
                routineResult.Mode = evaluation.Mode;


                routinesResult.Add(routineResult);
            }

            return routinesResult;
        }

        private static Dictionary<short, short> GetRoutinesResults(Model.Evaluation evaluation)
        {
            List<double> angles = new List<double>();
            Dictionary<short, short> angleCounter = new Dictionary<short, short>();
            short key = 0;

            var evaluations = Data.Officer.GetEvaluationResultsByCategory(evaluation.CategoryName);
            if (evaluations != null && evaluations.Count > 0)
            {
                foreach (var item in evaluations)
                {
                    key = Convert.ToInt16(item.Angle);

                    if (angleCounter.ContainsKey(key))
                        angleCounter[key] = Convert.ToInt16(angleCounter[key] + 1);
                    else
                        angleCounter.Add(key, 1);
                       
                }

                evaluation.Mean = GetEvaluationsMean(evaluations);
                evaluation.Median = GetEvaluationsMedian(evaluations);
                evaluation.Mode = GetEvaluationsMode(evaluations);

                angleCounter.Add(Convert.ToInt16(angleCounter.Keys.Min() - 10), 0);
                angleCounter.Add(Convert.ToInt16(angleCounter.Keys.Max() + 10), 0);


                angleCounter = angleCounter.OrderBy(k => k.Key).ToDictionary(t => t.Key, t => t.Value);

            }

            return angleCounter;
        }

        private static double GetEvaluationsMode(List<Model.Evaluation> evaluations)
        {
            var mode = evaluations
                                    .GroupBy(e => e.Angle)
                                    .OrderByDescending(gp => gp.Count())
                                    .Select(g => g.Key).FirstOrDefault();

            if (mode != null && mode > 0)
                mode = Math.Round(mode, 2);

            return mode;
        }

        private static double GetEvaluationsMedian(List<Model.Evaluation> evaluations)
        {
            var digitsAmount = evaluations.Count;
            double median = 0;
            if (digitsAmount % 2 > 0)
            {
                median = evaluations[Convert.ToInt16(Math.Truncate(Convert.ToDouble(digitsAmount / 2)))].Angle;
            }
            else {
                var rigthDigit = evaluations[Convert.ToInt16(Convert.ToDouble(digitsAmount / 2))].Angle;
                var leftDigit = evaluations[Convert.ToInt16((digitsAmount / 2)-1)].Angle;
                median = (rigthDigit + leftDigit) / 2;
            }

            if(median != null && median > 0)
                median = Math.Round(median, 2);

            return median;
        }

        private static double GetEvaluationsMean(List<Model.Evaluation> evaluations)
        {
            double amount = 0;
            foreach (var item in evaluations)
            {
                amount += item.Angle;
            }

            amount = amount / evaluations.Count;

            if (amount != null && amount > 0)
                amount = Math.Round(amount, 2);

            return amount;
        }

        public static bool ValidateCategory(string evaluationCategory)
        {
            Model.Evaluation.Category category;
            return Enum.TryParse(evaluationCategory, out category);
        }

        public static PatientResult MapPatientToPatientResult(Patient patient)
        {
            PatientResult patientResult = new PatientResult() {
                Age = patient.GetAge(),
                Gender = patient.Gender.ToString().ToLower(),
                LastName = patient.LastName,
                Name = patient.Name,
                Habits = new HabitsResult() {
                    ActiveBreaks = patient.ActiveBreaksAmount > 0,
                    Seated = patient.SeatedHours,
                    Sleep = patient.SleepHours,
                    Sport = patient.Sporter
                },
                PhysicalExam = new PhysicalExamResult() {
                    Bmi = patient.GetBmi(),
                    Height = Convert.ToInt16(patient.Height),
                    Weight = patient.Weight
                },
                Id = patient.Id.ToString()
               
            };

            patientResult.PhysicalExam.BmiDiagnostic = patient.GetBmiDiagnostic(patientResult.PhysicalExam.Bmi);

            return patientResult;
        }
    }
}
