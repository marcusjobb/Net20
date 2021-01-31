using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDB
{
    class SQLStrings
    {


        //Grundsträngen vi använder till våra sökningar för att plocka ut all information ur vår events-table med respektive koppling
        public static string sqlBase =
            @"SELECT Events.ID, Events.Time, Codes.Code, Tags.Tag, Actions.Action, Doors.Door, Doors.Explanation, Tenants.Name
            FROM Events
            INNER JOIN Tags ON Events.IDTag = Tags.ID
            INNER JOIN Tenants ON Events.IDTag = Tenants.IDTag
            INNER JOIN Actions ON Events.IDAction = Actions.ID
            INNER JOIN Doors ON Events.IDDoor = Doors.ID
            INNER JOIN Codes ON Events.IDCode = Codes.ID
            INNER JOIN Apartments ON Events.IDDoor = Apartments.IDDoor";
            

        //Strängen som söker på en specifik dörr
        public static string byDoor = " WHERE Doors.Door = @input";

         // strängen som söker efter en specifik "code"
        public static string byCode = " WHERE Codes.Code = @input";
         
        // strängen som söker efter en specifik plats
        public static string byLocation = " WHERE Apartments.Apartmentnumber = @input";

        // strängen som söker efter en specifik tagg
        public static string byTag = " WHERE Tags.Tag = @input";

        // strängen som söker efter en specifik boende
        public static string byTenant = " WHERE Tenants.Name = @input";

        //strängen som söker efter boende i en specifik lägenhet
        public static string tenantsAt = " WHERE Apartments.Apartmentnumber = @input";

        // strängen som sorterar och visar de 20 senaste posterna
        public static string orderBy = " Order by Time Desc limit 20";

        //strängen för input utav entry

        public static string sqlInput =
            @"INSERT INTO Events (IDTag, IDAction, IDDoor, IDCode)
            SELECT Tags.ID, Actions.ID, Doors.ID, Codes.ID
            FROM Tags
            CROSS JOIN Actions
            CROSS JOIN Doors
            CROSS JOIN Codes
            WHERE Tags.Tag = @Tag
            AND Actions.Action = @Action
            AND Doors.Door = @Door
            AND Codes.Code = @Code";
    }
}
