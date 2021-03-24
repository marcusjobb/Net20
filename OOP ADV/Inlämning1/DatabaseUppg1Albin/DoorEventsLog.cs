using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DatabaseUppg1Albin
{
    // Classen som innehåller alla "FindEntriesByXXXXX" metoder inklusive ListTenantsAt och LogEntry.
    public static class DoorEventsLog
    {
        public static int MaxEntries { get;  set; }  =  20;

        // Det är meningen att alla dessa metoderna skall returnera Datum, Tid, Dörrkod, Tagkod, Händelsekod, Lägenhetskod, Tagkod, hyresgästens namn.
        public static DataTable FindEntriesByDoor(string input)
        {
            string sql = StringCollection.caseDoor;
            var data = Datatable.GetDataTable(sql, "@input", input, "@limit", MaxEntries.ToString());
            return data;
        }

        public static DataTable FindEntriesByEvent(string input)
        {
            string sql = StringCollection.caseEvent;
            var data = Datatable.GetDataTable(sql, "@input", input, "@limit", MaxEntries.ToString());
            return data;
        }

        public static DataTable FindEntriesByTag(string input)
        {
            string sql = StringCollection.caseTag;
            var data = Datatable.GetDataTable(sql, "@input", input, "@limit", MaxEntries.ToString());
            return data;
        }

        public static DataTable FindEntriesByTenant(string input)
        {
            string sql = StringCollection.caseTenant;
            var data = Datatable.GetDataTable(sql, "@input", input, "@limit", MaxEntries.ToString());
            return data;
        }

        public static DataTable ListTenantsAt(string input)
        {
            string sql = StringCollection.caseTenantsAt;
            var data = Datatable.GetDataTable(sql, "@input", input, "@limit", MaxEntries.ToString());
            return data;
        }

        public static void LogEntry(string Time, string IDTag, string IDAction, string IDDoor, string IDCode)
        {
            string sql = StringCollection.caseLogEntry;

            string taggId = FindEntry.TaggID(IDTag);
            string actionId = FindEntry.ActionID(IDAction);
            string doorId = FindEntry.DoorID(IDDoor);
            string codeId = FindEntry.CodeID(IDCode);

            Datatable.GetDataTable(sql, "@Time", Time, "@IDTag", taggId, "@IDAction", actionId, "@IDDoor", doorId, "@IDCode", codeId);
        }  
    }
}