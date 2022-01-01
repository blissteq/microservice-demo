using DemoRestTest.Abstraction;
using DemoRestTest.Abstraction.BookLoan.Repository;
using DemoRestTest.Abstraction.BookLoan.Service;
using DemoRestTest.Abstraction.BookReader.Repository;
using DemoRestTest.Abstraction.BookReader.Service;
using DemoRestTest.Core.BookLoan.Service;
using DemoRestTest.Core.BookReader.Service;
using DemoRestTest.Grpc.Services;
using DemoRestTest.Infrastructure.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRestTest.Grpc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IReaderRepository, ReaderRepository>();
            services.AddTransient<IReaderApplication, ReaderApplication>();
            services.AddTransient<ILoanApplication, LoanApplication>();
            services.AddGrpc();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<LoanService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
