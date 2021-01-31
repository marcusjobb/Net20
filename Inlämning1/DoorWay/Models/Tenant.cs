using System;
using System.Collections.Generic;


namespace DoorWay
{
    public class Tenant
    {
        
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Tagg_id { get; set; }
        public string Apartment_id { get; set; }
        public Tenant( string first_name, string last_name, string tagg_id, string apartment_id)
        {
            
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Tagg_id = tagg_id;
            this.Apartment_id = apartment_id;
        }

        static Tenant Tenant1 = new Tenant("'Liam'", "'Jönsson'", "'0101A'", "'0101'");
        static Tenant Tenant2 = new Tenant("'Elias'", "'Petersson'", "'0102A'", "'0102'");
        static Tenant Tenant3 = new Tenant("'Wilma'", "'Johansson'", "'0102B'", "'0102'");
        static Tenant Tenant4 = new Tenant("'Alicia'", "'Sanchez'", "'0103A'", "'0103'");
        static Tenant Tenant5 = new Tenant("'Aaron'", "'Sanchez'", "'0103B'", "'0103'");
        static Tenant Tenant6 = new Tenant("'Olivia'", "'Erlander'", "'0201A'", "'0201'");
        static Tenant Tenant7 = new Tenant("'William'", "'Erlander'", "'0201B'", "'0201'");
        static Tenant Tenant8 = new Tenant("'Alexander'", "'Erlander'", "'0201C'", "'0201'");
        static Tenant Tenant9 = new Tenant("'Astrid'", "'Erlander'", "'0201D'", "'0201'");
        static Tenant Tenant10 = new Tenant("'Lucas'", "'Adolfsson'", "'0202A'", "'0202'");
        static Tenant Tenant11 = new Tenant("'Ebba'", "'Adolfsson'", "'0202B'", "'0202'");
        static Tenant Tenant12 = new Tenant("'Lilly'", "'Adolfsson'", "'0202C'", "'0202'");
        static Tenant Tenant13 = new Tenant("'Ella'", "'Ahlström'", "'0301A'", "'0301'");
        static Tenant Tenant14 = new Tenant("'Alma'", "'Alfredsson'", "'0301B'", "'0301'");
        static Tenant Tenant15 = new Tenant("'Elsa'", "'Ahlaström'", "'0301C'", "'0301'");
        static Tenant Tenant16 = new Tenant("'Maja'", "'Ahlaström'", "'0301D'", "'0301'");
        static Tenant Tenant17 = new Tenant("'Noah'", "'Almgren'", "'0302A'", "'0302'");
        static Tenant Tenant18 = new Tenant("'Adam'", "'Andersson'", "'0302B'", "'0302'");
        static Tenant Tenant19 = new Tenant("'Kattis'", "'Backman'", "'0302C'", "'0302'");
        static Tenant Tenant20 = new Tenant("'Oscar'", "'Chen'", "'0302D'", "'0302'");
        static Tenant Tenant21 = new Tenant("'Vaktmästare'", "'NULL'", "'VAKET01'", "'vakt'");
        /// <summary>
        /// Adds the data to list.
        /// </summary>
        public static void addData()
        {
            List<Tenant> tenants = new List<Tenant>();
            tenants.Add(Tenant1);
            tenants.Add(Tenant2);
            tenants.Add(Tenant3);
            tenants.Add(Tenant4);
            tenants.Add(Tenant5);
            tenants.Add(Tenant6);
            tenants.Add(Tenant7);
            tenants.Add(Tenant8);
            tenants.Add(Tenant9);
            tenants.Add(Tenant10);
            tenants.Add(Tenant11);
            tenants.Add(Tenant12);
            tenants.Add(Tenant13);
            tenants.Add(Tenant14);
            tenants.Add(Tenant15);           
            tenants.Add(Tenant16);
            tenants.Add(Tenant17);
            tenants.Add(Tenant18);
            tenants.Add(Tenant19);
            tenants.Add(Tenant20);
            tenants.Add(Tenant21);
            DatabaseCommunication.AddTenants(tenants);
        }
    }
}
