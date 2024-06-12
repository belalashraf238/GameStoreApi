using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options):DbContext(options)
{
    
public DbSet<Game> Games => Set<Game>();

public DbSet<Genere> Genres => Set<Genere>();




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Genere>().HasData(
            new {Id=1, Name="Action"},
            new {Id=2, Name="Adventure"},
            new {Id=3, Name="RPG"},
            new {Id=4, Name="Simulation"},
            new {Id=5, Name="Strategy"}
       );
    }





}
