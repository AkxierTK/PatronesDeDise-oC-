using Microsoft.EntityFrameworkCore;
using PatronesDeDiseño.Models.Data;
using PatronesDeDiseño.Repository;
using PatronesDeDiseñoASP.Configuration;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Se ha creado un objeto para inyectar desde los ficheros de configuración la ruta del log y así no tener que meterla manualmente en cada ruta del log
//Esta configuración se recoge del objeto Configuration/MiConfig y dentro del appsettings.json en el campo MiConfig
builder.Services.Configure<MiConfig>(builder.Configuration.GetSection("MiConfig"));


//Con ASP se puede utilizar una biblioteca que se llama Dependency Injection
//Hay 3 formas Singletone--> Un objeto para toda la app Transient --> Un objeto para cada servicio, solicitud, servicicio,... Scopt --> el mismo para la misma solicitud

//Con Services.Add y uno de los anteriores podemos añadirlo con una funcion lambda
builder.Services.AddTransient((factory) =>
{
    //Al añadir los valoes desde el fichero appSettings.json se resuelve el problema de modificar los valores de manera manual
    return new LocalEarnFactory(builder.Configuration.GetSection("MiConig").GetValue<decimal>("LocalPercentage"));
});

//Agregamos el contexto
builder.Services.AddDbContext<PatronesDeDiseñoContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

//Agregamos para tdodos los controladores la clase repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
