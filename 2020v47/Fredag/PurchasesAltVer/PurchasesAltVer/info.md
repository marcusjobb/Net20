# Lista på inköp
I detta program kan vi spara inköp och se sedan statistik på vilken butik man handlat mest på.

*Gott råd, dela alltid upp långa metoder i mindre metoder för att få snyggare och mer läsbar kod.*

Projekter har main class och två hjälpclasser

## Lärdom
För att programmet ska bli läsbar och hanterbar är det ibland enklast att skapa classer där man gömmer alla obekväma metoder, sedan anropar man dem vid behov.
Alla funktioner som kräver specialhantering av data, omvandlingar eller annat, kan läggas i egna metoder för att göra huvudprogrammet mer läsbar.

## Classer
Här är en förteckning av classerna

### Program
Mainclassen, den har själva input loopen, kollar input, skickar och tar emot data till/från databasen.

### DBHandler
Den här classen hjälper med vanliga databasanrop, som att skapa databasen, lägga till tabeller och göra sökningar
Classen har inget som gör den specifik för just detta projekt och kan lätt återanvändas.

### DBHelper
Den här classen är gjord bara för detta projekt. I den finns funktioner för SQL anrop som är specifika för detta projekt.

Man kan spara Varor, Butiker och inköp. Den är gjord väldigt snäll så man kan skicka in varor och butiker antingen som ID eller som sträng (varan/butikens namn).

Den har funktion som söker efter varor och butiker och skapar dessa om de inte finns, och returnerar Id till varan som söktes.

Alla specialfunktioner som är specifika för detta projekt och har med databaskommunikationen att göra, ligger i denna class.


