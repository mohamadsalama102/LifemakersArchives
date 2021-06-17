using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifemakersArchives.Controllers
{
    class HrPhoneControllers
    {

        public static DataTable Get(int IdHr)
        {
            return Connectiondb.Command($"Select * From hrPhone where IdHr ={IdHr}");
        }

        public static bool AddData(int IdHr, string Phone, OleDbConnection oleDbConnection, OleDbTransaction oleDbTransaction)
        {
            string str = $"Insert Into hrPhone (IdHr,Phone) Values (@IdHr,@Phone)";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);

            oleDbCommand.Parameters.AddWithValue("@IdHr", IdHr);
            oleDbCommand.Parameters.AddWithValue("@Phone", Phone);
 
            oleDbCommand.ExecuteNonQuery();

            return true;
        }

        public static bool UpData(int Id, string Phone, OleDbConnection oleDbConnection)
        {
            string str = $"UPDATE hrPhone SET Phone=@Phone WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.Parameters.AddWithValue("@Phone", Phone);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
 
        public static bool Delete(int Id)
        {
            string str = $"Delete From hrPhone  WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }


    }
}
