using Application;
using Core.Security;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSecurityServices(builder.Configuration,builder.Configuration.AddJsonFile(@"C:\Code\Backend\C#\Kodlama.io.Devs\src\corePackages\Core.Security\tokenoptions.json"));


builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
