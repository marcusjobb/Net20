namespace PurchasesAltVer.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class InputHandler
    {
        internal static string[] HandleInput(string input)
        {
            string[] values = input.Trim().TrimEnd(',').Split(',');

            if (input.Length == 0) { return new string[] { "Inget data angavs" }; }
            else if (values.Length == 1) { return new string[] { "Vara och pris saknas" }; }
            else if (values.Length == 2) { return new string[] { "Pris saknas" }; }

            double.TryParse(values[2].Trim(), out double price);
            if (price == 0) { return new string[] { "Inget pris angavs" }; }

            var date = DateTime.Now;
            if (values.Length > 3)
            {
                DateTime.TryParse(values[3], out date);
                if (date == default) { return new string[] { "Delaktig datum" }; }
            }

            return new string[] { values[0], values[1], values[2], date.ToString("yyyy-MM-dd") };
        }
    }
}
