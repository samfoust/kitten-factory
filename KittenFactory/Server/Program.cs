using KittenFactory.Application.Services;
using KittenFactory.Application.Services.Interfaces;
using KittenFactory.Core.Repositories;
using KittenFactory.Infrastructure.Data;
using KittenFactory.Infrastructure.Repository;
using KittenFactory.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// use in-memory database
builder.Services.AddDbContext<KittenFactoryContext>(c =>
    c.UseInMemoryDatabase("KittenFactoryMemoryDatabase"));


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICatRepository, CatRepository>();

builder.Services.AddScoped<ICatService, CatService>();

builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//Seed database
using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<KittenFactoryContext>();
    KittenFactoryContextSeed.SeedAsync(dbContext);
}

app.Run();
