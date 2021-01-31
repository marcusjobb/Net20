using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseUppg1Albin
{
    class StringCollection
    {
        public static string caseDoor =
            @"SELECT Events.ID, Events.Time, Codes.Code, Tags.Tag, Actions.Action, Doors.Door, Doors.Explaination, Tenants.Name
            FROM Events
            INNER JOIN Tags ON Events.IDTag = Tags.ID
            INNER JOIN Tenants ON Events.IDTag = Tenants.IDTag
            INNER JOIN Actions ON Events.IDAction = Actions.ID
            INNER JOIN Doors ON Events.IDDoor = Doors.ID
            INNER JOIN Codes ON Events.IDCode = Codes.ID
            WHERE Doors.Door LIKE @input
            ORDER BY Events.Time DESC
            Limit @limit";

        public static string caseEvent =
            @"SELECT Events.ID, Events.Time, Codes.Code, Tags.Tag, Actions.Action, Doors.Door, Doors.Explaination, Tenants.Name
            FROM Events
            INNER JOIN Tags ON Events.IDTag = Tags.ID
            INNER JOIN Tenants ON Events.IDTag = Tenants.IDTag
            INNER JOIN Actions ON Events.IDAction = Actions.ID
            INNER JOIN Doors ON Events.IDDoor = Doors.ID
            INNER JOIN Codes ON Events.IDCode = Codes.ID
            WHERE Codes.Code LIKE @input
            ORDER BY Events.Time DESC
            Limit @limit";

        public static string caseTag =
            @"SELECT Events.ID, Events.Time, Codes.Code, Tags.Tag, Actions.Action, Doors.Door, Doors.Explaination, Tenants.Name
            FROM Events
            INNER JOIN Tags ON Events.IDTag = Tags.ID
            INNER JOIN Tenants ON Events.IDTag = Tenants.IDTag
            INNER JOIN Actions ON Events.IDAction = Actions.ID
            INNER JOIN Doors ON Events.IDDoor = Doors.ID
            INNER JOIN Codes ON Events.IDCode = Codes.ID
            WHERE Tags.Tag LIKE @input
            ORDER BY Events.Time DESC
            Limit @limit";

        public static string caseTenant =
            @"SELECT Events.ID, Events.Time, Codes.Code, Tags.Tag, Actions.Action, Doors.Door, Doors.Explaination, Tenants.Name
            FROM Events
            INNER JOIN Tags ON Events.IDTag = Tags.ID
            INNER JOIN Tenants ON Events.IDTag = Tenants.IDTag
            INNER JOIN Actions ON Events.IDAction = Actions.ID
            INNER JOIN Doors ON Events.IDDoor = Doors.ID
            INNER JOIN Codes ON Events.IDCode = Codes.ID
            WHERE Tenants.Name LIKE @input
            ORDER BY Events.Time DESC
            Limit @limit";

        public static string caseTenantsAt =
            @"SELECT Tags.Tag, Apartments.Apartmentnumber, Tenants.Name
            FROM Tenants
            INNER JOIN Tags ON Tenants.IDTag = Tags.ID
            INNER JOIN Apartments ON Tenants.IDApartment = Apartments.ID
            WHERE Apartments.Apartmentnumber LIKE @input
            Limit @limit";

        public static string caseLogEntry =
            @"INSERT INTO Events (""Time"", ""IDTag"",""IDAction"",""IDDoor"",""IDCode"") VALUES (@Time, @IDTag, @IDAction, @IDDoor, @IDCode)";

    }
}