namespace DealerShop
{
    partial class Inverntory_System
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
            this.button3 = new System.Windows.Forms.Button();
            this.imventoryCars_btn = new System.Windows.Forms.Button();
            this.logOut_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stocks_frm1 = new DealerShop.Stocks_frm();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.imventoryCars_btn);
            this.panel1.Controls.Add(this.logOut_btn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 736);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 533);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 38);
            this.button3.TabIndex = 1;
            this.button3.Text = "car";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // imventoryCars_btn
            // 
            this.imventoryCars_btn.Location = new System.Drawing.Point(12, 601);
            this.imventoryCars_btn.Name = "imventoryCars_btn";
            this.imventoryCars_btn.Size = new System.Drawing.Size(51, 36);
            this.imventoryCars_btn.TabIndex = 0;
            this.imventoryCars_btn.Text = "all";
            this.imventoryCars_btn.UseVisualStyleBackColor = true;
            this.imventoryCars_btn.Click += new System.EventHandler(this.imventoryCars_btn_Click);
            // 
            // logOut_btn
            // 
            this.logOut_btn.Location = new System.Drawing.Point(12, 664);
            this.logOut_btn.Name = "logOut_btn";
            this.logOut_btn.Size = new System.Drawing.Size(51, 40);
            this.logOut_btn.TabIndex = 0;
            this.logOut_btn.Text = "exit";
            this.logOut_btn.UseVisualStyleBackColor = true;
            this.logOut_btn.Click += new System.EventHandler(this.logOut_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Location = new System.Drawing.Point(525, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "INVENTORY";
            // 
            // stocks_frm1
            // 
            this.stocks_frm1.Location = new System.Drawing.Point(129, 83);
            this.stocks_frm1.Name = "stocks_frm1";
            this.stocks_frm1.Size = new System.Drawing.Size(995, 603);
            this.stocks_frm1.TabIndex = 2;
            this.stocks_frm1.Load += new System.EventHandler(this.stocks_frm1_Load);
            // 
            // Inverntory_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1319, 735);
            this.Controls.Add(this.stocks_frm1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inverntory_System";
            this.Text = "Inverntory_System";
            this.Load += new System.EventHandler(this.Inverntory_System_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button imventoryCars_btn;
        private System.Windows.Forms.Button logOut_btn;
        private System.Windows.Forms.Label label1;
        private Stocks_frm stocks_frm1;
    }
}