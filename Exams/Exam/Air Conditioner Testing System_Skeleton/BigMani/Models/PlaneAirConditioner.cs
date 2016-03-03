namespace AirConditioningTestingSystem.Models
{
    using System;
    using Data;

    public class PlaneAirConditioner : AirConditioner
    {
        private int volumeCovered;
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered, int electricityUsed)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
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

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositiveMessage, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
                if (this.ElectricityUsed / sqrtVolume < Constants.PlaneAirTestBorderNumber)
                {
                    return 1;
                }

            return 0;
        }

        public override string ToString()
        {
            string result = base.ToString() + "Volume Covered: " + this.VolumeCovered + "\r\n" + "Electricity Used: " + this.ElectricityUsed + "\r\n";
            result += "====================";
            return result;
        }
    }
}
