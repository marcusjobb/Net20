namespace CleanUpThisCode
{
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    static class Filemanager
    {
        // Hämta lista på kattfiler
        public static string[] GetCatList() => Directory.EnumerateFiles(@".\", "*.Cat.*").ToArray();

        // Hämta lista på hund filer
        public static string[] GetDogList() => Directory.EnumerateFiles(@".\", "*.Dog.*").ToArray();

        // Läs in en katt
        public static Cat LoadCat(string name)
        {
            var fileName = GetFilename(name, nameof(Cat));
            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                return (Cat)JsonSerializer.Deserialize(jsonString, typeof(Cat));
            }
            return new Cat();
        }

        //Generera filnamn
        private static string GetFilename(string name, string breed) => name.Replace(" ", "") + "." + breed + ".json";

        // Läs in en hund
        public static Dog LoadDog(string name)
        {
            var fileName = GetFilename(name, nameof(Dog));
            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                return (Dog)JsonSerializer.Deserialize(jsonString, typeof(Dog));
            }
            return new Dog();
        }

        // Spara en katt
        public static void SaveCat(Cat cat)
        {
            var jsonString = JsonSerializer.Serialize(cat);
            var fileName = GetFilename(cat.N, nameof(Cat));
            File.WriteAllText(fileName, jsonString);
        }

        // Spara en hund
        public static void SaveDog(Dog dog)
        {
            var jsonString = JsonSerializer.Serialize(dog);
            var fileName = GetFilename(dog.N, nameof(Dog));
            File.WriteAllText(fileName, jsonString);
        }

    }
}
