using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using v1.Services;
using v1.Models;
using v1.Models.Contracts;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace v1
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
            

            // requires using Microsoft.Extensions.Options
            services.Configure<AppV1DatabaseSettings>(
                Configuration.GetSection(nameof(AppV1DatabaseSettings)));

            services.AddSingleton<IAuthenticationService, FakeAuthenticationService>();
            services.AddSingleton<IAuthorizationService, FakeAuthorizationService>();

            services.AddSingleton<IAppV1DatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AppV1DatabaseSettings>>().Value);

            services.AddSingleton<MotoristaService>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
