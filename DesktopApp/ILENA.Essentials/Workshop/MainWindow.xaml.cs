using Microsoft.Kinect;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes

        private KinectSensor _kinectSensor;

        #endregion

        #region Methods

        private bool StartKinectSensor(KinectSensor kinectSensor)
        {
            if (kinectSensor == null || kinectSensor.Status != KinectStatus.Connected)
                return false;

            kinectSensor.ColorStream.Enable();
            kinectSensor.DepthStream.Enable();
            kinectSensor.SkeletonStream.Enable();
            kinectSensor.SkeletonFrameReady += KinectSensor_SkeletonFrameReady;
            kinectSensor.AllFramesReady += KinectSensor_AllFramesReady;


            //kinectSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated

            //kinectSensor.SkeletonStream..
            try
            {
                kinectSensor.Start();
            }
            catch (System.IO.IOException)
            {
                kinectSensorChooser.AppConflictOccurred();
            }


            return true;
        }

        private void KinectSensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons;

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }
        }

        private void StopKinectSensor(KinectSensor kinectSensor)
        {
            if (kinectSensor == null || !kinectSensor.IsRunning)
                return;
            kinectSensor.Stop();
            if (kinectSensor.AudioSource != null)
                kinectSensor.AudioSource.Stop();
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser.KinectSensorChanged += KinectSensorChooser_KinectSensorChanged;
        }

        private void KinectSensorChooser_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            KinectSensor oldKinectSensor = (KinectSensor)e.OldValue;
            KinectSensor newKinectSensor = (KinectSensor)e.NewValue;

            StopKinectSensor(oldKinectSensor);
            StartKinectSensor(newKinectSensor);
        }

        private void KinectSensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            //using (ColorImageFrame colorImageFrame = e.OpenColorImageFrame())
            //{
            //    if (colorImageFrame == null)
            //        return;

            //    byte[] pixels = new byte[colorImageFrame.PixelDataLength];
            //    colorImageFrame.CopyPixelDataTo(pixels);

            //    int stride = colorImageFrame.Width * 4;
            //    image.Source = BitmapSource.Create(colorImageFrame.Width, colorImageFrame.Height, 96, 96, PixelFormats.Bgr32, null, pixels, stride);
            //}
        }

        private void ButtonSetAngle_Click(object sender, RoutedEventArgs e)
        {
            buttonSetAngle.IsEnabled = false;

            //Set angle to slider1 value
            if (kinectSensorChooser.Kinect != null && kinectSensorChooser.Kinect.IsRunning)
            {
                kinectSensorChooser.Kinect.ElevationAngle = (int)slider1.Value;
                lblCurrentAngle.Content = kinectSensorChooser.Kinect.ElevationAngle;
            }

            //Do not change Elevation Angle often, please see documentation on this and Kinect Explorer for a robust example
            System.Threading.Thread.Sleep(new TimeSpan(hours: 0, minutes: 0, seconds: 1));
            buttonSetAngle.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopKinectSensor(kinectSensorChooser.Kinect);
        }
    }
}
