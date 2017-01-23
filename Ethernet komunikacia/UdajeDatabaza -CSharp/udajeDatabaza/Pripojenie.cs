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
    public partial class Pripojenie : Form
    {
        /// <summary>
        /// Deklaracia premennych
        /// </summary>
        private bool existujePripojenie = false;
        private int ID_uzivatela;
        private MySqlConnection conn;
        private MySqlDataReader rdr = null;
        private string prihlasovacieMeno;
        private string hesloUzivatela;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Pripojenie(bool existujePripojenie, MySqlConnection conn)
        {
            InitializeComponent();
            this.existujePripojenie = existujePripojenie;
            this.conn = conn;
            nastavenieTlacidiel();
            nastavenieObrazkov();
        }
        /// <summary>
        /// Nastavanie grafiky tlacidiel a label 
        /// </summary>
        private void nastavenieTlacidiel() {
            PrihlasButton.BackColor = Color.FromArgb(31, 132, 148);
            PrihlasButton.ForeColor = Color.FromArgb(159, 238, 43);
            // Vypnutie oramovania
            PrihlasButton.FlatAppearance.BorderSize = 0;
            PrihlasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //Nastavenie pozadia tlacidla, ked nan prejdeme mysou
            //PrihlasButton.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            //Nastavenie label1,2
            label1.ForeColor = Color.FromArgb(159, 238, 43);
            label2.ForeColor = Color.FromArgb(159, 238, 43);
            hornyPictureBox.BackColor = Color.Black;
            hornyLabel.ForeColor = Color.White;
            hornyLabel.ForeColor = Color.White;
            hornyLabel.Text = "Zadajte prihlasovacie udaje !";
        }

        /// <summary>
        /// Nastavavenie dizajnu obrazkov
        /// </summary>
        private void nastavenieObrazkov() {
            pictureBox2.BackColor = Color.Black;
            pictureBox2.ImageLocation= @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\zamok.png";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.FromArgb(31, 132, 148);
            pictureBox1.ImageLocation = @"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\IOT.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            hornyPictureBox.BackColor = Color.Black;
            hornyLabel.BackColor = Color.Black;
            hornyLabel.ForeColor = Color.White;
        }

        /// <summary>
        /// Prihlasenie uzivatela, ziskanie jeho ID, vypnutie prihlasovacieho okna, zobrazenie hlavného okna
        /// </summary>
        private void PrihlasButton_Click_1(object sender, EventArgs e)
        {
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
                    prihlasovacieMeno = prihlasovacie_meno.Text;
                    hesloUzivatela = heslo.Text;
                    string stm1 = "SELECT ID_zakaznik FROM sql7145161.zakaznik where prihlasovacie_meno= '" + prihlasovacieMeno + "' and heslo='" + hesloUzivatela + "'";
                    MySqlCommand cmd1 = new MySqlCommand(stm1, conn);
                    rdr = cmd1.ExecuteReader();
                    // Kontrola ci "select" získal nejake udaje
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            this.ID_uzivatela = rdr.GetInt16(0);
                            // Prenesie udaje do "IoT" , okamzite ako ziska ID v "Pripojenie"
                            (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).uloz_ID_uzivatela(ID_uzivatela);
                            DialogResult potvrdenie = MessageBox.Show("Boli ste úspešne prihlásený !", "IoT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Vypnutie okna po uspesnom prihlaseny
                            if (potvrdenie == DialogResult.OK)
                            {
                                // Vypnutie prihlasovacieho okna, zobrazenie hlavneho okna
                                (System.Windows.Forms.Application.OpenForms["Pripojenie"] as Pripojenie).Close();
                                (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).Show();
                            }
                         }
                    }
                    // Chybova hlaska, ak nie je uzivatel najdeny
                    else
                    {
                        DialogResult vysledok_chyby = MessageBox.Show("Chyba", "IoT", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        if (vysledok_chyby == DialogResult.Retry)
                        {
                            // Vymaze jeho obsah a nastavi kurzor na zaciatok okna 
                            prihlasovacie_meno.Clear();
                            heslo.Clear();
                            prihlasovacie_meno.Focus();
                            hornyLabel.Show();

                            hornyLabel.Text = "Zlé heslo alebo prihlasovacie meno, skúz znovu.";
                            pictureBox2.BackColor = Color.FromArgb(204, 0, 0);
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

        /// <summary>
        /// Skrytie hesla pri jeho pisani (*) 
        /// </summary>
        private void heslo_TextChanged_1(object sender, EventArgs e)
        {
            heslo.PasswordChar = '*';
        }

        /// <summary>
        /// Vypnutie pozadia
        /// </summary>
        private void Pripojenie_Load(object sender, EventArgs e)
        {
            label2.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = System.Drawing.Color.Transparent;
        }

        /// <summary>
        /// Zabezpecenie zobzrazenia hlavneho opkna po vypnuti prihlasovacieho okna
        /// </summary>
        private void Pripojenie_FormClosed(object sender, FormClosedEventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).Show();
        }
    }
}
