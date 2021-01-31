namespace ooa_2_husrum_ef
{
  using Microsoft.EntityFrameworkCore;
  using ooa_2_husrum_ef.Database;
  using ooa_2_husrum_ef.Models;
  using ooa_2_husrum_ef.Utils.Helpers;
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  public class DoorEventsLog
  {
    /// <summary>
    /// Amount of log entries returned are limited to this. 
    /// 20 by default, set to 0 for no limit. 
    /// </summary>
    public static int MaxEntries { get; set; } = 20;

    /// <summary>
    /// Looks for log entries containing the specified door id. 
    /// </summary>
    /// <param name="door">Door id code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public static List<LogEntry> FindEntriesByDoor(string doorId)
    {
      using (var context = new LogsContext())
      {
        var entries = context.LogEntries
          .Include(le => le.Tag)
            .ThenInclude(ta => ta.Tenant)
          .Where(le => le.DoorId == doorId)
          .OrderByDescending(le => le.When);

        // Limit entries returned according to MaxEntries. 
        return MaxEntries > 0 ? entries.Take(MaxEntries).ToList() : entries.ToList();
      }
    }

    /// <summary>
    /// Looks for log entries containing the event id. 
    /// </summary>
    /// <param name="eventId">Event id code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public static List<LogEntry> FindEntriesByEvent(string eventId)
    {
      using (var context = new LogsContext())
      {
        var entries = context.LogEntries
          .Include(le => le.Tag)
            .ThenInclude(ta => ta.Tenant)
          .Where(le => le.EventId == eventId)
          .OrderByDescending(le => le.When);

        // Limit entries returned according to MaxEntries. 
        return MaxEntries > 0 ? entries.Take(MaxEntries).ToList() : entries.ToList();
      }
    }

    /// <summary>
    /// Looks for log entries involving the location. 
    /// </summary>
    /// <param name="location">Location id code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public static List<LogEntry> FindEntriesByLocation(string locationId)
    {
      using (var context = new LogsContext())
      {
        var entries = context.LogEntries
          .Include(le => le.Tag)
            .ThenInclude(ta => ta.Tenant)
          .Include(le => le.Door)
          .Where(le => le.Door.LocationId == locationId)
          .OrderByDescending(le => le.When);

        // Limit entries returned according to MaxEntries. 
        return MaxEntries > 0 ? entries.Take(MaxEntries).ToList() : entries.ToList();
      }
    }

    /// <summary>
    /// Looks for log entries containing the tag.
    /// </summary>
    /// <param name="tag">Tag code.</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public static List<LogEntry> FindEntriesByTag(string tagId)
    {
      using (var context = new LogsContext())
      {
        var entries = context.LogEntries
          .Include(le => le.Tag)
            .ThenInclude(ta => ta.Tenant)
          .Where(le => le.TagId == tagId)
          .OrderByDescending(le => le.When);

        // Limit entries returned according to MaxEntries. 
        return MaxEntries > 0 ? entries.Take(MaxEntries).ToList() : entries.ToList();
      }
    }

    /// <summary>
    /// Looks for log entries involving the tenant.
    /// </summary>
    /// <param name="name">Name of the tenant, e.g. "First Last"</param>
    /// <returns>Log entries, listed in descending order based on date and time, latest entry first.</returns>
    public static List<LogEntry> FindEntriesByTenant(string name)
    {
      using (var context = new LogsContext())
      {
        var entries = context.LogEntries
          .Include(le => le.Tag)
            .ThenInclude(ta => ta.Tenant)
          .Where(le => le.Tag.Tenant.Name == name)
          .OrderByDescending(le => le.When);

        // Limit entries returned according to MaxEntries. 
        return MaxEntries > 0 ? entries.Take(MaxEntries).ToList() : entries.ToList();
      }
    }

    /// <summary>
    /// Looks for the names and tags of all tenants living at the apartment.
    /// </summary>
    /// <param name="apartmentId">Apartment id code.</param>
    /// <returns>Names of all tenants, listed alpabethically in ascending order.</returns>
    public static List<Tag> ListTenantsAt(string apartmentId)
    {
      using (var context = new LogsContext())
      {
        return context.Tags
          .Include(t => t.Tenant)
          .Where(t => t.Tenant.ApartmentId == apartmentId)
          .OrderBy(t => t.Tenant.Name)
          .ToList();
      }
    }

    /// <summary>
    /// Saves a log entry to the database. 
    /// </summary>
    /// <param name="when">Date and time when this occured, using the format "YY-MM-DD HH:MM:SS"</param>
    /// <param name="doorId">Door id involved.</param>
    /// <param name="eventId">Event id, what happened</param>
    /// <param name="tagId">Tag id used.</param>
    /// <returns>True if operation was successful and changes were saved.</returns>
    public static bool LogEntry(string when, string doorId, string eventId, string tagId)
    {
      using (var context = new LogsContext())
      {
        context.Database.BeginTransaction();
        try
        {
          context.Add(
            new LogEntry()
            {
              When = DateTime.ParseExact(when, "yy-MM-dd HH:mm:ss", null),
              DoorId = doorId,
              EventId = eventId,
              TagId = tagId
            }
          );

          context.SaveChanges();
          context.Database.CommitTransaction();
        }
        catch (Exception)
        {
          context.Database.RollbackTransaction();
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Moves a tenant from an apartment and updates the tenants tag.
    /// </summary>
    /// <param name="tenantOrTagId">Full name of tenant or tenants tag id. </param>
    /// <param name="apartmentId">Id of apartment to move in to, 
    /// or an empty string to simply move out and not into another apartment.</param>
    /// <returns>True if operation was successful and changes were saved.</returns>
    public static bool MoveTenant(string tenantOrTagId, string apartmentId)
    {
      using (var context = new LogsContext())
      {
        try
        {
          var tenant = context.Tenants 
            .Where(t => t.Id == tenantOrTagId)
            .FirstOrDefault();
          
          var tag = context.Tags
            .Include(t => t.Tenant)
            .Where(t => t.Id == tenantOrTagId || t.Tenant.Id == tenantOrTagId)
            .FirstOrDefault();

          if (tenant == null && tag != null)
          {
            tenant = tag.Tenant;
          }
          else if (tenant == null && tag == null)
          {
            // Tenant not found by tenant id or tag id. 
            return false;
          }

          context.Database.BeginTransaction();
          try
          {
            if (apartmentId == "")
            {
              // Tenant moved out. Remove tenant and tag.
              context.Tenants.Remove(tenant);
              if (tag != null) context.Tags.Remove(tag);
            }
            else
            {
              // Tenant moved to another apartment. 
              // Set tenants new apartment id.
              tenant.ApartmentId = apartmentId;

              if (tag != null)
              {
                // Remove old tag if there was one. 
                context.Tags.Remove(tag);
              }
              
              // Set tenants new tag. 
              context.Add(
                new Tag()
                {
                  Tenant = tenant,
                  TenantId = tenant.Id,
                  Id = TagHelper.GetNextApartmentTag(apartmentId),
                }
              );
            }

            context.SaveChanges();
            context.Database.CommitTransaction();
          }
          catch (Exception)
          {
            context.Database.RollbackTransaction();
            return false;
          }
        }
        catch (Exception)
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Saves a new tenant to the database. 
    /// </summary>
    /// <param name="name">Tenants full name, "First Last"</param>
    /// <returns>True if operation was successful and changes were saved.</returns>
    public static bool AddTenant(string id, string name)
    {
      using (var context = new LogsContext())
      {
        context.Database.BeginTransaction();
        try
        {
          context.Add(
            new Tenant()
            {
              Id = id,
              Name = name
            });
          
          context.SaveChanges();
          context.Database.CommitTransaction();
        }
        catch (Exception)
        {
          context.Database.RollbackTransaction();
          return false;
        }
      }

      return true;
    }
  }
}
