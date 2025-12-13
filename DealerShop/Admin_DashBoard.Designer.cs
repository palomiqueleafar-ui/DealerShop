namespace DealerShop
{
    partial class Admin_DashBoard
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
            this.btn_Transaction = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dash_btn = new System.Windows.Forms.Button();
            this.inventory_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.adminPanel = new System.Windows.Forms.Panel();
            this.frmDashboard1 = new DealerShop.frmDashboard();
            this.sales2 = new DealerShop.Sales();
            this.frmInventory1 = new DealerShop.frmInventory();
            this.sales1 = new DealerShop.Sales();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.adminPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.btn_Transaction);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.dash_btn);
            this.panel1.Controls.Add(this.inventory_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 741);
            this.panel1.TabIndex = 0;
            // 
            // btn_Transaction
            // 
            this.btn_Transaction.Location = new System.Drawing.Point(29, 409);
            this.btn_Transaction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Transaction.Name = "btn_Transaction";
            this.btn_Transaction.Size = new System.Drawing.Size(189, 55);
            this.btn_Transaction.TabIndex = 7;
            this.btn_Transaction.Text = "TRANSACTIONS";
            this.btn_Transaction.UseVisualStyleBackColor = true;
            this.btn_Transaction.Click += new System.EventHandler(this.btn_Transaction_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 684);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 55);
            this.button1.TabIndex = 6;
            this.button1.Text = "SIGN OUT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(17, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 121);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dash_btn
            // 
            this.dash_btn.Location = new System.Drawing.Point(29, 187);
            this.dash_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dash_btn.Name = "dash_btn";
            this.dash_btn.Size = new System.Drawing.Size(189, 55);
            this.dash_btn.TabIndex = 4;
            this.dash_btn.Text = "DASHOARD";
            this.dash_btn.UseVisualStyleBackColor = true;
            this.dash_btn.Click += new System.EventHandler(this.dash_btn_Click);
            // 
            // inventory_btn
            // 
            this.inventory_btn.Location = new System.Drawing.Point(29, 334);
            this.inventory_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventory_btn.Name = "inventory_btn";
            this.inventory_btn.Size = new System.Drawing.Size(189, 55);
            this.inventory_btn.TabIndex = 3;
            this.inventory_btn.Text = "INVENTORY";
            this.inventory_btn.UseVisualStyleBackColor = true;
            this.inventory_btn.Click += new System.EventHandler(this.inventory_btn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(467, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACCOUNT";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 260);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "CASHIER";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // adminPanel
            // 
            this.adminPanel.Controls.Add(this.frmDashboard1);
            this.adminPanel.Controls.Add(this.sales2);
            this.adminPanel.Controls.Add(this.frmInventory1);
            this.adminPanel.Location = new System.Drawing.Point(288, 12);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(1213, 741);
            this.adminPanel.TabIndex = 1;
            // 
            // frmDashboard1
            // 
            this.frmDashboard1.Location = new System.Drawing.Point(3, -3);
            this.frmDashboard1.Name = "frmDashboard1";
            this.frmDashboard1.Size = new System.Drawing.Size(1213, 741);
            this.frmDashboard1.TabIndex = 2;            // 
            // sales2
            // 
            this.sales2.ForeColor = System.Drawing.Color.White;
            this.sales2.Location = new System.Drawing.Point(-3, 0);
            this.sales2.Name = "sales2";
            this.sales2.Size = new System.Drawing.Size(1213, 741);
            this.sales2.TabIndex = 1;
            // 
            // frmInventory1
            // 
            this.frmInventory1.Location = new System.Drawing.Point(0, 2);
            this.frmInventory1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.frmInventory1.Name = "frmInventory1";
            this.frmInventory1.Size = new System.Drawing.Size(1213, 741);
            this.frmInventory1.TabIndex = 0;
            // 
            // sales1
            // 
            this.sales1.ForeColor = System.Drawing.Color.White;
            this.sales1.Location = new System.Drawing.Point(284, 12);
            this.sales1.Margin = new System.Windows.Forms.Padding(2);
            this.sales1.Name = "sales1";
            this.sales1.Size = new System.Drawing.Size(1104, 741);
            this.sales1.TabIndex = 2;
            // 
            // Admin_DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1523, 775);
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Admin_DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_DashBoard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.adminPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button inventory_btn;
        private System.Windows.Forms.Button dash_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Transaction;
        private System.Windows.Forms.Button button1;
        private Sales sales1;
        private System.Windows.Forms.Panel adminPanel;
        private frmInventory frmInventory1;
        private frmDashboard frmDashboard1;
        private Sales sales2;
    }
}