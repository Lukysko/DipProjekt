using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Series;




namespace Arduino_komunikacia_verzia3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Deklaracie premennych
        /// </summary>
        private SerialPort myport;
        private string in_data;
        private Random rnd = new Random();
        int x = 0;
        int y = 0;
        int cislo;
        FunctionSeries serie = new FunctionSeries();

        public Form1()
        {

            InitializeComponent();

            double color = rnd.Next(0, 15);
            cislo = rnd.Next(0, 15);

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            var pm = new PlotModel
            {
                Title = "Graf",
                Subtitle = "Udaje z Arduina",
                PlotType = PlotType.Cartesian,
                Background = OxyColors.AliceBlue
            };
        }

        /// <summary>
        /// Vytvorenie seriovej komunikacie
        /// </summary>
        private void start_button_Click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = port_name.Text;
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            // Automaticky doplnenie
            myport.DataReceived += Myport_DataReceived;       

            try
            {
                myport.Open();
                Data_Tb.Text = "";
                in_data = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        /// <summary>
        /// Ziskavanie udajov zo serioveho portu
        /// </summary>
        private void Myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
            this.Invoke(new EventHandler(displaydata_event));
        }

        /// <summary>
        /// Vytvorenie bodov pre graf, vypisanie udajov
        /// </summary>
        private void displaydata_event(object sender, EventArgs e)
        {
            Data_Tb.AppendText(in_data + "\n");
            cislo = rnd.Next(0, 15);
            x = x + 1;
            y = Convert.ToInt32(in_data);
            DataPoint data = new DataPoint(x, y);
            serie.Points.Add(data);
            Text2.AppendText("Cas = " + x + "s  " + "Teplota = " + y + "°C \n");
        }

        /// <summary>
        /// Zastavenie seriovej komunikacie
        /// </summary>
        private void Stop_button_Click(object sender, EventArgs e)
        {
            myport.Close();
            graph();
        }

        /// <summary>
        /// Vykreslenie grafu
        /// </summary>
        public void graph()
        {
            var model = new PlotModel { Title = "Zavislot teploty a casu" };
            model.LegendPosition = LegendPosition.RightBottom;
            model.LegendPlacement = LegendPlacement.Outside;
            model.LegendOrientation = LegendOrientation.Horizontal;

            model.Series.Add(serie);
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            OxyPlot.Axes.LinearAxis XAxis = new OxyPlot.Axes.LinearAxis { Position = OxyPlot.Axes.AxisPosition.Bottom, Minimum = 0, Maximum = 100 };
            XAxis.Title = "Cas";
            Yaxis.Title = "Teplota";
            model.Axes.Add(Yaxis);
            model.Axes.Add(XAxis);
            this.plot1.Model = model;
        }

    }
}

        

            
    
            
