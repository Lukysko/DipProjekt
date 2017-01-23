using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using System.Threading;



namespace udajeDatabaza
{

    public partial class IoT : Form
    {
        /// <summary>
        /// Deklaracia premennych
        /// </summary>
        private MySqlConnection conn = null;
        private MySqlDataReader rdr = null;
        private int ID_uzivatela;
        public bool funkcnePripojenie = false;
        private int pocet_tiknuti = 0;
        private int chyba = 0;
        private int svetlo = 0;
        private NotifyIcon trayIcon;
        //Systemovy cas - nie windows form timer - nakolko ten sposoboval zamrznutie UI, pretoze vykreslovanie UI a vykonanie instrukcie v casovaci prebiahalo z jedneho vlakna
        private System.Timers.Timer casovac1, casovac2, casovac3;

        /// <summary>
        /// Konstruktor, spustenie aplikacie - nastavenie
        /// </summary>
        public IoT()
        {
            InitializeComponent();
            vytvorSpojenie();
            nastavenieTlacidiel();
            trayIcon_inicilizacia();
            trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            nastavCasovace();
        }

        /// <summary>
        /// Nastavenie casovacov
        /// </summary>
        private void nastavCasovace()
        {
            // Casovac s 1s - pri tomto type casovaca nie je potrobne vytvarat nove vlakno - "automaticky bezi na inom vlakne"
            casovac1 = new System.Timers.Timer(1000);
            casovac2 = new System.Timers.Timer(1000);
            casovac3 = new System.Timers.Timer(60000);
            // Prebudenie casovaca 
            casovac1.Elapsed += OnTimedEvent1;
            casovac2.Elapsed += OnTimedEvent2;
            casovac3.Elapsed += OnTimedEvent3;
            casovac1.AutoReset = true;
            casovac2.AutoReset = true;
            casovac3.AutoReset = true;
            casovac1.Enabled = true;
            casovac2.Enabled = true;
            casovac3.Enabled = true;
        }

