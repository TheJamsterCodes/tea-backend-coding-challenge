using TEABackEndCodingChallenge;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureBuilder();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();