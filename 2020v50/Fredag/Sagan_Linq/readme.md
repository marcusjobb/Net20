# Databas sagan
Sagan gör comeback men i Entity Framework form. 
Plus att vi använder Linq.

Då databasen är redan färdig använder vi Database-First medoden

Prova med att göra om det till en Code First genom att skapa en Add-Migration. 

Add-Migration kommer dock att återskapa databasens struktur, men inte innehållet.

Ett tips är att köra exempelvis

if (db.Personer.Count<1) SeedPeople();
