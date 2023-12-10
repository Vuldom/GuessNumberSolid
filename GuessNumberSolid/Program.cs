using GuessNumberSolid.BLL;
using GuessNumberSolid.BLL.Interfaces;
using GuessNumberSolid.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISettingsService, SettingsService>();
builder.Services.AddTransient<ISecretNumberService, SecretNumberService>();
builder.Services.AddTransient<IGameService, GameService>();
var storage = new Storage();
builder.Services.AddSingleton<Storage>(storage);


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