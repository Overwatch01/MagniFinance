using FastEndpoints.Swagger;
using MagniFinance.Data;
using MagniFinance.Domain.Shared;
using MagniFinance.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataService(builder.Configuration);
builder.Services.AddDomainService();

builder.Services.AddCors(options
    => options.AddPolicy(name: "CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(opt =>
{
    opt.DocumentSettings = s =>
    {
        s.Title = "Magni Finance";
        s.Version = "v1";
    };
});



var app = builder.Build();


app.Services.AutoMigrateDb();
app.UseCors("CorsPolicy");

app.UseFastEndpoints(config =>
{
    config.Endpoints.RoutePrefix = "api";
});
app.UseSwaggerGen();
app.UseMiddleware<ErrorHandlerMiddleware>();


app.Run();