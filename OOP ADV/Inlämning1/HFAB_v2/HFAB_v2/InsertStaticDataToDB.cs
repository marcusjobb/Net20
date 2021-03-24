using System;
using System.Collections.Generic;
using System.Text;

namespace HFAB_v2
{
    class InsertStaticDataToDB
    {
        public static void InsertIntoTables()
        {
            //Creates a new object of the class StaticData
            StaticData obj = new StaticData();

            //Adds tenants to table
            for (int i = 0; i < obj.TenantsArray.Length; i++)
            {
                DatabaseCommunication.ExecuteSQL("Insert Into Tenants (Tenant, Tag) Values (@Tenant, @Tag)", "@Tenant", obj.TenantsArray[i], "@Tag", obj.TagArray[i]);
            }

            //Updates Tenants.Location with values
            for (int i = 0; i < obj.LocationArray.Length; i++)
            {
                //DatabaseCommunication.ExecuteSQL($@"UPDATE Tenants SET ""Location"" = '{obj.LocationArray[i]}' WHERE Tag LIKE '{obj.LocationArray[i]}%';");

                DatabaseCommunication.ExecuteSQL("UPDATE Tenants SET Location = @Location WHERE Tenants.Tag LIKE @Location2;",
                    "@Location", obj.LocationArray[i],
                    "@Location2", obj.LocationArray[i] + "%"
                    );
            }

            //Adds values to Event.Event
            for (int i = 0; i < obj.EventArray.Length; i++)
            {
                DatabaseCommunication.ExecuteSQL("INSERT INTO Event (Event) Values (@Event)", "@Event", obj.EventArray[i]);

            }

            //Adds values to Door.Door
            for (int i = 0; i < obj.DoorArray.Length; i++)
            {
                DatabaseCommunication.ExecuteSQL("INSERT INTO Door (Door) Values (@Door)", "@Door", obj.DoorArray[i]);
            }

            //Updates Door.Location with values
            for (int i = 0; i < obj.LocationArray.Length; i++)
            {
                //DatabaseCommunication.ExecuteSQL($@"UPDATE Door SET ""Location"" = '{obj.LocationArray[i]}' WHERE Door.Door LIKE '%{obj.LocationArray[i]}';");
                DatabaseCommunication.ExecuteSQL("UPDATE Door SET Location = @Location WHERE Door.Door LIKE @Location2",
                    "@Location", obj.LocationArray[i],
                    "@Location2", "%" + obj.LocationArray[i] + "%"
                    );
            }
        }
    }
}
