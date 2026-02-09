using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Exceptions
{
    public class InfrastructureException : Exception
    {

        public InfrastructureException() { }

        public InfrastructureException(string message) : base(message) { }

        public InfrastructureException(string message, System.Exception inner) : base(message, inner) { }

    }
}
