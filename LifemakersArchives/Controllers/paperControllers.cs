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
    class paperControllers
    {
        public static DataTable Get()
        {
            return Connectiondb.Command($"SELECT Id as م, Name as الاسم, Date as التاريخ, Amount as وارد, Des as وصف FROM sills");
        }
        public static int lastID()
        {
            int lastID = 0;

            DataTable dataTable = Connectiondb.Command($"SELECT TOP 1 Id from  sills ORDER BY Id desc");
            if (dataTable.Rows.Count != 0)
            {
                lastID = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return lastID;
        }
        public static DataTable GetTeam(int id)
        {
            return co_TeamControllers.Get(id, "sills");
        }
        public static bool AddData(string Name, DateTime Date, double Amount, string Des, List<int> list)
        {
            int id = lastID() + 1;

            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region Insert sills
                string str = $"Insert Into sills ([Id],[Name],[Date],Amount,Des) Values (@Id,@Name,@Date,@Amount,@Des)";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.Parameters.AddWithValue("@Id", id);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@Amount", Amount);
                oleDbCommand.Parameters.AddWithValue("@Des", Des);
                oleDbCommand.ExecuteNonQuery();
                #endregion

                #region Insert team

                foreach (var item in list)
                    co_TeamControllers.AddData(id, "sills", item, Connectiondb.Con, oleDbTransaction);


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
        public static bool UpData(int Id, string Name, DateTime Date, double Amount, string Des, List<int> list)
        {
            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region UPDATE sills
                string str = $"UPDATE sills SET [Name]=@Name,[Date]=@Date,Amount=@Amount,Des=@Des WHERE[Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@Amount", Amount);
                oleDbCommand.Parameters.AddWithValue("@Des", Des);
                oleDbCommand.ExecuteNonQuery();
                #endregion
                #region Insert team
                if (sillsFormControllers.team)
                {
                    foreach (var item in list)
                        co_TeamControllers.AddData(Id, "sills", item, Connectiondb.Con, oleDbTransaction);

                }
                #endregion

                oleDbTransaction.Commit();
                Connectiondb.Con_Close();
                return true;
            }
            catch (Exception ex)
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

                string str = $"Delete From sills  WHERE [Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.ExecuteNonQuery();
                co_TeamControllers.Delete(Id, "sills", Connectiondb.Con, oleDbTransaction);
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
