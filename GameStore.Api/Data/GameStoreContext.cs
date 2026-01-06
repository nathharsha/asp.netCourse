using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
     : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Boxing" },
            new { Id = 2, Name = "Cricket" },
            new { Id = 3, Name = "Soccer" },
            new { Id = 4, Name = "Kids" },
            new { Id = 5, Name = "Racing" },
            new { Id = 6, Name = "RolePlay" }
        );
    }
}
