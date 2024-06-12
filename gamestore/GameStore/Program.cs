using GameStore.Data;
using GameStore.Dtos;
using GameStore.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var connString=builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);


var app = builder.Build();
app.CreateGamesEndPoints();
app.MigrateDb();
app.Run();
