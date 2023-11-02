using _3.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Context;

public class NimbusCenterDB:DbContext
{
    public NimbusCenterDB()
    {
        
    }
    public NimbusCenterDB(DbContextOptions<NimbusCenterDB> options) : base(options)
    {
    }
     
    public DbSet<Category> Categories { get; set; }
    public DbSet<Proveedores> Proveedores { get; set; }
     
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=Zeta123;Database=NimbusCenter;", serverVersion);
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Category");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(c => c.Title).IsRequired().HasMaxLength(90);
        builder.Entity<Category>().Property(c => c.Description).IsRequired().HasMaxLength(200); 
        builder.Entity<Category>().Property(c => c.DateCreate).HasDefaultValue(DateTime.Now);
        builder.Entity<Category>().Property(c => c.IsActive).HasDefaultValue(true);
         
         
        builder.Entity<Proveedores>().ToTable("Proveedores");
        builder.Entity<Proveedores>().HasKey(p => p.Id);
        builder.Entity<Proveedores>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Proveedores>().Property(c => c.Year).IsRequired();
        builder.Entity<Proveedores>().Property(c => c.Cost).IsRequired();
        builder.Entity<Proveedores>().Property(c => c.DateCreate).HasDefaultValue(DateTime.Now);
        builder.Entity<Proveedores>().Property(c => c.IsActive).HasDefaultValue(true);
    }
}