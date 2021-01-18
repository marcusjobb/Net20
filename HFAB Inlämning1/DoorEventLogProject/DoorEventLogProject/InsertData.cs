using System;
using System.Data.SQLite;

namespace DoorEventLogProject
{
    class InsertData
    {
        //Pre-recorded inputs to database for testing
        internal static void BuildingAndTenantData()
        {
            using var conn = new SQLiteConnection("data source=" + Settings.Database);
            conn.Open();

            string insert, table;

            SQLiteCommand cmd;

            table = "SELECT ID FROM TenantTable";
            var dt = Datatable.DataTable(table, "");
            if (dt.Rows.Count < 1)
            {
                insert = "INSERT INTO TenantTable(TenantTag,ApartmentNumber_ID,FirstName,LastName) " +
                         "VALUES('0101A','0','Liam','Jönsson'),('0102A','1','Elias','Petterson')," +
                               "('0102B','1','Wilma','Johansson'),('0103A','2','Alicia','Sanchez')," +
                               "('0103B','2','Aaron','Sanchez'),('0201A','3','Olivia','Erlander')," +
                               "('0201B','3','William','Erlander'),('0201C','3','Alexander','Erlander')," +
                               "('0201D','3','Astrid','Erlander'),('0202A','4','Lucas','Adolfsson')," +
                               "('0202B','4','Ebba','Adolfsson'),('0202C','4','Lilly','Adolfsson')," +
                               "('0301A','5','Ella','Ahlström'),('0301B','5','Alma','Alfredsson')," +
                               "('0301C','5','Elsa','Ahlström'),('0301D','5','Maja','Ahlström')," +
                               "('0302A','6','Noah','Almgren'),('0302B','6','Adam','Andersen')," +
                               "('0302C','6','Kattis','Backman'),('0302D','6','Oscar','Chen')," +
                               "('VAKT01','7','Vaktmästare','')";

                using (cmd = new SQLiteCommand(insert, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            table = "SELECT ID FROM DoorName";
            dt = Datatable.DataTable(table, "");
            if (dt.Rows.Count < 1)
            {
                insert = "INSERT INTO DoorName(DoorName) " +
                         "VALUES ('LGH0101'),('LGH0102')," +
                                "('LGH0103'),('LGH0201')," +
                                "('LGH0202'),('LGH0301')," +
                                "('LGH0302'),('VAKT')," +
                                "('SOPRUM'),('TVÄTT')," +
                                "('UT')";

                cmd = new SQLiteCommand(insert, conn);
                cmd.ExecuteNonQuery();
            }

            table = "SELECT ID FROM DoorEvent";
            dt = Datatable.DataTable(table, "");
            if (dt.Rows.Count < 1)
            {
                insert = "INSERT INTO DoorEvent(EventCode) " +
                         "VALUES ('DÖIN'),('DÖUT')," +
                                "('FDIN'),('FDUT')";

                cmd = new SQLiteCommand(insert, conn);
                cmd.ExecuteNonQuery();
            }

            table = "SELECT ID FROM DoorLocationTable";
            dt = Datatable.DataTable(table, "");
            if (dt.Rows.Count < 1)
            {
                insert = "INSERT INTO DoorLocationTable(ApartmentNumber) " +
                         "VALUES('0101'),('0102')," +
                               "('0103'),('0201')," +
                               "('0202'),('0301')," +
                               "('0302'),('VAKT')," +
                               "('SOPRUM'),('TVÄTT')";

                cmd = new SQLiteCommand(insert, conn);
                cmd.ExecuteNonQuery();
            }
        }
        //Inserts the testdata specified in to database tables
        internal static bool DataToLog(string OpenDate, string EventType, string DoorId, string TenantId)
        {
            string insert;

            try
            {
                insert = "INSERT INTO DoorEventTable(OpeningDate, DoorEventType, DoorID, TenantID) " +
                         "VALUES(@OpenDate, " +
                         "(SELECT ID FROM DoorEvent WHERE @EventType = DoorEvent.EventCode)," +
                         "(SELECT ID FROM DoorName WHERE @DoorId = DoorName.DoorName)," +
                         "(SELECT ID FROM TenantTable WHERE @TenantId = TenantTable.TenantTag))";

                using (SQLiteConnection conn = new SQLiteConnection("data source=" + Settings.Database))
                {
                    conn.Open();

                    using var cmd = new SQLiteCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@OpenDate", OpenDate);
                    cmd.Parameters.AddWithValue("@EventType", EventType);
                    cmd.Parameters.AddWithValue("@DoorId", DoorId);
                    cmd.Parameters.AddWithValue("@TenantId", TenantId);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        //Made up data used to test database functions
        public static void EventLogData()
        {
            const string insert = "SELECT ID FROM DoorEventTable";
            var dt = Datatable.DataTable(insert, "");

            if ( dt.Rows.Count < 1)
            {
                DataToLog("2020-10-23 10:07", "DÖIN", "LGH0201", "0201B");
                DataToLog("2020-10-23 10:08", "DÖUT", "LGH0201", "0201B");
                DataToLog("2020-10-23 10:19", "DÖIN", "LGH0302",  "0302A");
                DataToLog("2020-10-23 10:19", "DÖIN", "LGH0201", "0201A");
                DataToLog("2020-10-23 10:20", "DÖUT", "SOPRUM", "0302A");
                DataToLog("2020-10-23 10:20", "DÖIN", "UT", "0201A");
                DataToLog("2020-10-23 10:21", "DÖIN", "SOPRUM", "0302A");
                DataToLog("2020-10-23 10:22", "DÖIN", "LGH0302","0302A");
                DataToLog("2020-10-23 10:55", "DÖIN", "LGH0202", "0202A");
                DataToLog("2020-10-23 10:56", "DÖUT", "LGH0202", "0202A");
                DataToLog("2020-10-23 11:03", "DÖIN", "LGH0301","0301D");
                DataToLog("2020-10-23 11:04", "DÖUT", "LGH0301",  "0301D");
                DataToLog("2020-10-23 11:05", "DÖUT", "TVÄTT", "0301D");
                DataToLog("2020-10-23 11:07", "DÖIN", "SOPRUM", "0102A");
                DataToLog("2020-10-23 12:07", "DÖUT", "UT", "0201C");
                DataToLog("2020-10-23 13:20", "DÖUT", "SOPRUM", "0102A");
            }
        }
    }
}