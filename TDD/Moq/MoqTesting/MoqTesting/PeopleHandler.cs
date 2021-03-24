namespace MoqTesting
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="PeopleHandler" />.
    /// </summary>
    public class PeopleHandler : IPeopleHandler
    {
        public List<IPerson> People { get; set; } = new List<IPerson>();

        public IPerson FindPerson(string name) => People.FirstOrDefault(p => p.Name == name);
    }
}
