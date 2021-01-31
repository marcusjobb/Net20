using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Husrum_Fastigheter_AB
{
    class CreateDatabase : Database
    {
        public void Create_Database()
        {
            FileInfo file = new FileInfo(@".\House.db");
            if (!file.Exists)
            {
                SQLiteConnection.CreateFile(@".\House.db");

                SQL_Execution(@"CREATE TABLE Tenants (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Apartment TEXT, Tag TEXT);");
                SQL_Execution(@"CREATE TABLE Locations (ID INTEGER PRIMARY KEY AUTOINCREMENT, Location TEXT);");
                SQL_Execution(@"CREATE TABLE Events (ID INTEGER PRIMARY KEY AUTOINCREMENT, Event TEXT);");
                SQL_Execution(@"CREATE TABLE Logs (ID INTEGER PRIMARY KEY AUTOINCREMENT, Date INTEGER NOT NULL, Time INTEGER NOT NULL, Location INTEGER NOT NULL, Tenant INTEGER NOT NULL, Tag INTEGER NOT NULL, Event INTEGER NOT NULL);");


                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Liam Jönsson", "@Apartment", "0101", "@Tag", "0101A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Elias Petterson", "@Apartment", "0102", "@Tag", "0102A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Wilma Johansson", "@Apartment", "0102", "@Tag", "0102B" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Alicia Sanchez", "@Apartment", "0103", "@Tag", "0103A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Aaron Sanchez", "@Apartment", "0103", "@Tag", "0103B" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Olivia Erlander", "@Apartment", "0201", "@Tag", "0201A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "William Erlander", "@Apartment", "0201", "@Tag", "0201B" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Alexander Erlander", "@Apartment", "0201", "@Tag", "0201C" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Astrid Erlander", "@Apartment", "0201", "@Tag", "0201D" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Lucas Adolfsson", "@Apartment", "0202", "@Tag", "0202A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Ebba Adolfsson", "@Apartment", "0202", "@Tag", "0202B" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Lilly Adolfsson", "@Apartment", "0202", "@Tag", "0202C" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Ella Ahlström", "@Apartment", "0301", "@Tag", "0301A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Alma Alfredsson", "@Apartment", "0301", "@Tag", "0301B" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Elsa Alhström", "@Apartment", "0301", "@Tag", "0301C" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Maja Ahlström", "@Apartment", "0301", "@Tag", "0301D" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Noah Almgren", "@Apartment", "0302", "@Tag", "0302A" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Adam Andersen", "@Apartment", "0302", "@Tag", "0302B" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Kattis Backman", "@Apartment", "0302", "@Tag", "0302C" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Oscar Chen", "@Apartment", "0302", "@Tag", "0302D" });
                SQL_Execution(@"INSERT INTO Tenants (Name, Apartment, Tag) VALUES(@Name, @Apartment, @Tag);", new string[] { "@Name", "Vaktmästare", "@Apartment", "VAKT", "@Tag", "VAKT01" });


                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "UT" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "SOPRUM" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "TVÄTT" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "VAKT" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0101" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0102" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0103" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0201" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0202" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0301" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "LGH0302" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0101" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0102" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0103" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0201" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0202" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0301" });
                SQL_Execution(@"INSERT INTO Locations (Location) VALUES(@Location);", new string[] { "@Location", "BLK0302" });

                SQL_Execution(@"INSERT INTO Events (Event) VALUES(@Event);", new string[] { "@Event", "DÖUT" });
                SQL_Execution(@"INSERT INTO Events (Event) VALUES(@Event);", new string[] { "@Event", "DÖIN" });
                SQL_Execution(@"INSERT INTO Events (Event) VALUES(@Event);", new string[] { "@Event", "FDIN" });
                SQL_Execution(@"INSERT INTO Events (Event) VALUES(@Event);", new string[] { "@Event", "FDUT" });

                //SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "", "@Time", "", "@Location", "", "@Tenant", "", "@Tag", "", "@Event", "" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1007", "@Location", "8", "@Tenant", "7", "@Tag", "7", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1008", "@Location", "8", "@Tenant", "7", "@Tag", "7", "@Event", "1" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1019", "@Location", "11", "@Tenant", "17", "@Tag", "17", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1019", "@Location", "8", "@Tenant", "6", "@Tag", "6", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1020", "@Location", "2", "@Tenant", "17", "@Tag", "17", "@Event", "1" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1020", "@Location", "1", "@Tenant", "6", "@Tag", "6", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1021", "@Location", "2", "@Tenant", "17", "@Tag", "17", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1022", "@Location", "11", "@Tenant", "17", "@Tag", "17", "@Event", "1" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1055", "@Location", "9", "@Tenant", "10", "@Tag", "10", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1056", "@Location", "9", "@Tenant", "10", "@Tag", "10", "@Event", "1" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1103", "@Location", "10", "@Tenant", "16", "@Tag", "16", "@Event", "2" });
                SQL_Execution(@"INSERT INTO Logs (Date, Time, Location, Tenant, Tag, Event) VALUES(@Date, @Time, @Location, @Tenant, @Tag, @Event);", new string[] { "@Date", "20201023", "@Time", "1104", "@Location", "10", "@Tenant", "16", "@Tag", "16", "@Event", "1" });

            }
        }
    }
}
