namespace AirConditioningTestingSystem.Models
{
    public class Report : AirConditioner
    {
        public Report(string manufacturer, string model, int mark) : base(manufacturer, model)
        {
            this.Mark = mark;
        }

        public int Mark { get; set; }

        public override string ToString()
        {
            string grade = string.Empty;
            if (this.Mark == 0)
            {
                grade = "Failed";
            }
            else if (this.Mark == 1)
            {
                grade = "Passed";
            }

            string result = "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + this.Manufacturer + "\r\n" +
                      "Model: " + this.Model + "\r\n" + "Mark: " + grade + "\r\n" + "====================";

            return result;
        }
    }
}
