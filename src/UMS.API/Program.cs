using UMS.DataAccess.Repositories.Branchs;
using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.Countries;
using UMS.DataAccess.Repositories.Departments;
using UMS.DataAccess.Repositories.Faculties;
using UMS.DataAccess.Repositories.Students;
using UMS.Service.Branches;
using UMS.Service.Cities;
using UMS.Service.Countries;
using UMS.Service.Departments;
using UMS.Service.Services.Faculties;
using UMS.Service.Services.Students;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IStudentRepository , StudentRepository>();
//builder.Services.AddScoped<IStudentService , StudentService>();


builder.Services.AddScoped<ICityRepository , CityRepository>();
builder.Services.AddScoped<ICityService , CityService>();


builder.Services.AddScoped<ICountryRepository , CountryRepository>();
builder.Services.AddScoped<ICountryService , CountryService>();


builder.Services.AddScoped<IBranchRepository , BranchRepository>();
builder.Services.AddScoped<IBranchService , BranchService>();

builder.Services.AddScoped<IFacultyRepository , FacultyRepository>();
builder.Services.AddScoped<FacultyService , FacultyService>();

builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService , DepartmentService>();

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