namespace LifemakersArchives.Controllers
{
    partial class FormShowData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExSelect = new System.Windows.Forms.Button();
            this.btnExAll = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtQery = new System.Windows.Forms.TextBox();
            this.btnQery = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtQery);
            this.panel1.Controls.Add(this.btnQery);
            this.panel1.Controls.Add(this.btnExSelect);
            this.panel1.Controls.Add(this.btnExAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 377);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(537, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnExSelect
            // 
            this.btnExSelect.Location = new System.Drawing.Point(131, 10);
            this.btnExSelect.Name = "btnExSelect";
            this.btnExSelect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExSelect.Size = new System.Drawing.Size(104, 23);
            this.btnExSelect.TabIndex = 7;
            this.btnExSelect.Text = "استخرج المحدد.xls";
            this.btnExSelect.UseVisualStyleBackColor = true;
            this.btnExSelect.Click += new System.EventHandler(this.btnExSelect_Click);
            // 
            // btnExAll
            // 
            this.btnExAll.Location = new System.Drawing.Point(12, 10);
            this.btnExAll.Name = "btnExAll";
            this.btnExAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExAll.Size = new System.Drawing.Size(113, 23);
            this.btnExAll.TabIndex = 8;
            this.btnExAll.Text = "استخراج الكل.xls";
            this.btnExAll.UseVisualStyleBackColor = true;
            this.btnExAll.Click += new System.EventHandler(this.btnExAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(537, 377);
            this.dataGridView1.TabIndex = 7;
            // 
            // txtQery
            // 
            this.txtQery.Location = new System.Drawing.Point(308, 11);
            this.txtQery.Name = "txtQery";
            this.txtQery.Size = new System.Drawing.Size(217, 20);
            this.txtQery.TabIndex = 9;
            this.txtQery.Visible = false;
            // 
            // btnQery
            // 
            this.btnQery.Location = new System.Drawing.Point(241, 10);
            this.btnQery.Name = "btnQery";
            this.btnQery.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnQery.Size = new System.Drawing.Size(61, 23);
            this.btnQery.TabIndex = 7;
            this.btnQery.Text = "عرض";
            this.btnQery.UseVisualStyleBackColor = true;
            this.btnQery.Visible = false;
            this.btnQery.Click += new System.EventHandler(this.btnQery_Click);
            // 
            // FormShowData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 422);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormShowData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormShowData";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExSelect;
        private System.Windows.Forms.Button btnExAll;
        public System.Windows.Forms.TextBox txtQery;
        public System.Windows.Forms.Button btnQery;
    }
}