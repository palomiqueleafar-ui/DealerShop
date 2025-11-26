using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DealerShop
{
    public partial class Inverntory_System : Form
    {
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();

            return path;
        }
        public Inverntory_System()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20;        
                 
            

            Panel pnl = (Panel)sender;

            Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
            GraphicsPath path = GetRoundedPath(rect, radius);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            pnl.Region = new Region(path); // Clip panel to rounded shape

        
        }

        private void Inverntory_System_Load(object sender, EventArgs e)
        {
            int radius = 50;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = GetRoundedPath(rect, radius);

            this.Region = new Region(path);
        }

        private void imventoryCars_btn_Click(object sender, EventArgs e)
        {
            Stocks_frm stocks = new Stocks_frm();
            stocks.Dock = DockStyle.Fill;
        }

        private void logOut_btn_Click(object sender, EventArgs e)
        {
             Form1 loginForm = new Form1();
             loginForm.Show();
             
             this.Hide();
        }

        private void stocks_frm1_Load(object sender, EventArgs e)
        {

        }
    }
}
