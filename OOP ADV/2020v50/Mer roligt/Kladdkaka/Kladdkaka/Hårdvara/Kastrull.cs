namespace Recept.Hårdvara
{
    using Recept.Ingredienser;

    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Threading;

    /// <summary>
    /// Detta är en kastrull.
    /// </summary>
    public class Kastrull : Verktyg
    {
        /// <summary>
        /// Definition av på Plattan..
        /// </summary>
        private bool påPlattan = false;

        /// <summary>
        // Initialiserar en ny instans av <see cref="Kastrull"/> class.
        /// </summary>
        public Kastrull()
        {
            Ingredienser.CollectionChanged += Ingredienser_CollectionChanged;
        }

        /// <summary>
        /// Gets or sets the Ingredienser
        /// Egenskap av Ingredienser..
        /// </summary>
        public ObservableCollection<Ingrediens> Ingredienser { get; set; } = new ObservableCollection<Ingrediens>();

        /// <summary>
        /// Gets or sets a value indicating whether PåPlattan
        /// Egenskap av typen sant eller falskt för På Plattan..
        /// </summary>
        public bool PåPlattan { get => påPlattan; set => PositionPåPlattan(value); }

        /// <summary>
        /// Här deklareras Rör Om Ingredienser.
        /// </summary>
        internal void RörOmIngredienser()
        {
            Console.WriteLine("Rör om");
            for (int i = Ingredienser.Count - 1; i >= 0; i--)
            {
                Ingrediens ingrediens = Ingredienser[i];
                Ingredienser.Remove(ingrediens);
            }

            Ingredienser.Add(new Ingrediensröra());
            Console.WriteLine("Allt är en röra nu");
        }

        /// <summary>
        /// Här deklareras Ta Bort Från Platta.
        /// </summary>
        internal void TaBortFrånPlatta()
        {
            PåPlattan = false;
        }

        /// <summary>
        /// Här deklareras Värm Upp Till.
        /// </summary>
        /// <param name="grader"> Ett objekt med benämningen grader<see cref="double"/>.</param>
        internal void VärmUppTill(double grader)
        {
            PåPlattan = true;
            SättVärme(grader);
            Thread.Sleep(5 * 1000);
            foreach (Ingrediens ingrediens in Ingredienser)
            {
                if (ingrediens is Smör smör)
                {
                    smör.Tillstånd = Smörtillstånd.Flytande;
                }
            }
        }

        /// <summary>
        /// Här deklareras Ingredienser_CollectionChanged.
        /// </summary>
        /// <param name="sender"> Ett objekt med benämningen sender<see cref="object"/>.</param>
        /// <param name="e"> Ett objekt med benämningen e<see cref="NotifyCollectionChangedEventArgs"/>.</param>
        private void Ingredienser_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    if (!(item is Ingrediensröra))
                    {
                        Console.WriteLine("La till " + item.GetType().Name + " i grytan");
                    }
                }
            }
        }

        /// <summary>
        /// Här deklareras Position På Plattan.
        /// </summary>
        /// <param name="value"> Ett objekt med benämningen value<see cref="bool"/>.</param>
        private void PositionPåPlattan(bool value)
        {
            påPlattan = value;
            Console.WriteLine($"{GetType().Name} är {(!påPlattan ? "inte" : "")}på plattan");
        }
    }
}
