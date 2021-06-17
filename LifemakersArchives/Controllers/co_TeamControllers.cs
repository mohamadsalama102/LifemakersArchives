using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifemakersArchives.Controllers
{
    class co_TeamControllers
    {
        public static DataTable GetIdName(int id, string TypeTB)
        {
            DataTable dt = new DataTable();
            string Command = $"SELECT IdName FROM co_Team  WHERE  Id = {id} AND TypeTB=\"{TypeTB}\"";
            Connectiondb.Con_Open();
            OleDbDataAdapter da = new OleDbDataAdapter(Command, Connectiondb.Con);
            da.Fill(dt);
            Connectiondb.Con_Close();
            return dt;
        }

        public static DataTable Get(int id,string TypeTB)
        {
            DataTable dt = new DataTable();
            string Command= $"SELECT h.Name as الاسم FROM HR h INNER JOIN co_Team t ON h.Id = t.IdName WHERE  t.Id = {id} AND t.TypeTB=\"{TypeTB}\"";
            Connectiondb.Con_Open();

            OleDbDataAdapter da = new OleDbDataAdapter(Command, Connectiondb.Con);            
            da.Fill(dt);

            Connectiondb.Con_Close();
            return dt;
        }

        public static bool AddData(int Id, string TypeTB,int HrId, OleDbConnection oleDbConnection, OleDbTransaction oleDbTransaction)
        {
            string str = $"Insert Into co_Team (Id,TypeTB,IdName) Values (@Id,@TypeTB,@IdName)";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);

            oleDbCommand.Parameters.AddWithValue("@Id", Id);
            oleDbCommand.Parameters.AddWithValue("@TypeTB", TypeTB);
            oleDbCommand.Parameters.AddWithValue("@IdName", HrId);    
            
            oleDbCommand.ExecuteNonQuery();
            
            return true;
        }
        public static bool UpData(int Id, string TypeTB, int HrId)
        {
            string str = $"UPDATE co_Team SET(TypeTB,Name) Values (@TypeTB,@Name) WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
             oleDbCommand.Parameters.AddWithValue("@TypeTB", TypeTB);
            oleDbCommand.Parameters.AddWithValue("@Name", HrId);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
        public static bool Delete(int Id, string TypeTB,int HrId,OleDbConnection oleDbConnection)
        {
            Connectiondb.Con.Open();
            string str = $"Delete From co_Team  WHERE Id = {Id} and TypeTB=\"{TypeTB}\" and IdName={HrId}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, oleDbConnection);
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
        public static bool Delete(int Id, string TypeTB, OleDbConnection oleDbConnection,OleDbTransaction oleDbTransaction)
        {
            string str = $"Delete From co_Team  WHERE Id = {Id} and TypeTB=\"{TypeTB}\"";
            OleDbCommand oleDbCommand = new OleDbCommand(str, oleDbConnection, oleDbTransaction);
            oleDbCommand.ExecuteNonQuery();
            return true;
        }

    }
}
