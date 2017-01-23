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
    public partial class Load : Form
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Load()
        {
            InitializeComponent();
            nacitaj_pozadie();
        }

        /// <summary>
        /// Nastavenie pozadia
        /// </summary>
        private void nacitaj_pozadie()
        {
            pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\load.gif";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\loadingRed.gif";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
