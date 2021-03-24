namespace MoqÖvning
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Ange ditt namn");
            var input = Console.ReadLine();
            Console.WriteLine("Ditt namn har " + input.Length + " bokstäver");


        }

        public void Controller()
        {
            var view = new View();
            view.ShowQuestion();
            var input = Console.ReadLine();
            view.ShowResult(input.Length);
        }


    }
}
