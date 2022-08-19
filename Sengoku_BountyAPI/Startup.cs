using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Sengoku_BountyAPI
{
    public class Startup
    {
        private string _connectionString = null;
        public IConfiguration Configroot { get; }
        public Startup(IConfiguration configuration)
        {
            Configroot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            _connectionString = Configroot["ConnectionStrings:Database"];
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sengoku_BountyAPI", Version = "v1" });
            });
            services.AddMvc();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sengoku_BountyAPI"));
                app.UseCors("CorsPolicy");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.Run();
        }
    }
}
