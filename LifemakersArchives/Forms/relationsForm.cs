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
    public partial class relationsForm : Form
    {
        public relationsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = relationsControllers.Get();
            dataGridView1.Columns[0].Visible = false;
            sumAmount();
        }
        void sumAmount()
        {
            label1.Text = " مجموع الوارد :" + (from DataGridViewRow dr in dataGridView1.Rows where dr.Cells[3].FormattedValue.ToString() != string.Empty select Convert.ToDouble(dr.Cells[3].FormattedValue)).Sum().ToString();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            relationsFormControllers frm = new relationsFormControllers();
            frm.ShowDialog();
            dataGridView1.DataSource = relationsControllers.Get();
            sumAmount();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            relationsFormControllers frm = new relationsFormControllers();
            frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frm.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.dateTime.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            frm.txtAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.btn.Text = "تعديل";
            frm.ShowDialog();
            dataGridView1.DataSource = relationsControllers.Get();
            sumAmount();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            relationsControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            dataGridView1.DataSource = relationsControllers.Get();

            sumAmount();
        }

        private void btnExSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnExAll_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
