using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ILENA.Model;
using ILENA.Data;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        public Guid Id { get; set; }

        public Main()
        {
            InitializeComponent();
            Id = Guid.NewGuid();
            SetMainComboxes();

            //btnRecRightAngledRachis.IsEnabled = true;
            //btnRecThoracolumbarExtensionRaquis.IsEnabled = true;
            //btnRecRightLateralInclinationRaquis.IsEnabled = true;
            //btnRecRightRotationRaquis.IsEnabled = true;
            //btnRecRightScapulohumeralAbduction.IsEnabled = true;
            //btnRecRightScapulohumeralAdduction.IsEnabled = true;

            //btnRecLeftAngledRachis.IsEnabled = true;
            //btnRecLeftLateralInclinationRaquis.IsEnabled = true;
            //btnRecLeftRotationRaquis.IsEnabled = true;
            //btnRecLeftScapulohumeralAbduction.IsEnabled = true;
            //btnRecLeftScapulohumeralAdduction.IsEnabled = true;
        }


        private void SetMainComboxes()
        {
            cbxGender.Items.Add("Masculino");
            cbxGender.Items.Add("Femenino");
            cbxGender.SelectedValue = "Masculino";
            dpkBirthDate.SelectedDate = Convert.ToDateTime("1990/01/01");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidatePatient())
                return;

            var patient = new ILENA.Model.Patient();
            Patient.Genders gender;
            Enum.TryParse(cbxGender.SelectedItem.ToString(), out gender);

            patient.Birthdate = (DateTime)dpkBirthDate.SelectedDate;
            patient.Gender = gender;
            patient.Height = Convert.ToDouble(txtHeight.Text);
            patient.Id = Id;
            patient.LastName = txtLastName.Text;
            patient.Name = txtName.Text;
            patient.Weight = Convert.ToDouble(txtWeight.Text);

            patient.ActiveBreaksAmount = Convert.ToInt16(sldActiveBreaksTime.Value);
            patient.Backache = (bool)rbtBackacheYes.IsChecked;
            patient.Email = txtEmail.Text;
            patient.Handsache = (bool)rbtHandacheYes.IsChecked;
            patient.Neckache = (bool)rbtNeckacheYes.IsChecked;
            patient.SeatedHours = Convert.ToInt16(sldSeatedTime.Value);
            patient.Shoulderache = (bool)rbtShoulderacheYes.IsChecked;
            patient.SleepHours = Convert.ToInt16(sldSleepTime.Value);
            patient.Sporter = (bool)rbtSporterYes.IsChecked;
            patient.WhichSport = txtWhich.Text;
            patient.CreateDateTime = DateTime.Now;

            SavePatient(patient);


            btnRecRightAngledRachis.IsEnabled = true;
            btnRecLeftAngledRachis.IsEnabled = true;
            btnRecThoracolumbarExtensionRaquis.IsEnabled = true;
            btnRecRightLateralInclinationRaquis.IsEnabled = true;
            btnRecLeftLateralInclinationRaquis.IsEnabled = true;
            btnRecRightRotationRaquis.IsEnabled = true;
            btnRecLeftRotationRaquis.IsEnabled = true;
            btnRecRightScapulohumeralAbduction.IsEnabled = true;
            btnRecLeftScapulohumeralAbduction.IsEnabled = true;
            btnRecRightScapulohumeralAdduction.IsEnabled = true;
            btnRecLeftScapulohumeralAdduction.IsEnabled = true;

        }

        private void SavePatient(Patient patient)
        {

            Officer.SavePatient(patient);
            string sMessageBoxText = "La informacion basica del paciente ha sido guardada";
            string sCaption = "Creacion de paciente";
            MessageBoxButton btnMessageBox = MessageBoxButton.OK;
            MessageBoxImage icnMessageBox = MessageBoxImage.Information;
            MessageBoxResult rsltMessageBox = MessageBox.Show(
                sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
        }

        private bool ValidatePatient()
        {
            bool isValid = true;
            DateTime birthDate;
            double weight, height,seatedHours, activeBreaksHours, sleepHours;

            if (string.IsNullOrWhiteSpace(txtHeight.Text)
                || string.IsNullOrWhiteSpace(txtLastName.Text)
                || string.IsNullOrWhiteSpace(txtName.Text)
                || !DateTime.TryParse(dpkBirthDate.SelectedDate.ToString(), out birthDate)
                || ((!(bool)rbtSporterYes.IsChecked) && !(bool)rbtSporterNo.IsChecked)
                )
            {
                isValid = false;
                labelError.Content = "Todos los campos son obligatorios";
            }
            else if (!double.TryParse(txtWeight.Text, out weight) || !double.TryParse(txtHeight.Text, out height)
                || !double.TryParse(sldSeatedTime.Value.ToString(), out seatedHours)
                || !double.TryParse(sldActiveBreaksTime.Value.ToString(), out activeBreaksHours)
                || !double.TryParse(sldSleepTime.Value.ToString(), out sleepHours)
                || !double.TryParse(sldWeight.Value.ToString(), out weight)
                || !double.TryParse(sldHeight.Value.ToString(), out weight)
                )
            {
                isValid = false;
                labelError.Content = "El peso, la estatura, cantidad de pausas y la cantidad de horas sentado deben ser numericos";
            }
            else if (((bool)rbtSporterYes.IsChecked) && string.IsNullOrWhiteSpace(txtWhich.Text))
            {
                isValid = false;
                labelError.Content = "¿Que deporte practica?";
            }

            if (!isValid)
                labelError.Visibility = Visibility.Visible;
            else
                labelError.Visibility = Visibility.Hidden;

            return isValid;
        }


        private void btnRecRightAngledRachis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.RightAngledRachis);
        }

        private void btnRecLeftAngledRachis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.LeftAngledRachis);
        }

        private void btnRecRightLateralInclinationRaquis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.RightLateralInclinationRaquis);
        }

        private void btnRecLeftLateralInclinationRaquis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.LeftLateralInclinationRaquis);
        }

        private void btnRecRightRotationRaquis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.RightRotationRaquis);
        }

        private void btnRecLeftRotationRaquis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.LeftRotationRaquis);
        }
        private void btnRecThoracolumbarExtensionRaquis_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.ThoracolumbarExtensionRaquis);
        }

        private void btnRecRightScapulohumeralAbduction_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.RightScapulohumeralAbduction);
        }

        private void btnRecLeftScapulohumeralAbduction_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.LeftScapulohumeralAbduction);
        }

        private void btnRecRightScapulohumeralAdduction_Click(object sender, RoutedEventArgs e)
        {
            OpenRoutineWindow(Evaluation.Category.RightScapulohumeralAdduction);
        }

        private void btnRecLeftScapulohumeralAdduction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenRoutineWindow(Evaluation.Category category)
        {
            
            MainWindow mainWindow = new MainWindow(category, Id);

            mainWindow.ShowDialog();
            if (mainWindow.RoutineSaved)
            {
                SaveEvaluation(Id, category, mainWindow.Routine.Id, mainWindow.Angle, mainWindow.Pain);
                CheckRoutine(category);
            }
        }

        private void SaveEvaluation(Guid id, Evaluation.Category category, Guid routineId, double angle, bool pain)
        {
            Evaluation evaluation = new Evaluation();
            evaluation.Angle = angle;
            evaluation.CategoryName = category.ToString();
            evaluation.PatientId = Id;
            evaluation.RoutineId = routineId;
            evaluation.Pain = pain;
            Officer.SaveEvaluation(evaluation);
        }

        private void CheckRoutine(Evaluation.Category category)
        {
            switch (category)
            {
                case Evaluation.Category.RightAngledRachis:
                    ckbRecRightAngledRachis.IsChecked = true;
                    btnRecRightAngledRachis.IsEnabled = false;
                    break;
                case Evaluation.Category.LeftAngledRachis:
                    ckbRecLeftAngledRachis.IsChecked = true;
                    btnRecLeftAngledRachis.IsEnabled = false;
                    break;
                case Evaluation.Category.ThoracolumbarExtensionRaquis:
                    ckbRecThoracolumbarExtensionRaquis.IsChecked = true;
                    btnRecThoracolumbarExtensionRaquis.IsEnabled = false;
                    break;
                case Evaluation.Category.RightLateralInclinationRaquis:
                    ckbRecRightLateralInclinationRaquis.IsChecked = true;
                    btnRecRightLateralInclinationRaquis.IsEnabled = false;
                    break;
                case Evaluation.Category.LeftLateralInclinationRaquis:
                    ckbRecLeftLateralInclinationRaquis.IsChecked = true;
                    btnRecLeftLateralInclinationRaquis.IsEnabled = false;
                    break;
                case Evaluation.Category.RightRotationRaquis:
                    ckbRecRightRotationRaquis.IsChecked = true;
                    btnRecRightRotationRaquis.IsEnabled = false;
                    break;
                case Evaluation.Category.LeftRotationRaquis:
                    ckbRecLeftRotationRaquis.IsChecked = true;
                    btnRecLeftRotationRaquis.IsEnabled = false;
                    break;
                case Evaluation.Category.RightScapulohumeralAbduction:
                    ckbRecRightScapulohumeralAbduction.IsChecked = true;
                    btnRecRightScapulohumeralAbduction.IsEnabled = false;
                    break;
                case Evaluation.Category.LeftScapulohumeralAbduction:
                    ckbRecLeftScapulohumeralAbduction.IsChecked = true;
                    btnRecLeftScapulohumeralAbduction.IsEnabled = false;
                    break;
                case Evaluation.Category.RightScapulohumeralAdduction:
                    ckbRecRightScapulohumeralAdduction.IsChecked = true;
                    btnRecRightScapulohumeralAdduction.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetControls();
        }

        private void ResetControls()
        {
            
            txtEmail.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtName.Text = string.Empty;
            txtWhich.Text = string.Empty;

            txtActiveBreakTime.Text = sldActiveBreaksTime.Minimum.ToString();
            sldActiveBreaksTime.Value = sldActiveBreaksTime.Minimum;

            txtHeight.Text = sldHeight.Minimum.ToString();
            sldHeight.Value = sldHeight.Minimum;

            txtSeatedTime.Text = sldSeatedTime.Minimum.ToString();
            sldSeatedTime.Value = sldSeatedTime.Minimum;

            txtSleepTime.Text = sldSleepTime.Minimum.ToString();
            sldSleepTime.Value = sldSleepTime.Minimum;

            txtWeight.Text = sldWeight.Minimum.ToString();
            sldWeight.Value = sldWeight.Minimum;

            rbtBackacheNo.IsChecked = true;
            rbtHandacheNo.IsChecked = true;
            rbtNeckacheNo.IsChecked = true;
            rbtShoulderacheNo.IsChecked = true;
            rbtSporterNo.IsChecked = true;

            ckbRecLeftAngledRachis.IsChecked = false;
            btnRecLeftAngledRachis.IsEnabled = false;

            ckbRecLeftLateralInclinationRaquis.IsChecked = false;
            btnRecLeftLateralInclinationRaquis.IsEnabled = false;

            ckbRecLeftRotationRaquis.IsChecked = false;
            btnRecLeftRotationRaquis.IsEnabled = false;

            ckbRecLeftScapulohumeralAbduction.IsChecked = false;
            btnRecLeftScapulohumeralAbduction.IsEnabled = false;

            ckbRecLeftScapulohumeralAdduction.IsChecked = false;
            btnRecLeftScapulohumeralAdduction.IsEnabled = false;

            ckbRecRightAngledRachis.IsChecked = false;
            btnRecRightAngledRachis.IsEnabled = false;

            ckbRecRightLateralInclinationRaquis.IsChecked = false;
            btnRecRightLateralInclinationRaquis.IsEnabled = false;

            ckbRecRightRotationRaquis.IsChecked = false;
            btnRecRightRotationRaquis.IsEnabled = false;

            ckbRecRightScapulohumeralAbduction.IsChecked = false;
            btnRecRightScapulohumeralAbduction.IsEnabled = false;

            ckbRecRightScapulohumeralAdduction.IsChecked = false;
            btnRecRightScapulohumeralAdduction.IsEnabled = false;

            ckbRecThoracolumbarExtensionRaquis.IsChecked = false;
            btnRecThoracolumbarExtensionRaquis.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Id = Guid.NewGuid();
            ResetControls();
        }
    }
}
