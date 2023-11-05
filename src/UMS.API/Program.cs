using UMS.DataAccess.Repositories.AcadPositions;
using UMS.DataAccess.Repositories.Branchs;
using UMS.DataAccess.Repositories.Cities;
using UMS.DataAccess.Repositories.Departments;
using UMS.DataAccess.Repositories.Disciplines;
using UMS.DataAccess.Repositories.Faculties;
using UMS.DataAccess.Repositories.Universities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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