using DemoRestTest.Abstraction;
using DemoRestTest.Abstraction.BookLoan.Repository;
using DemoRestTest.Abstraction.BookLoan.Service;
using DemoRestTest.Abstraction.BookReader.Repository;
using DemoRestTest.Abstraction.BookReader.Service;
using DemoRestTest.Core.BookLoan.Service;
using DemoRestTest.Core.BookReader.Service;
using DemoRestTest.Infrastructure.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRestTest.API
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoGraphQL.API", Version = "v1" });
            });
            services.AddControllers();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IReaderRepository, ReaderRepository>();
            services.AddTransient<IReaderApplication, ReaderApplication>();
            services.AddTransient<ILoanApplication, LoanApplication>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoGraphQL.API v1"));
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
