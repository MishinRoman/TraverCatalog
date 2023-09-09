using Microsoft.EntityFrameworkCore;

using Npgsql.Internal.TypeHandling;

using webapi.Data;
using webapi.Services;
using webapi.Services.Intrefaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PostgresDbContext>(options=>options.UseNpgsql(builder.Configuration.GetConnectionString("PsqlConnectionString")));
builder.Services.AddScoped<DbContext, PostgresDbContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(EFRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();

