namespace HFABEF
{
    public static class Program
    {
        /// <summary>
        /// main metoden i programmet som tillkallar CheckTables(läs mer i Models.DatabaseBootstrapper) och sedan Views.MyView.View()(läs mer i Views.MyView...)
        /// </summary>
        private static void Main()
        {
            Models.DatabaseBootstrapper.CheckTables();
            Views.MyView.View();
        }
    }
}