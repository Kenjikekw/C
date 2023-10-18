using Clase.Models;
using Microsoft.EntityFrameworkCore;
using Clase.Services;
using System.Text;
using Microsoft.OpenApi.Models;


namespace Clase{
class Program
{
     static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<UsersContextSqlServer>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UserContextSqlServer")));

        builder.Services.AddDbContext<UsersContextPostgres>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("UserContextPostgres")));
       
       
       

        builder.Services.AddScoped<DbContext>(provider => provider.GetService<UsersContextSqlServer>());
        builder.Services.AddControllers();
        builder.Services.AddTransient<IJuegoService, JuegoService>();
        builder.Services.AddTransient<IAnimalService, AnimalService>();
        /*builder.Services.AddTransient<IPuntuacionService, PuntuacionService>();
        builder.Services.AddTransient<ILogroService, LogroService>();
        builder.Services.AddTransient<IAmigoService, AmigoService>();*/


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Multiapi",
                Version = "v1"
            });
        }); ;


        builder.Services.AddCors(options =>
                    {
                        options.AddPolicy(name: "frontend",
                            policy =>
                            {
                                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                            });
                    });
        builder.Services.AddMvc().AddMvcOptions(e => e.EnableEndpointRouting = false);
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        var app = builder.Build();

        app.UseCors("frontend");

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
}