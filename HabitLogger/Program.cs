using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HabitLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DB db = new DB();

            db.ShowMenu();

            while (true)
            {
                string userInput = Console.ReadLine();
                switch (userInput.ToUpper())
                {
                    case "U":
                        db.UpdateData();
                        break;
                    case "D":
                        db.DeleteData();
                        break;
                    case "I":
                        db.InsertNewRecord();
                        break;
                    case "V":
                        db.ViewDatabase();
                        break;
                    case "0":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error: Invalid input!"); //TODO instead of cw learn to use Ilogger
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
