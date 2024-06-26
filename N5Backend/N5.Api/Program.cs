using N5.Api.Application;
using N5.Api.Domain.Models;
using N5.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()!;
builder.Services.AddSingleton(appSettings);

builder.Services.AddApplicationServiceRegistration();
builder.Services.AddInfrastructureServiceRegistration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI((options) =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "N5 Api Employers permissions");
        options.DocumentTitle = "N5 Api Employers permissions";
    });
}

app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Api is Running.");

app.Run();
