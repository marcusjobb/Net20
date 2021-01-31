namespace ooa_2_husrum_ef.Utils.Helpers.Output.Console
{
  using ooa_2_husrum_ef.Interfaces;
  using ooa_2_husrum_ef.Models;
  using ooa_2_husrum_ef.Utils.Extensions;
  using System;
  using System.Collections.Generic;
  using System.Text;

  class COutLogEntries : IConsoleOutputEntities
  {
    private List<LogEntry> LogEntries { get; set; }
    public COutLogEntries(List<LogEntry> logEntries)
    {
      LogEntries = logEntries;
    }

    public void Write(string header)
    {
      LogEntries.Write(header);
    }
  }
}
