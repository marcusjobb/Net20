namespace SaganLinq
{
    using SaganLinq.Database;

    using System;
    using System.Linq;

    static class Program
    {
        static void Main()
        {
            using (var sagan = new Sagan())
            {
                if (sagan.Händelser.Count() == 0 && sagan.Koppling.Count() == 0 && sagan.Personer.Count() == 0 && sagan.Saker.Count() == 0)
                {
                    // Kalla en seeder funktion
                }
                // Gör en sökning
                var saga = from koppling in sagan.Koppling
                           join personA in sagan.Personer on koppling.Person1 equals personA.ID
                           join händelse in sagan.Händelser on koppling.Handling equals händelse.ID
                           join sak in sagan.Saker on koppling.Sak equals sak.ID
                           join personB in sagan.Personer on koppling.Person2 equals personB.ID into checkNull
                           from mottagare in checkNull.DefaultIfEmpty()
                           select new
                           {
                               // Skapa objekt med önskad information
                               Person1 = personA.Namn,
                               händelse = händelse.Namn,
                               Sak = sak.Namn,
                               Person2 = mottagare.Namn
                           }
                           ;

                // Skriv ut informationen
                foreach (var item in saga)
                {
                    Console.WriteLine($"{item.Person1} {item.händelse} {item.Sak} {item.Person2}");
                }

            }
        }

        private static void AddNewItem(Sagan sagan, int person1Id, int HandlingId, int SakId, int Person2Id)
        {
            //Hämta senaste ID (då databasen inte är inställd på autoincrement :(
            var KopplingsID = sagan.Koppling.Max(k => k.ID);

            //Skapa ny objekt
            sagan.Koppling.Add(new Models.Koppling
            {
                ID = KopplingsID,
                Person1 = person1Id,
                Handling = HandlingId,
                Sak = SakId,
                Person2 = Person2Id
            });

            //Spara ändringen
            sagan.SaveChanges();
        }
    }
}
