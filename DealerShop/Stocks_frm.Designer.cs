namespace DealerShop
{
    partial class Stocks_frm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.del_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.prod_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(409, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "INVENTORY";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.del_btn);
            this.panel2.Controls.Add(this.clear_btn);
            this.panel2.Controls.Add(this.add_btn);
            this.panel2.Location = new System.Drawing.Point(26, 602);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1051, 76);
            this.panel2.TabIndex = 3;
            // 
            // del_btn
            // 
            this.del_btn.Location = new System.Drawing.Point(366, 11);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(112, 59);
            this.del_btn.TabIndex = 3;
            this.del_btn.Text = "DELETE";
            this.del_btn.UseVisualStyleBackColor = true;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click_1);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(524, 11);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(112, 59);
            this.clear_btn.TabIndex = 2;
            this.clear_btn.Text = "CLEAR";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click_1);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(154, 11);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(112, 59);
            this.add_btn.TabIndex = 0;
            this.add_btn.Text = "ADD";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 681);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_brand,
            this.prod_model,
            this.prod_year,
            this.prod_color,
            this.prod_price,
            this.prod_quantity});
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.Location = new System.Drawing.Point(26, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1051, 564);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // prod_brand
            // 
            this.prod_brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_brand.HeaderText = "BRAND";
            this.prod_brand.MinimumWidth = 6;
            this.prod_brand.Name = "prod_brand";
            // 
            // prod_model
            // 
            this.prod_model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_model.HeaderText = "MODEL";
            this.prod_model.MinimumWidth = 6;
            this.prod_model.Name = "prod_model";
            // 
            // prod_year
            // 
            this.prod_year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_year.HeaderText = "YEAR";
            this.prod_year.MinimumWidth = 6;
            this.prod_year.Name = "prod_year";
            // 
            // prod_color
            // 
            this.prod_color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_color.HeaderText = "COLOR";
            this.prod_color.MinimumWidth = 6;
            this.prod_color.Name = "prod_color";
            // 
            // prod_price
            // 
            this.prod_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_price.HeaderText = "PRICE";
            this.prod_price.MinimumWidth = 6;
            this.prod_price.Name = "prod_price";
            // 
            // prod_quantity
            // 
            this.prod_quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prod_quantity.HeaderText = "QUANTITY";
            this.prod_quantity.MinimumWidth = 6;
            this.prod_quantity.Name = "prod_quantity";
            // 
            // Stocks_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Stocks_frm";
            this.Size = new System.Drawing.Size(1104, 741);
            this.Load += new System.EventHandler(this.Stocks_frm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_quantity;
    }
}
