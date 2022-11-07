using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Pages.Index;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services
    .AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddRazorPages();
builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddServerSideBlazor(options =>
{
    options.RootComponents.RegisterCustomElement<ProductsList>("products-list");
});

var app = builder.Build();
SeedData.EnsureSeeded(app.Services);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
