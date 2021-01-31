namespace IU2_Test.Interfaces
{
    using IU2_Test.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface mallar för Output.cs
    /// Med parametrar som skall skickas ut.
    /// </summary>
    public interface IOutput
    {
        void OutputByTenant(string outTenant, List<Relation> data);
        void OutputByDoor(string outDoor, List<Relation> data);
        void OutputByLocation(string outLocation, List<Relation> data);
        void OutputByTag(string outTag, List<Relation> data);
        void OutputByEvent(string outEvent, List<Relation> data);
        void OutputListTenant(List<Relation> data);
    }
}
