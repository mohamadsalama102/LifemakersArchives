using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifemakersArchives.Controllers
{
  public  class ExportData
    {
        public class ExportExcel
        {
            public static void select(DataGridView dataGridView)
            {

                try
                {
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)Excel.ActiveSheet;
                    Excel.Visible = false;

                    // Add Header
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                        ws.Cells[1, 1 + i] = dataGridView.Columns[i].HeaderText;
                    // Add Rows
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                        ws.Cells[2, 1 + i] = dataGridView.CurrentRow.Cells[i].Value;
                    Excel.Visible = true;
                }
                catch (Exception)
                {

                }

            }
            public static void all(DataGridView dataGridView)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)Excel.ActiveSheet;
                    Excel.Visible = false;
                    // Add Header
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                        ws.Cells[1, 1 + i] = dataGridView.Columns[i].HeaderText;
                    // Add Rows
                    for (int j = 0; j < dataGridView.Rows.Count; j++)
                        for (int i = 1; i <= dataGridView.Columns.Count; i++)
                            ws.Cells[j + 2, i] = dataGridView.Rows[j].Cells[i - 1].Value;
                    Excel.Visible = true;

                }
                catch (Exception)
                {


                }

            }
        }
    }
}
