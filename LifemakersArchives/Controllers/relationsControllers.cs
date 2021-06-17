using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifemakersArchives.Controllers
{
    class relationsControllers
    {
        public static DataTable Get()
        {
            return Connectiondb.Command($"SELECT Id as م, Name as الاسم ,[Date] as التاريخ,Amount  as وارد FROM relations ");
        }

        public static bool AddData(string Name, DateTime Date, Double Amount)
        {
            string str = $"Insert Into relations (Name,[Date],Amount) Values (@Name,@Date,@Amount)";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);

            oleDbCommand.Parameters.AddWithValue("@Name", Name);
            oleDbCommand.Parameters.AddWithValue("@Date", Date);
            oleDbCommand.Parameters.AddWithValue("@Amount", Amount);

            Connectiondb.Con.Open();

            oleDbCommand.ExecuteNonQuery();

            Connectiondb.Con.Close();

            return true;
        }

        public static bool UpData(int Id, string Name, DateTime Date, Double Amount)
        {
            string str = $"UPDATE relations SET  Name=@Name,[Date]=@Date,Amount=@Amount WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.Parameters.AddWithValue("@Name", Name);
            oleDbCommand.Parameters.AddWithValue("@Date", Date);
            oleDbCommand.Parameters.AddWithValue("@Amount", Amount);
            Connectiondb.Con.Open();
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }

        public static bool Delete(int Id)
        {
            Connectiondb.Con.Open();
            string str = $"Delete From relations  WHERE Id = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }

    }
}
