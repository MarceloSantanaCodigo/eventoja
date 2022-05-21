using EventosJa.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosJa.Api;

public class InforJaDB:DbContext
{
    private const string strSqlServer =
        "Initial Catalog=EventoJa;User=sa;Password=Your_password123;Data Source=localhost,5434";
    public InforJaDB()  
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(strSqlServer);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().ToTable("Categoria");
    }
}


 