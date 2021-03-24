using System;
using System.Collections.Generic;
using System.Text;

namespace DoorWay
{
    public class Tagg
    {
        public string tagg_id { get; set; }
        public Tagg(string tagg_id)
        {
            this.tagg_id = tagg_id;
        }
        static Tagg Tagg1 = new Tagg("'0101A'");
        static Tagg Tagg2 = new Tagg("'0102A'");
        static Tagg Tagg3 = new Tagg("'0102B'");
        static Tagg Tagg4 = new Tagg("'0103A'");
        static Tagg Tagg5 = new Tagg("'0103B'");
        static Tagg Tagg6 = new Tagg("'0201A'");
        static Tagg Tagg7 = new Tagg("'0201B'");
        static Tagg Tagg8 = new Tagg("'0201C'");
        static Tagg Tagg9 = new Tagg("'0201D'");
        static Tagg Tagg10 = new Tagg("'0202A'");
        static Tagg Tagg11 = new Tagg("'0202B'");
        static Tagg Tagg12 = new Tagg("'0202C'");
        static Tagg Tagg13 = new Tagg("'0301A'");
        static Tagg Tagg14 = new Tagg("'0301B'");
        static Tagg Tagg15 = new Tagg("'0301C'");
        static Tagg Tagg16 = new Tagg("'0301D'");
        static Tagg Tagg17 = new Tagg("'0302A'");
        static Tagg Tagg18 = new Tagg("'0302B'");
        static Tagg Tagg19 = new Tagg("'0302C'");
        static Tagg Tagg20 = new Tagg("'0302D'");
        static Tagg Tagg21 = new Tagg("'VAKET01'");
        /// <summary>
        /// Adds the tagg data to the list.
        /// </summary>
        public static void addData()
        {
            List<Tagg> taggs = new List<Tagg>();
            taggs.Add(Tagg1);
            taggs.Add(Tagg2);
            taggs.Add(Tagg3);
            taggs.Add(Tagg4);
            taggs.Add(Tagg5);
            taggs.Add(Tagg6);
            taggs.Add(Tagg7);
            taggs.Add(Tagg8);
            taggs.Add(Tagg9);
            taggs.Add(Tagg10);
            taggs.Add(Tagg11);
            taggs.Add(Tagg12);
            taggs.Add(Tagg13);
            taggs.Add(Tagg14);
            taggs.Add(Tagg15);
            taggs.Add(Tagg16);
            taggs.Add(Tagg17);
            taggs.Add(Tagg18);
            taggs.Add(Tagg19);
            taggs.Add(Tagg20);
            taggs.Add(Tagg21);
            
            DatabaseCommunication.AddTaggs(taggs);
            
        }
    }

}
