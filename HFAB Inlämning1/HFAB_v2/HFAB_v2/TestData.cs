using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SQLite;

namespace HFAB_v2
{
    class TestData
    {
        public TestData()
        { }

        public static void GenerateTestData()
        {
            //Creates new object of StaticData and Random
            StaticData data = new StaticData();
            Random rand = new Random();
            DoorEventsLog log = new DoorEventsLog();

            //Sets random number
            int hour = rand.Next(10, 13);
            int min = rand.Next(0, 59);
            int sec = rand.Next(0, 59);

            //Randomizes a new time within 4 hours for test purposes
            string date = $"2020-10-31 {hour}:{min:00}:{sec:00}";

            //Sets random numbers for array-index 
            string tag = data.TagArray[rand.Next(0, data.TagArray.Length)];
            string eventCode = data.EventArray[rand.Next(0, data.EventArray.Length)];
            string door = data.DoorArray[rand.Next(0, data.DoorArray.Length)];

            //Sends log info to LogEntry table
            log.LogEntry(date, door, eventCode, tag);
        }
    }
}
