using System.Data.SQLite;
using System.IO;

namespace Inlämningsuppgift_DB1
{
    class DataFeed : Database
    {
        public static void SkapaDatabas()
        {
            // Hämta filinfo
            FileInfo fi = new FileInfo(database);

            // Kontrollera att databasfilen finns eller om den är tom
            if (!fi.Exists || fi.Length == 0)
            {
                // Om databasfilen inte finns, skapa en
                SQLiteConnection.CreateFile(database);
                System.Diagnostics.Debug.WriteLine("Skapade en databas");

                // Skapa tabeller
                ExecuteSQL(@"CREATE TABLE ""LägenhetsInformation"" (""Dörr"" TEXT, ""Person"" TEXT, ""Tagg"" TEXT)");
                ExecuteSQL(@"CREATE TABLE ""DörrID"" (""Dörrbenämning"" TEXT, ""Förklaring"" TEXT)");
                ExecuteSQL(@"CREATE TABLE ""DörrKoder"" (""Kod"" TEXT, ""Förklaring"" TEXT)");
                ExecuteSQL(@"CREATE TABLE ""Logg"" (""Tid""  TEXT, ""Kod"" TEXT, ""Gäst"" TEXT, ""Dörr"" TEXT, ""Tagg"" TEXT)");

                //Skapa Logg data
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖUT"", ""Liam Jönsson"",""LGH0101"", ""0101A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖIN"", ""Elias Pettersson"",""LGH0102"", ""0102A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDIN"", ""Wilma Johansson"",""LGH0102"", ""0102B"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDUT"", ""Alicia Sanchez"",""LGH0103"", ""0103A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖUT"", ""Aaron Sanchez"",""LGH0103"", ""0103B"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖIN"", ""Olivia Erlander"", ""LGH01201"", ""0201A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDIN"", ""William Erlander"",""LGH0201"", ""0201B"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDUT"", ""Alexander Erlander"",""LGH0201"", ""0201C"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖUT"", ""Astrid Erlander"",""LGH0201"", ""0201D"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖIN"", ""Lucas Adolfsson"",""LGH0202"", ""0202A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDUT"", ""Ebba Adolfsson"",""LGH0202"", ""0202B"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDIN"", ""Lilly Adolfsson"",""LGH0202"", ""0202C"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖUT"", ""Ella Ahlström"", ""LGH0301"", ""0301A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖIN"", ""Alma Alfredsson"",""LGH0301"", ""0301B"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDIN"", ""Elsa Ahlström"",""LGH0301"", ""0301C"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDUT"", ""Maja Ahlström"",""LGH0301"", ""0301D"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖUT"", ""Noah Almgren"",""LGH0302"", ""0302A"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""DÖIN"", ""Adam Andersen"",""LGH0302"", ""0302B"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDIN"", ""Kattis Backman"",""LGH0302"", ""0302C"")");
                ExecuteSQL(@"INSERT INTO Logg (""Kod"", ""Gäst"", ""Dörr"", ""Tagg"") VALUES(""FDUT"", ""Oscar Chen"",""LGH0302"", ""0302D"")");

                //Skapa Koder för dörrar.
                ExecuteSQL(@"INSERT INTO DörrKoder (""Kod"", ""Förklaring"") VALUES(""DÖUT"", ""Dörr har öppnats utifrån"")");
                ExecuteSQL(@"INSERT INTO DörrKoder (""Kod"", ""Förklaring"") VALUES(""DÖIN"", ""Dörr har öppnats inifrån"")");
                ExecuteSQL(@"INSERT INTO DörrKoder (""Kod"", ""Förklaring"") VALUES(""FDIN"", ""Fel dörr - försökte öppna dörr utan tillstånd."")");
                ExecuteSQL(@"INSERT INTO DörrKoder (""Kod"", ""Förklaring"") VALUES(""FDUT"", ""Fel dörr - försökte öppna ut från en dörr med fel tagg."")");

                //Information om Dörrnamn
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0101"", ""Dörr till lägenhet LGH0101"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0101"", ""Dörr till balkong LGH0101"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0102"", ""Dörr till lägenhet LGH0102A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0102"", ""Dörr till balkong LGH0102A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0103"", ""Dörr till lägenhet LGH0103A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0103"", ""Dörr till balkong LGH0103A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0201"", ""Dörr till lägenhet LGH0201A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0201"", ""Dörr till balkong BLK0201A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0202"", ""Dörr till lägenhet LGH0202A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0202"", ""Dörr till balkong LGH0202A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0301"", ""Dörr till lägenhet LGH0301A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0301"", ""Dörr till balkong LGH0301A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""LGH0302"", ""Dörr till lägenhet LGH0302A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""BLK0302"", ""Dörr till balkong LGH0302A"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""Soprum"", ""Dörr till Soprum"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""UT"", ""Dörr ut mot gatan"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""SoprumM"", ""Dörr mot soprummet"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""Tvätt"", ""Dörr mot tvättstugan"")");
                ExecuteSQL(@"INSERT INTO DörrID (""Dörrbenämning"", ""Förklaring"") VALUES (""Vakt"", ""Dörr mot vaktmästares rum"")");

                //Information för lägenheterna, gästerna och deras tagg.
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0101"", ""Liam Jönsson"",""0101A"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0102"", ""Elias Pettersson"",""0102A"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0102"", ""Wilma Johansson"",""0102B"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0103"", ""Alicia Sanchez"",""0103A"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0103"", ""Aaron Sanchez"",""0103B"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0201"", ""Olivia Erlander"",""0201A"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0201"", ""William Erlander"",""0201B"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0201"", ""Alexander Erlander"",""0201C"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0201"", ""Astrid Erlander"",""0201D"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0202"", ""Lucas Adolfsson"",""0202A"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0202"", ""Ebba Adolfsson"",""0202B"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0202"", ""Lilly Adolfsson"",""0202C"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0301"", ""Ella Ahlström"",""0301A"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0301"", ""Alma Alfredsson"",""0301B"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0301"", ""Elsa Ahlström"",""0301C"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0301"", ""Maja Ahlström"",""0301D"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0302"", ""Noah Almgren"",""0302A"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0302"", ""Adam Andersen"",""0302B"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0302"", ""Kattis Backman"",""0302C"")");
                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""LGH0302"", ""Oscar Chen"",""0302D"")");

                ExecuteSQL(@"INSERT INTO LägenhetsInformation (""Dörr"",""Person"",""Tagg"") VALUES(""VAKT"", ""Vaktmästare"",""VAKT01"")");
            }
        }
    }
}
