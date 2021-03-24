namespace Assignment_1_Architecture
{
    internal static class GettingID
    {
        public static long GettingDateID(string gettingDate)
        {
            // Definierar SQL sökningen
            const string sql = "SELECT ID FROM Dates WHERE Date LIKE @date";

            // Söker efter datumet
            var dt = DBHandler.GetDataTable(sql, "@date", gettingDate);

            // Kontrollerar om datumet finns
            if (dt != null && dt.Rows.Count > 0)
            {
                // Returnerar ID på datumet
                return (long)dt.Rows[0]["ID"];
            }
            else
            {
                // ID finns ej, skapar ett och returnerar ID
                return DBHelper.InsertDate(gettingDate);
            }
        }

        public static long GettingDoorID(string gettingDoor)
        {
            // Definierar SQL sökningen
            const string sql = "SELECT ID FROM Doors WHERE Door LIKE @door";

            // Söker efter dörren
            var dt = DBHandler.GetDataTable(sql, "@door", gettingDoor);

            // Kontrollerar om dörren finns
            if (dt != null && dt.Rows.Count > 0)
            {
                // Returnerar ID på dörren
                return (long)dt.Rows[0]["ID"];
            }
            else
            {
                // ID finns ej, skapar ett och returnerar ID
                return DBHelper.InsertDoor(gettingDoor);
            }
        }

        public static long GettingEventID(string gettingEvent)
        {
            // Definierar SQL sökningen
            const string sql = "SELECT ID FROM DoorCodes WHERE DoorCode LIKE @doorcode";

            // Söker efter dörrkoden
            var dt = DBHandler.GetDataTable(sql, "@doorcode", gettingEvent);

            // Kontrollerar om dörrkoden finns
            if (dt != null && dt.Rows.Count > 0)
            {
                // Returnerar ID på dörrkoden
                return (long)dt.Rows[0]["ID"];
            }
            else
            {
                // ID finns ej, skapar ett och returnerar ID
                return DBHelper.InsertDoorCode(gettingEvent);
            }
        }

        public static long GettingLocationID(string gettingLocation)
        {
            // Definierar SQL sökningen
            const string sql = "SELECT ID FROM Doors WHERE Door LIKE @door";

            // Söker efter platsen
            var dt = DBHandler.GetDataTable(sql, "@door", gettingLocation);

            // Kontrollerar om lägenheten/rummet finns
            if (dt != null && dt.Rows.Count > 0)
            {
                // Returnerar ID på lägenheten/rummet
                return (long)dt.Rows[0]["ID"];
            }
            return 0;
        }

        public static long GettingTagID(string gettingTag)
        {
            // Definierar SQL sökningen
            const string sql = "SELECT ID FROM Tenants WHERE Tag LIKE @tag";

            // Söker efter taggen
            var dt = DBHandler.GetDataTable(sql, "@tag", gettingTag);

            // Kontrollerar om taggen finns
            if (dt != null && dt.Rows.Count > 0)
            {
                // Returnerar ID på taggen
                return (long)dt.Rows[0]["ID"];
            }
            return 0;
        }

        public static long GettingTenantID(string gettingTenant)
        {
            // Definierar SQL sökningen
            const string sql = "SELECT ID FROM Tenants WHERE Name LIKE @name";

            // Söker efter hyresgästen
            var dt = DBHandler.GetDataTable(sql, "@name", gettingTenant);

            // Kontrollerar om hyresgästen finns
            if (dt != null && dt.Rows.Count > 0)
            {
                // Returnerar ID på hyresgästen
                return (long)dt.Rows[0]["ID"];
            }
            else
            {
                return 0;
            }
        }
    }
}