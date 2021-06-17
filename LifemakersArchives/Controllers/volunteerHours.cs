using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace LifemakersArchives.Controllers
{
    public class volunteerHours
    {
        public static DataTable Get(string Table)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("n", typeof(int));

            DataTable SumdataTable = new DataTable();
            SumdataTable.Columns.Add("الاسم", typeof(string));
            SumdataTable.Columns.Add("وقت التطوع", typeof(string));
             
                DataTable data = Connectiondb.Command("SELECT HR.Name,Sum(DateDiff(\"n\",[StartTime],[EndTime])) AS Minutes  FROM HR INNER JOIN (" + Table + " INNER JOIN co_Team ON " + Table + ".Id = co_Team.Id) ON HR.Id = co_Team.IdName GROUP BY HR.Name, co_Team.TypeTB HAVING (co_Team.TypeTB=\"" + Table + "\")");
                foreach (DataRow dr in data.Rows)
                {
                    DataRow drdt = dataTable.NewRow();
                    drdt[0] = dr[0];
                    drdt[1] = dr[1];
                    dataTable.Rows.Add(drdt);
                }
           

            var da = (from a in dataTable.AsEnumerable()
                      group a by a.Field<string>("Name") into g
                      select new
                      {
                          Name = g.Key,
                          n = g.Sum(x => x.Field<int>("n")),
                      });

            foreach (var item in da)
            {
                DataRow dr = SumdataTable.NewRow();
                TimeSpan ts = TimeSpan.FromMinutes(item.n);

                dr[0] = item.Name;
                dr[1] = (string)new DateTime(ts.Ticks).ToString("HH:mm");
                SumdataTable.Rows.Add(dr);

            }
            return SumdataTable;
        }

        public static DataTable Get(string[] Table)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("n", typeof(int));

            DataTable SumdataTable = new DataTable();
            SumdataTable.Columns.Add("الاسم", typeof(string));
            SumdataTable.Columns.Add("وقت التطوع", typeof(string));
            foreach (var item in Table)
            {
                DataTable data = Connectiondb.Command("SELECT HR.Name,Sum(DateDiff(\"n\",[StartTime],[EndTime])) AS Minutes  FROM HR INNER JOIN (" + item + " INNER JOIN co_Team ON " + item + ".Id = co_Team.Id) ON HR.Id = co_Team.IdName GROUP BY HR.Name, co_Team.TypeTB HAVING (co_Team.TypeTB=\"" + item + "\")");
                foreach (DataRow dr in data.Rows)
                {
                    DataRow drdt = dataTable.NewRow();
                    drdt[0] = dr[0];
                    drdt[1] = dr[1];
                    dataTable.Rows.Add(drdt);
                }
            }

          var  da =   (from a in dataTable.AsEnumerable()
            group a by a.Field < string >("Name") into g
            select new
            {
                Name =g.Key,
                n = g.Sum(x => x.Field<int>("n")),
            });

            foreach (var item in da)
            {
                DataRow dr = SumdataTable.NewRow();
                TimeSpan ts = TimeSpan.FromMinutes(item.n);

                dr[0] = item.Name;
                dr[1] = (string)new DateTime(ts.Ticks).ToString("HH:mm");
                SumdataTable.Rows.Add(dr);

            }
            return SumdataTable;
        }

        public static DataTable Get(string[] Table,string name)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("n", typeof(int));

            DataTable SumdataTable = new DataTable();
            SumdataTable.Columns.Add("Name", typeof(string));
            SumdataTable.Columns.Add("n", typeof(string));
            foreach (var item in Table)
            {
                DataTable data = Connectiondb.Command("SELECT HR.Name, Sum(DateDiff(\"n\",[StartTime],[EndTime])) AS Minutes  FROM HR INNER JOIN (" + item + " INNER JOIN co_Team ON " + item + ".Id = co_Team.Id) ON HR.Id = co_Team.IdName GROUP BY HR.Name, co_Team.TypeTB HAVING (co_Team.TypeTB=\"" + item + "\" and HR.Name=\"" + name + "\" )");
                foreach (DataRow dr in data.Rows)
                {
                    DataRow drdt = dataTable.NewRow();
                    drdt[0] = dr[0];
                    drdt[1] = dr[1];
                    dataTable.Rows.Add(drdt);
                }
            }

            var da = (from a in dataTable.AsEnumerable()
                      group a by a.Field<string>("Name") into g
                      select new
                      {
                          Name = g.Key,
                           n = g.Sum(x => x.Field<int>("n")),
                      });

            foreach (var item in da)
            {
                DataRow dr = SumdataTable.NewRow();
                TimeSpan ts = TimeSpan.FromMinutes(item.n);

                dr[0] = item.Name;
                dr[1] = (string)new DateTime(ts.Ticks).ToString("HH:mm");
                SumdataTable.Rows.Add(dr);

            }
            return SumdataTable;
         }
    }
}