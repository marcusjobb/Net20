using System;
using System.Data;

namespace ooa_1_husrum
{
  class Program
  {
    static void Main()
    {
      DoorEventsLog log = new DoorEventsLog();
      TestData.CreateTestData(log);

      DataTable entriesByDoor = log.FindEntriesByDoor("LGH0201");
      DataTable entriesByEvent = log.FindEntriesByEvent("DÖIN");
      DataTable entriesByLocation = log.FindEntriesByLocation("SOPRUM");
      DataTable entriesByTag = log.FindEntriesByTag("0302A");
      DataTable entriesByTenant = log.FindEntriesByTenant("Alexander Erlander");
      DataTable tenants = log.ListTenantsAt("0201");

      WriteLogEntries("Logs on door LGH0201", entriesByDoor);
      WriteLogEntries("Logs on event DÖIN", entriesByEvent);
      WriteLogEntries("Logs on location SOPRUM", entriesByLocation);
      WriteLogEntries("Logs on tag 0302A", entriesByTag);
      WriteLogEntries("Logs on tenant Alexander Erlander", entriesByTenant);
      WriteTenants("Tenants at 0201", tenants);

      Console.Write("\nPress any key to exit> ");
      Console.ReadKey();
    }

    static void WriteLogEntries(string title, DataTable dt)
    {
      Console.WriteLine(title);
      if (dt != null && dt.Rows.Count > 0)
      {
        string header = "";
        foreach (DataColumn col in dt.Columns)
        {
          header += $"{col.ColumnName} ";
        }
        Console.WriteLine(header);
        foreach (DataRow row in dt.Rows)
        {
          string line = "";
          foreach (DataColumn col in dt.Columns)
          {
            line += $"{row[col]} ";
          }
          Console.WriteLine(line + "-> " + PhraseLogEntry(row));
        }
      }
      else
      {
        Console.WriteLine("No entries found.");
      }
      Console.WriteLine();
    }

    static void WriteTenants(string title, DataTable dt)
    {
      Console.WriteLine(title);
      if (dt != null && dt.Rows.Count > 0)
      {
        string header = "";
        foreach (DataColumn col in dt.Columns)
        {
          header += $"{col.ColumnName} ";
        }
        Console.WriteLine(header);
        foreach (DataRow row in dt.Rows)
        {
          string line = "";
          foreach (DataColumn col in dt.Columns)
          {
            line += $"{row[col]} ";
          }
          Console.WriteLine(line);
        }
      }
      else
      {
        Console.WriteLine("No entries found.");
      }
      Console.WriteLine();
    }

    static string PhraseLogEntry(DataRow row)
    {
      string phrase = "";
      string who = row["Tenant"].ToString();
      string eventId = row["EventId"].ToString();
      string doorId = row["DoorId"].ToString();

      string action = "";
      switch (eventId.Substring(0, 2))
      {
        case "FD":
          action = "försökte öppna";
          break;
        case "DÖ":
          action = "öppnade";
          break;
        case "DS":
          action = "stängde";
          break;
      }

      string door = "dörr till ";
      switch (doorId.Substring(0, 2))
      {
        case "LG":
          door += "lägenhet " + doorId.Substring(3, 4);
          break;
        case "BL":
          door += $"{(doorId.Substring(4, 1) == "1" ? "altanen" : "balkongen")} för lägenhet " + doorId.Substring(3, 4);
          break;
        case "UT":
          door += "gatan";
          break;
        case "SO":
          door += "soprummet";
          break;
        case "TV":
          door += "tvättstugan";
          break;
        case "VA":
          door += "vaktmästarens rum";
          break;
      }

      string how = "";
      if (eventId.Length > 2)
      {
        how = eventId.Substring(2, 2) == "UT" ? "utifrån" : "inifrån";
      }

      phrase = $"{who} {action} {door} {how}.";

      return phrase;
    }
  }
}
