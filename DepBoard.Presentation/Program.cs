using DepBoard.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServicosApplication();
builder.Services.AddControllersWithViews();
builder.Services.AddServicosInfra(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
