namespace AirConditioningTestingSystem.Exceptions
{
    using System;

    public class DuplicateEntryException : DivideByZeroException
    {
        public DuplicateEntryException(string msg) : base(msg)
        {
        }
    }
}
