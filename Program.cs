using EdTechAPI.Model;
using EdTechAPI.Services;
using EdTechAPI.Structure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();

var server = builder.Configuration["DbServer"] ?? "localhost";
var port = builder.Configuration["DbPort"] ?? "5432";
var user = builder.Configuration["DbUser"] ?? "edtech";
var password = builder.Configuration["Password"] ?? "edtech";
var database = builder.Configuration["Database"] ?? "edtech";

var connectionString = $"Server={server}, {port};Initial Catalog={database},Persist Security Info=True; User ID={user};Password={password}";

builder.Services.AddDbContext<ConnectionContext>(options =>
        options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInitialization(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
