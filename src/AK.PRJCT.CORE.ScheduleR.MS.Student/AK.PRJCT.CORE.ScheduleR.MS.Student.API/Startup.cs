using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AK.PRJCT.CORE.ScheduleR.MS.Student.API
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
            services.AddTransient(typeof(Data.Repositories.IStudentRepository), typeof(Data.Repositories.StudentRepository));
            services.AddTransient(typeof(Data.Services.IStudentDataService), typeof(Data.Services.StudentDataService));
             services.AddTransient(typeof(Business.Services.IStudentService), typeof(Business.Services.StudentService));
            services.AddMvc();            
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
