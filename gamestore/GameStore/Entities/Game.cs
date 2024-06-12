namespace GameStore.Entities;

public class Game
{
    public int Id { get; set; }
public required string Name { get; set; }
public int GenereId { get; set; }
public Genere? Gene { get; set; }
public decimal Price { get; set; }
public DateOnly ReleaseDate { get; set; }

}
