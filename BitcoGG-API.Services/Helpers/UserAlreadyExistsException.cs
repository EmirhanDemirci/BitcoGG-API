using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoGG_API.Services.Helpers
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string message)
                :base(message)
        {
        }

        public UserAlreadyExistsException(string message, Exception inner)
                :base(message, inner)
        {
        }
    }
}
