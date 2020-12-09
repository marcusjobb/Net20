namespace Recept.Ingredienser
{
    using System;

    /// <summary>
    /// Definition av <see cref="Socker" />.
    /// </summary>
    public class Socker : Ingrediens
    {
        /// <summary>
        /// Här deklareras StröPå.
        /// </summary>
        /// <param name="kaka"> Ett objekt med benämningen kaka<see cref="Kladdkaka"/>.</param>
        public void StröPå(Kladdkaka kaka)
        {
            Console.WriteLine($"Strör {GetType().Name} över {kaka.GetType().Name}");
        }
    }
}
