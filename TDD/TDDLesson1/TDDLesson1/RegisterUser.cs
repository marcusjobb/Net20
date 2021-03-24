using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDLesson1
{
    public class RegisterUser
    {
        public bool IsPasswordValid(string password)
        {
            // Regler
            // 1 - De ska vara längre än 7 tecken
            if (password.Length < 7) return false;
            // 2 - Får inte vara längre än 50 tecken
            if (password.Length > 50) return false;
            // 3 - Måste innehålla siffror
            // 4 - Måste innehålla Versal
            // 5 - Måste innehålla gemen
            // 6 - Måste innehålla specialtecken +-!%

            return true;
        }
    }
}
