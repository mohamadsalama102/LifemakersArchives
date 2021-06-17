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
    public partial class HrForm : Form
    {
        public bool StateShow;
        public List<int> listID;
        public HrForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = HrControllers.Get();
           
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            listID = new List<int>();
            try
            {
                foreach (DataGridViewRow itemChecked in dataGridView1.SelectedRows)
                {
                    listID.Add(Convert.ToInt32(itemChecked.Cells[0].Value.ToString()));
                }
            }
            catch (Exception)
            {
            }
            if (listID.Count != 0)
            {
                Close();
            }
            else
            {
                MessageBox.Show("برجاءتحديد الاسماء");
            }
            Close();
        }

        private void HrFormControllers_Load(object sender, EventArgs e)
        {
            if (!StateShow) { btnDone.Hide(); }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HrFormControllers frm = new HrFormControllers();
            frm.ShowDialog();
            dataGridView1.DataSource = HrControllers.Get();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HrFormControllers frm = new HrFormControllers();
            frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            frm.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.dateTime.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value.ToString()==""?DateTime.Now.ToString(): dataGridView1.CurrentRow.Cells[2].Value.ToString());
            frm.txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.txtFacebook.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.checkValidity.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            frm.btn.Text = "تعديل";
            frm.ShowDialog();
            dataGridView1.DataSource = HrControllers.Get();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف : " + dataGridView1.CurrentRow.Cells[1].Value.ToString(), "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HrControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = HrControllers.Get();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
