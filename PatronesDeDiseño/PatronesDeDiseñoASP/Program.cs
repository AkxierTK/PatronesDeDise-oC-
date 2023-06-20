using PatronesDeDiseñoASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Se ha creado un objeto para inyectar desde los ficheros de configuración la ruta del log y así no tener que meterla manualmente en cada ruta del log
//Esta configuración se recoge del objeto Configuration/MiConfig y dentro del appsettings.json en el campo MiConfig
builder.Services.Configure<MiConfig>(builder.Configuration.GetSection("MiConfig"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
