namespace Recept.Hårdvara
{
    using Recept.Ingredienser;

    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    /// <summary>
    /// Definition av <see cref="Ugnsform" />.
    /// </summary>
    public class Ugnsform : Verktyg
    {
        /// <summary>
        // Initialiserar en ny instans av <see cref="Ugnsform"/> class.
        /// </summary>
        public Ugnsform()
        {
            Smet.CollectionChanged += Smet_CollectionChanged;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Bröad
        /// Egenskap av typen sant eller falskt för Bröad..
        /// </summary>
        public bool Bröad { get; internal set; } = false;

        /// <summary>
        /// Gets or sets the Kaka
        /// Egenskap av Kaka..
        /// </summary>
        public ObservableCollection<Ingrediens> Kaka { get; set; } = new ObservableCollection<Ingrediens>();

        /// <summary>
        /// Gets or sets the Smet
        /// Egenskap av Smet..
        /// </summary>
        public ObservableCollection<Ingrediens> Smet { get; set; } = new ObservableCollection<Ingrediens>();

        /// <summary>
        /// Gets or sets a value indicating whether Smord
        /// Egenskap av typen sant eller falskt för Smord..
        /// </summary>
        public bool Smord { get; internal set; } = false;

        /// <summary>
        /// Här deklareras BröaFormen.
        /// </summary>
        public void BröaFormen()
        {
            if (!Smord)
            {
                Console.WriteLine("Brödet fastnar inte");
            }
            else
            {
                Bröad = true;
                Console.WriteLine("Formen är bröad");
            }
        }

        /// <summary>
        /// Här deklareras SmörjFormen.
        /// </summary>
        public void SmörjFormen()
        {
            if (Bröad)
            {
                Console.WriteLine("Kan inte smörja formed, det är ströbröd i vägen");
            }
            else
            {
                Console.WriteLine("Formen är insmörad");
                Smord = true;
            }
        }

        /// <summary>
        /// Här deklareras HällSmetFrån.
        /// </summary>
        /// <param name="kastrullen"> Ett objekt av kastrullen<see cref="Kastrull"/>.</param>
        internal void HällSmetFrån(Kastrull kastrullen)
        {
            for (int i = kastrullen.Ingredienser.Count - 1; i >= 0; i--)
            {
                Ingrediens ingrediens = kastrullen.Ingredienser[i];
                Smet.Add(ingrediens);
                kastrullen.Ingredienser.Remove(ingrediens);
            }
            kastrullen.Ingredienser.Clear();
        }

        /// <summary>
        /// Här deklareras Smet_CollectionChanged.
        /// </summary>
        /// <param name="sender"> Ett objekt av sender<see cref="object"/>.</param>
        /// <param name="e"> Ett objekt av e<see cref="NotifyCollectionChangedEventArgs"/>.</param>
        private void Smet_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    Console.WriteLine("La till " + item.GetType().Name + " i " + GetType().Name);
                }
            }
        }
    }
}
