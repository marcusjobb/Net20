using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentDBEF.Views;
using ApartmentDBEF.Database;

namespace ApartmentDBEF
{
    class Program
    {
        static void Main(string[] args)
        {
            FillTables.checkTables();
            Menu.MainMenu();
        }



    }
}


              


