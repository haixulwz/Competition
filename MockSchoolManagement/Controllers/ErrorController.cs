using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MockSchoolManagement.Controllers
{
    public class ErrorController : Microsoft.AspNetCore.Mvc.Controller        
    {
        private ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger) {
            this.logger = logger;
        }

        [Route("Error/Index")]
        public IActionResult Index( )
        {
            

            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"路径{exceptionFeature.Path} 产生了一个错误 {exceptionFeature.Error}");

            return View();
        }
        [Route("Error/NotFound/{code}")]
        public IActionResult NotFound(int code)
        {
            var result = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (result != null)
            {
                logger.LogWarning($"发生了一个{code}错误,路劲为{result.OriginalPath},参数为{result.OriginalQueryString}");
            }
            else {
                var a = Request.Headers["Referer"].ToString();
            }
          
            return View();
        }
    }
}
