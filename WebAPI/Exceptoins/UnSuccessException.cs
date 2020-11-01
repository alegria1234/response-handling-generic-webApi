using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Exceptoins
{
    public class UnSuccessException : Exception
    {
        public UnSuccessException()
        {

        }
        public UnSuccessException(string message) : base(message)
        {

        }
    }
}