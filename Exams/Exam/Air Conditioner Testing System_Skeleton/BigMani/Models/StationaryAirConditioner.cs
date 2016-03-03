namespace AirConditioningTestingSystem.Models
{
    using System;
    using Data;

    public class StationaryAirConditioner : AirConditioner
    {
        private string energyRating;
        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, string energyRating, int powerUsage)
            : base(manufacturer, model)
        {
            this.EnergyRating = energyRating;
            this.PowerUsage = powerUsage;
        }

        public string EnergyRating
        {
            get
            {
                return this.energyRating;
            }

            set
            {
                if (!value.Equals("A") && !value.Equals("B") && !value.Equals("C") && !value.Equals("D") & !value.Equals("E"))
                {
                    throw new ArgumentException(Constants.IncorrectRatingMessage);
                }

                this.energyRating = value;
            }
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositiveMessage, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public override int Test()
        {
            int rating = 0;
            switch (this.EnergyRating)
            {
                case "A":
                    rating = 1000;
                    if (this.PowerUsage < rating)
                    {
                        return 1;
                    }

                    break;
                case "B":
                    rating = 1251;
                    if (this.PowerUsage < rating)
                    {
                        return 1;
                    }

                    break;
                case "C":
                    rating = 1501;
                    if (this.PowerUsage < rating)
                    {
                        return 1;
                    }

                    break;
                case "D":
                    rating = 2001;
                    if (this.PowerUsage < rating)
                    {
                        return 1;
                    }

                    break;
                case "E":
                    return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string result = base.ToString() + "Required energy efficiency rating: " + this.EnergyRating + "\r\n" + "Power Usage(KW / h): " +
                         this.PowerUsage + "\r\n";
            result += "====================";

            return result;
        }
    }
}
