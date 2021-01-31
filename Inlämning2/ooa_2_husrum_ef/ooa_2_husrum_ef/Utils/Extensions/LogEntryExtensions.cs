namespace ooa_2_husrum_ef.Utils.Extensions
{
  using ooa_2_husrum_ef.Models;

  static class LogEntryExtensions
  {
    /// <summary>
    /// Tells the log entry in a sentence. 
    /// </summary>
    /// <param name="le">Log entry to phrase.</param>
    /// <returns>Log entry expressed in a sentence.</returns>
    public static string Phrase(this LogEntry le)
    {
      var who = le.Tag.Tenant.Name;
      var eventId = le.EventId;
      var doorId = le.DoorId;

      var action = "";
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

      var door = "dörr till ";
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

      var how = "";
      if (eventId.Length > 2)
      {
        how = eventId.Substring(2, 2) == "UT" ? "utifrån" : "inifrån";
      }

      return $"{who} {action} {door} {how}.";
    }
  }
}
