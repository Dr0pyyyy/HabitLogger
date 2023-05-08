using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

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
                        try
                        {
                            Console.Write("Insert ID of item you want to update: ");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Insert start of your sleep:");
                            DateTime UpdatedSleepStartDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Insert end of your sleep:");
                            DateTime UpdatedSleepEndDate = Convert.ToDateTime(Console.ReadLine());
                            db.UpdateData(UpdatedSleepStartDate, UpdatedSleepEndDate);
                        }
                        catch { 
                            Console.WriteLine("Wrong input! Date format is following: MM/DD/YYYY hh:mm:ss"); //TODO instead of cw learn to use Ilogger
                        }
                        break;
                    case "D":
                        Console.Write("Please type ID of item you want to delete: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        db.DeleteData(id);
                        break;
                    case "I":
                        try
                        {
                            Console.Write("Insert start of your sleep:");
                            DateTime SleepStartDate = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Insert end of your sleep:");
                            DateTime SleepEndDate = Convert.ToDateTime(Console.ReadLine());
                            db.InsertNewRecord(SleepStartDate, SleepEndDate);
                        }
                        catch
                        {
                            Console.WriteLine("Wrong input! Date format is following: MM/DD/YYYY hh:mm:ss"); //TODO instead of cw learn to use Ilogger
                        }
                        break;
                    case "V":
                        db.ViewDatabase();
                        break;
                    case "S":
                        db.ShowMenu();
                        break;
                    case "0":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error: Invalid input!"); //TODO instead of cw learn to use Ilogger
                        break;
                }
            }
        }
    }
}
