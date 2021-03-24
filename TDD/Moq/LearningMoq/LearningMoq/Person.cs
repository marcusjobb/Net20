using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMoq
{
    public interface IPerson
    {
        DateTime BirthDate { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
