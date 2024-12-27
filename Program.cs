using System.Reflection;
using Microsoft.OpenApi.Models;
using contosopizza.Data;
using contosopizza.Service;
using contosopizza.data;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");
builder.Services.AddSqlite<PromotionsContext>("Data Source=promotions/Promotions.db");

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((options) =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Contoso Pizza API",
        Description = "Contoso pizza api lets you create and manage your pizzas",
        TermsOfService = new Uri("https://go.microsoft.com/fwlink/?LinkID=206977"),
        Contact = new OpenApiContact
        {
            Name = "Your name",
            Email = string.Empty,
            Url = new Uri("https://learn.microsoft.com/training")
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // add xml file here
    options.IncludeXmlComments(xmlPath);
});


builder.Services.AddScoped<PizzaService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI((options) =>
    {
        // add swagger endpoint
        options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Add the CreateDbIfNotExists method call
Extentions.CreateDbIfNotExist(app);

app.MapControllers();

app.Run();
