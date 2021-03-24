using System;
using System.Collections.Generic;
using System.Text;

namespace DoorWay
{
    //TODO:Change Apartment_id type to int and.
    public class Apartment
    {
        public string Apartment_id { get; set; }
        public string Apartment_name { get; set; }
        public Apartment(string Apartment_id, string Apartment_name)
        {
            this.Apartment_id = Apartment_id;
            this.Apartment_name = Apartment_name;
        }
        //Test-1-serch query.
          /*SELECT * 
          FROM husrum_fastigheter.tenants 
          join husrum_fastigheter.apartments 
          on husrum_fastigheter.tenants.apartment_id = husrum_fastigheter.apartments.apartment_id*/

        
        static Apartment Apartment1 = new Apartment("'0101'","''");
        static Apartment Apartment2 = new Apartment("'0102'","''");
        static Apartment Apartment3 = new Apartment("'0103'","''");
        static Apartment Apartment4 = new Apartment("'0201'","''");
        static Apartment Apartment5 = new Apartment("'0202'","''");
        static Apartment Apartment6 = new Apartment("'0301'","''");
        static Apartment Apartment7 = new Apartment("'0302'","''");
        static Apartment Apartment8 = new Apartment("'VAKT'","''");
        public static void addData()
        {
            List<Apartment> apartments = new List<Apartment>();
            apartments.Add(Apartment1);
            apartments.Add(Apartment2);
            apartments.Add(Apartment3);
            apartments.Add(Apartment4);
            apartments.Add(Apartment5);
            apartments.Add(Apartment6);
            apartments.Add(Apartment7);
            apartments.Add(Apartment8);

            DatabaseCommunication.AddApartment(apartments);
        }
    }
}