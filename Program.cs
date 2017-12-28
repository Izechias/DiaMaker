using System;
using System.Data.SqlClient;
using System.IO;

namespace DiaMaker
{
    using Sql;

    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("Persist Security Info=False;Integrated Security=true;Initial Catalog=CON003;server=.\\sqlserver2014");
            db = null;

            Console.WriteLine("Hello World!");
        }
    }
}
