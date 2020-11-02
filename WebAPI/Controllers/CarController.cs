using System.Web.Http;
using WebAPI.Controllers._Base;
using WebAPI.Models;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/car")]
    public class CarController : BaseController
    {
        [HttpPost]
        [Route("create")]
        public ResponseData Create([FromBody] Car car)
        {
            return Execute(CreateResquestWithReturn, () =>
            {
                ValidationFromDataAnnotationValidate();

                ValidationValidate(car.Brand == car.Name, "Brand is the same as the Name");

                return true;
            });
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public ResponseData GetAll(int id)
        {
            return Execute(SucessResquest, () =>
            {
                NoDataValidate(id == 0, "No Data");

                return "It's OK";
            });
        }
    }
}