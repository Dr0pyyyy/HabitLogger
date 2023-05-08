using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    internal class DB
    {
        public SqlConnection Connection { get; set; }
        public string ConnectionString { get; set; }
        public int ItemID { get; set; }

        public DB() {
            ConnectionString = "Data Source=DESKTOP-NJS96BC\\MSSQLSERVER01;Initial Catalog=test;Integrated Security=SSPI;MultipleActiveResultSets=true;";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            Console.WriteLine("Database loaded successfully!"); //TODO instead of cw learn to use Ilogger
            Connection.Close();
            GetID();
        }

        public void ShowMenu()
        {
            Console.WriteLine(
                "------------------------\n" +
                "Input your command\n" +
                "\n" +
                "\n" +
                "U to update hours\n" +
                "D to delete date\n" +
                "I to insert date\n" +
                "V to view data\n" +
                "S to show menu\n" +
                "0 to exit\n" +
                "------------------------"
            );
        }

        public void InsertNewRecord(DateTime sleepStartDate, DateTime sleepEndDate) {
            Connection.Open();
            ItemID = ItemID + 1;
            string data = string.Format("INSERT INTO SleepSchedule VALUES('{0}','{1}','{2}','{3}')", ItemID, sleepStartDate, sleepEndDate, (24-(sleepStartDate.Hour-sleepEndDate.Hour))); //3. hodnotu dopočítat
            SqlCommand cmd = new SqlCommand(data, Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            Console.WriteLine("Value inserted successufully!");  //TODO instead of cw learn to use Ilogger
        }

        public void ViewDatabase() {
            string output = "-----------------------------------------------------------------------------------------------------\n" +
                            "ID                 Sleep start date                   Sleep end date                   Hours of sleep\n" +
                            "-----------------------------------------------------------------------------------------------------\n";
            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SleepSchedule", Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output += reader.GetValue(0) + "                ";
                output += reader.GetValue(1) + "               ";
                output += reader.GetValue(2) + "                      ";
                output += reader.GetValue(3);
                output += "\n-----------------------------------------------------------------------------------------------------\n";
            }
            Connection.Close();
            reader.Close();
            Console.WriteLine(output); //TODO instead of cw learn to use Ilogger
        }

        public void DeleteData(int id) {
            Connection.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT ID FROM SleepSchedule", Connection);
            SqlDataReader reader = cmdSelect.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader.GetValue(0)) == id)
                {
                    SqlCommand cmdDelete = new SqlCommand(string.Format("DELETE FROM SleepSchedule WHERE ID='{0}'", id), Connection);
                    cmdDelete.ExecuteNonQuery();
                }
            }
            Connection.Close();
            reader.Close();
            Console.WriteLine("Data deleted successfully!"); //TODO instead of cw learn to use Ilogger
        }

        public void UpdateData(DateTime sleepStartDate, DateTime sleepEndDate) {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE SleepSchedule SET SleepStartDate = '{0}', SleepEndDate = '{1}' WHERE ID = 'aaaa'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            Console.WriteLine("Data updated successfully!"); //TODO instead of cw learn to use Ilogger
        }

        private void GetID() {
            Connection.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT TOP 1 * FROM SleepSchedule ORDER BY ID DESC", Connection);
            SqlDataReader reader = cmdSelect.ExecuteReader();
            while(reader.Read())
            {
                ItemID = Convert.ToInt32(reader.GetValue(0));
            }
            Connection.Close();
            reader.Close();
        }
    }
}
