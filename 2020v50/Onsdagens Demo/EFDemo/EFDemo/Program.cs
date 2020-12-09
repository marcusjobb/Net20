namespace EFDemo
{
    using EFDemo.Database;

    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            using (var filmsamling = new FilmLista())
            {
                var film = filmsamling.Filmer.FirstOrDefault(_ => _.EngTitel == "Elf");
                if (film!=null)
                {
                    filmsamling.Remove(film);
                    filmsamling.SaveChanges();
                }
            }
        }
    }
}
