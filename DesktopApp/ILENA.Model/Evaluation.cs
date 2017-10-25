using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILENA.Model
{
    

    public class Evaluation
    {
        public enum Category
        {
            RightAngledRachis,
            LeftAngledRachis,
            RightLateralInclinationRaquis,
            LeftLateralInclinationRaquis,
            RightRotationRaquis,
            LeftRotationRaquis,
            ThoracolumbarExtensionRaquis,


            RightScapulohumeralAbduction,
            LeftScapulohumeralAbduction,

            RightScapulohumeralAdduction,

        }

        public Guid Id { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
        public string CategoryName { get; set; }
        public Guid RoutineId { get; set; }
        public double Angle { get; set; }
        public bool Pain { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Result { get; set; }
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Mode { get; set; }

        public Evaluation()
        {
            Id = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }

        public string GetName()
        {
            string categoryName = string.Empty;
            Category category;
            if (Enum.TryParse(CategoryName, out category))
            {
                switch (category)
                {
                    case Category.RightAngledRachis:
                        categoryName = "Right raquis angled";
                        break;
                    case Category.LeftAngledRachis:
                        categoryName = "Left raquis angled";
                        break;
                    case Category.RightLateralInclinationRaquis:
                        categoryName = "Right lateral raquis inclination";
                        break;
                    case Category.LeftLateralInclinationRaquis:
                        categoryName = "Left lateral raquis inclination";
                        break;
                    case Category.RightRotationRaquis:
                        categoryName = "Right raquis rotation";
                        break;
                    case Category.LeftRotationRaquis:
                        categoryName = "Left raquis rotation";
                        break;
                    case Category.ThoracolumbarExtensionRaquis:
                        categoryName = "Thoracolumbar raquis extension";
                        break;
                    case Category.RightScapulohumeralAbduction:
                        categoryName = "Right scapulohumeral abduction";
                        break;
                    case Category.LeftScapulohumeralAbduction:
                        categoryName = "Left scapulohumeral abduction";
                        break;
                    case Category.RightScapulohumeralAdduction:
                        categoryName = "Right scapulohumeral abduction";
                        break;
                    default:
                        break;
                }

                SetResult(category);
            }

            return categoryName;
        }

        private void SetResult(Category category)
        {
            if (category == Category.RightLateralInclinationRaquis || category == Category.LeftLateralInclinationRaquis)
            {
                Result = Angle <= 45 ? "success" : "warning";

            }

            else if (category == Category.RightRotationRaquis || category == Category.LeftRotationRaquis)
            {
                Result = Angle <= 80 ? "success" : "warning";
            }

            else if (category == Category.RightAngledRachis || category == Category.LeftAngledRachis)
            {
                Result = Angle <= 35 ? "success" : "warning";
            }

            else if (category == Category.ThoracolumbarExtensionRaquis)
                {

                Result = Angle <= 30 ? "success" : "warning";
            }

            else if (category == Category.RightScapulohumeralAbduction || category == Category.LeftScapulohumeralAbduction)
            {
                Result = Angle <= 180 ? "success" : "warning";
            }

        }
    }
}
