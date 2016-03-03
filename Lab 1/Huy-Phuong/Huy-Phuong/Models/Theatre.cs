namespace TheaterSystem.Models
{
    using System.Collections.Generic;

    public class Theatre
    {
        private IList<Performance> performances;
        private string name;

        public Theatre(string name)
        {         
            this.Name = name;
            this.performances = new List<Performance>();
        }

        public string Name { get; set; }       
    }
}
