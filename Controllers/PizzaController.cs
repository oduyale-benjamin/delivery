using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza.Data;
using pizza.Models;

namespace pizza.Controllers;

public class PizzaController : Controller
{
    private readonly PizzaDbContext _context;
    public PizzaController(PizzaDbContext context)
    {
        _context = context;
    }
    // CREATE

    //GET

    public IActionResult Create()
    {
        return View();
    }
    //POST pizza/create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        if (ModelState.IsValid)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pizza);
    }

    //READ
    //GET
    public async Task<IActionResult> Index()
    {
        var pizzas = await _context.Pizzas.ToListAsync();
        return View(pizzas);
    }
    //GET Pizza/Detail/Id
    public async Task<IActionResult> Detail(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        if (pizza == null)
        {
            return NotFound();
        }
        return View(pizza);
    }

    //UPDATE
    //GET Pizza/Edit/Id
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return View(pizza);
    }
    //POST Pizza/Edit/Id
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,Pizza pizza)
    {
        if (id != pizza.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            _context.Pizzas.Update(pizza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pizza);
    }

    //DELETE
    //GET Pizza/Delete/Id
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var pizza = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        if (pizza == null)
        {
            return NotFound();
        }
        return View(pizza);
    }
    //POST Pizza/Delete/Id
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza != null)
        {
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

