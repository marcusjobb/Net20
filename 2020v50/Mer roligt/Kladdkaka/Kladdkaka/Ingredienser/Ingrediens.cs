namespace Recept.Ingredienser
{
    using System;

    /// <summary>
    /// Definition av <see cref="Ingrediens" />.
    /// </summary>
    public class Ingrediens
    {
        /// <summary>
        /// Gets or sets a value indicating whether Chansa
        /// Egenskap av typen sant eller falskt för Chansa..
        /// </summary>
        public bool Chansa { get; set; } = false;

        /// <summary>
        /// Gets or sets the Mängd
        /// Egenskap av Mängd..
        /// </summary>
        public double Mängd { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Måttenhet
        /// Egenskap av Måttenhet..
        /// </summary>
        public string Måttenhet { get; set; } = "mg";

        /// <summary>
        /// Här deklareras Hämta.
        /// </summary>
        public void Hämta()
        {
            Console.WriteLine($"Hämtade {GetType().Name}, {Mängd} {Måttenhet} ");
        }
    }
}
