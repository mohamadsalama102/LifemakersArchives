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

namespace LifemakersArchives.Forms
{
    public partial class campaignsForm : Form
    {
        public campaignsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource= campaignsControllers.Get();
         }

        private void campaignsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            campaignsFormControllers frm = new campaignsFormControllers();
            //بيانات الحملة
            frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frm.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.dateTime.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.startTime.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.endTime.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


            //بيانات التحدي
            frm.dataTableEx = ExceptionsControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "campaigns");

            frm.btn.Text = "تعديل";
            frm.ShowDialog();
            dataGridView1.DataSource = campaignsControllers.Get();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف : " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                campaignsControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = campaignsControllers.Get();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.DataSource =  co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "campaigns");
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
        }

        private void btnExceptions_Click(object sender, EventArgs e)
        {
             FormShowData formatException = new FormShowData(ExceptionsControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "campaigns"));

            formatException.Text = "تحديات حملة : "+ dataGridView1.CurrentRow.Cells[1].Value.ToString();
            formatException.dataGridView1.Columns[0].Visible = false;
            formatException.ShowDialog();
         }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var dataTable = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "campaigns");
            foreach (DataRow item in dataTable.Rows)
                listBox1.Items.Add(item[0].ToString());

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            campaignsFormControllers frm = new campaignsFormControllers();
            frm.ShowDialog();
            dataGridView1.DataSource = campaignsControllers.Get();
        }
    }
}
