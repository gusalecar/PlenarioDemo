using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MvcDemo.Controllers
{
    public class PersonasController : Controller
    {
        private readonly DemoContext context;

        public PersonasController(DemoContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(string searchString = "")
        {
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                return View(
                    await context.Personas.Where(p => p.Nombre.Contains(searchString)).ToListAsync());
            }
            else
            {
                return View(await context.Personas.ToListAsync());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            ModelState.Remove(nameof(persona.Telefonos));
            if (ModelState.IsValid)
            {
                context.Update(persona);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await context.Personas.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Persona persona)
        {
            ModelState.Remove(nameof(persona.Telefonos));
            if (ModelState.IsValid)
            {
                context.Personas.Update(persona);
                await context.SaveChangesAsync();
            }
            
            return View(persona);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await context.Personas.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Persona persona)
        {
            context.Personas.Remove(persona);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
