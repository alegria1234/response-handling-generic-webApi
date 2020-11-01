using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Responses
{
    public enum EResponse
    {
        OK,
        UnexpectedError,
        NoData,
        ValidationError, 
        NoPermission,
        UnSuccess
    }
}