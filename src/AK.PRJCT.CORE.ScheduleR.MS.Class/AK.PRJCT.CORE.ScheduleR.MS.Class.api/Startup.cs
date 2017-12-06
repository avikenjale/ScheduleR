using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Business.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Repositories;
using AK.PRJCT.CORE.ScheduleR.MS.Class.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AK.PRJCT.CORE.ScheduleR.MS.Class.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IClassRepository),typeof(ClassRepository));
            services.AddTransient(typeof(IClassDataService),typeof(ClassDataService));
            services.AddTransient(typeof(IClassService),typeof(ClassService));

             services.AddSingleton(typeof(ILoggerFactory), typeof(LoggerFactory));  

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
