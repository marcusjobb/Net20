using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqÖvning
{
public class Controller
{
    public void Index()
    {
        var view = new View();
        view.ShowQuestion();
        var input = Console.ReadLine();
        view.ShowResult(input.Length);
    }
}
}
