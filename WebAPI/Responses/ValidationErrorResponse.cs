using System.Collections.Generic; 

namespace WebAPI.Responses
{
    public class ValidationErrorResponse
    {
        public string Key { get; private set; }
        public List<string> Message { get; private set; }

        public ValidationErrorResponse(string Key, List<string> Message)
        {
            this.Key = Key;
            this.Message = Message;
        }
    }
}