﻿using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public static class DataExtension
{
public static void MigrateDb(this WebApplication app)
{
   using var scope = app.Services.CreateScope();
   var dbContext=scope.ServiceProvider.GetRequiredService<GameStoreContext>();
   dbContext.Database.Migrate();

}
}
