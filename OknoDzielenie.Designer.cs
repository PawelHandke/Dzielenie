namespace Dzielenie
{
    partial class OknoDzielenie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOblicz = new System.Windows.Forms.Button();
            this.tbDzielna = new System.Windows.Forms.TextBox();
            this.tbDzielnik = new System.Windows.Forms.TextBox();
            this.lblDzielna = new System.Windows.Forms.Label();
            this.lblDzielnik = new System.Windows.Forms.Label();
            this.btnWyjdz = new System.Windows.Forms.Button();
            this.bw_ObliczDzielenie = new System.ComponentModel.BackgroundWorker();
            this.btnOtworzRaport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOblicz
            // 
            this.btnOblicz.Enabled = false;
            this.btnOblicz.Location = new System.Drawing.Point(523, 56);
            this.btnOblicz.Name = "btnOblicz";
            this.btnOblicz.Size = new System.Drawing.Size(85, 46);
            this.btnOblicz.TabIndex = 0;
            this.btnOblicz.Text = "Oblicz";
            this.btnOblicz.UseVisualStyleBackColor = true;
            this.btnOblicz.Click += new System.EventHandler(this.btnOblicz_Click);
            // 
            // tbDzielna
            // 
            this.tbDzielna.Location = new System.Drawing.Point(30, 56);
            this.tbDzielna.Multiline = true;
            this.tbDzielna.Name = "tbDzielna";
            this.tbDzielna.Size = new System.Drawing.Size(225, 92);
            this.tbDzielna.TabIndex = 1;
            this.tbDzielna.TextChanged += new System.EventHandler(this.czyPodanoWartosci);
            // 
            // tbDzielnik
            // 
            this.tbDzielnik.Location = new System.Drawing.Point(296, 56);
            this.tbDzielnik.Multiline = true;
            this.tbDzielnik.Name = "tbDzielnik";
            this.tbDzielnik.Size = new System.Drawing.Size(197, 92);
            this.tbDzielnik.TabIndex = 2;
            this.tbDzielnik.TextChanged += new System.EventHandler(this.czyPodanoWartosci);
            // 
            // lblDzielna
            // 
            this.lblDzielna.AutoSize = true;
            this.lblDzielna.Location = new System.Drawing.Point(27, 40);
            this.lblDzielna.Name = "lblDzielna";
            this.lblDzielna.Size = new System.Drawing.Size(94, 13);
            this.lblDzielna.TabIndex = 3;
            this.lblDzielna.Text = "Wprowadź dzielną";
            // 
            // lblDzielnik
            // 
            this.lblDzielnik.AutoSize = true;
            this.lblDzielnik.Location = new System.Drawing.Point(293, 40);
            this.lblDzielnik.Name = "lblDzielnik";
            this.lblDzielnik.Size = new System.Drawing.Size(96, 13);
            this.lblDzielnik.TabIndex = 4;
            this.lblDzielnik.Text = "Wprowadź dzielnik";
            // 
            // btnWyjdz
            // 
            this.btnWyjdz.Location = new System.Drawing.Point(523, 282);
            this.btnWyjdz.Name = "btnWyjdz";
            this.btnWyjdz.Size = new System.Drawing.Size(85, 46);
            this.btnWyjdz.TabIndex = 5;
            this.btnWyjdz.Text = "Wyjdź";
            this.btnWyjdz.UseVisualStyleBackColor = true;
            this.btnWyjdz.Click += new System.EventHandler(this.btnWyjdz_Click);
            // 
            // btnOtworzRaport
            // 
            this.btnOtworzRaport.Enabled = false;
            this.btnOtworzRaport.Location = new System.Drawing.Point(523, 108);
            this.btnOtworzRaport.Name = "btnOtworzRaport";
            this.btnOtworzRaport.Size = new System.Drawing.Size(85, 46);
            this.btnOtworzRaport.TabIndex = 6;
            this.btnOtworzRaport.Text = "Otwórz raport";
            this.btnOtworzRaport.UseVisualStyleBackColor = true;
            this.btnOtworzRaport.Click += new System.EventHandler(this.OtworzRaport_Click);
            // 
            // OknoDzielenie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 371);
            this.Controls.Add(this.btnOtworzRaport);
            this.Controls.Add(this.btnWyjdz);
            this.Controls.Add(this.lblDzielnik);
            this.Controls.Add(this.lblDzielna);
            this.Controls.Add(this.tbDzielnik);
            this.Controls.Add(this.tbDzielna);
            this.Controls.Add(this.btnOblicz);
            this.Name = "OknoDzielenie";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOblicz;
        private System.Windows.Forms.TextBox tbDzielna;
        private System.Windows.Forms.TextBox tbDzielnik;
        private System.Windows.Forms.Label lblDzielna;
        private System.Windows.Forms.Label lblDzielnik;
        private System.Windows.Forms.Button btnWyjdz;
        private System.ComponentModel.BackgroundWorker bw_ObliczDzielenie;
        private System.Windows.Forms.Button btnOtworzRaport;
    }
}

