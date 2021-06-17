using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using LifemakersArchives.Controllers;

namespace LifemakersArchives.Forms
{
    public partial class campaignsFormControllers : Form
    {
        public campaignsFormControllers()
        {
            InitializeComponent();
            
        }
        public DataTable dataTableEx;
        public int id;
        public static bool team;
        List<int> list;

        private void campaignsFormControllers_Load(object sender, EventArgs e)
        {
            
            if (btn.Text != "اضافة")
            {
                //بيانات الفريق
                listBox1.Items.Clear();
                listBox1.DataSource = co_TeamControllers.Get(id, "campaigns");
                listBox1.DisplayMember = "الاسم";
 

                dataGridView1.DataSource = dataTableEx;
                dataGridView1.Columns[0].Visible = false;
            }
            else
            {
                btnEditEx.Enabled = false;
                btnDelete.Enabled = false;
                dataTableEx = new DataTable();
                dataTableEx.Columns.Add("التحدي");
                dataTableEx.Columns.Add("كيفة الحل");
                dataGridView1.DataSource = dataTableEx;
                
                dataGridView1.DataSource = dataTableEx;
            }
        }



        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            team = true;
            try
            {
                if (btn.Text != "اضافة")
                {
                    var dataTable = co_TeamControllers.GetIdName(id, "campaigns");
                    foreach (DataRow item in dataTable.Rows)
                        co_TeamControllers.Delete(id, "campaigns", Convert.ToInt32(item[0].ToString()), Connectiondb.Con);
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

        private void btn_Click(object sender, EventArgs e)
        {
            if (btn.Text == "اضافة")
            {
                if (campaignsControllers.AddData(txtName.Text, dateTime.Value.Date, startTime.Value, endTime.Value, list,dataTableEx))
                {
                    Close();
                }
                else
                    MessageBox.Show("لم تتم الاضافة");

            }
            else
            {
                if (campaignsControllers.UpData(id, txtName.Text, dateTime.Value.Date, startTime.Value, endTime.Value, list))
                    Close();
                else
                    MessageBox.Show("لم يتم التعديل");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (btn.Text != "اضافة")
            {
                txtEx.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtAn.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }

        }

        private void btnAddEx_Click(object sender, EventArgs e)
        {
            if (btn.Text != "اضافة")
            {
                ExceptionsControllers.AddData(txtEx.Text, txtAn.Text, "campaigns", id);
                dataGridView1.DataSource = ExceptionsControllers.Get(id, "campaigns");
            }
            else
            {
                DataRow dr = dataTableEx.NewRow();
                dr[0] = txtEx.Text;
                dr[1] = txtAn.Text;
                dataTableEx.Rows.Add(dr);
            }
        }
        private void btnEditEx_Click(object sender, EventArgs e)
        {
            ExceptionsControllers.UpData(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), txtEx.Text, txtAn.Text);
            dataGridView1.DataSource = ExceptionsControllers.Get(id, "campaigns");
            txtEx.Text = "";
            txtAn.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ExceptionsControllers.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            txtEx.Text = "";
            txtAn.Text = "";
            dataGridView1.DataSource = ExceptionsControllers.Get(id, "campaigns");
        }
    }
}
