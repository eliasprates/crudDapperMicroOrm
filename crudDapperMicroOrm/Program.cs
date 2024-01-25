using crudDapperMicroOrm.Repositories.Implementations;
using crudDapperMicroOrm.Repositories.Interfaces;
using crudDapperMicroOrm.Services.Implementations;
using crudDapperMicroOrm.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Configuração do arquivo appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Configuração das conexões com os bancos de dados
builder.Services.AddTransient<SqlConnection>(_ => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

//Configuração dos Repositories
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// Configuração dos Services
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddControllers();
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
