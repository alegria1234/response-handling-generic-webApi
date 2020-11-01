using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Exceptoins
{
    public class NoDataException : Exception
    {
        public NoDataException()
        {

        }
        public NoDataException(string message) : base(message)
        {

        }
    }
}
