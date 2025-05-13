using WorkHub.Web.Controllers.InjectionsConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddServicesConfiguration();
builder.Services.AddSessionConfiguration();
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Authentication}/{action=Login}");

await app.RunAsync();