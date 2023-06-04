
namespace SloziSliku_29_2019
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
            this.components = new System.ComponentModel.Container();
            this.btnUcitaj = new System.Windows.Forms.Button();
            this.btnNovaIgra = new System.Windows.Forms.Button();
            this.lblPoteza = new System.Windows.Forms.Label();
            this.lblUkupnoPoteza = new System.Windows.Forms.Label();
            this.gbRedovi = new System.Windows.Forms.GroupBox();
            this.rbRed4 = new System.Windows.Forms.RadioButton();
            this.rbRed5 = new System.Windows.Forms.RadioButton();
            this.rbRed3 = new System.Windows.Forms.RadioButton();
            this.gbKolone = new System.Windows.Forms.GroupBox();
            this.rbKolona4 = new System.Windows.Forms.RadioButton();
            this.rbKolona3 = new System.Windows.Forms.RadioButton();
            this.rbKolona5 = new System.Windows.Forms.RadioButton();
            this.btnBoja = new System.Windows.Forms.Button();
            this.btnKraj = new System.Windows.Forms.Button();
            this.lblNazivSlike = new System.Windows.Forms.Label();
            this.btnRezultati = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblVreme = new System.Windows.Forms.Label();
            this.gbRedovi.SuspendLayout();
            this.gbKolone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUcitaj
            // 
            this.btnUcitaj.Location = new System.Drawing.Point(899, 19);
            this.btnUcitaj.Margin = new System.Windows.Forms.Padding(2);
            this.btnUcitaj.Name = "btnUcitaj";
            this.btnUcitaj.Size = new System.Drawing.Size(82, 25);
            this.btnUcitaj.TabIndex = 0;
            this.btnUcitaj.Text = "Ucitaj sliku";
            this.btnUcitaj.UseVisualStyleBackColor = true;
            this.btnUcitaj.Click += new System.EventHandler(this.btnUcitaj_Click);
            // 
            // btnNovaIgra
            // 
            this.btnNovaIgra.Location = new System.Drawing.Point(899, 111);
            this.btnNovaIgra.Margin = new System.Windows.Forms.Padding(2);
            this.btnNovaIgra.Name = "btnNovaIgra";
            this.btnNovaIgra.Size = new System.Drawing.Size(82, 25);
            this.btnNovaIgra.TabIndex = 1;
            this.btnNovaIgra.Text = "Nova igra";
            this.btnNovaIgra.UseVisualStyleBackColor = true;
            this.btnNovaIgra.Click += new System.EventHandler(this.btnNovaIgra_Click);
            // 
            // lblPoteza
            // 
            this.lblPoteza.AutoSize = true;
            this.lblPoteza.Location = new System.Drawing.Point(902, 152);
            this.lblPoteza.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoteza.Name = "lblPoteza";
            this.lblPoteza.Size = new System.Drawing.Size(39, 13);
            this.lblPoteza.TabIndex = 3;
            this.lblPoteza.Text = "poteza";
            // 
            // lblUkupnoPoteza
            // 
            this.lblUkupnoPoteza.AutoSize = true;
            this.lblUkupnoPoteza.Location = new System.Drawing.Point(941, 152);
            this.lblUkupnoPoteza.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUkupnoPoteza.Name = "lblUkupnoPoteza";
            this.lblUkupnoPoteza.Size = new System.Drawing.Size(0, 13);
            this.lblUkupnoPoteza.TabIndex = 4;
            // 
            // gbRedovi
            // 
            this.gbRedovi.Controls.Add(this.rbRed4);
            this.gbRedovi.Controls.Add(this.rbRed5);
            this.gbRedovi.Controls.Add(this.rbRed3);
            this.gbRedovi.Location = new System.Drawing.Point(893, 210);
            this.gbRedovi.Margin = new System.Windows.Forms.Padding(2);
            this.gbRedovi.Name = "gbRedovi";
            this.gbRedovi.Padding = new System.Windows.Forms.Padding(2);
            this.gbRedovi.Size = new System.Drawing.Size(83, 120);
            this.gbRedovi.TabIndex = 5;
            this.gbRedovi.TabStop = false;
            this.gbRedovi.Text = "Broj vrsta";
            // 
            // rbRed4
            // 
            this.rbRed4.AutoSize = true;
            this.rbRed4.Checked = true;
            this.rbRed4.Location = new System.Drawing.Point(22, 50);
            this.rbRed4.Margin = new System.Windows.Forms.Padding(2);
            this.rbRed4.Name = "rbRed4";
            this.rbRed4.Size = new System.Drawing.Size(31, 17);
            this.rbRed4.TabIndex = 8;
            this.rbRed4.TabStop = true;
            this.rbRed4.Text = "4";
            this.rbRed4.UseVisualStyleBackColor = true;
            this.rbRed4.CheckedChanged += new System.EventHandler(this.rbRed4_CheckedChanged);
            // 
            // rbRed5
            // 
            this.rbRed5.AutoSize = true;
            this.rbRed5.Location = new System.Drawing.Point(22, 78);
            this.rbRed5.Margin = new System.Windows.Forms.Padding(2);
            this.rbRed5.Name = "rbRed5";
            this.rbRed5.Size = new System.Drawing.Size(31, 17);
            this.rbRed5.TabIndex = 9;
            this.rbRed5.Text = "5";
            this.rbRed5.UseVisualStyleBackColor = true;
            this.rbRed5.CheckedChanged += new System.EventHandler(this.rbRed5_CheckedChanged);
            // 
            // rbRed3
            // 
            this.rbRed3.AutoSize = true;
            this.rbRed3.Location = new System.Drawing.Point(22, 22);
            this.rbRed3.Margin = new System.Windows.Forms.Padding(2);
            this.rbRed3.Name = "rbRed3";
            this.rbRed3.Size = new System.Drawing.Size(31, 17);
            this.rbRed3.TabIndex = 7;
            this.rbRed3.Text = "3";
            this.rbRed3.UseVisualStyleBackColor = true;
            this.rbRed3.CheckedChanged += new System.EventHandler(this.rbRed3_CheckedChanged);
            // 
            // gbKolone
            // 
            this.gbKolone.Controls.Add(this.rbKolona4);
            this.gbKolone.Controls.Add(this.rbKolona3);
            this.gbKolone.Controls.Add(this.rbKolona5);
            this.gbKolone.Location = new System.Drawing.Point(894, 353);
            this.gbKolone.Margin = new System.Windows.Forms.Padding(2);
            this.gbKolone.Name = "gbKolone";
            this.gbKolone.Padding = new System.Windows.Forms.Padding(2);
            this.gbKolone.Size = new System.Drawing.Size(83, 120);
            this.gbKolone.TabIndex = 6;
            this.gbKolone.TabStop = false;
            this.gbKolone.Text = "Broj kolona";
            // 
            // rbKolona4
            // 
            this.rbKolona4.AutoSize = true;
            this.rbKolona4.Location = new System.Drawing.Point(22, 49);
            this.rbKolona4.Margin = new System.Windows.Forms.Padding(2);
            this.rbKolona4.Name = "rbKolona4";
            this.rbKolona4.Size = new System.Drawing.Size(31, 17);
            this.rbKolona4.TabIndex = 11;
            this.rbKolona4.Text = "4";
            this.rbKolona4.UseVisualStyleBackColor = true;
            this.rbKolona4.CheckedChanged += new System.EventHandler(this.rbKolona4_CheckedChanged);
            // 
            // rbKolona3
            // 
            this.rbKolona3.AutoSize = true;
            this.rbKolona3.Location = new System.Drawing.Point(22, 21);
            this.rbKolona3.Margin = new System.Windows.Forms.Padding(2);
            this.rbKolona3.Name = "rbKolona3";
            this.rbKolona3.Size = new System.Drawing.Size(31, 17);
            this.rbKolona3.TabIndex = 10;
            this.rbKolona3.Text = "3";
            this.rbKolona3.UseVisualStyleBackColor = true;
            this.rbKolona3.CheckedChanged += new System.EventHandler(this.rbKolona3_CheckedChanged);
            // 
            // rbKolona5
            // 
            this.rbKolona5.AutoSize = true;
            this.rbKolona5.Checked = true;
            this.rbKolona5.Location = new System.Drawing.Point(22, 78);
            this.rbKolona5.Margin = new System.Windows.Forms.Padding(2);
            this.rbKolona5.Name = "rbKolona5";
            this.rbKolona5.Size = new System.Drawing.Size(31, 17);
            this.rbKolona5.TabIndex = 12;
            this.rbKolona5.TabStop = true;
            this.rbKolona5.Text = "5";
            this.rbKolona5.UseVisualStyleBackColor = true;
            this.rbKolona5.CheckedChanged += new System.EventHandler(this.rbKolona5_CheckedChanged);
            // 
            // btnBoja
            // 
            this.btnBoja.Location = new System.Drawing.Point(893, 499);
            this.btnBoja.Margin = new System.Windows.Forms.Padding(2);
            this.btnBoja.Name = "btnBoja";
            this.btnBoja.Size = new System.Drawing.Size(82, 25);
            this.btnBoja.TabIndex = 7;
            this.btnBoja.Text = "Boja linija";
            this.btnBoja.UseVisualStyleBackColor = true;
            this.btnBoja.Click += new System.EventHandler(this.btnBoja_Click);
            // 
            // btnKraj
            // 
            this.btnKraj.Location = new System.Drawing.Point(891, 596);
            this.btnKraj.Margin = new System.Windows.Forms.Padding(2);
            this.btnKraj.Name = "btnKraj";
            this.btnKraj.Size = new System.Drawing.Size(82, 25);
            this.btnKraj.TabIndex = 8;
            this.btnKraj.Text = "Kraj";
            this.btnKraj.UseVisualStyleBackColor = true;
            this.btnKraj.Click += new System.EventHandler(this.btnKraj_Click);
            // 
            // lblNazivSlike
            // 
            this.lblNazivSlike.Location = new System.Drawing.Point(903, 57);
            this.lblNazivSlike.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNazivSlike.Name = "lblNazivSlike";
            this.lblNazivSlike.Size = new System.Drawing.Size(79, 49);
            this.lblNazivSlike.TabIndex = 9;
            // 
            // btnRezultati
            // 
            this.btnRezultati.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRezultati.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezultati.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRezultati.Location = new System.Drawing.Point(42, 4);
            this.btnRezultati.Margin = new System.Windows.Forms.Padding(2);
            this.btnRezultati.Name = "btnRezultati";
            this.btnRezultati.Size = new System.Drawing.Size(162, 30);
            this.btnRezultati.TabIndex = 10;
            this.btnRezultati.Text = "NAJBOLJI REZULTATI";
            this.btnRezultati.UseVisualStyleBackColor = false;
            this.btnRezultati.Click += new System.EventHandler(this.btnRezultati_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblVreme
            // 
            this.lblVreme.AutoSize = true;
            this.lblVreme.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVreme.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblVreme.Location = new System.Drawing.Point(415, 9);
            this.lblVreme.Name = "lblVreme";
            this.lblVreme.Size = new System.Drawing.Size(96, 25);
            this.lblVreme.TabIndex = 13;
            this.lblVreme.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 651);
            this.ControlBox = false;
            this.Controls.Add(this.lblVreme);
            this.Controls.Add(this.btnRezultati);
            this.Controls.Add(this.lblNazivSlike);
            this.Controls.Add(this.btnKraj);
            this.Controls.Add(this.btnBoja);
            this.Controls.Add(this.gbKolone);
            this.Controls.Add(this.gbRedovi);
            this.Controls.Add(this.lblUkupnoPoteza);
            this.Controls.Add(this.lblPoteza);
            this.Controls.Add(this.btnNovaIgra);
            this.Controls.Add(this.btnUcitaj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbRedovi.ResumeLayout(false);
            this.gbRedovi.PerformLayout();
            this.gbKolone.ResumeLayout(false);
            this.gbKolone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUcitaj;
        private System.Windows.Forms.Button btnNovaIgra;
        private System.Windows.Forms.Label lblPoteza;
        private System.Windows.Forms.Label lblUkupnoPoteza;
        private System.Windows.Forms.GroupBox gbRedovi;
        private System.Windows.Forms.GroupBox gbKolone;
        private System.Windows.Forms.RadioButton rbRed4;
        private System.Windows.Forms.RadioButton rbRed5;
        private System.Windows.Forms.RadioButton rbRed3;
        private System.Windows.Forms.RadioButton rbKolona4;
        private System.Windows.Forms.RadioButton rbKolona3;
        private System.Windows.Forms.RadioButton rbKolona5;
        private System.Windows.Forms.Button btnBoja;
        private System.Windows.Forms.Button btnKraj;
        private System.Windows.Forms.Label lblNazivSlike;
        private System.Windows.Forms.Button btnRezultati;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblVreme;
    }
}

