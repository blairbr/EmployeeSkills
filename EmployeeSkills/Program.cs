//Need to register controllers/services,etc here

using EmployeeSkills.Data;
using EmployeeSkills.Services;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://editor.swagger.io");
                      });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<ISkillService, SkillService>();


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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
