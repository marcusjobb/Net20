using System;
using System.Collections.Generic;
using System.Linq;

namespace HFABEF.Helper
{
    public static class Seeder
    {
        /// <summary>
        /// Metod som lägger in objekt (data) in i alla tabeller som skapats för databasen (Förutom Logs).
        /// </summary>
        public static void TablesInsert()
        {
            using var db = new Database.MyDatabase();

            db.Door_Explanation.AddRange(DoorExplanations);
            db.Doors.AddRange(Doors);
            db.Event.AddRange(EventExplanations);
            db.Tenants.AddRange(Tenants);
            db.Tenants_Info.AddRange(TenantsInfo);

            db.SaveChanges();
        }
        /// <summary>
        /// Metod som slumpgenererar och matar in data in i logs tabellen
        /// </summary>
        public static void LogsInsert()
        {
            Random rnd = new Random();
            using var db = new Database.MyDatabase();

            for (int pos = 0; pos < 200; pos++)
            {
                db.Add(new Models.Logs
                {
                    Date = RandomDate(rnd),
                    Door = db.Doors.ToList()[rnd.Next(0, db.Doors.Count() )], // slumpar rader från tabellen Doors i databasen
                    Event = db.Event.ToList()[rnd.Next(0, db.Event.Count())],
                    Tenant = db.Tenants.ToList()[rnd.Next(0, db.Tenants.Count())]
                });
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Metod som skapar ett slumpdatum till LogsInsert()
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        public static string RandomDate(Random rnd) // Tar med instansen av rnd som parameter. Har inte kollat så att det fungerar som intended.
        {
            var year = 2018 + rnd.Next(2);
            var month = rnd.Next(1, 13);
            var day = rnd.Next(1, 28);
            var hour = rnd.Next(1, 23);
            var minute = rnd.Next(1, 59);
            var second = rnd.Next(1, 59);

            var date = new DateTime(year, month, day, hour, minute, second).ToString("yyyy-MM-dd HH:mm:ss");

            return date;
        }

        public static List<Models.Door_Explanation> DoorExplanations = new List<Models.Door_Explanation>()
        {
            new Models.Door_Explanation { Door_Name = "LGH0101", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0101", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "LGH0102", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0102", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "LGH0103", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0103", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "LGH0201", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0201", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "LGH0202", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0202", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "LGH0301", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0301", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "LGH0302", Explanation = "Dörr till lägenhet" },
            new Models.Door_Explanation { Door_Name = "BLK0302", Explanation = "Dörr till Balkong" },
            new Models.Door_Explanation { Door_Name = "UT", Explanation = "Dörr ut mot gatan" },
            new Models.Door_Explanation { Door_Name = "Soprum", Explanation = "Dörr mot soprummet" },
            new Models.Door_Explanation { Door_Name = "Tvätt", Explanation = "TVÄTT" },
            new Models.Door_Explanation { Door_Name = "VAKT", Explanation = "VAKT" },
        };

        public static List<Models.Doors> Doors = new List<Models.Doors>()
        {
            new Models.Doors { Door = "LGH0101", Location = "0101"},
            new Models.Doors { Door = "BLK0101", Location = "0101"},
            new Models.Doors { Door = "LGH0102", Location = "0102"},
            new Models.Doors { Door = "BLK0102", Location = "0102"},
            new Models.Doors { Door = "LGH0103", Location = "0103"},
            new Models.Doors { Door = "BLK0103", Location = "0103"},
            new Models.Doors { Door = "LGH0201", Location = "0201"},
            new Models.Doors { Door = "BLK0201", Location = "0201"},
            new Models.Doors { Door = "LGH0202", Location = "0202"},
            new Models.Doors { Door = "BLK0202", Location = "0202"},
            new Models.Doors { Door = "LGH0301", Location = "0301"},
            new Models.Doors { Door = "BLK0301", Location = "0301"},
            new Models.Doors { Door = "LGH0302", Location = "0302"},
            new Models.Doors { Door = "BLK0302", Location = "0302"},
            new Models.Doors { Door = "UT", Location = "UT"},
            new Models.Doors { Door = "SOPRUM", Location = "SOPRUM"},
            new Models.Doors { Door = "TVÄTT", Location = "TVÄTT"},
            new Models.Doors { Door = "VAKT", Location = "0302"},
        };

        public static List<Models.Event> EventExplanations = new List<Models.Event>()
        {
            new Models.Event { Code= "DÖUT", Explanation= "Dörr har öppnats utifrån"},
            new Models.Event { Code= "DÖIN", Explanation= "Dörr har öppnats inifrån"},
            new Models.Event { Code= "FDIN", Explanation= "\"Fel dörr\" - Gäst har försökt öppna en dörr utan tillstånd (exempelvis fel lägenhet)"},
            new Models.Event { Code= "FDUT", Explanation= "\"Fel dörr\" - Person har försökt gå ut från en dörr där taggen inte tillåter (borde aldrig kunna ske)"},
        };

        public static List<Models.Tenants> Tenants = new List<Models.Tenants>()
        {
            new Models.Tenants { Tenant = "Liam Jönsson", Tag = "0101A", Location = "0101"},
            new Models.Tenants { Tenant = "Elias Petterson", Tag = "0102A", Location = "0102"},
            new Models.Tenants { Tenant = "Wilma Johansson", Tag = "0102B", Location = "0102"},
            new Models.Tenants { Tenant = "Alicia Sanchez", Tag = "0103A", Location = "0103", },
            new Models.Tenants { Tenant = "Aaron Sanchez", Tag = "0103B", Location = "0103"},
            new Models.Tenants { Tenant = "Olivia Erlander", Tag = "0201A", Location = "0201"},
            new Models.Tenants { Tenant = "William Erlander", Tag = "0201B", Location = "0201"},
            new Models.Tenants { Tenant = "Alexander Erlander", Tag = "0201C", Location = "0201"},
            new Models.Tenants { Tenant = "Astrid Erlander", Tag = "0201D", Location = "0201"},
            new Models.Tenants { Tenant = "Lucas Adolfsson", Tag = "0202A", Location = "0202"},
            new Models.Tenants { Tenant = "Ebba Adolfsson", Tag = "0202B", Location = "0202"},
            new Models.Tenants { Tenant = "Lilly Adolfsson", Tag = "0202C", Location = "0202"},
            new Models.Tenants { Tenant = "Ella Ahlström", Tag = "0301A", Location = "0301"},
            new Models.Tenants { Tenant = "Alma Alfredsson", Tag = "0301B", Location = "0301"},
            new Models.Tenants { Tenant = "Elsa Ahlström", Tag = "0301C", Location = "0301"},
            new Models.Tenants { Tenant = "Maja Ahlström", Tag = "0301D", Location = "0301"},
            new Models.Tenants { Tenant = "Noah Almgren", Tag = "0302A", Location = "0302"},
            new Models.Tenants { Tenant = "Adam Andersen", Tag = "0302B", Location = "0302"},
            new Models.Tenants { Tenant = "Kattis Backman", Tag = "0302C", Location = "0302"},
            new Models.Tenants { Tenant = "Oscar Chen", Tag = "0302D", Location = "0302"},
            new Models.Tenants { Tenant = "Vaktmästare", Tag = "VAKTO1", Location = "VAKT"}
        };

        public static List<Models.Tenants_Info> TenantsInfo = new List<Models.Tenants_Info>()
        {
            new Models.Tenants_Info { Name= "Liam Jönsson", Info = "Liam är en ung studerande kille som spenderar dagarna mest med att plugga, relaxar på puben nån gång då och då kommer hem vid 10 tiden när puben stängt pga Covid-19",},
            new Models.Tenants_Info { Name= "Elias Petterson", Info = "Elias och Wilma är ett äldre par som gärna spenderar kvällarna i lugn och ro och tittar på dokumentärer och drama på TV. Tyvärr är de båda äldre och kan ibland ha TV på lite för högt ljud.",},
            new Models.Tenants_Info { Name= "Wilma Johansson", Info = "Elias och Wilma är ett äldre par som gärna spenderar kvällarna i lugn och ro och tittar på dokumentärer och drama på TV. Tyvärr är de båda äldre och kan ibland ha TV på lite för högt ljud."},
            new Models.Tenants_Info { Name= "Alicia Sanchez", Info = "Alicia och Aaron är ett sydamerikanskt par som levt i Sverige sen 1970-talet. De festar gärna med sina grannar men är också väldigt noga med att respektera alla regler."},
            new Models.Tenants_Info { Name= "Aaron Sanchez", Info = "Alicia och Aaron är ett sydamerikanskt par som levt i Sverige sen 1970-talet. De festar gärna med sina grannar men är också väldigt noga med att respektera alla regler."},
            new Models.Tenants_Info { Name= "Olivia Erlander", Info = "Olivia och William har två barn, Alexander och Astrid. Alexander går på andra året i gymnasiet och Astrid är på sitt sista år i högstadiet. Föräldrarna arbetar heltid och är hemma på kvällarna, barnen har ett rikt liv och många vänner."},
            new Models.Tenants_Info { Name= "William Erlander", Info = "Olivia och William har två barn, Alexander och Astrid. Alexander går på andra året i gymnasiet och Astrid är på sitt sista år i högstadiet. Föräldrarna arbetar heltid och är hemma på kvällarna, barnen har ett rikt liv och många vänner."},
            new Models.Tenants_Info { Name= "Alexander Erlander", Info = "Olivia och William har två barn, Alexander och Astrid. Alexander går på andra året i gymnasiet och Astrid är på sitt sista år i högstadiet. Föräldrarna arbetar heltid och är hemma på kvällarna, barnen har ett rikt liv och många vänner."},
            new Models.Tenants_Info { Name= "Astrid Erlander", Info = "Olivia och William har två barn, Alexander och Astrid. Alexander går på andra året i gymnasiet och Astrid är på sitt sista år i högstadiet. Föräldrarna arbetar heltid och är hemma på kvällarna, barnen har ett rikt liv och många vänner."},
            new Models.Tenants_Info { Name= "Lucas Adolfsson", Info = "Lucas och Ebba är ett ungt par som nyligen blivit stolta föräldrar till söta lilla Lilly. Lucas arbetar som konsult, men arbetar mest hemifrån. Ebba arbetar som lärare men har föräldraledigt."},
            new Models.Tenants_Info { Name= "Ebba Adolfsson", Info = "Lucas och Ebba är ett ungt par som nyligen blivit stolta föräldrar till söta lilla Lilly. Lucas arbetar som konsult, men arbetar mest hemifrån. Ebba arbetar som lärare men har föräldraledigt."},
            new Models.Tenants_Info { Name= "Lilly Adolfsson", Info = "Lucas och Ebba är ett ungt par som nyligen blivit stolta föräldrar till söta lilla Lilly. Lucas arbetar som konsult, men arbetar mest hemifrån. Ebba arbetar som lärare men har föräldraledigt."},
            new Models.Tenants_Info { Name= "Ella Ahlström", Info = "Ella och Alma fann varandra efter Ellas skilsmässa, hon har två döttrar och Alma har nu blivit deras extra mamma. Ella arbetar som fastighetsmäklare och Alma arbetar som headhunter för konsulter inom IT. Då barnen är i tonåren klarar de sig själva när Ella och Alma går ut på restaurang eller på teatern."},
            new Models.Tenants_Info { Name= "Alma Alfredsson", Info = "Ella och Alma fann varandra efter Ellas skilsmässa, hon har två döttrar och Alma har nu blivit deras extra mamma. Ella arbetar som fastighetsmäklare och Alma arbetar som headhunter för konsulter inom IT. Då barnen är i tonåren klarar de sig själva när Ella och Alma går ut på restaurang eller på teatern."},
            new Models.Tenants_Info { Name= "Elsa Ahlström", Info = "Elsa och Maja är döttrar till Ella och Alma.  Alma har blivit deras styvmamma efter Ellas skillsmässa. Elsa och maja är tonåringar som klarar sig själva hemma"},
            new Models.Tenants_Info { Name= "Maja Ahlström", Info = "Elsa och Maja är döttrar till Ella och Alma.  Alma har blivit deras styvmamma efter Ellas skillsmässa. Elsa och maja är tonåringar som klarar sig själva hemma"},
            new Models.Tenants_Info { Name= "Noah Almgren", Info = "Noah, Adam, Kattis och Oscar är ett gäng pigga studenter som delar på en lägenhet. De studerar med olika inriktningar. Även om alla har sin bekantskapskrets separerad från gruppen så håller de ändå bra ihop tillsammans. De har ofta besök av sina vänner."},
            new Models.Tenants_Info { Name= "Adam Andersen", Info = "Noah, Adam, Kattis och Oscar är ett gäng pigga studenter som delar på en lägenhet. De studerar med olika inriktningar. Även om alla har sin bekantskapskrets separerad från gruppen så håller de ändå bra ihop tillsammans. De har ofta besök av sina vänner."},
            new Models.Tenants_Info { Name= "Kattis Backman", Info = "Noah, Adam, Kattis och Oscar är ett gäng pigga studenter som delar på en lägenhet. De studerar med olika inriktningar. Även om alla har sin bekantskapskrets separerad från gruppen så håller de ändå bra ihop tillsammans. De har ofta besök av sina vänner."},
            new Models.Tenants_Info { Name= "Oscar Chen", Info = "Noah, Adam, Kattis och Oscar är ett gäng pigga studenter som delar på en lägenhet. De studerar med olika inriktningar. Även om alla har sin bekantskapskrets separerad från gruppen så håller de ändå bra ihop tillsammans. De har ofta besök av sina vänner."},
            new Models.Tenants_Info { Name= "Vaktmästare", Info = "Vaktmästare för lägenhetområdet"},
        };
    }
}