using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Exceptoins
{
  public  class NoPermissionException : Exception
    {
        public NoPermissionException()
        {

        }
        public NoPermissionException(string message) : base(message)
        {

        }
    }
}
