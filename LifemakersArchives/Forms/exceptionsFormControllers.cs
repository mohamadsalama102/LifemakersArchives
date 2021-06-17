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
    public partial class exceptionsFormControllers : Form
    {
        public exceptionsFormControllers()
        {
            InitializeComponent();
        }
        public int id;
        private void btn_Click(object sender, EventArgs e)
        {
            if (btn.Text == "اضافة")
            {
                ExceptionsControllers.AddData(txtEx.Text, txtAn.Text, "", 0);
            }
            else
            {
                ExceptionsControllers.UpData(id, txtEx.Text, txtAn.Text);
            }
            Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
