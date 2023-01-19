using api.Models;
using api.ModelViews;
using Microsoft.OpenApi.Models;

namespace api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration? Configuration { get;set; }
   
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Codigo do futuro", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Codigo do futuro v1"));
        }

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 1, Nome="Luan"});
        ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 2, Nome="Bea"});
        ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 3, Nome="Leo"});
        ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 4, Nome="Carina"});
        ClienteRepositorio.Instancia().Lista.Add(new Cliente { Id = 5, Nome="Sung Ju"});

    }
}