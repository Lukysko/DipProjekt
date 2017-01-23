using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace udajeDatabaza
{
    public partial class ControlArduino : Form
    {
        /// <summary>
        /// Premenne
        /// </summary>
        int svetlo;
        private bool existujePripojenie = false;
        private int ID_uzivatela;
        private MySqlConnection conn;
        private MySqlDataReader rdr = null;

        public ControlArduino(bool existujePripojenie, MySqlConnection conn, int ID_uzivatela)
        {
            InitializeComponent();
            this.ID_uzivatela = ID_uzivatela;
            this.existujePripojenie = existujePripojenie;
            this.conn = conn;
        }

        private void ControlArduino_Load(object sender, EventArgs e)
        {
            button1.TabStop = false;
            button2.TabStop = false;
            {
                if (existujePripojenie == true)
                {
                    try
                    {
                        // Osetrenie,ci je spojenie k databze dobre naviazane - zatvorenie a otvorenie pripojenia
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Open();
                        }
                        string stm1 = "SELECT hodnota FROM sql7145161.svetlo where ID_zakaznik = '" + ID_uzivatela + "' ";
                        MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                        rdr = cmd1.ExecuteReader();
                        // Kontrola ci "select" získal nejake udaje
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.svetlo = rdr.GetInt16(0);
                                // Prenesie udaje do "IoT" , okamzite ako ziska hodnotu svetla v "ControlArduino"
                                (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).uloz_hodnotu_Svetla(svetlo);
                            }
                        }
                    }
                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nie je nadviazane spojenie s databazou", "IoT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (svetlo == 1)
            {
                pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\svetlo.png";
            }
            else if (svetlo == 2) {
                pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\tma.png";
            }

        }

        /// <summary>
        /// Zapnutie svetla
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (svetlo == 2)
            {
                this.svetlo = 1;
                pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\svetlo.png";
                if (existujePripojenie == true)
                {
                    try
                    {
                        // Osetrenie, ci je spojenie k databaze dobre naviazane - zatvorenie a otvorenie pripojenia
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Open();
                        }
                        string stm1 = "INSERT INTO sql7145161.svetlo (hodnota,ID_zakaznik) VALUES ('1','" + ID_uzivatela + "') ";
                        MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                        cmd1.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nie je nadviazane spojenie s databazou", "IoT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Vypnutie svetla
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (svetlo == 1)
            {
                this.svetlo = 2;
                pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\tma.png";
                if (existujePripojenie == true)
                {
                    try
                    {
                        // Osetrenie, ci je spojenie k databze dobre naviazane - zatvorenie a otvorenie pripojenia
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Open();
                        }
                        string stm1 = "INSERT INTO sql7145161.svetlo (hodnota,ID_zakaznik) VALUES ('2','" + ID_uzivatela + "') ";
                        MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                        cmd1.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (conn != null)
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nie je nadviazane spojenie s databazou", "IoT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
    }
        /// <summary>
        /// Zatvorenie okna
        /// </summary>
        private void ControlArduino_FormClosing(object sender, FormClosingEventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).Show();
        }

    }
}
