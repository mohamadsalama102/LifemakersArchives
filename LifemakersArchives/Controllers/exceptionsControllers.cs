using LifemakersArchives.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace LifemakersArchives.Controllers
{
    class ExceptionsControllers
    {
        /// <summary>
        /// كل التحديات
        /// </summary>
        /// <returns></returns>
        public static DataTable Get()
        {
            return Connectiondb.Command($"SELECT Id as م ,  Ex  as التحدي ,An as [كيفية الحل] FROM exceptions ");
        }
        /// <summary>
        /// تحديات مخصصة
        /// </summary>
        /// <param name="id">رقم السطر</param>
        /// <param name="TypeTB">اسم الجدول</param>
        /// <returns></returns>
        public static DataTable Get(string TypeTB)
        {
            return Connectiondb.Command($"SELECT Id as م, Ex  as التحدي ,An as [كيفية الحل] FROM exceptions WHERE TypeTB=\"{TypeTB}\" ");
        }
        public static DataTable Get(int id,string TypeTB)
        {
            return Connectiondb.Command($"SELECT Id as م, Ex  as التحدي ,An as [كيفية الحل] FROM exceptions WHERE TypeTB=\"{TypeTB}\"  and TypeId={id}");
        }
        public static DataTable Search(string text)
        {
            return Connectiondb.Command($"SELECT Id as م, Ex  as التحدي ,An as [كيفية الحل] FROM exceptions WHERE Ex like %\"{text}\"% or An like %\"{text}\"% ");
        }
        public static bool AddData(string Ex, string An, string TypeTB, int TypeId)
        {
            Connectiondb.Con_Open();

            string str = $"Insert Into exceptions (Ex,An,TypeTB,TypeId) Values (@Ex,@An,@TypeTB,@TypeId)";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.Parameters.AddWithValue("@Ex", Ex);
            oleDbCommand.Parameters.AddWithValue("@An", An);
            oleDbCommand.Parameters.AddWithValue("@TypeTB", TypeTB);
            oleDbCommand.Parameters.AddWithValue("@TypeId", TypeId);

            oleDbCommand.ExecuteNonQuery();

            Connectiondb.Con_Close();

            return true;
        }

        public static bool AddData(string Ex, string An, string TypeTB, int TypeId, OleDbConnection oleDbConnection, OleDbTransaction oleDbTransaction)
        {
            string str = $"Insert Into exceptions (Ex,An,TypeTB,TypeId) Values (@Ex,@An,@TypeTB,@TypeId)";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con, oleDbTransaction);
            
            oleDbCommand.Parameters.AddWithValue("@Ex", Ex);
            oleDbCommand.Parameters.AddWithValue("@An", An);
            oleDbCommand.Parameters.AddWithValue("@TypeTB", TypeTB);
            oleDbCommand.Parameters.AddWithValue("@TypeId", TypeId);

            oleDbCommand.ExecuteNonQuery();

            return true;
        }

        public static bool UpData(int Id, string Ex, string An)
        {
            Connectiondb.Con.Open();
            string str = $"UPDATE exceptions SET Ex=@Ex,An=@An WHERE [Id] = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);

            oleDbCommand.Parameters.AddWithValue("@Ex", Ex);
            oleDbCommand.Parameters.AddWithValue("@An", An);
          
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }
 
        public static bool Delete(int Id)
        {
            Connectiondb.Con.Open();
            string str = $"Delete From exceptions  WHERE Id = {Id}";
            OleDbCommand oleDbCommand = new OleDbCommand(str, Connectiondb.Con);
            oleDbCommand.ExecuteNonQuery();
            Connectiondb.Con.Close();
            return true;
        }

    }
}
