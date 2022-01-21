using SprintManager.WebApi.AppStart;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCustom()
    .AddDatabaseContext(builder.Configuration)
    .AddAutoMapperCustom()
    .AddControllers().Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGenCustom();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}

app.UseCors("CorsPolicy")
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();