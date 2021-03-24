namespace Recept.Ingredienser
{
    using System;

    /// <summary>
    /// Definition av <see cref="Smör" />.
    /// </summary>
    public class Smör : Ingrediens
    {
        /// <summary>
        /// Definition av tillstånd..
        /// </summary>
        private Smörtillstånd tillstånd = Smörtillstånd.Fast;

        /// <summary>
        /// Gets or sets the Tillstånd
        /// Egenskap av Tillstånd..
        /// </summary>
        public Smörtillstånd Tillstånd { get => tillstånd; set => SättTillstånd(value); }

        /// <summary>
        /// The SättTillstånd.
        /// </summary>
        /// <param name="value">The value<see cref="Smörtillstånd"/>.</param>
        private void SättTillstånd(Smörtillstånd value)
        {
            tillstånd = value;
            Console.WriteLine($"Smöret är nu i {tillstånd} tillstånd");
        }
    }
}
