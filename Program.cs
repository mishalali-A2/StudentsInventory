using Microsoft.EntityFrameworkCore;
using StudentsInventory.Data;
using Microsoft.OpenApi.Models;
using StudentsInventory.Data.Interfaces;
using StudentsInventory.Data.Repositories;
using StudentsInventory.Services;
using StudentsInventory.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder => builder.WithOrigins("http://localhost:4200") // Angular dev server
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

//services registering
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentService, StudentService>();

//Swagger services for testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Students API", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Students API V1");
    });
}

app.UseCors("AllowAngularDev");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();