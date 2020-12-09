namespace Recept.Ingredienser
{
    using System;

    /// <summary>
    /// Definition av <see cref="Ägg" />.
    /// </summary>
    public class Ägg : Ingrediens
    {
        /// <summary>
        /// Här deklareras KnäckÄgg.
        /// </summary>
        /// <returns> Ett objekt med benämningen <see cref="Ingrediens"/>.</returns>
        internal Ingrediens KnäckÄgg()
        {
            if (Mängd > 1)
            {
                for (int i = 0; i < Mängd; i++)
                {
                    Console.WriteLine("Knäcker ägg");
                }
                return new KnäcktaÄgg();
            }
            else
            {
                Console.WriteLine("Knäcker ägget");
                return new KnäcktÄgg();
            }
        }
    }
}
