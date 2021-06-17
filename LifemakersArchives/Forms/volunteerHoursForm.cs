using LifemakersArchives.Controllers;
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
    public partial class volunteerHoursForm : Form
    {
        public volunteerHoursForm()
        {
            InitializeComponent();
        }
        string[] table = new string[] { "campaigns" , "meetings", "events" };

        private void btnExSelect_Click(object sender, EventArgs e)
        {
            ExportData.ExportExcel.select(dataGridView1);

        }

        private void btnExAll_Click(object sender, EventArgs e)
        {
            ExportData.ExportExcel.all(dataGridView1);

        }

        private void comboTable_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboChanged = false;
            if (comboTable.Text.ToString() == "الكل")
            {
                dataTable = volunteerHours.Get(table);
                dataGridView1.DataSource = dataTable;
            }
            else if (comboTable.Text.ToString() == "حملات")
            {
                dataTable = volunteerHours.Get(table[0]);
                dataGridView1.DataSource = dataTable;
            }
            else if (comboTable.Text.ToString() == "اجتماعات")
            {
                dataTable = volunteerHours.Get(table[1]);
                dataGridView1.DataSource = dataTable;
            }
            else if (comboTable.Text.ToString() == "مناسبات")
            {
                dataTable = volunteerHours.Get(table[2]);
                dataGridView1.DataSource = dataTable;
            }
            comboChanged = true;

        }
        bool comboChanged;
        DataTable dataTable;
        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = dataTable.DefaultView;
                dv.RowFilter = $" الاسم  like '%{txtSearch.Text}%'";
                dataGridView1.DataSource = new BindingSource(dv, null);
            }
            catch (Exception)
            {
             }
         }
    }
}
