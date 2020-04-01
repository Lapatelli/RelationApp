using System;

namespace RelationApp.Core.Exceptions
{
    public class InvalidSortingPropertyException : Exception
    {
        public InvalidSortingPropertyException(string message) : base(message) { }
    }
}
