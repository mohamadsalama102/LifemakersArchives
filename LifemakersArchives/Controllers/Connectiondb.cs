using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifemakersArchives.Controllers
{

    class Connectiondb
    {
        public static OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=archives.accdb");
        public static void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        }
        public static void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con.Close();
            }
        }

        public static DataTable Command(string Command)
        {
            DataTable dt = new DataTable();

            try
            {
                Con_Open();
                OleDbDataAdapter da;
                da = new OleDbDataAdapter(Command, Connectiondb.Con);
                da.Fill(dt);
                 Con_Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }

        }

        public static bool Command(string Command,Dictionary<string, string> parameters)
        {
            Con_Open();
            OleDbCommand oleDbCommand = new OleDbCommand(Command, Con);
            if (parameters!=null)
            {
                foreach (var item in parameters)
                {
                    oleDbCommand.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
             oleDbCommand.ExecuteNonQuery();
            Con_Close();
            return true;
        }
        public static bool Command(string Command, OleDbConnection oleDbConnection, OleDbTransaction oleDbTransaction, Dictionary<string, string> parameters)
        {
             
            OleDbCommand oleDbCommand = new OleDbCommand(Command, oleDbConnection, oleDbTransaction);
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    oleDbCommand.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            oleDbCommand.ExecuteNonQuery();
           
            return true;
        }
    }
}
