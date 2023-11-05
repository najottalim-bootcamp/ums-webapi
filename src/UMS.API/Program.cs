using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.ScienDegrees;
using UMS.DataAccess.Repositories.Specialties;
using UMS.DataAccess.Repositories.SpecialtyEduForms;
using UMS.DataAccess.Repositories.Teachers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICityRepository, CityRepository>();

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
