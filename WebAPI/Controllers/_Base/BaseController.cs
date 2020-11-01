using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;
using WebAPI.Controllers._Config;
using WebAPI.Exceptoins;
using WebAPI.Responses;

namespace WebAPI.Controllers._Base
{
    public  abstract class BaseController : ResponseController
    {
        protected delegate ResponseData ExecuteReponse(object res);
        protected delegate object ExecuteAction();

        protected ResponseData Execute(ExecuteReponse response, ExecuteAction action)
        {
            try
            {
                return response(action());
            }
            catch (NoDataException ex)
            {
                return NoDataResquest(ex.Message);
            }
            catch (ValidationException ex)
            {
                if (ex.ValidationErrorResponses is null)
                    return ValidationErrorResquest(ex.Message);
                else
                    return ValidationErrorResquest(ex.ValidationErrorResponses);
            }
            catch (NoPermissionException ex)
            {
                return NoPermissionResquest(ex.Message);
            }
            catch (UnSuccessException ex)
            {
                return UnSuccessResquest();
            }
            catch (Exception ex)
            {
                return UnexpectedErrorResquest(ex.Message);
            }
        }

        protected void NoDataValidate(bool condition, string message = null)
        {
            if (condition)
                throw new NoDataException(message);
        }
        protected void ValidationFromDataAnnotationValidate()
        {
            if (!ModelState.IsValid)
                throw new ValidationException(GetMessageValidationErrorResponse(ModelState));
        }
        protected void ValidationValidate(bool condition, string message = null)
        {
            if (condition)
                throw new ValidationException(message);
        }
        protected void NoPermissionExceptionValidate(bool condition, string message = null)
        {
            if (condition)
                throw new NoPermissionException(message);
        }

        protected object GetUserData()
        {
            NoPermissionExceptionValidate(!User.Identity.IsAuthenticated, "No permission");

            return "id:1 - name: Joe";
        }


        private List<ValidationErrorResponse> GetMessageValidationErrorResponse(ModelStateDictionary modelState)
        {
            List<ValidationErrorResponse> res = new List<ValidationErrorResponse>();

            if (!modelState.IsValid)
            {
                for (int i = 0; i < modelState.Keys.Count; i++)
                {
                    string key = modelState.Keys.ElementAt(i).Contains(".") ? modelState.Keys.ElementAt(i).Split('.')[1] : modelState.Keys.ElementAt(i);
                    List<string> errors = new List<string>();
                    foreach (var error in modelState.Values.ElementAt(i).Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }

                    res.Add(new ValidationErrorResponse(key, errors));
                }
            }
            return res;
        }
    }
}