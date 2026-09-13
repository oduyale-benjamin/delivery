using Microsoft.EntityFrameworkCore;
using pizza.Models;

namespace pizza.Data;

public class PizzaDbContext : DbContext
{
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
    {
    }
    public DbSet<Pizza> Pizzas{get;set;}
}
