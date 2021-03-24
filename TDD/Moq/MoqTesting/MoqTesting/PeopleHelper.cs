namespace MoqTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PeopleHelper : IPeopleHelper
    {
        public int GetAge(IPerson current) => (int)((DateTime.Now - current.BirthDate).Days / 365.25);
    }
}
