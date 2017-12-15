using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Business.Services;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Repository;
using AK.PRJCT.CORE.ScheduleR.MS.Appointment.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AK.PRJCT.CORE.ScheduleR.MS.Appointment.API
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
            services.AddTransient(typeof(IAppointmentRepository), typeof(AppointmentRepository));
            services.AddTransient(typeof(IAppointmentDataService), typeof(AppointmentDataService));
            services.AddTransient(typeof(IAppointmentService), typeof(AppointmentService));

            services.AddTransient(typeof(ILoggerFactory), typeof(LoggerFactory));

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
