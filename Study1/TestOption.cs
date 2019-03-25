using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study1
{
    public class TestOption : IDisposable
    {
        private IOptionsMonitor<MyOptions> _options;
        private readonly ILogger<TestOption> _logger;
        private readonly IDisposable change;
        private IOptions<MyOptions> _myoptions;
        public TestOption(IOptionsMonitor<MyOptions> options , ILogger<TestOption>  logger,IOptions<MyOptions> myoptions)
        {
            _options = options;
            _logger = logger;
            change= _options.OnChange(a => {   _logger.LogInformation(a.DefaultValue); });
            _myoptions = myoptions;
        }
        public void Dispose()
        {
          //  change.Dispose();
            //throw new NotImplementedException();
        }
        public string  Options {
            get { return _options.CurrentValue.DefaultValue; }
        }
        public string MyOp {
            get { return _myoptions.Value.DefaultValue; }
        }
    }
}
