using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifemakersArchives.Controllers
{
    class HrControllers
    {
        public static DataTable Get()
        {
            return Connectiondb.Command($"Select Id as م, Name as الاسم ,(Format(Date,\"Short Date\")) as التاريخ,Email as [البريد الالكتروني],Facebook as [فيسبوك], Validity as فعال  From HR");
        }
        public static DataTable Get(int id)
        {
            return Connectiondb.Command($"Select Name From HR where Id ={id}");
        }
        public static int lastId()
        {
            int lastID = 0;

            DataTable dataTable = Connectiondb.Command($"SELECT TOP 1 Id from  HR ORDER BY Id desc");
            if (dataTable.Rows.Count != 0)
            {
                lastID = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return lastID;
        }

        public static bool AddData(string Name, DateTime Date ,string Email, string Facebook, bool Validity,ListBox listBox)
        {
            int id = lastId()+1;
            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region Insert HR
                string str = $"Insert Into HR ([Id],[Name],[Date],Email,Facebook,[Validity]) Values (@Id,@Name,@Date,@Email,@Facebook,@Validity)";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.Parameters.AddWithValue("@Id", id);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date.ToShortDateString());
                oleDbCommand.Parameters.AddWithValue("@Email", Email);
                oleDbCommand.Parameters.AddWithValue("@Facebook", Facebook);
                oleDbCommand.Parameters.AddWithValue("@Validity", Validity);
                oleDbCommand.ExecuteNonQuery();
                #endregion
                foreach (var item in listBox.Items)
                    HrPhoneControllers.AddData(id,item.ToString(), Connectiondb.Con, oleDbTransaction);
             
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

        public static bool UpData(int Id, string Name, DateTime Date, string Email, string Facebook, bool Validity)
        {
            Connectiondb.Con_Open();
            OleDbTransaction oleDbTransaction;
            OleDbCommand oleDbCommand;
            oleDbTransaction = Connectiondb.Con.BeginTransaction();
            try
            {
                #region UPDATE opposed
                string str = $"UPDATE HR SET Name=@Name,[Date]=@Date,Email=@Email,Facebook=@Facebook,Validity=@Validity  WHERE[Id] = {Id}";
                oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
                oleDbCommand.Parameters.AddWithValue("@Name", Name);
                oleDbCommand.Parameters.AddWithValue("@Date", Date);
                oleDbCommand.Parameters.AddWithValue("@Email", Email);
                oleDbCommand.Parameters.AddWithValue("@Facebook", Facebook);
                oleDbCommand.Parameters.AddWithValue("@Validity", Validity);
                oleDbCommand.ExecuteNonQuery();
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
            string str = $"Delete From HR  WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }

    }
}
