using CurlConnection.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); //! Comment if you use localhost instead of ipconfig on your device

app.MapCrudEndpoints<Category>("categories");
app.MapCrudEndpoints<Customer>("customers");
app.MapCrudEndpoints<Discount>("discounts");
app.MapCrudEndpoints<Employee>("employees");
app.MapCrudEndpoints<Order>("orders");
app.MapCrudEndpoints<OrderItem>("orderitems");
app.MapCrudEndpoints<Product>("products");
app.MapCrudEndpoints<User>("users");

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
