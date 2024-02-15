using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoleTracker.Data;
using RoleTracker.Models.SeedData;
using RoleTracker.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RoleTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoleTrackerContext") ?? throw new InvalidOperationException("Connection string 'RoleTrackerContext' not found.")));

builder.Services.AddScoped<IGameQueryService, GameQueryService>();
builder.Services.AddScoped<ICharacterQueryService, CharacterQueryService>();
builder.Services.AddScoped<ICharacterCrudService, CharacterCrudService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
