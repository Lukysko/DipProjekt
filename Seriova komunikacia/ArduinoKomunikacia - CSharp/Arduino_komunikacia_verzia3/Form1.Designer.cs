using OxyPlot.WindowsForms;

namespace Arduino_komunikacia_verzia3

{
    partial class Form1
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
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.start_button = new System.Windows.Forms.Button();
            this.Stop_button = new System.Windows.Forms.Button();
            this.port_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Data_Tb = new System.Windows.Forms.TextBox();
            this.Text2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // plot1
            // 
            this.plot1.Location = new System.Drawing.Point(0, 280);
            this.plot1.Margin = new System.Windows.Forms.Padding(0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(632, 446);
            this.plot1.TabIndex = 0;
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(705, 110);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(119, 45);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.Location = new System.Drawing.Point(705, 184);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(119, 48);
            this.Stop_button.TabIndex = 1;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = true;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // port_name
            // 
            this.port_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.port_name.Location = new System.Drawing.Point(794, 55);
            this.port_name.Name = "port_name";
            this.port_name.Size = new System.Drawing.Size(119, 24);
            this.port_name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(575, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zadaj cislo portu";
            // 
            // Data_Tb
            // 
            this.Data_Tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Data_Tb.Location = new System.Drawing.Point(58, 44);
            this.Data_Tb.Multiline = true;
            this.Data_Tb.Name = "Data_Tb";
            this.Data_Tb.Size = new System.Drawing.Size(500, 233);
            this.Data_Tb.TabIndex = 5;
            // 
            // Text2
            // 
            this.Text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Text2.Location = new System.Drawing.Point(690, 254);
            this.Text2.Multiline = true;
            this.Text2.Name = "Text2";
            this.Text2.Size = new System.Drawing.Size(201, 373);
            this.Text2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(179, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Udaje z arduina";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 732);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Text2);
            this.Controls.Add(this.Data_Tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.port_name);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.plot1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.TextBox port_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Data_Tb;
        private PlotView plot1;
        private System.Windows.Forms.TextBox Text2;
        private System.Windows.Forms.Label label2;
    }
}

