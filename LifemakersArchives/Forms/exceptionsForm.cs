using LifemakersArchives.Controllers;
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

namespace LifemakersArchives.Forms
{
    public partial class exceptionsForm : Form
    {
        public exceptionsForm()
        {
            InitializeComponent();
            dataTable =  ExceptionsControllers.Get();
            dataGridView1.DataSource = ExceptionsControllers.Get();
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            exceptionsFormControllers frm = new exceptionsFormControllers();
            frm.ShowDialog();
            dataGridView1.DataSource = ExceptionsControllers.Get();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            exceptionsFormControllers frm = new exceptionsFormControllers();

            frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frm.txtEx.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtAn.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.btn.Text = "تعديل";

            frm.ShowDialog();

            dataGridView1.DataSource = ExceptionsControllers.Get();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            ExceptionsControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.DataSource = ExceptionsControllers.Get();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExAll_Click(object sender, EventArgs e)
        {
            ExportData.ExportExcel.all(dataGridView1);
        }

        private void btnExSelect_Click(object sender, EventArgs e)
        {
            ExportData.ExportExcel.select(dataGridView1);
        }

        private void comboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboChanged = false;
            if (comboTable.Text.ToString() == "الكل")
            {
                dataGridView1.DataSource = ExceptionsControllers.Get();
                dataTable =  ExceptionsControllers.Get();
                comboName.DataSource = null;
            }
            else if (comboTable.Text.ToString() == "حملات")
            {
                comboName.DataSource = campaignsControllers.Get();
                comboName.DisplayMember = "الاسم";
                comboName.ValueMember = "م";
                table = "campaigns";
                dataTable =   ExceptionsControllers.Get("campaigns");
                dataGridView1.DataSource = ExceptionsControllers.Get("campaigns");
            }
            else if (comboTable.Text.ToString() == "اجتماعات")
            {
                comboName.DataSource = meetingsControllers.Get();
                comboName.DisplayMember = "الاسم";
                comboName.ValueMember = "م";
                table = "meetings";
                dataTable =  ExceptionsControllers.Get("meetings");
                dataGridView1.DataSource = ExceptionsControllers.Get("meetings");
            }
            else if (comboTable.Text.ToString() == "مناسبات")
            {
                comboName.DataSource = eventsControllers.Get();
                comboName.DisplayMember = "الاسم";
                comboName.ValueMember = "م";
                table = "events";
                dataTable =   ExceptionsControllers.Get("events");
                dataGridView1.DataSource = ExceptionsControllers.Get("events");
            }
            comboChanged = true;

        }
        bool comboChanged;string table;
        private void comboName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboChanged)
            {
                dataTable = ExceptionsControllers.Get(Convert.ToInt32(comboName.SelectedValue.ToString()), table);
                dataGridView1.DataSource = ExceptionsControllers.Get(Convert.ToInt32(comboName.SelectedValue.ToString()), table);
            }
         }
        System.Data.DataTable dataTable;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = $" التحدي  like '%{textBox1.Text}%' or  [كيفية الحل]  like '%{textBox1.Text}%'";
                dataGridView1.DataSource = new BindingSource(dv, null);
            }
            catch (Exception ex)
            {
            }
        }

        private void exceptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
