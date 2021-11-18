using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

using (DemoContext context = new())
{
    context.Database.Migrate();

    if (!await context.Personas.AnyAsync())
    {
        await context.Personas.AddRangeAsync(new[]
        {
            new Persona
            {
                Nombre = "Juan Topo",
                FechaNacimiento = DateTime.Today,
                CreditoMaximo = 10000,
                Telefonos = new[]
                {
                    new Telefono { Numero = "12345678" },
                    new Telefono { Numero = "87654321" }
                }
            },
            new Persona
            {
                Nombre = "Maria Sol",
                FechaNacimiento = DateTime.Today,
                CreditoMaximo = 10000,
                Telefonos = new[]
                {
                    new Telefono { Numero = "11112222" },
                    new Telefono { Numero = "22221111" }
                }
            }
        });
        _ = context.SaveChanges();
    }
}

builder.Services.AddDbContext<DemoContext>();

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
    pattern: "{controller=Personas}/{action=Index}/{id?}");

app.Run();
