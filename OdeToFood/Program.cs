using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContextPool<OdeToFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OdeToFoodDb"));
});

builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();
// builder.Services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseNodeModules(maxAge: TimeSpan.FromSeconds(600));
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.UseCookiePolicy();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
