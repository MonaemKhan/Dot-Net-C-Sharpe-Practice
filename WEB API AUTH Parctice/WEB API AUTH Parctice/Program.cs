using WEB_API_AUTH_Parctice.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.CoreConfiguration(builder.Configuration); // add servicecollection class so it can complie our requried class

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
