namespace Recept.Hårdvara
{
    using System;

    /// <summary>
    /// Definition av <see cref="Verktyg" />.
    /// </summary>
    public class Verktyg
    {
        /// <summary>
        /// Gets or sets the Värme
        /// Egenskap av Värme..
        /// </summary>
        public double Värme { get; set; } = 0;

        /// <summary>
        /// Här deklareras SättVärme.
        /// </summary>
        /// <param name="värme"> Ett objekt av värme<see cref="double"/>.</param>
        internal void SättVärme(double värme)
        {
            Värme = värme;
            Console.WriteLine($"{GetType().Name} på {värme} grader");
        }
    }
}
