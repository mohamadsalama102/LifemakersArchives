using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifemakersArchives.Controllers
{
    class trainingControllers
    {
        public static DataTable Get()
        {
             return Connectiondb.Command($"Select Id as م,FacilitatorName as الاسم,checkTraining as تدرب From training");
        }
        public static int lastID()
        {
            int lastID = 0;

            DataTable dataTable = Connectiondb.Command($"SELECT TOP 1 Id from  training ORDER BY Id desc");
            if (dataTable.Rows.Count != 0)
            {
                lastID = Convert.ToInt32(dataTable.Rows[0][0])+1;
            }
            return lastID;
        }
        public static bool AddData(string Facilitator, bool Training)
        {
            int ID = lastID();
            string str = $"Insert Into training (Id,FacilitatorName,checkTraining) Values (@Id,@FacilitatorName,@checkTraining)";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.Parameters.AddWithValue("@Id", ID);
            oleDbCommand.Parameters.AddWithValue("@FacilitatorName", Facilitator);
            oleDbCommand.Parameters.AddWithValue("@checkTraining", Training);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
        public static bool UpData(int Id, string Facilitator, bool Training)
        {
            string str = $"UPDATE training SET  FacilitatorName=@FacilitatorName,checkTraining=@checkTraining  WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.Parameters.AddWithValue("@FacilitatorName", Facilitator);
            oleDbCommand.Parameters.AddWithValue("@checkTraining", Training);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
        public static bool Delete(int Id, string Facilitator, bool Training)
        {
            string str = $"Delete From training  WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
    }
}
