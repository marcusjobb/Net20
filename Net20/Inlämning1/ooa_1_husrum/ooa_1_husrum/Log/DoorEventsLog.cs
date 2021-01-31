using System.Data;

namespace ooa_1_husrum
{
  class DoorEventsLog
  {
    /// <summary>
    /// The amount of log entries returned are limited to. 
    /// It's set to 20 by default, set to 0 for no limit. 
    /// </summary>
    public int MaxEntries { get; set; }
    public DBHandler DBHandler { get; private set; }

    /// <summary>
    /// The select parameters defining what columns are returned in the data table when looking for log entries. 
    /// </summary>
    private const string EntryColumns = "Log.Date as Date, Log.Time as Time, Log.DoorId as DoorId, Log.EventId as EventId, Log.Tag as Tag, Keys.Owner as Tenant";
    
    /// <summary>
    /// Finds and stores log entries of door events in a house. 
    /// Log entries store the tag id and tag owner used in the event, when the event occured, and from which side of the door the entry or attempt of entry was made. 
    /// </summary>
    public DoorEventsLog()
    {
      DBHandler = new DBHandler();
      MaxEntries = 20;
    }
    public DoorEventsLog(DBHandler dbh)
    {
      DBHandler = dbh;
      MaxEntries = 20;
    }

    /// <summary>
    /// Looks for log entries containing the specified door id. 
    /// </summary>
    /// <param name="door">Door id code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public DataTable FindEntriesByDoor(string door)
    {
      string sql = @$"
        SELECT {EntryColumns} 
        FROM Log 
        INNER JOIN Keys ON Keys.Tag = Log.Tag
        WHERE Log.DoorId = @door 
        ORDER BY Log.Date DESC, Log.Time DESC
        {(MaxEntries > 0 ? "LIMIT '" + MaxEntries + "'" : "")};
      ";
      return DBHandler.GetDataSet(sql, "@door", door);
    }

    /// <summary>
    /// Looks for log entries containing the specified event id. 
    /// </summary>
    /// <param name="eventId">Event id code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public DataTable FindEntriesByEvent(string eventId)
    {
      string sql = @$"
        SELECT {EntryColumns} 
        FROM Log
        INNER JOIN Keys ON Keys.Tag = Log.Tag
        WHERE Log.EventId = @eventId
        ORDER BY Log.Date DESC, Log.Time DESC
        {(MaxEntries > 0 ? "LIMIT '" + MaxEntries + "'" : "")};
      ";
      return DBHandler.GetDataSet(sql, "@eventId", eventId);
    }

    /// <summary>
    /// Looks for log entries involving the specified location. 
    /// </summary>
    /// <param name="location">Location id code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public DataTable FindEntriesByLocation(string location)
    {
      string sql = @$"
        SELECT {EntryColumns} 
        FROM Log
        INNER JOIN Keys ON Keys.Tag = Log.Tag
        INNER JOIN Doors ON Log.DoorId = Doors.Id
        WHERE Doors.Location = @location
        ORDER BY Log.Date DESC, Log.Time DESC
        {(MaxEntries > 0 ? "LIMIT '" + MaxEntries + "'" : "")};
      ";
      return DBHandler.GetDataSet(sql, "@location", location);
    }

    /// <summary>
    /// Looks for log entries containing the specified tag.
    /// </summary>
    /// <param name="tag">Tag code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public DataTable FindEntriesByTag(string tag)
    {
      string sql = @$"
        SELECT {EntryColumns} 
        FROM Log
        INNER JOIN Keys ON Keys.Tag = Log.Tag
        WHERE Log.Tag = @tag
        ORDER BY Log.Date DESC, Log.Time DESC
        {(MaxEntries > 0 ? "LIMIT '" + MaxEntries + "'" : "")};
      ";
      return DBHandler.GetDataSet(sql, "@tag", tag);
    }

    /// <summary>
    /// Looks for log entries involving the specified tenant.
    /// </summary>
    /// <param name="name">Name of the tenant, e.g. "First Last"</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public DataTable FindEntriesByTenant(string name)
    {
      string sql = @$"
        SELECT {EntryColumns} 
        FROM Log
        INNER JOIN Keys ON Keys.Tag = Log.Tag
        WHERE Keys.Owner = @name
        ORDER BY Log.Date DESC, Log.Time DESC
        {(MaxEntries > 0 ? "LIMIT '" + MaxEntries + "'" : "")};
      ";
      return DBHandler.GetDataSet(sql, "@name", name);
    }

    /// <summary>
    /// Looks for the names of all tenants living at the specified apartment.
    /// </summary>
    /// <param name="apartment">Apartment id code.</param>
    /// <returns>Names of all tenants, listed alpabethically in ascending order.</returns>
    public DataTable ListTenantsAt(string apartment)
    {
      string sql = @$"
        SELECT Tenants.Name 
        FROM Tenants 
        WHERE Tenants.Apartment = @apartment
        ORDER BY Tenants.Name ASC 
        {(MaxEntries > 0 ? "LIMIT '" + MaxEntries + "'" : "")};
      ";
      return DBHandler.GetDataSet(sql, "@apartment", apartment);
    }

    /// <summary>
    /// Saves a log entry to the database. 
    /// </summary>
    /// <param name="tag">Tag used.</param>
    /// <param name="doorId">Door related to the incident.</param>
    /// <param name="date">Date when this occured, using the format "YY-MM-DD"</param>
    /// <param name="time">Time when this occured, in the format of "HH:MM:SS"</param>
    /// <param name="eventId">Event id. (What happened)</param>
    public void LogEntry(string tag, string doorId, string date, string time, string eventId)
    {
      string sql = @$"
        INSERT INTO Log (Tag, DoorId, Date, Time, EventId)
        VALUES (@tag, @doorId, @date, @time, @eventId);
      ";
      DBHandler.ExecuteSQL(sql, "@tag", tag, "@doorId", doorId, "@date", date, "@time", time, "@eventId", eventId);
    }
  }
}
