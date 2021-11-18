using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcDemo.Controllers
{
    public class TelefonosController : Controller
    {
        private readonly DemoContext context;

        public TelefonosController(DemoContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int id)
        {
            ViewData["PersonaId"] = id;
            ViewData["Nombre"] = context.Personas.FindAsync(id).Result?.Nombre;
            return View(context.Telefonos.Where(t => t.PersonaId == id));
        }

        public IActionResult Create(int id)
        {
            ViewData["PersonaId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            ModelState.Remove(nameof(telefono.Persona));
            if (ModelState.IsValid)
            {
                context.Update(telefono);
                context.SaveChanges();
            }

            return RedirectToAction(nameof(Index), new { id = telefono.PersonaId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await context.Telefonos.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Telefono telefono)
        {
            ModelState.Remove(nameof(telefono.Persona));
            if (ModelState.IsValid)
            {
                context.Telefonos.Update(telefono);
                await context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index), new { id = telefono.PersonaId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await context.Telefonos.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Telefono telefono)
        {
            context.Telefonos.Remove(telefono);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = telefono.PersonaId });
        }
    }
}
