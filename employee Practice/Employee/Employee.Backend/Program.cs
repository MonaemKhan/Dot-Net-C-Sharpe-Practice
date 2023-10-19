using Employee.Ioc.Configaration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Employee",
            Version = "v1",
            Description = "This is a Employee Project to see how documentation can easily be generated for ASP.NET Core Web APIs using Swagger and ReDoc.",
            Contact = new OpenApiContact
            {
                Name = "M.A. Monaem Khan",
                Email = "Khanmonaem07@gmail.com"
            }
        });
});

builder.Services.MapCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Swagger Demo Documentation v1"));

    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Swagger Demo Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
