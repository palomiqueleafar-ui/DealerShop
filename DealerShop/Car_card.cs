using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealerShop
{
    public partial class Car_card : UserControl
    {
        public Car_card()
        {
            InitializeComponent();

            pictureBox2.Click += (s, e) => this.OnClick(e);
        }

        public string ProductID { get; set; }

        public Image CarImage
        {
            get=>pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        public string ProductName
        {
            get => label_carName.Content;
            set => label_carName.Content = value;
        }

        public string ProductPrice
        {
            get => label_price.Content;
            set => label_price.Content = value;
        }

    }
}
