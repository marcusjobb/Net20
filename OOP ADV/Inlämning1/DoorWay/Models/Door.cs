using System;
using System.Collections.Generic;
using System.Text;

namespace DoorWay
{
    public class Door
    {
        public string Door_id { get; set; }
        public string Door_name { get; set; }
        public string Door_Cod { get; set; }
        public Door(string Door_id)
        {
            this.Door_id = Door_id;
           
        }

        static Door door = new Door( "'LGH'");
        static Door door1 = new Door("'BLK'");
        static Door door2 = new Door("'SOPRUM'");
        static Door door3 = new Door("'UT'");
        static Door door4 = new Door("'SOPRUM2'");
        static Door door5 = new Door("'TVÄTT'");
        static Door door6 = new Door("'VAKT'");
        /// <summary>
        /// Adds the data.
        /// </summary>
        public static void addData()
        {
            List<Door> doors = new List<Door>();
            doors.Add(door);
            doors.Add(door1);
            doors.Add(door2);
            doors.Add(door3);
            doors.Add(door4);
            doors.Add(door5);
            doors.Add(door6);
            DatabaseCommunication.AddDoor(doors);
        }



    }
}