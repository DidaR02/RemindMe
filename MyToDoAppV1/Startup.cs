using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using ToDoLibrary.DataAgent;

namespace MyToDoAppV1
{
    public class Startup
    {
        //public Startup()
        //{            
        //}
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //ToDo: Dependancy Injection            
            services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ToDoTaskDbConn")));
            //services.AddDbContext<ToDoDataContext>(options => options.UseInMemoryDatabase("MemoryToDoDB"));
                                   
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "My Doc",
                    Version = "v1",
                    Description = "This is my first Swashbuckle description",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Rudzani Raedani",
                        Email = "rudzani123@gmail.com",
                        Url = "N/A"
                    },
                    License = new License
                    {
                        Name = "N/A",
                        Url = "NoUrl"
                    }
                });


                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
                c.DescribeAllEnumsAsStrings();
            });


            var connectionString = @"";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //Swagger needs to request a pipeline to expose generated data.
            app.UseSwagger();
            app.UseSwaggerUI(endpoint => { endpoint.SwaggerEndpoint("/swagger/v1/swagger.json", "MyToDoApi v1");
            });
            
        }

        //private string getXmlCommentsPath()
        //{
        //    // Set the comments path for the Swagger JSON and UI.....MyToDoAppV1.xml
        //    //var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
        //    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        //    var app = AppContext.BaseDirectory;
        //    return Path.Combine(app.ApplicationBasePath, "MyToDoAppV1.xml");

        //}

    }
}
