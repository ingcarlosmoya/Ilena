using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace ILENA.Model
{
    public class Movement
    {
        public Guid Id { get; set; }

        public Guid RoutineId { get; set; }

        public DateTime CreateDateTime { get; set; }

        [ForeignKey("RoutineId")]
        public virtual Routine Routine { get; set; }

        public List<Vector> Vectors { get; set; }

        public void CreateVector(Vector3D vector3D)
        {
            if (Vectors == null)
                Vectors = new List<Vector>();

            Vectors.Add(new Vector()
            {
                X = vector3D.X,
                Y = vector3D.Y,
                Z = vector3D.Z
            });

        }

        public Movement()
        {
            Id = Guid.NewGuid();
            CreateDateTime = DateTime.Now;
        }

        public double GetCurrentAngleByEvaluation(Evaluation.Category category)
        {
            double angle = 0;

            switch (category)
            {
                case Evaluation.Category.RightAngledRachis:
                    angle = RightAngledRachis();
                    break;
                case Evaluation.Category.LeftAngledRachis:
                    angle = LeftAngledRachis();
                    break;
                case Evaluation.Category.RightLateralInclinationRaquis:
                    angle = RightLateralInclinationRaquis();
                    break;
                case Evaluation.Category.LeftLateralInclinationRaquis:
                    angle = LeftLateralInclinationRaquis();
                    break;
                case Evaluation.Category.RightRotationRaquis:
                    angle = RightRotationRaquis();
                    break;
                case Evaluation.Category.LeftRotationRaquis:
                    angle = LeftRotationRaquis();
                    break;

                case Evaluation.Category.ThoracolumbarExtensionRaquis:
                    angle = ThoracolumbarExtensionRaquis();
                    break;
                case Evaluation.Category.RightScapulohumeralAbduction:
                    angle = RightScapulohumeralAbduction();
                    break;
                case Evaluation.Category.LeftScapulohumeralAbduction:
                    angle = LeftScapulohumeralAbduction();
                    break;
                default:
                    break;
            }

            return Math.Round(angle,2);
        }

        private double AngledRachis()
        {
            double hyp, a, b, alpha;
            var head = Vectors.Where(v => v.Joint == "Head").FirstOrDefault();
            var shoulderCenter = Vectors.Where(v => v.Joint == "ShoulderCenter").FirstOrDefault();
            a = head.Y - shoulderCenter.Y;
            b = head.X - shoulderCenter.X;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = ((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }

        private double LeftAngledRachis()
        {
            return AngledRachis();
        }

        private double RightAngledRachis()
        {
            return AngledRachis();
        }

        private double LateralInclinationRaquis()
        {
            double hyp, a, b, alpha;
            var shoulderCenter = Vectors.Where(v => v.Joint == "ShoulderCenter").FirstOrDefault();
            var spine = Vectors.Where(v => v.Joint == "Spine").FirstOrDefault();
            a = shoulderCenter.Y - spine.Y;
            b = shoulderCenter.X - spine.X;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = ((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }

        private double LeftLateralInclinationRaquis()
        {
            return LateralInclinationRaquis();
        }

        private double RightLateralInclinationRaquis()
        {
            return LateralInclinationRaquis();
        }

        private double LeftRotationRaquis()
        {
            double hyp, a, b, alpha;
            var shoulderRight = Vectors.Where(v => v.Joint == "ShoulderLeft").FirstOrDefault();
            var shoulderCenter = Vectors.Where(v => v.Joint == "ShoulderCenter").FirstOrDefault();
            a = shoulderRight.X - shoulderCenter.X;
            b = shoulderRight.Z - shoulderCenter.Z;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = ((Math.Acos(a / hyp) * 180) / Math.PI)-90;
            return alpha;
        }

        private double RightRotationRaquis()
        {
            double hyp, a, b, alpha;
            var shoulderRight = Vectors.Where(v => v.Joint == "ShoulderRight").FirstOrDefault();
            var shoulderCenter = Vectors.Where(v => v.Joint == "ShoulderCenter").FirstOrDefault();
            a = shoulderRight.X - shoulderCenter.X;
            b = shoulderRight.Z - shoulderCenter.Z;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = 90-((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }





        private double ThoracolumbarExtensionRaquis()
        {
            double hyp, a, b, alpha;
            var shoulderCenter = Vectors.Where(v => v.Joint == "ShoulderCenter").FirstOrDefault();
            var spine = Vectors.Where(v => v.Joint == "Spine").FirstOrDefault();
            a = shoulderCenter.Y - spine.Y;
            b = shoulderCenter.Z - spine.Z;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = ((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }

        private double RightScapulohumeralAbduction()
        {
            double hyp, a, b, alpha;
            var elbowRight = Vectors.Where(v => v.Joint == "ElbowRight").FirstOrDefault();
            var shoulderRight = Vectors.Where(v => v.Joint == "ShoulderRight").FirstOrDefault();
            a = elbowRight.Y - shoulderRight.Y;
            b = elbowRight.X - shoulderRight.X;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = 180 - ((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }

        private double LeftScapulohumeralAbduction()
        {
            double hyp, a, b, alpha;
            var elbowRight = Vectors.Where(v => v.Joint == "ElbowLeft").FirstOrDefault();
            var shoulderRight = Vectors.Where(v => v.Joint == "ShoulderLeft").FirstOrDefault();
            a = elbowRight.Y - shoulderRight.Y;
            b = elbowRight.X - shoulderRight.X;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = 180 - ((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }

        private double RightScapulohumeralAdduction()
        {
            double hyp, a, b, alpha;
            var elbowRight = Vectors.Where(v => v.Joint == "ElbowRight").FirstOrDefault();
            var shoulderRight = Vectors.Where(v => v.Joint == "ShoulderRight").FirstOrDefault();
            a = elbowRight.Y - shoulderRight.Y;
            b = elbowRight.X - shoulderRight.X;
            hyp = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            alpha = 180 + ((Math.Acos(a / hyp) * 180) / Math.PI);
            return alpha;
        }

    }


}
