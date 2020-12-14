namespace CleanUpThisCode
{
    using System;

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

    static class Program
    {
        private static void Main()
        {
            //Kan du snygga upp koden?
            var c = new Cat { N = "Misse", O = "Jonas", E = "Jonas@catlover.dk", P = "+452332232" };
            var d = new Dog { N = "Vovven", O = "Linda", E = "Linda@outlook.com", P = "+4619374629" };

            var c2 = new Cat { N = "Mr Meow", O = "Marcus", E = "hello@marcusmedina.pro", P = "+46001001002" };
            var d2 = new Dog { N = "Doggidogg", O = "Donny", E = "donny@yahoo.com", P = "+462256984" };

            // Kan man göra detta snyggare?
            Filemanager.SaveCat(c);
            Filemanager.SaveDog(d);
            Filemanager.SaveCat(c2);
            Filemanager.SaveDog(d2);

            // Kan detta skötas på ett bättre sätt?
            // Testar att läsa in filerna
            Console.WriteLine(Filemanager.LoadCat("Misse").N);
            Console.WriteLine(Filemanager.LoadDog("Vovven").N);
            Console.WriteLine(Filemanager.LoadCat("MrMeow").N);
            Console.WriteLine(Filemanager.LoadDog("Doggidogg").N);

            // Kan denna lista optimeras?
            Console.WriteLine();
            Console.WriteLine("Filer");
            foreach (var cat in Filemanager.GetCatList())
            {
                Console.WriteLine("Cat :" + cat);
            }

            foreach (var dog in Filemanager.GetDogList())
            {
                Console.WriteLine("Dog :" + dog);
            }
        }
    }

    class Dog
    {
        // Är detta vettiga properties?
        public string N { get; set; } // Name
        public string O { get; set; } // Owner's name
        public string P { get; set; } // PhoneNumber
        public string E { get; set; } // Email
    }

    class Cat 
    {
        // Är detta vettiga properties?
        public string O { get; set; } // Owner's name
        public string P { get; set; } // PhoneNumber
        public string E { get; set; } // Email
        public string N { get; set; }
    }
}
