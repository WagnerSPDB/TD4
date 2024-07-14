using Microsoft.EntityFrameworkCore;

namespace td4.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DbSet<ListaDeTarefasModel> ListaDeTarefas { get; set; }
    }
}
