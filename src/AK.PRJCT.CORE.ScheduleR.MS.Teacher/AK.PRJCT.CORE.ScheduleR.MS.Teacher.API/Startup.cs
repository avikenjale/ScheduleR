using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Business.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Repositories;
using AK.PRJCT.CORE.ScheduleR.MS.Teacher.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AK.PRJCT.CORE.ScheduleR.MS.Teacher.API
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
            services.AddTransient(typeof(ITeacherService),typeof(TeacherService));
            services.AddTransient(typeof(ITeacherDataService),typeof(TeacherDataService));
            services.AddTransient(typeof(ITeacherRepository),typeof(TeacherRepository));

            services.AddSingleton(typeof(ILoggerFactory), typeof(LoggerFactory));            

            services.AddMvc();
            services.AddCors(o =>
            {
                o.AddPolicy("AllowAnyOrigin",
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
