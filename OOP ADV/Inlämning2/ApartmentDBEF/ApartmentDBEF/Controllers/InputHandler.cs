using ApartmentDBEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentDBEF.Controllers
{
    public class InputHandler
    {

        // Tar emot en sträng som skickas vidare till att delas upp och "trimmas", returneras sedan och delas upp ytterliggare i egna variabler.
        public static void HandleInputEvent(string input)
        {
            var split = HandleInputEventTrim(input);

            var Tag = split[0].Trim();
            var Action = split[1].Trim();
            var Door = split[2].Trim();
            var Code = split[3].Trim();
            DoorEventsLog.InsertEvent(Tag, Action, Door, Code);

        }

        // Tar emot en sträng och delar upp den till egna index-positioner i en array vid kommatecken samt tar bort andra tomrum.
        public static string[] HandleInputEventTrim(string input)
        {
            string[] values = input.Trim().TrimEnd(',').Split(',');

            return new string[] { values[0], values[1], values[2], values[3] };
        }

        // Tar emot en sträng som den delar upp, skalar och returnerar.
        public static string[] HandleInputMoveTenant(string input)
        {
            string[] values = input.TrimEnd(',').Split(',');

            return new string[] { values[0], values[1]};
        }





    }
}
