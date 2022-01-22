using Microsoft.AspNetCore.SpaServices.AngularCli;
using SprintManager.WebApi.AppStart;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCustom()
    .AddDatabaseContext(builder.Configuration)
    .AddAutoMapperCustom()
    .AddControllers().Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGenCustom()
    .AddSpaStaticFiles(configuration =>
    {
        configuration.RootPath = "ClientApp/dist/sprint-manager-client";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app
        .UseSwagger()
        .UseSwaggerUI();
}
else
{
    app.UseSpaStaticFiles();
}

app.UseCors("CorsPolicy")
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.MapWhen(
    context => !context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase),
    cfg =>
    {
        cfg.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";
            if (app.Environment.IsDevelopment())
            {
                spa.UseAngularCliServer(npmScript: "start");
            }
        });
    }
);

app.Run();