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
    public partial class meetingsFormControlles : Form
    {
        public meetingsFormControlles()
        {
            InitializeComponent();
        }
        public int id;
        public static bool team;
        List<int> list;

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            team = true;
            try
            {
                if (btn.Text != "اضافة")
                {
                    var dataTable = co_TeamControllers.GetIdName(id, "meetings");
                    foreach (DataRow item in dataTable.Rows)
                        co_TeamControllers.Delete(id, "meetings", Convert.ToInt32(item[0].ToString()), Connectiondb.Con);


                }
                HrForm hrForm = new HrForm();
                hrForm.StateShow = true;
                hrForm.ShowDialog();
                list = hrForm.listID;
                listBox1.Items.Clear();
                foreach (var item in list)
                    listBox1.Items.Add(HrControllers.Get(item).Rows[0][0]);

            }
            catch (Exception)
            {

            }

        }

        private void meetingsFormControlles_Load(object sender, EventArgs e)
        {
            if (btn.Text != "اضافة")
            {
                var dataTable = co_TeamControllers.Get(id, "meetings");
                foreach (DataRow item in dataTable.Rows)
                    listBox1.Items.Add(item[0].ToString());

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (btn.Text == "اضافة")
            {
                if (meetingsControllers.AddData(txtName.Text, dateTime.Value.Date, startTime.Value, endTime.Value,txtIdeas.Text, txtDes.Text, list))
                {
                    Close();
                }
                else
                    MessageBox.Show("لم تتم الاضافة");

            }
            else
            {
                if (meetingsControllers.UpData(id, txtName.Text, dateTime.Value.Date, startTime.Value, endTime.Value, txtIdeas.Text, txtDes.Text, list))
                    Close();
                else
                    MessageBox.Show("لم يتم التعديل");
            }

        }
    }
}
