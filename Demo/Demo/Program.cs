using Demo.Repository;
using EzPz.EasyPeasy.Infrastructure.Data;
using Mascot.PLM.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.InitSqlDbContext(builder.Configuration);
builder.Services.AddScoped<IFabricTestRepository, FabricTestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    DemoContextSeed.SeedAsync(service);
}

app.Run();
