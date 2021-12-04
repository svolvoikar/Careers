using TEK_Careers.API.Helpers;
using System.Web.Http;

namespace TEK_Careers.API.Controllers
{
    [AuthorizeApi]
    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
        }
    }
}
