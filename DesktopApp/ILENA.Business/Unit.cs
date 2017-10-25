namespace ILENA.Business
{
    public class Unit
    {
        public double ConvertMetersToCentimeters(double meters)
        {
            var centimeters = meters*100;
            return centimeters;
        }
    }
}