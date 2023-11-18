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
        
        builder.Services.AddTransient<IGPAService, GPAService>();
        builder.Services.AddSingleton<INpgsqlConnection, NpgsqlConnection>();
        builder.Services.AddSingleton<ISqlConnection, SqlConnection>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IStudentService, StudentService>();
    }
}
