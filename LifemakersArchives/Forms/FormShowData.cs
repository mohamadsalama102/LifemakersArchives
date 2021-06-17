using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifemakersArchives.Controllers
{
    public partial class FormShowData : Form
    {
        public FormShowData(System.Data.DataTable dataTable = null)
        {
            InitializeComponent();
            dataGridView1.DataSource = dataTable;
        }

        private void btnExSelect_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = false;

            // Add Header
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                ws.Cells[1, 1 + i] = dataGridView1.Columns[i].HeaderText;
            // Add Rows
            int j = 2;
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    ws.Cells[j, 1 + i] = item.Cells[i].Value.ToString();
                j++;
            }
            Excel.Visible = true;
        }

        private void btnExAll_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = false;
            // Add Header
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                ws.Cells[1, 1 + i] = dataGridView1.Columns[i].HeaderText;
             // Add Rows
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                    ws.Cells[j + 2, i] = dataGridView1.Rows[j].Cells[i - 1].Value;
            Excel.Visible = true;

        }

        private void btnQery_Click(object sender, EventArgs e)
        {
            if(txtQery.Text!=string.Empty)
                dataGridView1.DataSource = Connectiondb.Command(txtQery.Text);
        }
    }
}
