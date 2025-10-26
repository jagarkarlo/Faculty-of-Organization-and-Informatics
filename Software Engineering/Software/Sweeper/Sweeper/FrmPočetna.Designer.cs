namespace Sweeper
{
    partial class FrmPočetna
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
            this.labelOdjava = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPregledajZahtjeve = new System.Windows.Forms.Label();
            this.labelKreirajZahtjev = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOdjava
            // 
            this.labelOdjava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(78)))));
            this.labelOdjava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOdjava.ForeColor = System.Drawing.Color.White;
            this.labelOdjava.Location = new System.Drawing.Point(25, 213);
            this.labelOdjava.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOdjava.Name = "labelOdjava";
            this.labelOdjava.Size = new System.Drawing.Size(108, 48);
            this.labelOdjava.TabIndex = 19;
            this.labelOdjava.Text = "Odjavi se";
            this.labelOdjava.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOdjava.Click += new System.EventHandler(this.labelOdjava_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Fugaz One", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(52, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "Dobrodošli u Sweeper";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPregledajZahtjeve
            // 
            this.labelPregledajZahtjeve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(78)))));
            this.labelPregledajZahtjeve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPregledajZahtjeve.ForeColor = System.Drawing.Color.White;
            this.labelPregledajZahtjeve.Location = new System.Drawing.Point(25, 146);
            this.labelPregledajZahtjeve.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPregledajZahtjeve.Name = "labelPregledajZahtjeve";
            this.labelPregledajZahtjeve.Size = new System.Drawing.Size(108, 48);
            this.labelPregledajZahtjeve.TabIndex = 13;
            this.labelPregledajZahtjeve.Text = "Pregledaj zahtjeve";
            this.labelPregledajZahtjeve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPregledajZahtjeve.Click += new System.EventHandler(this.labelPregledajZahtjeve_Click);
            // 
            // labelKreirajZahtjev
            // 
            this.labelKreirajZahtjev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(50)))), ((int)(((byte)(78)))));
            this.labelKreirajZahtjev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKreirajZahtjev.ForeColor = System.Drawing.Color.White;
            this.labelKreirajZahtjev.Location = new System.Drawing.Point(25, 83);
            this.labelKreirajZahtjev.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKreirajZahtjev.Name = "labelKreirajZahtjev";
            this.labelKreirajZahtjev.Size = new System.Drawing.Size(108, 48);
            this.labelKreirajZahtjev.TabIndex = 12;
            this.labelKreirajZahtjev.Text = "Kreiraj zahtjev";
            this.labelKreirajZahtjev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelKreirajZahtjev.Click += new System.EventHandler(this.labelKreirajZahtjev_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sweeper.Properties.Resources.Sweeper;
            this.pictureBox1.Location = new System.Drawing.Point(158, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPočetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(397, 300);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelOdjava);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPregledajZahtjeve);
            this.Controls.Add(this.labelKreirajZahtjev);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPočetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Početna";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOdjava;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPregledajZahtjeve;
        private System.Windows.Forms.Label labelKreirajZahtjev;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}