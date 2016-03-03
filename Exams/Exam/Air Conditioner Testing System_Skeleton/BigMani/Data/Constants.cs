namespace AirConditioningTestingSystem.Data
{
    public static class Constants
    {
        public const string IncorrectPropertyLengthMessage = "{0}'s name must be at least {1} symbols long.";

        public const string MissingReportsMessage = "No reports.";

        public const string InvalidCommandMessage = "Invalid command";

        public const string StatusMessage = "Jobs complete: {0:F2}%";

        public const string IncorrectRatingMessage = "Energy efficiency rating must be between \"A\" and \"E\".";

        public const string NonPositiveMessage = "{0} must be a positive integer.";

        public const string DuplicateEntry = "An entry for the given model already exists.";

        public const string NotExistingEntry = "The specified entry does not exist.";

        public const string SuccessfullRegister = "Air Conditioner model {0} from {1} registered successfully.";

        public const string SuccessfullTest = "Air Conditioner model {0} from {1} tested successfully.";

        public const int ModelMinLength = 2;

        public const int ManufacturerMinLength = 4;

        public const int MinCarVolume = 3;

        public const int CarAirTestBorderNumber = 3;

        public const int PlaneAirTestBorderNumber = 150;
    }
}
