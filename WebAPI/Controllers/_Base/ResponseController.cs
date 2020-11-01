using System.Collections.Generic; 
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebAPI.Responses; 
using System.Linq;

namespace WebAPI.Controllers._Config
{
    public abstract class ResponseController : ApiController
    {
        protected ResponseData ResultResquest(EResponse code, object result = null) => new ResponseData(code: code, data: result);
        protected ResponseData SucessResquest() => ResultResquest(EResponse.OK, result: null);
        protected ResponseData SucessResquest(object result) => ResultResquest(EResponse.OK, result: result);
        protected ResponseData UnexpectedErrorResquest(object result = null) => ResultResquest(EResponse.UnexpectedError, result);
        protected ResponseData NoDataResquest(object result = null) => ResultResquest(EResponse.NoData, result);
        protected ResponseData NoPermissionResquest(object result = null) => ResultResquest(EResponse.NoPermission, result);
        protected ResponseData ValidationErrorResquest(List<ValidationErrorResponse> errorList) => ResultResquest(EResponse.ValidationError, result: errorList);
        protected ResponseData ValidationErrorResquest(List<string> errorList) => ResultResquest(EResponse.ValidationError, result: errorList);
        protected ResponseData ValidationErrorResquest(string errorList) => ResultResquest(EResponse.ValidationError, result: errorList);
        protected ResponseData UnSuccessResquest() => ResultResquest(EResponse.UnSuccess);
        protected ResponseData CreateResquest(object result) => result is null ? UnSuccessResquest() : SucessResquest();
        protected ResponseData CreateResquestWithReturn(object result) => result is null ? UnSuccessResquest() : SucessResquest(result);
    }
}