using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Competition.Tools.Configuration
{
  public static  class HostingEnvironmentExtensions
    {
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }
    }
}
