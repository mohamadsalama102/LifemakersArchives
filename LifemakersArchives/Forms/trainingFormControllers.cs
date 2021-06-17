using LifemakersArchives.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifemakersArchives.Forms
{
    public partial class trainingFormControllers : Form
    {
        public trainingFormControllers()
        {
            InitializeComponent();
            
        }
        public int id;
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (btn.Text=="اضافة")
            {
                if (Controllers.trainingControllers.AddData(txtName.Text, checkTraining.Checked))
                    Close();
                else
                    MessageBox.Show("لم تتم الاضافة");

            }
            else
            {
                if (Controllers.trainingControllers.UpData(id, txtName.Text, checkTraining.Checked))
                    Close();
                else
                    MessageBox.Show("لم تتم الاضافة");
            }
        }
    }
}
