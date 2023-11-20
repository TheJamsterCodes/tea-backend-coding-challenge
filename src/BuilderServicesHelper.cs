using System.Reflection;
using TEABackEndCodingChallenge.Repository;
using TEABackEndCodingChallenge.Services;

namespace TEABackEndCodingChallenge;

public static class BuilderServicesHelper
{
    public static void ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMemoryCache();

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
            .AddEnvironmentVariables()
            .Build();        
        
        builder.Services.AddTransient<IGPAService, GPAService>();
        builder.Services.AddSingleton<IDatabaseConnection>(db => new DatabaseConnection(config, isUsingSQLServer: true));
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IStudentService, StudentService>();
    }
}
