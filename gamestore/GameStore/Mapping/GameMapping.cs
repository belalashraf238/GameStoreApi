﻿using GameStore.Dtos;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
 public static Game ToEntity(this CreateGameDto game){
   return new (){
        Name=game.Name,

        GenereId=game.GenreId,

        Price=game.Price,
        ReleaseDate=game.ReleaseDate
    };
 }
 public static GameDto ToDto(this Game game){
     return new(game.Id,game.Name,game.Gene!.Name,game.Price,game.ReleaseDate);
 }
 
}
