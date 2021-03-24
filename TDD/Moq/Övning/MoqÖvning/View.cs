using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqÖvning
{
public class View
{
    public void ShowQuestion()
    {
        Console.WriteLine("Ange ditt namn");
    }
    public void ShowResult(int length)
    {
        Console.WriteLine("Ditt namn har " + length + " bokstäver");
    }
}
}
