using LifemakersArchives.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifemakersArchives.Controllers
{
    class campaignsControllers
    {
        public static DataTable Get()
        {
            return Connectiondb.Command($"SELECT Id as م, Name as الاسم ,Date as التاريخ, (Format(StartTime,\"Short Time\")) as من,(Format(EndTime,\"Short Time\"))  as الي ,(DateDiff(\"n\",StartTime,EndTime) \\ 60 & Format(DateDiff(\"n\",StartTime, EndTime) Mod 60, \"\\:00\")) as المدة FROM campaigns ");
        }



        public static int lastId()
        {
            int lastID = 0;

            DataTable dataTable = Connectiondb.Command($"SELECT TOP 1 Id from  campaigns ORDER BY Id desc");
            if (dataTable.Rows.Count != 0)
            {
                lastID = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return lastID;
        }
        public static bool AddData(string Name, DateTime Date, DateTime StartTime, DateTime EndTime, List<int> team,DataTable dataTableEx)
        {
            int id =  lastId() + 1;

            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region Insert campaigns
                string str = $"Insert Into campaigns ([Id],[Name],[Date],StartTime,EndTime) Values (@Id,@Name,@Date,@StartTime,@EndTime)";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);

                oleDbCommand.Parameters.AddWithValue("@Id", id);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@StartTime", StartTime);
                oleDbCommand.Parameters.AddWithValue("@EndTime", EndTime);

                oleDbCommand.ExecuteNonQuery();
                #endregion

                #region Insert team
                foreach (var item in team)
                    co_TeamControllers.AddData(id, "campaigns", item, Connectiondb.Con, oleDbTransaction);

                #endregion

                #region Insert Ex

                foreach (DataRow item in dataTableEx.Rows)
                    ExceptionsControllers.AddData(item[0].ToString(), item[1].ToString(), "campaigns", id, Connectiondb.Con, oleDbTransaction);

                #endregion
                oleDbTransaction.Commit();
                Connectiondb.Con_Close();
                return true;

            }
            catch (Exception)
            {
                oleDbTransaction.Rollback();
                return false;
            }

        }
        public static bool UpData(int Id, string Name, DateTime Date, DateTime StartTime, DateTime EndTime, List<int> list)
        {
            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region UPDATE opposed
                string str = $"UPDATE campaigns SET Name=@Name,[Date]=@Date,StartTime=@StartTime,EndTime=@EndTime  WHERE[Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                 oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@StartTime", StartTime);
                oleDbCommand.Parameters.AddWithValue("@EndTime", EndTime);
                oleDbCommand.ExecuteNonQuery();
                #endregion
                #region Insert team
                if (campaignsFormControllers.team)
                    foreach (var item in list)
                        co_TeamControllers.AddData(Id, "campaigns", item, Connectiondb.Con, oleDbTransaction);
                #endregion

                
                oleDbTransaction.Commit();

                Connectiondb.Con_Close();
                return true;
            }
            catch (Exception)
            {
                oleDbTransaction.Rollback();
                return false;
            }

        }
        public static bool Delete(int Id)
        {
            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                string str = $"Delete From campaigns  WHERE [Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.ExecuteNonQuery();
                co_TeamControllers.Delete(Id, "campaigns", Connectiondb.Con, oleDbTransaction);
                oleDbTransaction.Commit();
                Connectiondb.Con.Close();
                return true;
            }
            catch (Exception)
            {
                oleDbTransaction.Rollback();
                Connectiondb.Con.Close();
                return false;
            }
        }

    }
}
