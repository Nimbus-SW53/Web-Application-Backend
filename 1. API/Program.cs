using System.Reflection;
using _1._API.Mapper;
using _1._API.Mapper.CategoryMapper;
using _1._API.Mapper.ProductMapper;
using _1._API.Mapper.ProviderMapper;
using _1._API.Mapper.ReviewMapper;
using _1._API.Mapper.UserMapper;
using _2._Domain;
using _3._Data;
using _3._Data.Context;
using _3._Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Documentacion de la API
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Nimbus API",
        Description = "Contact software providers from all over the world and choose the software that best suits you",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Nimbus Contact",
            Url = new Uri("https://nimbus.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "OpenSource License",
            Url = new Uri("https://opensource.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


//Inyeccion dependencias
builder.Services.AddScoped<IProductData, ProductMySQLData>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddScoped<IReviewData, ReviewMySQLData>();
builder.Services.AddScoped<IReviewDomain, ReviewDomain>();

builder.Services.AddScoped<IProviderData, ProviderMySQLData>();
builder.Services.AddScoped<IProviderDomain, ProviderDomain>();

builder.Services.AddScoped<IUserData, UserMySQLData>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<ICategoryData, CategoryMySQLData>();
builder.Services.AddScoped<ICategoryDomain, CategoryDomain>();

//Pomelo MySQL Conexion
var connectionString = builder.Configuration.GetConnectionString("NimbusDB");

builder.Services.AddDbContext<NimbusDB>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });


//Automapper
builder.Services.AddAutoMapper(
    typeof(ProductAPIToModel),
    typeof(ProductModelToAPI),
    typeof(ReviewAPIToModel),
    typeof(ReviewModelToAPI),
    typeof(ProviderAPIToModel),
    typeof(ProviderModelToAPI),
    typeof(UserAPIToModel),
    typeof(UserModelToAPI),
    typeof(CategoryAPIToModel),
    typeof(CategoryModelToAPI)
);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<NimbusDB>())
{
   context.Database.EnsureCreated();
}
    
    
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