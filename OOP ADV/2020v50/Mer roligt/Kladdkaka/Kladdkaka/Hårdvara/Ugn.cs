namespace Recept.Hårdvara
{
    using Recept.Ingredienser;

    using System;
    using System.Threading;

    /// <summary>
    /// Definition av <see cref="Ugn" />.
    /// </summary>
    public class Ugn : Verktyg
    {
        /// <summary>
        /// Här deklareras Grädda.
        /// </summary>
        /// <param name="ugnsformen"> Ett objekt med benämningen ugnsformen<see cref="Ugnsform"/>.</param>
        /// <param name="minuter"> Ett objekt med benämningen minuter<see cref="int"/>.</param>
        internal void Grädda(Ugnsform ugnsformen, int minuter)
        {
            for (int i = 1; i <= minuter; i++)
            {
                Console.WriteLine($"{minuter - i} minuter kvar");
                Thread.Sleep(500);
            }
            ugnsformen.Smet.Clear();
            ugnsformen.Kaka.Add(new Färdigkaka());
        }

        /// <summary>
        /// Här deklareras Ta Ut Kakan.
        /// </summary>
        internal void TaUtKakan()
        {
            Console.WriteLine("Det luktar mums!");
        }
    }
}
