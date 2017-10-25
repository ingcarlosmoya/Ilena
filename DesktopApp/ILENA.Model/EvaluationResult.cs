using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Model
{
    public class EvaluationResult
    {
        public PatientResult Patient { get; set; }
        public List<RoutineResult> Routines { get; set; }
    }

    public class PatientResult {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public PhysicalExamResult PhysicalExam { get; set; }
        public HabitsResult Habits { get; set; }
        public string Id { get; set; }
    }

    public class PhysicalExamResult
    {
        public int Height { get; set; }
        public double Weight { get; set; }
        public double Bmi { get; set; }
        public string BmiDiagnostic { get; set; }
        public string BmiClass { get; set; }
    }

    public class HabitsResult
    {
        public bool Sport { get; set; }
        public int Seated { get; set; }
        public int Sleep { get; set; }
        public bool ActiveBreaks { get; set; }
    }

    public class RoutineResult
    {
        public string Name { get; set; }
        public double Angle { get; set; }
        public string Result { get; set; }
        public string Pain { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Mode { get; set; }
        public List<short> Angles { get; set; }
        public string Label { get; set; }
        public List<short> Labels { get; set; }
    }

}
