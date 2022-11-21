using Microsoft.EntityFrameworkCore;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopDbContext  : DbContext
{
    public WebShopDbContext(DbContextOptions<WebShopDbContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TShirt>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    } 
    
    public DbSet<TShirt> BoxTable { get; set; }
}