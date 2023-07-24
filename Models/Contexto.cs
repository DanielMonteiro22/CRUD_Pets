using Microsoft.EntityFrameworkCore;

namespace PetsSite.Models
{
    public class Contexto : DbContext
    {
        public Contexto( DbContextOptions<Contexto> options) : base(options) 
        { 
        
        }
        public DbSet<AnimaisModel> Animais { get; set; }
    }
}
