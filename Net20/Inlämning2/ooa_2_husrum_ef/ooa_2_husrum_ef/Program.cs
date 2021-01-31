namespace ooa_2_husrum_ef
{
  using ooa_2_husrum_ef.Database.Seeders;
  using System;
  using ooa_2_husrum_ef.Utils.Helpers.Output.Console;

  class Program
  {
    static void Main()
    {
      Seed();

      #region december features demo
      var doorId = "LGH0201";
      var doorEntries = new COutLogEntries(
        DoorEventsLog.FindEntriesByDoor(doorId));
      doorEntries.Write($"Log entries by door {doorId}:");

      var eventId = "DÖIN";
      var eventEntries = new COutLogEntries(
        DoorEventsLog.FindEntriesByEvent(eventId));
      eventEntries.Write($"Log entries by event {eventId}:");

      var locationId = "SOPRUM";
      var locationEntries = new COutLogEntries(
        DoorEventsLog.FindEntriesByLocation(locationId));
      locationEntries.Write($"Log entries by location {locationId}:");

      var tagId = "0302A";
      var tagEntries = new COutLogEntries(
        DoorEventsLog.FindEntriesByTag(tagId));
      tagEntries.Write($"Log entries by tag {tagId}:");

      var tenantName = "Alexander Erlander";
      var tenantEntries = new COutLogEntries(
        DoorEventsLog.FindEntriesByTenant(tenantName));
      tenantEntries.Write($"Log entries by tenants name {tenantName}:");

      var apartmentId = "0102";
      var tenantsAtApartment2020 = new COutTags(
        DoorEventsLog.ListTenantsAt(apartmentId));
      tenantsAtApartment2020.Write($"Tenants at apartment {apartmentId}:");
      #endregion

      #region january new features demo
      var moveOutElias = new SuccessReportMoveTenant(
        DoorEventsLog.MoveTenant("0102A", "")); 
      moveOutElias.Write();

      var moveOutWilma = new SuccessReportMoveTenant(
      DoorEventsLog.MoveTenant("00010101-0003", ""));
      moveOutWilma.Write();

      var addTenantAlice = new SuccessReportAddTenant(
      DoorEventsLog.AddTenant("00010101-0022", "Alice Olsson"));
      addTenantAlice.Write();

      var addTenantLucas = new SuccessReportAddTenant(
      DoorEventsLog.AddTenant("00010101-0023", "Lucas Olsson"));
      addTenantLucas.Write();

      var moveInAlice = new SuccessReportMoveTenant(
      DoorEventsLog.MoveTenant("00010101-0022", "0102"));
      moveInAlice.Write();

      var moveInLucas = new SuccessReportMoveTenant(
      DoorEventsLog.MoveTenant("00010101-0023", "0102"));
      moveInLucas.Write();

      Console.WriteLine();

      var tenantsAtApartment2021 = new COutTags(
        DoorEventsLog.ListTenantsAt(apartmentId));
      tenantsAtApartment2021.Write($"Tenants at apartment {apartmentId}:");
      #endregion

      Exit();
    }

    static void Seed()
    {
      Console.Write("Seeding... ");
      LogsDataSeeder.Seed();
      Console.WriteLine("Done!\n");
    }

    static void Exit()
    {
      Console.Write("Press any key to exit... ");
      Console.ReadKey();
    }
  }
}
