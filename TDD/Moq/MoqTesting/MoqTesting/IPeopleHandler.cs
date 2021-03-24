using System.Collections.Generic;

namespace MoqTesting
{
    public interface IPeopleHandler
    {
        List<IPerson> People { get; set; }
        IPerson FindPerson(string name);
    }
}