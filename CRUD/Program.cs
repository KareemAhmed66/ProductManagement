using CRUD.Data;
using CRUD.Repositories.Implementations;
using CRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//add dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options => options
.UseSqlServer(connectionString)
.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
.UseLazyLoadingProxies()
);


// ignore loop reference
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//add controllers
builder.Services.AddControllers();


//add repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//add automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
