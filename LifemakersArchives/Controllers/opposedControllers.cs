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
    class opposedControllers
    {
        public static DataTable Get()
        {
            return Connectiondb.Command($"SELECT Id as م, Name as الاسم, Date as التاريخ, AllAmount as وارد, Amount as صافي, QualityClothes as  الجودة , Des as وصف , Validity as الصلاحية  FROM opposed");
        }
        public static int lastID()
        {
            int lastID=0;

            DataTable dataTable = Connectiondb.Command($"SELECT TOP 1 Id from  opposed ORDER BY Id desc");
            if (dataTable.Rows.Count!=0)
            {
                lastID = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return lastID;
         }
        public static DataTable GetTeam(int id)
        {
            return co_TeamControllers.Get(id, "opposed");
        }
        public static bool AddData(string Name,DateTime Date, double AllAmount, double Amount,string Challenges,string QualityClothes, bool Validity,List<int> list)
        {
            int id = Controllers.opposedControllers.lastID() + 1;

            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region Insert opposed
                string str = $"Insert Into opposed ([Id],[Name],[Date],AllAmount,Amount,Des,QualityClothes,[Validity]) Values (@Id,@Name,@Date,@AllAmount,@Amount,@Des,@QualityClothes,@Validity)";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.Parameters.AddWithValue("@Id", id);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@AllAmount", AllAmount);
                oleDbCommand.Parameters.AddWithValue("@Amount", Amount);
                oleDbCommand.Parameters.AddWithValue("@Des", Challenges);
                oleDbCommand.Parameters.AddWithValue("@QualityClothes", QualityClothes);
                oleDbCommand.Parameters.AddWithValue("@Validity", Validity);
                oleDbCommand.ExecuteNonQuery();
                #endregion

                #region Insert team
                foreach (var item in list)
                    co_TeamControllers.AddData(id, "opposed", item, Connectiondb.Con, oleDbTransaction);

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
        public static bool UpData(int Id,string Name, DateTime Date, double AllAmount, double Amount, string Des, string QualityClothes, bool Validity, List<int> list)
        {
            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region UPDATE opposed
                string str = $"UPDATE opposed SET Name=@Name,[Date]=@Date,AllAmount=@AllAmount,Amount=@Amount,Des=@Des,QualityClothes=@QualityClothes,Validity=@Validity  WHERE[Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@AllAmount", AllAmount);
                oleDbCommand.Parameters.AddWithValue("@Amount", Amount);
                oleDbCommand.Parameters.AddWithValue("@Des", Des);
                oleDbCommand.Parameters.AddWithValue("@QualityClothes", QualityClothes);
                oleDbCommand.Parameters.AddWithValue("@Validity", Validity);
                oleDbCommand.ExecuteNonQuery();
                #endregion
                #region Insert team
                if (opposedFormControllers.team)
                {
                    foreach (var item in list)
                        co_TeamControllers.AddData(Id, "opposed", item, Connectiondb.Con, oleDbTransaction);
                 
                }
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
                 string str = $"Delete From opposed  WHERE [Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.ExecuteNonQuery();
                co_TeamControllers.Delete(Id, "opposed", Connectiondb.Con, oleDbTransaction);
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
