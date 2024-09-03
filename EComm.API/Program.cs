using EComm.API.Infrastructure.Implementation.Repositories;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using EComm.API.RunTime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMyServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyName", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin(); // WithOrigins("frontDomain");
        policyBuilder.AllowAnyHeader(); // no secuirty for header request
        policyBuilder.AllowAnyMethod();// al CRUD allowed and we check specific methods 
        //policyBuilder.AllowCredentials(); // allow any credential to use apis (for test resons)
    });
});

//dbcontext config

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("PolicyName");

DependencyInjection.AppConfig(app);

app.Run();
