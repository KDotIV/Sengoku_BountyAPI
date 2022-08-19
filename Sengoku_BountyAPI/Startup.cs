using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Sengoku_BountyAPI
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
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
