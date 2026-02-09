using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AdvancedDevSample.Application.Exceptions
{
    public class ApplicationServiceException : Exception
    {
        // Ajoutez cette propriété publique à la classe ApplicationServiceException
        public HttpStatusCode StatusCode { get; }

        public ApplicationServiceException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public ApplicationServiceException(string? message) : base(message)
        {
        }
    }
}
