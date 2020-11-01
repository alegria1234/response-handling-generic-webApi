using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Responses;

namespace WebAPI.Exceptoins
{
    public class ValidationException : Exception
    {
       public List<ValidationErrorResponse> ValidationErrorResponses { get; set; }
        public ValidationException()  
        {

        }
        public ValidationException(string message) : base(message)
        {

        }
        public ValidationException(List<ValidationErrorResponse> validationErrorResponses) 
        {
            ValidationErrorResponses = validationErrorResponses;
        }
    }
}
