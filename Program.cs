using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using precio_summer_project.Data;
using precio_summer_project.Models;
using precio_summer_project.Repositories.Events;
using precio_summer_project.Services.Events;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseString"));
});

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddAuthorization();
builder
    .Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors(x =>
    x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials()
);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
