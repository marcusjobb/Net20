namespace FamilyTree
{
    using FamilyTree.Database;
    using FamilyTree.Helpers;
    using FamilyTree.Models;

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
                bool hasMother = (person.Mother != null);
                var hasFather = (person.Father != null);
                if (hasMother || hasFather)
                {
                    // Skapa en sträng med givet antal mellanslag för att ge intrycket av tabulering
                    var spaces = new string(' ', tab);
                    Console.WriteLine(spaces + person.Name);
                    if (hasMother) Console.WriteLine($"{spaces} Mother: {person.Mother.Name}");
                    // Öka mellanslag för nästa generation
                    tab += 2;
                    if (hasFather) Console.WriteLine($"{spaces} {person.Father.Name}");
                    // Sök efter moderns föräldrar
                    if (hasMother) FindAncestors(person.Mother, tab);
                    // Sök efter faderns föräldrar
                    if (hasFather) FindAncestors(person.Father, tab);
                }
            }
        }

        private static void Main()
        {
            // Seeda familjerna
            Seeder.GenerateFamilyTree();

            // Fråga om person att söka
            Console.WriteLine("Enter a name");
            var name = Console.ReadLine();
            Console.WriteLine();

            // Sök upp alla som matchar givet namn
            Data.Family.
                Where(
                    n => n.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
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