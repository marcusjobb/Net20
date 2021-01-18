namespace HFAB
{
    internal static class Program
    {
        private static void Main()
        {
            // Tillkallar metod som kollar ifall databasen finns. Om inte skapar den en samt allt innehåll(tables och rows).
            DBHandler.InitiateDatabase();

            //Skapar en variabel/objekt/instans av DorrEventsLog();
            var events = new DoorEventsLog();

            //Tillkallar metod som tar emot UserInputs.
            InputOutput.UserInput(events);
        }
    }
}