using System;
using System.Web.Http;

namespace HeaderReproductionTest.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult Get()
        {
            Console.WriteLine("Request for /api/test");
            System.Diagnostics.Debug.WriteLine("Request for /api/test");
            return Ok("Hello, world111111111111111!");
        }
    }
}
