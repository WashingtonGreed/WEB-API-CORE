using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Models;

namespace WEB_API_CORE.Data
{
  public class DataContext: DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<CATEGORIA> CATEGORIAS {get; set;}
    public DbSet<PRODUTO> PRODUTOS {get; set;}
    public DbSet<USUARIO> USUARIOS {get; set;}
    public DbSet<REMESSA> REMESSAS { get; set;}
    public DbSet<LOTE> LOTES { get; set; }
    public DbSet<CLIENTE> CLIENTES { get; set; }

    }
}