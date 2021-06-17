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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region Forms and Controllers 
        opposedForm _opposed = new opposedForm();
        sillsForm _sills = new sillsForm();
        training _training = new training();
        HrForm _hrForm = new HrForm();
        trainingFormControllers _trainingFormControllers = new trainingFormControllers();
        opposedFormControllers _opposedFormControllers = new opposedFormControllers();
        sillsFormControllers _sillsFormControllers = new sillsFormControllers();
        HrFormControllers _hrFormControllers = new HrFormControllers();
        #endregion
        private void معارضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _opposed = new opposedForm();
            _opposed.MdiParent = this;           
            _opposed.Show();

        }

        private void سلزToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _sills = new sillsForm();
            _sills.MdiParent = this;
             _sills.Show();

        }

        private void الميسرينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _training = new training();
            _training.MdiParent = this;
             _training.Show();

        }

        private void اضافةميسرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _trainingFormControllers = new trainingFormControllers();
            _trainingFormControllers.MdiParent = this;
            _trainingFormControllers.StartPosition = FormStartPosition.CenterScreen;
            _trainingFormControllers.Show();

        }

        private void اضافةمعرضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _opposedFormControllers = new opposedFormControllers();
                _opposedFormControllers.MdiParent = this;
                _opposedFormControllers.StartPosition = FormStartPosition.CenterScreen;
                _opposedFormControllers.Show();

            }
            catch (Exception)
            {

             }    

        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sillsFormControllers = new sillsFormControllers();
            _sillsFormControllers.MdiParent = this;
            _sillsFormControllers.StartPosition = FormStartPosition.CenterScreen;
            _sillsFormControllers.Show();

        }

        private void المتطوعينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _hrForm = new HrForm();
            _hrForm.MdiParent = this;
            _hrForm.StartPosition = FormStartPosition.CenterScreen;
            _hrForm.Show();
        }

        private void اضافةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _hrFormControllers = new HrFormControllers();
            _hrFormControllers.MdiParent = this;
            _hrFormControllers.StartPosition = FormStartPosition.CenterScreen;
            _hrFormControllers.Show();
        }

        private void حملاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            campaignsForm _campaignsForm = new campaignsForm();
            _campaignsForm.MdiParent = this;
            _campaignsForm.StartPosition = FormStartPosition.CenterScreen;
            _campaignsForm.Show();
        }

        private void اجتماعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            meetingsForm _meetingsForm = new meetingsForm();
            _meetingsForm.MdiParent = this;
            _meetingsForm.StartPosition = FormStartPosition.CenterScreen;
            _meetingsForm.Show();
        }

        private void مناسباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventsForm _eventsForm = new eventsForm();
            _eventsForm.MdiParent = this;        
            _eventsForm.StartPosition = FormStartPosition.CenterScreen;
            _eventsForm.Show();
        }

        private void التحدياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exceptionsForm _exceptionsForm = new exceptionsForm();
            _exceptionsForm.MdiParent = this;
            _exceptionsForm.StartPosition = FormStartPosition.CenterScreen;
            _exceptionsForm.Show();
         }

        private void مخصصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData frm = new FormShowData();
            frm.MdiParent = this;
            frm.Text = "تحليل مخصص";
            frm.txtQery.Visible = true;
            frm.btnQery.Visible = true;
            frm.Show();
        }

        private void علاقاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            relationsForm _relationsForm = new relationsForm();
            _relationsForm.MdiParent = this;
            _relationsForm.Show();

        }

        private void ساعاتالتطوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            volunteerHoursForm _volunteerHoursForm = new volunteerHoursForm();
            _volunteerHoursForm.MdiParent = this;
            _volunteerHoursForm.Show();

        }
    }
}
