using GameStore.Data;
using GameStore.Dtos;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GameEndPoints
{
    private static readonly List<GameDto>  games=[
new(
    1,
    "street fighter",
    "fighting",
    19.99m,
    new DateOnly(1992,7,15)
),
new(
    2,
    "final fantasy",
    "Rpg",
    20.15m,
    new DateOnly(1996,1,22)
),
new(
    1,
    "Fifa 23",
    "Sports",
    60m,
    new DateOnly(2023,2,9)
),

];

public static RouteGroupBuilder CreateGamesEndPoints(this WebApplication app){
 var group=app.MapGroup("games").WithParameterValidation();    
group.MapGet("/",()=>games);

group.MapGet("/{id}",(int id,GameStoreContext dbContext)=>
{
  Game? game= dbContext.Games.Find(id);
  
  return game is null ? Results.NotFound(): Results.Ok(game);
}).WithName("GetGame");

group.MapPost("/",(CreateGameDto newGame,GameStoreContext dbContext )=>{
    if(string.IsNullOrEmpty(newGame.Name)){
        return Results.BadRequest("Name is Required ");
    }
     Game game=newGame.ToEntity();
     game.Gene=dbContext.Genres.Find(newGame.GenreId);

    dbContext.Games.Add(game);
    dbContext.SaveChanges();

    GameDto gameDto=new(game.Id,game.Name,game.Gene!.Name,game.Price,game.ReleaseDate);
   
    return Results.CreatedAtRoute("GetGame",new {id=game.Id},game.ToDto());
});
group.MapPut("/{id}",(int id,UpdateGameDto updateGame)=>{
 var index=games.FindIndex(game=>game.Id==id);
 if (index==-1){
    return Results.NotFound();
 }
 games[index]=new GameDto(
    id,
    updateGame.Name,
    updateGame.Genre,
    updateGame.Price,
    updateGame.ReleaseDate
 );
 return Results.NoContent();


});
group.MapDelete("/{id}",(int id)=>{
    games.RemoveAll(game=>game.Id==id);
    return Results.NoContent(); 
});

return group;
}

}
