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
    public partial class eventsForm : Form
    {
        public eventsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = eventsControllers.Get();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var dataTable = co_TeamControllers.Get(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), "campaigns");
            foreach (DataRow item in dataTable.Rows)
                listBox1.Items.Add(item[0].ToString());
        }
    }
}
