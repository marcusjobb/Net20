namespace ooa_2_husrum_ef.Utils.Extensions
{
  using ooa_2_husrum_ef.Models;
  using System;
  using System.Collections.Generic;

  public static class ListLogEntryExtensions
  {
    /// <summary>
    /// Writes a set of log entries to the console. 
    /// </summary>
    /// <param name="logEntries">Set of log entries to write to console.</param>
    /// <param name="title">Describes this set of log entries.</param>
    public static void Write(this List<LogEntry> logEntries, string title)
    {
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.WriteLine(title);
      Console.ResetColor();

      if (logEntries != null && logEntries.Count > 0)
      {
        foreach (LogEntry le in logEntries)
        {
          Console.WriteLine($"{le.When} {le.DoorId} {le.EventId} {le.TagId} {le.Tag.Tenant.Name} --> {le.Phrase()}");
        }
      }
      else
      {
        Console.WriteLine("No entries found.");
      }

      Console.WriteLine();
    }
  }
}
