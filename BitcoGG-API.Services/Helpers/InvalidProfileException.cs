using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.Services.Helpers
{
    public class InvalidProfileException : Exception
    {
        public InvalidProfileException()
        {
        }

        public InvalidProfileException(string message)
            : base(message)
        {
        }

        public InvalidProfileException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
