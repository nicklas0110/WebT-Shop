using Microsoft.EntityFrameworkCore;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class DatabaseContext  : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Webshop 
        modelBuilder.Entity<Item>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Item>()
            .HasOne<Category>()
            .WithMany(c => c.CategoryItems)
            .HasForeignKey(i => i.ItemCategoryId);

        modelBuilder.Entity<Category>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Option>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Option>()
            .HasMany(o => o.Items)
            .WithMany(i => i.Options);

        
        //User Login
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<User>()
            .HasIndex((u => u.Email))
            .IsUnique();


    } 
    
    public DbSet<Item> ItemTable { get; set; }
    public DbSet<Category> CategoryTable { get; set; }
    public DbSet<Option> OptionTable { get; set; }
    public DbSet<User> UserTable { get; set; }
}