using ExpertDirectory.API.Models;
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
using Microsoft.EntityFrameworkCore;
using ExpertDirectory.API.Models.Repository;

namespace ExpertDirectory.API
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
            //Add EF Data Content
            services.AddDbContext<ExpertsDirectoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Add Scoped Entity Mappings
            services.AddScoped<IDataRepository<Member>, MemberRespository>();
            services.AddScoped<IDataRepository<MemberFriend>, MemberFriendRespository>();
            services.AddScoped<IDataRepository<MemberHeader>, MemberHeaderRespository>();

            // Add CORs - Setting to allow all for now, this should be changes to selective origins when deploying to PROD
            services.AddCors(o => o.AddPolicy("CORsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Enable Controller - setting ReferenceLoopHandling.Ignore to use EF classes as DTOs, should be removed by adding seperate POCOs as DTOs
            services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Add Swagger Support
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpertDirectory.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExpertDirectory.API v1"));
            }

            //Enable HTTPs Redirection
            app.UseHttpsRedirection();

            // Enable Cors
            app.UseCors("CORsPolicy");

            //Enable Routing
            app.UseRouting();            

            //Enable Endpoint Routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
