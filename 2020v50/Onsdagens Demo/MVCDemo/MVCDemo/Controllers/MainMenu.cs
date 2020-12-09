namespace MVCDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MainMenu
    {
        public MainMenu()
        {
            while (true)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Main menu")
                    .AppendLine("1) Name list")
                    .AppendLine("2) Car list")
                    .AppendLine("3) End");

                Views.MainMenu.Display(sb.ToString());

                var input = Console.ReadLine();
                if (input=="1")
                {
                    NameList.Run();
                }
                if (input  == "2")
                {
                    CarList.Run();
                }
                if (input == "3")
                {
                    return;
                }
            }
        }
    }
}
