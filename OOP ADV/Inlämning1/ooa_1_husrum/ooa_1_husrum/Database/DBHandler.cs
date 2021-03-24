using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ooa_1_husrum
{
  /// <summary>
  /// Creates and connects to an SQLite database. 
  /// </summary>
  class DBHandler
  {
    public static readonly string DBFilePath = @".\DoorEventsLog.db";
    public DBHandler()
    {
      CreateDatabase();
    }

    /// <summary>
    /// Executes SQL code towards the database.
    /// </summary>
    /// <param name="sql">SQL statement</param>
    /// <param name="values">SQL values</param>
    /// <returns>Amount of rows affected.</returns>
    public int ExecuteSQL(string sql, params string[] values)
    {
      int rowsAffected = 0;
      using (SQLiteConnection connection = new SQLiteConnection("data source=" + DBFilePath))
      {
        connection.Open();

        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
        {
          for (int i = 0; i < values.Length; i += 2)
          {
            command.Parameters.AddWithValue(values[i], values[i + 1]);
          }
          rowsAffected = command.ExecuteNonQuery(); 
        }
      }
      return rowsAffected;
    }

    /// <summary>
    /// Fetches data specified by the SQL statement.
    /// </summary>
    /// <param name="sql">SQL statement. (SELECT * FROM Table WHERE = "@name";)</param>
    /// <param name="values">Values used in the statement. ("@name", "value")</param>
    /// <returns>Data yielded from the sql statement.</returns>
    public DataTable GetDataSet(string sql, params string[] values)
    {
      DataTable dataTable = new DataTable();
      
      using (SQLiteConnection connection = new SQLiteConnection("data source=" + DBFilePath))
      {
        connection.Open();
        using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
        {
          for (int i = 0; i < values.Length; i += 2)
          {
            cmd.Parameters.AddWithValue(values[i], values[i + 1]);
          }

          SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
          da.Fill(dataTable);
        }
      }
      return dataTable;
    }

    /// <summary>
    /// Creates the database file and tables as per the database design (unless the file already exists). (Doors, Events, Keys, Access, Tenants, Log)
    /// </summary>
    private void CreateDatabase()
    {
      FileInfo dBFile = new FileInfo(DBFilePath);

      // Dont need to do anything if the db file has already been set up.
      if (!dBFile.Exists || dBFile.Length == 0)
      {
        // Create the db file.
        SQLiteConnection.CreateFile(DBFilePath);

        // Create all tables required by DoorEventsLog and write them to the file.
        // doors
        ExecuteSQL(@"
          CREATE TABLE Doors(
            Id TEXT NOT NULL UNIQUE, 
            Location TEXT,
            Description TEXT, 
            PRIMARY KEY(Id)
          ); 
        ");
        // events
        ExecuteSQL(@"
          CREATE TABLE Events (
            Id TEXT NOT NULL UNIQUE, 
            Description TEXT, 
            PRIMARY KEY(Id)
          ); 
        ");
        // keys
        ExecuteSQL(@"
          CREATE TABLE Keys (
            Tag TEXT NOT NULL UNIQUE, 
            Owner TEXT, 
            Activate TEXT, 
            Expire TEXT, 
            PRIMARY KEY(Tag)
          ); 
        ");
        // access
        ExecuteSQL(@"
          CREATE TABLE Access(
            Tag TEXT NOT NULL, 
            DoorId TEXT NOT NULL
          );
        ");
        // tenants
        ExecuteSQL(@"
          CREATE TABLE Tenants (
            Id INTEGER NOT NULL UNIQUE, 
            Name TEXT NOT NULL, 
            Apartment TEXT, 
            PRIMARY KEY(Id)
          ); 
        ");
        // log
        ExecuteSQL(@"
          CREATE TABLE Log (
            Tag TEXT, 
            DoorId TEXT, 
            Date TEXT, 
            Time TEXT, 
            EventId TEXT
          ); 
        ");
      }
    }
    public void CreateTenant(string name, string apartment)
    {
      string sql = @"
        INSERT INTO Tenants (Name, Apartment) 
        VALUES(@name, @apartment);
      ";
      ExecuteSQL(sql, "@name", name, "@apartment", apartment);
    }
    public void CreateTag(string tag, string owner)
    {
      string sql = @"
        INSERT INTO Keys (Tag, Owner)
        VALUES (@tag, @owner);
      ";
      ExecuteSQL(sql, "@tag", tag, "@owner", owner);
    }
    public void CreateDoor(string id, string location, string description)
    {
      string sql = @"
        INSERT INTO Doors (Id, Location, Description )
        VALUES (@id, @location, @description);
      ";
      ExecuteSQL(sql, "@id", id, "@location", location, "@description", description);
    }
    public void CreateAccess(string tag, string doorId)
    {
      string sql = @"
        INSERT INTO Access (Tag, DoorId )
        VALUES (@tag, @doorId);
      ";
      ExecuteSQL(sql, "@tag", tag, "@doorId", doorId);
    }
    public void CreateAccess(string tag, string[] doorIds)
    {
      foreach (string doorId in doorIds)
      {
        CreateAccess(tag, doorId);
      }
    }
    public void CreateEvent(string id, string description)
    {
      string sql = @"
        INSERT INTO Events (Id, Description )
        VALUES (@id, @description);
      ";
      ExecuteSQL(sql, "@id", id, "@description", description);
    }
  }
}
