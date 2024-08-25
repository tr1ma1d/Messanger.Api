using Messanger.DataAccess;
using Messanger.DataAccess.Repository;
using Messanger.Services.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//configure a postgreSQL
builder.Services.AddDbContext<MessangerDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);


//for register 
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<IRepository, UserRepository>();

//ADd Cors policy == для взаимодействия с React
// Добавьте Redis как Singleton сервис
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse("localhost");
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use CORS policy
app.UseCors("AllowAll");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
