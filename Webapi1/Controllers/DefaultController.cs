using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi1.Model;
 
namespace Webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpPost]
        public JsonResult PostPerson(Person p)
        {
            
            return new JsonResult(p);
        }
    }
}