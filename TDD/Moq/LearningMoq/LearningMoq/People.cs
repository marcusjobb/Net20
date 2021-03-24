using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMoq
{
    public interface ICrowd
    {
        List<Person> People { get; set; }
        IPerson GetName(int pos);
        int GetAge(string name);
    }

    public class Crowd : ICrowd
    {
        public List<Person> People { get; set; } = new List<Person>();
        public int GetAge(string name) => (int)((DateTime.Now - People.FirstOrDefault(p => p.Name == name).BirthDate).TotalDays / 365.25);
        public IPerson GetName(int pos) => People[pos];
    }
}
