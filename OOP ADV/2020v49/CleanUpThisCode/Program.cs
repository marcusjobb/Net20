namespace CleanUpThisCode
{
    using System;
    using System.Linq;

    /*
     *
     * Den här koden är hemsk! Den är svårläst och omständig.
     * Vad händer om vi vill kunna hantera hästar och pandas.
     * Enklast vore en lista, för då kan vi loopa igenom alla
     *
     * Kan vi använda Interfaces?
     *
     * Hur kan vi skydda main om det inte finns katter och hundar definierade
     *
     * Städa upp min hemska kod så den följer SOLID möstret så gott som det går
     * Gör koden mer läsbar och mer användbart
     *
     */

    internal static class Program
    {
        private static void Main()
        {
            //Kan du snygga upp koden?
            var c = new Cat
            {
                Name = "Misse",
                Owner = "Jonas",
                Email = "Jonas@catlover.dk",
                PhoneNumber = "+452332232"
            };
            var d = new Dog
            {
                Name = "Vovven",
                Owner = "Linda",
                Email = "Linda@outlook.com",
                PhoneNumber = "+4619374629"
            };

            var c2 = new Cat { Name = "Mr Meow", Owner = "Marcus", Email = "hello@marcusmedina.pro", PhoneNumber = "+46001001002" };
            var d2 = new Dog { Name = "Doggidogg", Owner = "Donny", Email = "donny@yahoo.com", PhoneNumber = "+462256984" };

            var catPos = 2;
            var result = catPos switch
            {
                1 => "Cat is #1",
                2 => "Second cat",
                _ => "Cat sux",
            };

            Console.WriteLine(result);

            // Kan man göra detta snyggare?
            Filemanager.SaveCat(c);
            Filemanager.SaveDog(d);
            Filemanager.SaveCat(c2);
            Filemanager.SaveDog(d2);

            // Kan detta skötas på ett bättre sätt?
            // Testar att läsa in filerna

            Console.WriteLine(Filemanager.LoadCat("Misse").Name);
            Console.WriteLine(Filemanager.LoadDog("Vovven").Name);
            Console.WriteLine(Filemanager.LoadCat("MrMeow").Name);
            Console.WriteLine(Filemanager.LoadDog("Doggidogg").Name);

            // Kan denna lista optimeras?
            Console.WriteLine();
            Console.WriteLine("Filer");
            Filemanager.GetCatList()
                .ToList()
                .ForEach(c => Console.WriteLine("Cat :" + c));

            foreach (var dog in Filemanager.GetDogList())
            {
                Console.WriteLine("Dog :" + dog);
            }
        }

        public static void SayHello()
        {
            string msg = "Hello";
            Console.WriteLine(msg);
        }
    }

    internal class Dog
    {
        public string Name { get; set; } // Name
        public string Owner { get; set; } // Owner's name
        public string PhoneNumber { get; set; } // PhoneNumber
        public string Email { get; set; } // Email
    }

    internal class Cat
    {
        public string Name { get; set; } // Name
        public string Owner { get; set; } // Owner's name
        public string PhoneNumber { get; set; } // PhoneNumber
        public string Email { get; set; } // Email
    }
}