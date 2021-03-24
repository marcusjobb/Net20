namespace EventDemo
{
    using System;
    using System.Threading;

    /*
    Föst skapa en delegate som beskriver hur metoden som tar emot 
    notifikationen (event) ska se ut
    */
    public delegate void HasChanged(string aString);

class Person
{
    /*
    Sen deklarerar du ett event som med den delegate du skapat innan
    */
    public event HasChanged NameChanged;
    private string name;
    private string oldName = "Nobody";

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            /*
                för att skicka en avisering (event), kolla först om någon metod prenumererar
                på den, antingen via 
                if (NameChanged!=null) NameChanged.Invoce("Tralala");
                eller använd ? som i exemplet nedan.
            */
            NameChanged?.Invoke($"{Name} was changed from {oldName}");
            oldName = value;
        }
    }
}

    class Program
    {
        static void Main()
        {
            var p = new Person();
            /*
            Prenumerera på eventet genom att välja namnet på den i objektets properties
            och skriva += och namnet på metoden som ska ta emot eventet, tänk på att 
            metoden måste matcha din delegate.
            */
            p.NameChanged += PropertyNameHasChanged;
            p.Name = "Marcus";
            p.Name = "Erik";
            p.Name = "Johan";
        }

        /*
            Exempel på metod som matchar din delegate
            Vilka parametrar som skickas med bestämmer du själv.
            Faktum är att det fungerar som ett vanligt metodanrop, så om
            du ändrar i parametrar som är byref (exempelvis objekt) så
            kommer de att ändras hos metoden som skickade eventet.
            Det kan vara bra att ha ibland.
        */
        private static void PropertyNameHasChanged(string name)
        {
            Console.WriteLine(name);
        }

    }
}
