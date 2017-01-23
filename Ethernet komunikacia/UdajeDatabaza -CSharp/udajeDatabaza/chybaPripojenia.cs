using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace udajeDatabaza
{
    public partial class chybaPripojenia : Form
    {
        public chybaPripojenia()
        {
            InitializeComponent();
            zobrazChybu();
        }

        /// <summary>
        /// Zobrazenie chyby
        /// </summary>
        private void zobrazChybu() {
            pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\internetConnection.gif";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
