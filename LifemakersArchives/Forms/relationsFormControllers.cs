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
    public partial class relationsFormControllers : Form
    {
        public relationsFormControllers()
        {
            InitializeComponent();
        }
        public int id=0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (btn.Text == "اضافة")
            {
                if (relationsControllers.AddData(txtName.Text, dateTime.Value.Date, Convert.ToDouble(txtAmount.Text)))
                {
                    Close();
                }
                else
                    MessageBox.Show("لم تتم الاضافة");

            }
            else
            {
                if (relationsControllers.UpData(id, txtName.Text, dateTime.Value.Date, Convert.ToDouble(txtAmount.Text)))
                    Close();
                else
                    MessageBox.Show("لم يتم التعديل");
            }

        }
    }
}
