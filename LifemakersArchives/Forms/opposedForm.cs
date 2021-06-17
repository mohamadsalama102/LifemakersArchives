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
    public partial class opposedForm : Form
    {
        public opposedForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = opposedControllers.Get();
             sumAmount();
        }
 
        void sumAmount()
        {
            label1.Text = " مجموع الوارد :" +(from DataGridViewRow dr in dataGridView1.Rows where dr.Cells[3].FormattedValue.ToString() !=string.Empty select Convert.ToDouble(dr.Cells[3].FormattedValue)).Sum().ToString();

            label2.Text = "مجموع الصافي :" + (from DataGridViewRow dr in dataGridView1.Rows where dr.Cells[4].FormattedValue.ToString() != string.Empty select Convert.ToDouble(dr.Cells[4].FormattedValue)).Sum().ToString();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            opposedFormControllers frm = new opposedFormControllers();
            frm.ShowDialog();
            dataGridView1.DataSource = opposedControllers.Get();
            sumAmount();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            opposedFormControllers frm = new opposedFormControllers();

            frm.id =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frm.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.dateTime.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtAllAmount.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtAmount.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.txtQualityClothes.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm.txtDes.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm.checkValidity.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            frm.btn.Text = "تعديل";
            frm.ShowDialog();
            dataGridView1.DataSource = opposedControllers.Get();
            sumAmount();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف : " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                opposedControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = opposedControllers.Get();
                sumAmount();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var dataTable = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "opposed");
            foreach (DataRow item in dataTable.Rows)
                listBox1.Items.Add(item[0].ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
             listBox1.DataSource = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "opposed");
            listBox1.DisplayMember = "الاسم";
 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
