using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dzielenie
{
    public partial class OknoDzielenie : Form
    {
        public OknoDzielenie()
        {
            InitializeComponent();
        }

        public string sciezkaDoRaportu = "";
        
        private void btnOblicz_Click(object sender, EventArgs e)
        {
            try
            {
                btnOblicz.Text = "Trwa obliczanie...";
                tbDzielna.ReadOnly = true;
                tbDzielnik.ReadOnly = true;

                try
                {
                    iDzielenie procesDzielenia = new Dzielenie(tbDzielna.Text, tbDzielnik.Text);
                    procesDzielenia.Oblicz();

                    sciezkaDoRaportu = procesDzielenia.plikRaport;
                    btnOtworzRaport.Enabled = true;

                    if (procesDzielenia.wynik != "OK")
                        MessageBox.Show(procesDzielenia.wynik);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Podczas próby obliczenia wystąpił błąd:\n" + ex.Message);
                }
                
            }
            catch(Exception ex)
            {
                btnOtworzRaport.Enabled = false;
                MessageBox.Show("Podczas procesu wystąpił błąd: " + ex.Message);
            }
            
            btnOblicz.Text = "Oblicz";
            tbDzielna.ReadOnly = false;
            tbDzielnik.ReadOnly = false;
        }

        private void btnWyjdz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void czyPodanoWartosci(object sender, EventArgs e)
        {
            btnOblicz.Enabled = tbDzielna.Text.Length > 0 && tbDzielnik.Text.Length > 0 ? true : false;
        }

        private void OtworzRaport_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(sciezkaDoRaportu))
                    System.Diagnostics.Process.Start("notepad.exe", sciezkaDoRaportu);
                else
                {
                    MessageBox.Show("Nie znaleziono pliku z raportem.");
                    btnOtworzRaport.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd podczas próby otwarcia pliku z raportem.\n" + ex.Message);
                btnOtworzRaport.Enabled = false;
            }
        }
    }
}
