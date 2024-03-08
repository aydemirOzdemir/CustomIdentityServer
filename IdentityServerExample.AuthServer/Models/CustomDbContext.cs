using Microsoft.EntityFrameworkCore;

namespace IdentityServerExample.AuthServer.Models;

public class CustomDbContext:DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options):base(options)
    {
        
    }
    public DbSet<CustomUser> CustomUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomUser>().HasData(new CustomUser
        {
            Id = 1,
            Name="Aydemir",
            City="Bursa",
            Email="aydemirozdemir@gmail.com",
            Password="Password12*"
        },new CustomUser
        {
            Id = 2,
            Name = "Alpartun",
            City = "Bursa",
            Email = "alpartunozdemir@gmail.com",
            Password = "Password12*"
        });



        base.OnModelCreating(modelBuilder);
    }
}
