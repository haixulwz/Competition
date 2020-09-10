using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MockSchoolManagement.Model;

namespace MockSchoolManagement
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration configuration) {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(c => c.EnableEndpointRouting = false);
            services.AddControllersWithViews(c=>c.EnableEndpointRouting=false) ;
            services.AddSingleton<IStudentRepository, StudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage();
            }
          //  app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.Use(async(context,next)=> {

                logger.LogInformation(  "start1 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                await next();
                logger.LogInformation(  "end1 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            });
            app.Use(async (context, next) => {

                logger.LogInformation("start2 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                await next();
                logger.LogInformation("end2 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            });
            app.Run(async(context)=> {
              //  throw new Exception("发生了异常");
                await context.Response.WriteAsync(env.EnvironmentName);
                logger.LogInformation("end3 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            });
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        var conf = configuration["m"];
            //        context.Response.ContentType = "text/plain;charset=utf-8";
            //        await context.Response.WriteAsync(processName + conf);
            //    });
            //});
        }
    }
}
