using System;

namespace Football.MigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new SearchAndPopulateMigration();

            a.Execute();
        }
    }
}
