using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Responses
{
    public class ResponseData
    {
        public EResponse Code { get; set; }
        public bool Status { get; set; }
        public object Message { get; set; }
        public object Data { get; set; }


        public ResponseData()
        {
        }

        public ResponseData(EResponse code)
        {
            this.Code = Code;
            this.Message = GetMessage(Code);
            this.Data = null;
            Status = EResponse.OK == code;
        }

        public ResponseData(EResponse code, object message, object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
            Status = EResponse.OK == code;
        }

        public ResponseData(EResponse code, object data)
        {
            this.Code = Code;
            this.Message = GetMessage(code);
            Status = EResponse.OK == code;
            this.Data = data;
        }

        private string GetMessage(EResponse code)
        {
            switch (code)
            {
                case EResponse.OK:
                    {
                        return "Sucess";
                    }
                case EResponse.ValidationError:
                    {
                        return "Validation Error";
                    }
                case EResponse.UnexpectedError:
                    {
                        return "Unexpected Error";
                    }
                case EResponse.NoData:
                    {
                        return "No data";
                    }
                case EResponse.NoPermission:
                    {
                        return "No Permission";
                    }
                case EResponse.UnSuccess:
                    {
                        return "No Permission";
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}