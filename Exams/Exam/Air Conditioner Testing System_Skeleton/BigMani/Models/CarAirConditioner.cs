namespace AirConditioningTestingSystem.Models
{
    using System;
    using Data;

    public class CarAirConditioner : AirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCovered)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositiveMessage, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (sqrtVolume < Constants.CarAirTestBorderNumber)
            {
                return 0;
            }

            return 1;
        }

        public override string ToString()
        {
            string result = base.ToString() + "Volume Covered: " + this.VolumeCovered + "\r\n";
            result += "====================";
            return result;
        }
    }  
}
