using DynemicSun;
using DynemicSun.Services.IGetServices;
using DynemicSun.Services.ISetServices;
using DynemicSun.Services.ITranslateServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.Write(connectionString);
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<ISetService,SetService>();
builder.Services.AddScoped<ITranslateService, TranslateService>();
builder.Services.AddScoped<IGetService, GetService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();