using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pricope_Delia_project.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Contextul pt date(produse,cmenzi,angajati)
builder.Services.AddDbContext<Pricope_Delia_projectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pricope_Delia_projectContext") ?? throw new InvalidOperationException("Connection string not found.")));

// Contextul pt identity (users & roles)
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pricope_Delia_projectContext") ?? throw new InvalidOperationException("Connection string not found.")));

// Configurare Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

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

app.UseRouting();


app.UseAuthentication(); // Login
app.UseAuthorization();  // Roluri


app.MapRazorPages();

app.Run();
