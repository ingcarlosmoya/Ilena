using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Model
{
    public class Patient
    {
        public enum Genders
        {
            Female = 0,
            Male = 1
        }

        public DateTime Birthdate { get; set; }
        public Genders Gender { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDateTime { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public bool Sporter { get; set; }
        public string WhichSport { get; set; }
        public int SeatedHours { get; set; }
        public int ActiveBreaksAmount { get; set; }
        public int SleepHours { get; set; }
        public bool Backache { get; set; }
        public bool Neckache { get; set; }

        public int GetAge()
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - this.Birthdate.Year;
            // Go back to the year the person was born in case of a leap year
            if (this.Birthdate > today.AddYears(-age)) age--;

            return age;
        }

        public bool Shoulderache { get; set; }
        public bool Handsache { get; set; }

        public double GetBmi()
        {
            double result = Math.Round((this.Weight / (Math.Pow((this.Height / 100), 2))), 2);
            return result;
        }

        public string GetBmiDiagnostic(double bmi)
        {
            string bmiDiagnostic = string.Empty;
            if (bmi <= 15)
                bmiDiagnostic = "Very severely underweight";
            else if (bmi > 15 && bmi <= 16)
                bmiDiagnostic = "Severely underweight";
            else if (bmi > 16 && bmi <= 18.5)
                bmiDiagnostic = "Underweight";
            else if (bmi > 18.5 && bmi <= 25)
                bmiDiagnostic = "Normal";
            else if (bmi > 25 && bmi <= 30)
                bmiDiagnostic = "Overweight";
            else if (bmi > 30 && bmi <= 35)
                bmiDiagnostic = "Obese Class I (Moderately obese)";
            else if (bmi > 35 && bmi <= 40)
                bmiDiagnostic = "Obese Class II (Severely obese)";
            else if (bmi > 40)
                bmiDiagnostic = "Obese Class III (Very severely obese)";

            return bmiDiagnostic;
        }
    }


}
