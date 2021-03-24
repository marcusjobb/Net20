namespace EFStarWarsFamilyTree.Database
{
    using EFStarWarsFamilyTree.Models;

    using System;
    using System.Linq;

    public static class Seeder
    {
        public static void PopulateDatabase()
        {
            using (var db = new StarWarsFamilyTree())
            {
                //Skywalker family
                AddPerson(db, "Shmi Skywalker", string.Empty, string.Empty);
                AddPerson(db, "Anakin Skywalker", string.Empty, "Shmi Skywalker");
                AddPerson(db, "Padmé Amidala", "Ruwee Naberrie", "Jobal Naberrie");
                AddPerson(db, "Leia Organa", "Anakin Skywalker", "Padmé Amidala");
                AddPerson(db, "Luke Skywalker", "Anakin Skywalker", "Padmé Amidala");

                // Solo family
                AddPerson(db, "Den Solo", "Korol Solo", string.Empty);
                AddPerson(db, "Jonash Solo", "Den Solo", "Tira Gama Solo");
                AddPerson(db, "Tiion Solo", "Den Solo", "Tira Gama Solo");
                AddPerson(db, "Thrackan Sal-Solo", "Randil Sal", "Tiion Solo");
                AddPerson(db, "Han Solo", "Jonash Solo", "Jaina Solo (Elder)");

                // Naberrie family
                AddPerson(db, "Jobal Naberrie", string.Empty, "Ryoo Thule");

                // Djo Family
                AddPerson(db, "Ta'a Chume", string.Empty, "Ni'Korish");
                AddPerson(db, "Isolder", "Ta'a Chume", "Consort");
                AddPerson(db, "Kalen", "Ta'a Chume", "Consort");
                AddPerson(db, "Tenel Ka Djo", "Isolder", "Teneniel Djo");

                // Skywalker Jade family
                AddPerson(db, "Ben Skywalker", "Luke Skywalker", "Mara Jade");

                // Skywalker Solo Family
                AddPerson(db, "Anakin Solo", "Han Solo", "Leia Organa");
                AddPerson(db, "Jacen Solo", "Han Solo", "Leia Organa");
                AddPerson(db, "Jaina Solo", "Han Solo", "Leia Organa");
                // Ben Solo och Rey är inte med för att de är en Disney-påhittade karaktärer!
                // JJ Abrams och Disney suger!

                //Solo Djo Family
                AddPerson(db, "Allana Solo", "Jacen Solo", "Tenel Ka Djo");

                // Solo Fel family
                AddPerson(db, "Fel II", "Jagged Fel", "Jaina Solo");
                AddPerson(db, "Roan Fel", "Fel II", string.Empty);
                AddPerson(db, "Marasiah Fel", "Roan Fel", "Elliah Fel");

                //Lars Family
                AddPerson(db, "Owen Lars", "Cliegg Lars", "Aika Lars");
                AddPerson(db, "Cliegg Lars", "Lef Lars", "Gredda Lars");
                AddPerson(db, "Edern Lars", "Lef Lars", "Gredda Lars");
                AddPerson(db, "Beru Whitesun", string.Empty, string.Empty);
                db.SaveChanges();
            }
        }

        private static Person AddPerson(StarWarsFamilyTree db, string name, string father, string mother)
        {
            var motherObj = FindOrAddParent(db, mother);
            var fatherObj = FindOrAddParent(db, father);
            var child = db.Person.FirstOrDefault(p => p.Name == name);
            // Om personen inte finns, skapa den
            if (child == null)
            {
                child = new Person { Name = name, MotherId = motherObj?.Id, FatherId = fatherObj?.Id };
                db.Person.Add(child);
                db.SaveChanges();
                Console.WriteLine($"Created {name}");
            }
            else
            {
                //Om personen finns, ta bort personen och skapa en my med givna föräldrar
                if (motherObj != null) child.MotherId = motherObj.Id;
                if (fatherObj != null) child.FatherId = fatherObj.Id;
                db.Person.Update(child);
                Console.WriteLine($"Updated {name}");
            }
            // Returnera det nyskapade personobjektet
            return child;
        }

        private static Person FindOrAddParent(StarWarsFamilyTree db, string name)
        {
            // Sök personen med givet namn
            var obj = db.Person.FirstOrDefault(p => p.Name == name);
            if (obj == null && name != string.Empty)
            {
                obj = AddPerson(db, name, string.Empty, string.Empty);
            }

            return obj;
        }
    }
}