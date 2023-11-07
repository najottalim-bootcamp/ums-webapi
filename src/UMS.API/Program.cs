using UMS.DataAccess.Repositories.AcadPositions;
using UMS.DataAccess.Repositories.Branchs;
using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.Contracts;
using UMS.DataAccess.Repositories.Countries;
using UMS.DataAccess.Repositories.Departments;
using UMS.DataAccess.Repositories.Disciplines;
using UMS.DataAccess.Repositories.Faculties;
using UMS.DataAccess.Repositories.PersonalDatas;
using UMS.DataAccess.Repositories.ScienDegrees;
using UMS.DataAccess.Repositories.Specialties;
using UMS.DataAccess.Repositories.SpecialtyEduForms;
using UMS.DataAccess.Repositories.Students;
using UMS.DataAccess.Repositories.Subjects;
using UMS.DataAccess.Repositories.Teachers;
using UMS.Service.Common.Files;
using UMS.Service.Common.Paginations;
using UMS.Service.Departments;
using UMS.Service.Disciplines;
using UMS.Service.Services.Faculties;
using UMS.Service.SpecialtyEduForms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IPagination, Pagination>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();

builder.Services.AddScoped<ISpecialtyEduFormRepository, SpecialtyEduFormRepository>();
builder.Services.AddScoped<ISpecialtyEduFormService, SpecialtyEduFormService>();

builder.Services.AddScoped<IDisciplineRepository, DisciplineRepository>();
builder.Services.AddScoped<IDisciplineService, DisciplineService>();

builder.Services.AddScoped<IFacultyRepository, FacultyRepository>();
builder.Services.AddScoped<FacultyService, FacultyService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<ITeacherRepository , TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();
builder.Services.AddScoped<IAcadPositionRepository , AcadPositionRepository>();
builder.Services.AddScoped<IScienDegreeRepository, ScienDegreeRepository>();

builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IContractService, ContractService>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();

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