using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Competition.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Study1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IOptions<MyOptions> _options;
        private string str = "str";
        private readonly ILogger<ValuesController> _logger;
        private IDisposable change;
        private TestOption testOption;
        // private readonly MyOptions _options;
        public ValuesController(TestOption t, IOptions<MyOptions> myoptions)
        {
            testOption = t;
            _options = myoptions;
            
            //_options = options ;
            //_logger = logger;
            //_logger.LogError("test");

            //  change= _options.OnChange(a =>_logger.LogError(a.DefaultValue)  );
              
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {


            return new string[] { (ServiceLocator.Instance.GetService(typeof(IConfiguration)) as IConfiguration)["MyOptions:DefaultValue"]+"__"+ testOption.MyOp, testOption.Options +"__"+ _options.Value.DefaultValue };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
