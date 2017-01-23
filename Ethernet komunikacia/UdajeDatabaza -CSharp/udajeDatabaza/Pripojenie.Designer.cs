namespace udajeDatabaza
{
    partial class Pripojenie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pripojenie));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PrihlasButton = new System.Windows.Forms.Button();
            this.prihlasovacie_meno = new System.Windows.Forms.TextBox();
            this.heslo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hornyPictureBox = new System.Windows.Forms.PictureBox();
            this.hornyLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hornyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prihlasovacie meno:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.label2.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Heslo:";
            // 
            // PrihlasButton
            // 
            this.PrihlasButton.BackColor = System.Drawing.Color.Teal;
            this.PrihlasButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PrihlasButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PrihlasButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.PrihlasButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrihlasButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(238)))), ((int)(((byte)(43)))));
            this.PrihlasButton.Location = new System.Drawing.Point(183, 194);
            this.PrihlasButton.Name = "PrihlasButton";
            this.PrihlasButton.Size = new System.Drawing.Size(96, 32);
            this.PrihlasButton.TabIndex = 3;
            this.PrihlasButton.Text = "Prihlás";
            this.PrihlasButton.UseVisualStyleBackColor = false;
            this.PrihlasButton.Click += new System.EventHandler(this.PrihlasButton_Click_1);
            // 
            // prihlasovacie_meno
            // 
            this.prihlasovacie_meno.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prihlasovacie_meno.Location = new System.Drawing.Point(183, 95);
            this.prihlasovacie_meno.Multiline = true;
            this.prihlasovacie_meno.Name = "prihlasovacie_meno";
            this.prihlasovacie_meno.Size = new System.Drawing.Size(265, 24);
            this.prihlasovacie_meno.TabIndex = 5;
            // 
            // heslo
            // 
            this.heslo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.heslo.Location = new System.Drawing.Point(183, 141);
            this.heslo.Multiline = true;
            this.heslo.Name = "heslo";
            this.heslo.Size = new System.Drawing.Size(265, 23);
            this.heslo.TabIndex = 6;
            this.heslo.TextChanged += new System.EventHandler(this.heslo_TextChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(465, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 233);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // hornyPictureBox
            // 
            this.hornyPictureBox.Location = new System.Drawing.Point(-1, 1);
            this.hornyPictureBox.Name = "hornyPictureBox";
            this.hornyPictureBox.Size = new System.Drawing.Size(1372, 50);
            this.hornyPictureBox.TabIndex = 8;
            this.hornyPictureBox.TabStop = false;
            // 
            // hornyLabel
            // 
            this.hornyLabel.AutoSize = true;
            this.hornyLabel.Font = new System.Drawing.Font("Perpetua", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hornyLabel.Location = new System.Drawing.Point(117, 9);
            this.hornyLabel.Name = "hornyLabel";
            this.hornyLabel.Size = new System.Drawing.Size(62, 23);
            this.hornyLabel.TabIndex = 9;
            this.hornyLabel.Text = "label3";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 50);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // Pripojenie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(132)))), ((int)(((byte)(148)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(903, 354);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.hornyLabel);
            this.Controls.Add(this.hornyPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.heslo);
            this.Controls.Add(this.prihlasovacie_meno);
            this.Controls.Add(this.PrihlasButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pripojenie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pripojenie";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pripojenie_FormClosed);
            this.Load += new System.EventHandler(this.Pripojenie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hornyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PrihlasButton;
        private System.Windows.Forms.TextBox prihlasovacie_meno;
        private System.Windows.Forms.TextBox heslo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox hornyPictureBox;
        private System.Windows.Forms.Label hornyLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}