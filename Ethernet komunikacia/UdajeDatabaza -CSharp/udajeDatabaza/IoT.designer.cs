namespace udajeDatabaza
{
    partial class IoT
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IoT));
            this.spusti = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.graf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uloz_Graf = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graf)).BeginInit();
            this.SuspendLayout();
            // 
            // spusti
            // 
            this.spusti.Cursor = System.Windows.Forms.Cursors.Default;
            this.spusti.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.spusti.Location = new System.Drawing.Point(119, 155);
            this.spusti.Name = "spusti";
            this.spusti.Size = new System.Drawing.Size(93, 85);
            this.spusti.TabIndex = 10;
            this.spusti.UseVisualStyleBackColor = true;
            this.spusti.Click += new System.EventHandler(this.spusti_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(326, 46);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(363, 194);
            this.textBox1.TabIndex = 1;
            // 
            // graf
            // 
            chartArea1.Name = "ChartArea1";
            this.graf.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.graf.Legends.Add(legend1);
            this.graf.Location = new System.Drawing.Point(12, 288);
            this.graf.Name = "graf";
            series1.BorderColor = System.Drawing.Color.LightBlue;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Teplota";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.graf.Series.Add(series1);
            this.graf.Size = new System.Drawing.Size(889, 345);
            this.graf.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(478, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 31);
            this.button2.TabIndex = 8;
            this.button2.Text = "Pripojený ? ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(8, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 90);
            this.button3.TabIndex = 10;
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(119, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 93);
            this.button4.TabIndex = 10;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(338, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Test pripojenia";
            // 
            // uloz_Graf
            // 
            this.uloz_Graf.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uloz_Graf.Location = new System.Drawing.Point(714, 77);
            this.uloz_Graf.Name = "uloz_Graf";
            this.uloz_Graf.Size = new System.Drawing.Size(142, 138);
            this.uloz_Graf.TabIndex = 12;
            this.uloz_Graf.UseVisualStyleBackColor = true;
            this.uloz_Graf.Click += new System.EventHandler(this.uloz_Graf_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 87);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(227, 43);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 93);
            this.button6.TabIndex = 15;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // IoT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(895, 775);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uloz_Graf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.graf);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.spusti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IoT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IoT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IoT_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.graf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button spusti;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart graf;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uloz_Graf;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
    }
}

