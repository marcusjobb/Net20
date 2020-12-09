namespace Recept
{
    using Recept.Hårdvara;
    using Recept.Ingredienser;

    using System;
    using System.Threading;

    /// <summary>
    /// Inspiration från
    ///  https://www.arla.se/recept/kladdkaka/.
    /// </summary>
    public class Kladdkaka
    {
        /// <summary>
        /// Definition av Ägg..
        /// </summary>
        private readonly Ägg Ägg = new Ägg { Mängd = 2, Måttenhet = "st" };

        /// <summary>
        /// Definition av Florsocker..
        /// </summary>
        private readonly Florsocker Florsocker = new Florsocker { Mängd = 0, Måttenhet = "", Chansa = true };

        /// <summary>
        /// Definition av Kakao..
        /// </summary>
        private readonly Kakao Kakao = new Kakao { Mängd = 3, Måttenhet = "msk" };

        /// <summary>
        /// Definition av Kastrull..
        /// </summary>
        private readonly Kastrull Kastrullen = new Kastrull();

        /// <summary>
        /// Definition av Smör..
        /// </summary>
        private readonly Smör Smör = new Smör { Mängd = 100, Måttenhet = "g" };

        /// <summary>
        /// Definition av Strösocker..
        /// </summary>
        private readonly Strösocker Strösocker = new Strösocker { Mängd = 2.5, Måttenhet = "dl" };

        /// <summary>
        /// Definition av Ugnen..
        /// </summary>
        private readonly Ugn Ugnen = new Ugn();

        /// <summary>
        /// Definition av Ugnsform..
        /// </summary>
        private readonly Ugnsform Ugnsformen = new Ugnsform();

        /// <summary>
        /// Definition av Vaniljsocker..
        /// </summary>
        private readonly Vaniljsocker Vaniljsocker = new Vaniljsocker { Mängd = 1, Måttenhet = "tsk" };

        /// <summary>
        /// Definition av Vetemjöl..
        /// </summary>
        private readonly Vetemjöl Vetemjöl = new Vetemjöl { Mängd = 1, Måttenhet = "dl" };

        /// <summary>
        /// Bakning av Kladdkakan.
        /// </summary>
        public void Baka()
        {
            Smör.Hämta();
            Strösocker.Hämta();
            Ägg.Hämta();
            Vetemjöl.Hämta();
            Kakao.Hämta();
            Vaniljsocker.Hämta();
            Florsocker.Hämta();

            Thread.Sleep(5 * 1000);
            Console.WriteLine();

            Ugnen.SättVärme(195);
            Kastrullen.Ingredienser.Add(Smör);
            Kastrullen.VärmUppTill(40);
            Kastrullen.TaBortFrånPlatta();
            Kastrullen.Ingredienser.Add(Strösocker);
            Kastrullen.Ingredienser.Add(Ägg?.KnäckÄgg());
            Kastrullen.RörOmIngredienser();
            Kastrullen.Ingredienser.Add(Vetemjöl);
            Kastrullen.Ingredienser.Add(Kakao);
            Kastrullen.Ingredienser.Add(Vaniljsocker);
            Kastrullen.RörOmIngredienser();
            Ugnsformen.SmörjFormen();
            Ugnsformen.BröaFormen();
            Ugnsformen.HällSmetFrån(Kastrullen);
            Ugnen.Grädda(Ugnsformen, 15);
            Ugnen.TaUtKakan();
            Florsocker?.StröPå(this);
            Thread.Sleep(5 * 1000);
            ServeraMed(new Vispgrädde());
        }

        /// <summary>
        /// Här deklareras Servera Med metoden.
        /// </summary>
        /// <param name="klet"> Ett objekt med benämningen klet<see cref="Vispgrädde"/>.</param>
        private void ServeraMed(Vispgrädde klet)
        {
            Console.WriteLine($"Mums med {klet.GetType().Name} på");
            Console.WriteLine(@"

               .-----------.___
          .-----,~~~~~~~~~~,,,,'---.
        -,,~~'-'                ~~~~~._
    .---~                             ,'.
   /,'-'                               ~,\
  / ;                       ____________;_)
  | ;                      `'-._          |
  | ;                           '-._      |
  |\ ~,,,                      ,,,,,'-____|
  | '-._ ~~,,,            ,,,~~ __.-'~ |
  |     '-.__ ~~~~~~~~~~~~ __.-'       |
  |\         `'----------'`           _|
    '-._                         __.-'
        '-.__               __.-'
             `'-----------'`

Källa: https://asciiart.website/index.php?art=events/birthday
");
        }
    }
}
