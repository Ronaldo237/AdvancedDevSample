using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Exceptions
{
    /// <summary>
    /// Exception lancée par les services d'application (couche application).
    /// </summary>

    public class ApplicationServiceException : Exception
    {
        public ApplicationServiceException() { }

        public ApplicationServiceException(string message) : base(message) { }

        public ApplicationServiceException(string message, Exception innerException) : base(message, innerException) { }

        public int StatusCode { get; set; }

    }
}
