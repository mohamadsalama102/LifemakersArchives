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
    public partial class HrFormControllers : Form
    {
        public HrFormControllers()
        {
            InitializeComponent();
           
        }
        public int id;
        void LoadPhone()
        {
            listPhone.DataSource = HrPhoneControllers.Get(id);
            listPhone.DisplayMember = "Phone";
            listPhone.ValueMember = "Id";
        }
        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn.Text == "اضافة")
                {
                    if (Controllers.HrControllers.AddData(txtName.Text, dateTime.Value,txtEmail.Text,txtFacebook.Text, checkValidity.Checked,listPhone))
                    {
                        Close();
                    }
                    else
                        MessageBox.Show("لم تتم الاضافة");

                }
                else
                {
                    LoadPhone();
                    if (Controllers.HrControllers.UpData(id, txtName.Text, dateTime.Value, txtEmail.Text, txtFacebook.Text, checkValidity.Checked))
                        Close();
                    else
                        MessageBox.Show("لم يتم التعديل");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddEx_Click(object sender, EventArgs e)
        {
            if (btn.Text != "اضافة")
            {
                Connectiondb.Con_Open();
                if (HrPhoneControllers.AddData(id,txtPhone.Text,Connectiondb.Con,null))
                {
                    Connectiondb.Con_Close();

                    LoadPhone();
                }
                else
                    MessageBox.Show("لم تتم الاضافة");
                Connectiondb.Con_Close();

            }
            else
            {
                listPhone.Items.Add(txtPhone.Text);
            }

        }

        private void btnEditEx_Click(object sender, EventArgs e)
        {
            HrPhoneControllers.UpData(Convert.ToInt32(listPhone.SelectedValue.ToString()), txtPhone.Text, Connectiondb.Con);
            LoadPhone();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HrPhoneControllers.Delete(Convert.ToInt32(listPhone.SelectedValue.ToString()));
            LoadPhone();
        }

        private void listPhone_SelectedIndexChanged(object sender, EventArgs e)
        {
         txtPhone.Text = listPhone.SelectedItem.ToString();
        }

        private void HrFormControllers_Load(object sender, EventArgs e)
        {
            if (btn.Text != "اضافة")
                LoadPhone();
        }
    }
}
