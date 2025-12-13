namespace DealerShop
{
    partial class Car_card
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Price = new System.Windows.Forms.Label();
            this.CarName = new System.Windows.Forms.Label();
            this.addToCart_btn = new MaterialSkin.Controls.MaterialButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 135);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("OCR A Extended", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(9, 168);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(64, 19);
            this.Price.TabIndex = 2;
            this.Price.Text = "Price";
            // 
            // CarName
            // 
            this.CarName.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarName.Location = new System.Drawing.Point(9, 11);
            this.CarName.Name = "CarName";
            this.CarName.Size = new System.Drawing.Size(247, 22);
            this.CarName.TabIndex = 3;
            this.CarName.Text = "CarName";
            // 
            // addToCart_btn
            // 
            this.addToCart_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addToCart_btn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addToCart_btn.Depth = 0;
            this.addToCart_btn.HighEmphasis = true;
            this.addToCart_btn.Icon = null;
            this.addToCart_btn.Location = new System.Drawing.Point(191, 161);
            this.addToCart_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addToCart_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addToCart_btn.Name = "addToCart_btn";
            this.addToCart_btn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addToCart_btn.Size = new System.Drawing.Size(64, 36);
            this.addToCart_btn.TabIndex = 4;
            this.addToCart_btn.Text = "ADD";
            this.addToCart_btn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addToCart_btn.UseAccentColor = false;
            this.addToCart_btn.UseVisualStyleBackColor = true;
            // 
            // Car_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addToCart_btn);
            this.Controls.Add(this.CarName);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.panel1);
            this.Name = "Car_card";
            this.Size = new System.Drawing.Size(259, 203);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label CarName;
        private MaterialSkin.Controls.MaterialButton addToCart_btn;
    }
}