        /// <summary>
        /// Vykonanie udalosti timer
        /// </summary>
        private void OnTimedEvent1(Object source, ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)(() => zatvorLoad()));
        }

        /// <summary>
        /// Nastavenie loadingu a prepnutie okien
        /// </summary>
        private void zatvorLoad() {
            pocet_tiknuti = pocet_tiknuti + 1;
            if (pocet_tiknuti == 5)
            {
                (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).Opacity = 150;
                (System.Windows.Forms.Application.OpenForms["Load"] as Load).Close();
                casovac1.Enabled = false;
            }
        }

        /// <summary>
        /// Vykonanie udalosti - timer
        /// </summary>
        private void OnTimedEvent2(Object source, ElapsedEventArgs e)
        {
            // Umozni zapisat do cas do "label2", aj ked instrukcia na vykonanie udalosti prichadza z ineho vlakna
            Invoke((MethodInvoker)(() => vypisCas()));
        }

        /// <summary>
        /// Vypisanie casu
        /// </summary>
        private void vypisCas() {
            label2.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss");
        }

        /// <summary>
        /// Vykonanie udalosti - timer
        /// </summary>
        private void OnTimedEvent3(Object source, ElapsedEventArgs e)
        {
             Invoke((MethodInvoker)(() => kontrolaInternetu()));
        }

        /// <summary>
        /// Kontrola pripojenia internetu - hlavna funkcia
        /// </summary>
        private void kontrolaInternetu() { 
              if (kontrolaInternetovehoPripojenia() == false) {
                 chyba = chyba + 1;
                    if (chyba == 1) {
                        new chybaPripojenia().Show();
                }
                } else if ((kontrolaInternetovehoPripojenia() == true) && (chyba > 1)) {
                    (System.Windows.Forms.Application.OpenForms["chybaPripojenia"] as chybaPripojenia).Close();
                    chyba = 0;
                }
        }

        /// <summary>
        /// Nastavenie grafiky tlacidiel a pozadia - ich zobrazenie, vlastnosti, nastavenie načítania aplikácie
        /// </summary>
        private void nastavenieTlacidiel() {
            // Skrytie okna po spustení
            this.Opacity = 0;
            new Load().Show();
            // rozmer okna
            this.Size = new Size(360, 325);
            // Button prihlasenie
            button3.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\login4.png");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackColor = Color.White;
            // Button riadenie
            button6.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\control.png");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.BackColor = Color.White;
            // Vypnutie okraja sposobeneho automatickim vyberanim funkcie tab
            button3.TabStop = false;
            button1.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\graf.png");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.BackColor = Color.White;
            button1.TabStop = false;
            spusti.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\load.png");
            spusti.BackgroundImageLayout = ImageLayout.Stretch;
            spusti.BackColor = Color.White;
            spusti.TabStop = false;
            button4.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\off2.png");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.BackColor = Color.White;
            button4.TabStop = false;
            // Testovania pripojenia - skryte
            button2.Hide();
            label1.Hide();
            // Skrytie vypisovania
            textBox1.Hide();
            uloz_Graf.BackColor = Color.LightGreen;
            // Pozadie
            this.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\pozadie.jpg");
            label2.Show();
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.FromArgb(159, 238, 43);
            // Skrytie tlacidla "Uloz graf", nastavenie pozadia
            uloz_Graf.BackgroundImage = Image.FromFile(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\save.png");
            uloz_Graf.BackgroundImageLayout = ImageLayout.Stretch;
            uloz_Graf.BackColor = Color.White;
            uloz_Graf.Hide();
            // Skrytie grafu
            graf.Hide();
        }

        /// <summary>
        /// Vytvorenie spojenia na databazu
        /// </summary>
        private void vytvorSpojenie() {
            // Deklaracia pripojenia
            string cs = @"server=sql7.freemysqlhosting.net;
                userid=sql7145161;
                password=hCUWvrahmL;
                database=sql7145161";
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                // Kontrola pripojenia
                // textBox1.AppendText("Databáza pripojená \n");
                funkcnePripojenie = true;
            }
            catch (MySqlException ex)
            {
                textBox1.AppendText("Chyba! - Databaza nie je pripojená");
                funkcnePripojenie = false;
            }

        }

        /// <summary>
        /// Ziskanie udajov do grafu a vypisanie udajov na zaklade prihlaseneho uzivatela
        /// </summary>
        private void spusti_Click(object sender, EventArgs e)
        {
            // Zabazpecenie, ci mame co vykreslit
            if (ID_uzivatela > 0)
            {
                try
                {
                    // Kontrola, ci nie je spojenie uzavrete
                    if (conn.State != ConnectionState.Open)
                    {
                        // Nakolko moze nastat aj nejaka chyba, tak ho pre istotu zatvorime a znovu otvorime
                        conn.Close();
                        conn.Open();
                    }
                    string stm = "SELECT * FROM sql7145161.udaje_dom where ID_zakaznik = '" + ID_uzivatela + "'";
                    MySqlCommand cmd = new MySqlCommand(stm, conn);
                    rdr = cmd.ExecuteReader();
                    // Zobrazenie casu a datumu
                    label2.Show();
                    // Premazanie grafu pri kazdom jeho vykrelesni
                    foreach (var series in graf.Series)
                    {
                        series.Points.Clear();
                    }
                    // Kontrola, ci ma "select" nejaky vysledok, t.j nejake riadky
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            textBox1.Show();
                            textBox1.AppendText("\n Teplota: " + rdr.GetInt32(1) + " °C bola v dátum/čas: " + rdr.GetString(2) + "\n");
                            this.Size = new Size(814, 354);
                            graf.Series["Teplota"].Points.AddXY(rdr.GetDateTime(2), rdr.GetInt32(1));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    textBox1.AppendText("Chyba!");
                    textBox1.AppendText(ex.ToString());
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
                MessageBox.Show("Žiadne údaje k vykresleniu","IoT Graf",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Kontrola pripojenia 
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (funkcnePripojenie == true) {
                textBox1.AppendText("Pripojení k databáze! \n");
            }
            else {
                textBox1.AppendText("Chyba!");
            }
           
        }

        /// <summary>
        /// Prihlasovacie menu, prepnutie obrazoviek, skrytie hlavneho okna
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            new Pripojenie(funkcnePripojenie,conn).Show();
            (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).Hide();
        }

        /// <summary>
        /// Ulozi ID uzivatela , funkcia sa vola v "Pripojenie"
        /// </summary>
        public void uloz_ID_uzivatela(int ID_uzivatela) {
            this.ID_uzivatela = ID_uzivatela;
        }

        /// <summary>
        /// Ulozi hodnotu svetla , funkcia sa vola v "ArduinoControl"
        /// </summary>
        public void uloz_hodnotu_Svetla(int svetlo)
        {
            this.svetlo = svetlo;
        }

        /// <summary>
        /// Ulozenie grafu
        /// </summary>
        private void uloz_Graf_Click(object sender, EventArgs e)
        {
            // Zvolenie cesty pre ulozenie obrazka
            var folderBrowserDialog = new FolderBrowserDialog();
            //folderDialog.ShowDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string newDirectoryPath = folderBrowserDialog.SelectedPath;
                string cesta = folderBrowserDialog.SelectedPath;
                graf.SaveImage(cesta + "\\mychart.png", ChartImageFormat.Png);
            }
        }

        /// <summary>
        /// Zobrazi graf
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(930, 687);
            graf.Show();
            uloz_Graf.Show();
        }

        /// <summary>
        /// Odhlasenie
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Boli ste úspešne odhlásený !", "IoT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        /// <summary>
        /// Kontrola pripojenia
        /// </summary>
        public static bool kontrolaInternetovehoPripojenia()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Notifikacia 1 - Centrum akcii
        /// </summary>
        private void notifikacia1()
        {
            string xml = $@"
                <toast>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text>IoT</text>
                            <text>Aplikácia minimalizovaná!</text>
                        </binding>
                    </visual>
                </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification toast = new ToastNotification(doc);
            toast.Tag = "tag";
            toast.Group = "group";
            

            ToastNotificationManager.CreateToastNotifier("IoT").Show(toast);
        }

        /// <summary>
        /// Inicilizácia ikony minimalizácie
        /// </summary>
        private void trayIcon_inicilizacia() {
            trayIcon = new NotifyIcon();
            trayIcon.Text = "IoT klient";
            trayIcon.Icon = Icon.ExtractAssociatedIcon(@"C:\Users\lukys\OneDrive\Arduino\Napojenie na databazu\udajeDatabaza\udajeDatabaza\Image\icona.ico");
        }

        /// <summary>
        /// Otvorenie aplikácie po minimalizácii z panela nástrojov
        /// </summary>
        private void trayIcon_DoubleClick(object Sender, EventArgs e)
        {
            Show();
        }

        /// <summary>
        /// Prepnutie na obrazovku "ControlArduino" - riadenie svetla
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            new ControlArduino(funkcnePripojenie, conn, ID_uzivatela).Show();
            (System.Windows.Forms.Application.OpenForms["IoT"] as IoT).Hide();
        }

        /// <summary>
        /// Minimalizacia aplikácie (panel nástrojov) po vypnutí
        /// </summary>
        private void IoT_FormClosing(Object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            // Pridanie iconu do menu a jej zobrazenie
            //trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            Visible = false; // Skrytie aplikacie
            ShowInTaskbar = false; // Skrytie z listy
            notifikacia1();
            Hide();
        }
    } 
}
