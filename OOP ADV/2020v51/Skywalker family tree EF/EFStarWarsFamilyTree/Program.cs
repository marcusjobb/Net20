namespace EFStarWarsFamilyTree
{
    using EFStarWarsFamilyTree.Database;
    using EFStarWarsFamilyTree.Models;

    using System;
    using System.Linq;

    internal static class Program
    {
        private static void FindAncestors(Person person, int tab = 0)
        {
            if (person != null)
            {
                // Lagrar jämförelsen i en variabel för att slippa ställa samma fråga
                // flera gånger
                var hasMother = person.Mother != null;
                var hasFather = person.Father != null;
                if (hasMother || hasFather)
                {
                    // Skapa en sträng med givet antal mellanslag för att ge intrycket av tabulering
                    var spaces = new string(' ', tab);
                    Console.WriteLine(spaces + person.Name);
                    if (hasMother)
                    {
                        // Om personen har mor och far, skriv ├─── annars skriv └───
                        // för att det ska bli snyggare output
                        Console.Write($"{spaces} {(hasFather ? "├─── " : "└─── ")}");
                        Console.WriteLine($"Mother: {person.Mother.Name}");
                    }
                    // Öka mellanslag för nästa generation
                    tab += 2;
                    if (hasFather)
                    {
                        Console.WriteLine($"{spaces} └─── Father: {person.Father.Name}");
                    }
                    // Sök efter moderns föräldrar
                    if (hasMother)
                    {
                        FindAncestors(person.Mother, tab);
                    }
                    // Sök efter faderns föräldrar
                    if (hasFather)
                    {
                        FindAncestors(person.Father, tab);
                    }
                }
            }
        }

        private static void Main()
        {
            using (var family = new StarWarsFamilyTree())
            {
                if (family.Person.Count() == 0) Seeder.PopulateDatabase();

                // Fråga om person att söka
                Console.WriteLine("Enter a name");
                var name = Console.ReadLine().ToLower();
                Console.WriteLine();

                // Sök upp alla som matchar givet namn
                family.Person.
                Where(
                    n => n.Name.ToLower().IndexOf(name) >= 0
                )
                .OrderBy(n => n.Name) // Sortera på namn
                .ToList() // för att göra det kompatibelt med ForEach
                .ForEach(
                    // Hitta familjemedlemmarna
                    person => FindAncestors(person)
                );

            }
        }
    }
}