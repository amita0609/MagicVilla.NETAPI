//using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MagicVilla_VillaAPI.Data;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// for database
builder.Services.AddDbContext<MagicVilla_VillaAPI.Data.ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingConfig));



// seriLog configuration
/* Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.
    File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();  */

builder.Services.AddControllers(Option =>
{
    //Option.ReturnHttpNotAcceptable = true;

}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//custom logger configuration
//builder.Services.AddSingleton<ILogging, Logging>();


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
