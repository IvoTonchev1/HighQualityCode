namespace AirConditioningTestingSystem.Interfaces
{
    /// <summary>
    /// Inteface providing the basic properties required in every report and AC
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Manufacturer property for assigning a manufacturer to a given report or AC
        /// </summary>
        string Manufacturer { get; set; }

        /// <summary>
        /// Model property for assigning a model to a given report or AC
        /// </summary>
        string Model { get; set; }
    }
}
