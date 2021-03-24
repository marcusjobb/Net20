namespace FamilyTree.Helpers
{
    using FamilyTree.Database;
    using FamilyTree.Models;

    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Seeder to generate the family tree
    /// </summary>
    public static class Seeder
    {
        internal static void GenerateFamilyTree()
        {
            Data.Family = new List<Person>();
            Seed();
        }

        // Lägger till en person i listan
        private static Person AddPerson(string name, string father, string mother)
        {
            var motherObj = FindOrAddParent(mother);
            var fatherObj = FindOrAddParent(father);
            var child = Data.Family.Find(p => p.Name == name);
            // Om personen inte finns, skapa den
            if (child == null)
            {
                child = new Person { Name = name, Mother = motherObj, Father = fatherObj };
                Data.Family.Add(child);
            }
            else
            {
                //Om personen finns, ta bort personen och skapa en my med givna föräldrar
                Data.Family.Remove(child);
                if (motherObj != null) child.Mother = motherObj;
                if (fatherObj != null) child.Father = fatherObj;
                Data.Family.Add(child);
            }
            // Returnera det nyskapade personobjektet
            return child;
        }

        /// <summary>
        /// Söker en person med det givna namnet
        /// </summary>
        /// <param name="name">Namnet på personen</param>
        /// <returns>En person<see cref="Person"/></returns>
        private static Person FindOrAddParent(string name)
        {
            // Sök personen med givet namn
            var obj = Data.Family.Find(p => p.Name == name);
            if (obj == null && name != string.Empty)
            {
                obj = AddPerson(name, string.Empty, string.Empty);
            }

            return obj;
        }

        /// <summary>
        /// Lägger in data i familjeträdet
        /// </summary>
        private static void Seed()
        {
            // Source: https://starwars.fandom.com/wiki/Skywalker_family/Legends

            //Skywalker family
            AddPerson("Shmi Skywalker", string.Empty, string.Empty);
            AddPerson("Anakin Skywalker", string.Empty, "Shmi Skywalker");
            AddPerson("Padmé Amidala", "Ruwee Naberrie", "Jobal Naberrie");
            AddPerson("Leia Organa", "Anakin Skywalker", "Padmé Amidala");
            AddPerson("Luke Skywalker", "Anakin Skywalker", "Padmé Amidala");

            // Solo family
            AddPerson("Den Solo", "Korol Solo", string.Empty);
            AddPerson("Jonash Solo", "Den Solo", "Tira Gama Solo");
            AddPerson("Tiion Solo", "Den Solo", "Tira Gama Solo");
            AddPerson("Thrackan Sal-Solo", "Randil Sal", "Tiion Solo");
            AddPerson("Han Solo", "Jonash Solo", "Jaina Solo (Elder)");

            // Naberrie family
            AddPerson("Jobal Naberrie", string.Empty, "Ryoo Thule");

            // Djo Family
            AddPerson("Ta'a Chume", string.Empty, "Ni'Korish");
            AddPerson("Isolder", "Ta'a Chume", "Consort");
            AddPerson("Kalen", "Ta'a Chume", "Consort");
            AddPerson("Tenel Ka Djo", "Isolder", "Teneniel Djo");

            // Skywalker Jade family
            AddPerson("Ben Skywalker", "Luke Skywalker", "Mara Jade");

            // Skywalker Solo Family
            AddPerson("Anakin Solo", "Han Solo", "Leia Organa");
            AddPerson("Jacen Solo", "Han Solo", "Leia Organa");
            AddPerson("Jaina Solo", "Han Solo", "Leia Organa");
            // Ben Solo och Rey är inte med för att de är en Disney-påhittade karaktärer!
            // JJ Abrams och Disney suger!

            //Solo Djo Family
            AddPerson("Allana Solo", "Jacen Solo", "Tenel Ka Djo");

            // Solo Fel family
            AddPerson("Fel II", "Jagged Fel", "Jaina Solo");
            AddPerson("Roan Fel", "Fel II", string.Empty);
            AddPerson("Marasiah Fel", "Roan Fel", "Elliah Fel");

            //Lars Family
            AddPerson("Owen Lars", "Cliegg Lars", "Aika Lars");
            AddPerson("Cliegg Lars", "Lef Lars", "Gredda Lars");
            AddPerson("Edern Lars", "Lef Lars", "Gredda Lars");
            AddPerson("Beru Whitesun", string.Empty, string.Empty);
        }
    }
}