using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifemakersArchives.Controllers;
using Microsoft.Office.Interop.Excel;

namespace LifemakersArchives.Forms
{
    public partial class meetingsForm : Form
    {
        System.Data.DataTable dt;
        public meetingsForm()
        { 
            InitializeComponent();

            dt = meetingsControllers.Get();
            dataGridView1.DataSource = dt;

            //var dtt = new DataTable();
            //dtt.Columns.Add("المدة", typeof(TimeSpan));
            //foreach (DataRow item in dt.Rows)
            //{
            //    var dr = dtt.NewRow();
            //    dr["المدة"] = (TimeSpan)item[7];
            //    dtt.Rows.Add(dr);
            //}


            //var sum = (TimeSpan)dtt.Compute("Sum(المدة)", "");
            //label1.Text = string.Format("{0}:{1}:{2}", sum.TotalHours, sum.Minutes, sum.Seconds);

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var dataTable = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "meetings");
            foreach (DataRow item in dataTable.Rows)
                listBox1.Items.Add(item[0].ToString());

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            meetingsFormControlles frm = new meetingsFormControlles();

            frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frm.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.dateTime.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.startTime.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.endTime.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.txtIdeas.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm.txtDes.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm.btn.Text = "تعديل";
            frm.ShowDialog();
            dt = meetingsControllers.Get();
             dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف : " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                meetingsControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = meetingsControllers.Get();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            meetingsFormControlles frm = new meetingsFormControlles();
            frm.ShowDialog();
            dt = meetingsControllers.Get();
            dataGridView1.DataSource = dt;
        }

        private void btnExSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حفظ الفريق", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)Excel.ActiveSheet;
                    Excel.Visible = false;
                   
                    // Add Header
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        ws.Cells[1, 1 + i] = dataGridView1.Columns[i].HeaderText;
                    // Add Rows
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        ws.Cells[2, 1+i] = dataGridView1.CurrentRow.Cells[i].Value;
                    Excel.Visible = true;
                }
                else
                {
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)Excel.ActiveSheet;
                    Excel.Visible = false;
                    // Add Header
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        ws.Cells[1, 1 + i] = dataGridView1.Columns[i].HeaderText;
                    ws.Cells[1, dataGridView1.Columns.Count + 1] = "الفريق";
                    // Add Rows
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        ws.Cells[2, 1 + i] = dataGridView1.CurrentRow.Cells[i].Value;

                    string team = "";
                    var dataTable = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "meetings");
                    foreach (DataRow item in dataTable.Rows)
                        team += (item[0].ToString()) + ","; 
                    ws.Cells[2, dataGridView1.Columns.Count + 1] = team;
                    Excel.Visible = true;
                }
                MessageBox.Show("تم الحفظ");
            }
            catch { }
        }
           
        private void btnExAll_Click(object sender, EventArgs e)
        {

            try
            {

                if (MessageBox.Show("هل تريد حفظ الفريق", "", MessageBoxButtons.YesNo) == DialogResult.No)
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
                else
                {
                    Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)Excel.ActiveSheet;
                    Excel.Visible = false;
                    // Add Header
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        ws.Cells[1, 1 + i] = dataGridView1.Columns[i].HeaderText;
                    ws.Cells[1, dataGridView1.Columns.Count + 1] = "الفريق";
                    // Add Rows
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                            ws.Cells[j + 2, i] = dataGridView1.Rows[j].Cells[i - 1].Value;

                        // Add Team
                        string team = "";
                        
                        var dataTable = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.Rows[j].Cells[0].Value.ToString()), "meetings");
                        foreach (DataRow item in dataTable.Rows)
                            team += (item[0].ToString()) + ",";
                        ws.Cells[j + 2, dataGridView1.Columns.Count + 1] = team;
                    }

                    Excel.Visible = true;

                }
                MessageBox.Show("تم الحفظ");
            }
            catch { }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
