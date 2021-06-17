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
    public partial class training : Form
    {
        public training()
        {
            InitializeComponent();
            dataGridView.DataSource = Controllers.trainingControllers.Get();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        trainingFormControllers form;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            form = new trainingFormControllers();
            form.btn.Text = "اضافة";
            form.ShowDialog();
            dataGridView.DataSource = Controllers.trainingControllers.Get();
        }

        private void btnEdit_Click(object sender, EventArgs e)
          {
            form = new trainingFormControllers();
            form.btn.Text = "تعديل";
            form.id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
            form.txtName.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            form.checkTraining.Checked =Convert.ToBoolean(dataGridView.CurrentRow.Cells[2].Value.ToString());

            form.ShowDialog();
            dataGridView.DataSource = Controllers.trainingControllers.Get();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف : " + dataGridView.CurrentRow.Cells[1].Value.ToString(), "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool delet = Controllers.trainingControllers.Delete(Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString()), dataGridView.CurrentRow.Cells[1].Value.ToString(), Convert.ToBoolean(dataGridView.CurrentRow.Cells[2].Value.ToString()));
                    if (delet)
                    {
                        MessageBox.Show("تم الحذف");
                        dataGridView.DataSource = Controllers.trainingControllers.Get();

                    }
                }
            }
            catch (Exception)
            {

             }
     
        }
    }
}
