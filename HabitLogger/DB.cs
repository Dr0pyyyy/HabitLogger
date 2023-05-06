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

        public DB() {
            ConnectionString = "Data Source=DESKTOP-NJS96BC\\MSSQLSERVER01;Initial Catalog=test;Integrated Security=SSPI;";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            Console.WriteLine("Database loaded successfully!"); //TODO instead of cw learn to use Ilogger
            Connection.Close();
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

        public void InsertNewRecord() { 
            Connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tableTest VALUES('aaaa')", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            Console.WriteLine("Value inserted successufully!");  //TODO instead of cw learn to use Ilogger
        }

        public void ViewDatabase() {
            string output = "";
            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tableTest", Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                output += reader.GetValue(0);
            }
            Connection.Close();
            Console.WriteLine(output); //TODO instead of cw learn to use Ilogger
        }

        public void DeleteData() {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM tableTest WHERE column1='aaaa'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            Console.WriteLine("Data deleted successfully!"); //TODO instead of cw learn to use Ilogger
        }

        public void UpdateData() {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tableTest set column1 = 'adamececek' where column1 = 'aaaa'", Connection);
            cmd.ExecuteNonQuery();
            Connection.Close();
            Console.WriteLine("Data updated successfully!"); //TODO instead of cw learn to use Ilogger
        }
    }
}
