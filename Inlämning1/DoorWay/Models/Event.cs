using System;
using System.Collections.Generic;
using System.Text;

namespace DoorWay
{
    public class Event
    {
        public string Event_cod { get; set; }
        public string Date_of_Events { get; set; }
        public string Door_id { get; set; }
        public string Tagg_id { get; set; }
        public string Events_description { get; set; }
        public Event(string Event_cod, string Date_of_Events, string Door_id, string Tagg_id, string Events_description)
        {
            this.Event_cod = Event_cod;
            this.Date_of_Events = Date_of_Events;
            this.Door_id = Door_id;
            this.Tagg_id = Tagg_id;
            this.Events_description = Events_description;
        }
        //-Datum och tid,  Dörrkod, händelsekod, Personens tagg, Personens namn och textbeskrivning
        //-2020-10-23 10:23, LGH0301, DÖIN, 0301A, Ella Ahlström Öppnade dörr till lägenhet 0301 inifrån

        static Event event1 = new Event("'DÖUT'","'2012-12-12'", "'LGH'", "'0101A'", "''");
        static Event event2 = new Event("'DÖUT'","'2013-12-11'", "'TVÄTT'", "'0102A'", "''");
        static Event event3 = new Event("'DÖUT'","'2014-12-11'", "'UT'", "'0102A'", "''");
        static Event event4 = new Event("'DÖUT'","'2015-12-11'", "'SOPRUM'", "'0102A'", "''");
        static Event event5 = new Event("'DÖIN'","'2016-12-11'", "'LGH'", "'0102A'", "' '");
        static Event event6 = new Event("'DÖUT'","'2017-12-11'", "'LGH'", "'0202A'", "' '");
        static Event event7 = new Event("'FDUT'","'2018-12-11'", "'BLK'", "'0102A'","''");
        static Event event8 = new Event("'DÖIN'","'2019-12-11'", "'BLK'", "'0201A'","''");
        static Event event9 = new Event("'DÖUT'","'2010-12-11'", "'SOPRUM'", "'0103A'","''");
        static Event event10 = new Event("'FDUT'","'2020-12-11'", "'LGH'", "'0102A'", "''");
        static Event event11 = new Event("'FDUT'","'2012-12-11'", "'LGH'", "'0202A'", "''");
        static Event event12= new Event("'FDUT'","'2020-12-11'", "'LGH'", "'0302A'", "' '");
        static Event event13 = new Event("'FDUT'","'2020-12-11'", "'LGH'", "'0102B'","''");
        static Event event14 = new Event("'DÖUT'", "'2012-12-12'", "'LGH'", "'0101A'", "''");
        static Event event15 = new Event("'DÖUT'", "'2013-12-11'", "'TVÄTT'", "'0102A'", "''");
        static Event event16= new Event("'DÖUT'", "'2014-12-11'", "'UT'", "'0102A'", "''");
        static Event event17= new Event("'DÖUT'", "'2015-12-11'", "'SOPRUM'", "'0102A'", "' '");
        static Event event18 = new Event("'DÖIN'", "'2016-12-11'", "'LGH'", "'0102A'", "''");
        static Event event19 = new Event("'DÖUT'", "'2017-12-11'", "'LGH'", "'0202A'", "''");
        static Event event20 = new Event("'FDUT'","'2019-12-13'", "'LGH'", "'0102A'", "''");
        
        /// <summary>
        /// Adds the data.
        /// </summary>
        public static void addData()
        {
            List<Event> events = new List<Event>();
            events.Add(event1);
            events.Add(event2);
            events.Add(event3);
            events.Add(event4);
            events.Add(event5);
            events.Add(event6);
            events.Add(event7);
            events.Add(event8);
            events.Add(event9);
            events.Add(event10);
            events.Add(event11);
            events.Add(event12);
            events.Add(event13);
            events.Add(event14);
            events.Add(event15);
            events.Add(event16);
            events.Add(event17);
            events.Add(event18);
            events.Add(event19);
            events.Add(event20);


            DatabaseCommunication.AddEvent(events);
        }
    }
}