using Sweeper.Models;
using Sweeper.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sweeper
{
    public partial class FrmKreiranjeZahtjeva : Form
    {
        public FrmKreiranjeZahtjeva()
        {
            InitializeComponent();
        }
        private void Vrijeme_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker1.Value;
            
        }

        private void PokreniPocetnu()
        {
            FrmPočetna frmPočetna = new FrmPočetna();
            Hide();
            frmPočetna.ShowDialog();
            Close();
        }

        private void btnOdustani_Click_1(object sender, EventArgs e)
        {
            PokreniPocetnu();
        }

        private void btnKreirajZahtjev_Click(object sender, EventArgs e)
        {
            string naziv = txtNaziv.Text;
            DateTime vrijemeKreiranja = DateTime.Now;
            string potrebnoVrijemeIzvodenja = txtTrajanje.Text;
            DateTime terminObavljanja = dateTimePicker1.Value;
            var nazivZaposlenika = cboZaposlenik.SelectedValue;

            var zaposlenik = ZaposlenikRepository.DohvatiZaposlenikaPremaImenu(nazivZaposlenika) as Zaposlenik;

            var nazivKategorije = cboKategorija.SelectedValue;
            var kategorija = KategorijaRepository.DohvatiKategorijuPremaNazivu(nazivKategorije);

            var nazivPodkategorije = cboPodkategorija.SelectedValue;
            var podkategorija = PodkategorijaRepository.DohvatiPodkategorijuPremaNazivu(nazivPodkategorije);

            if(kategorija.IdKategorija != 14)
            {
                ZahtjevRepository.KreirajZahtjev(naziv, vrijemeKreiranja, zaposlenik, terminObavljanja, potrebnoVrijemeIzvodenja, kategorija.IdKategorija, podkategorija.IdPodkategorija);
            }
            else
            {
                ZahtjevRepository.KreirajZahtjev(naziv, vrijemeKreiranja, zaposlenik, terminObavljanja, potrebnoVrijemeIzvodenja, kategorija.IdKategorija, 12);
            }
            

            MessageBox.Show("Zahtjev uspiješno kreiran");

            PokreniPocetnu();
        }

        private void FrmKreiranjeZahtjeva_Load(object sender, EventArgs e)
        {
            DohvatiZaposlenike();
            DohvatiKategorije();
        }

        private void DohvatiZaposlenike()
        {
            cboZaposlenik.DataSource = ZaposlenikRepository.DohvatiZaposlenike();
        }

        private void DohvatiKategorije()
        {
            cboKategorija.DataSource = KategorijaRepository.DohvatiKategorije();
        }



        private void DohvatiPodkategorije(int idKategorija)
        {
            var kategorija = KategorijaRepository.DohvatiKategoriju(idKategorija);
            string nazivKategorije = kategorija.NazivKategorije.ToString();
            if(nazivKategorije != "Cišcenje vanjskih površina i objekata")
            {
                var podkategorije = PodkategorijaRepository.DohvatiPodkategorije(kategorija.IdKategorija);
                cboPodkategorija.DataSource = podkategorije;
            }
            else
            {
                cboPodkategorija.DataSource = null;
                cboPodkategorija.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            
        }

        private void cboKategorija_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Kategorija odabranaKategorija = cboKategorija.SelectedItem as Kategorija;
            if (odabranaKategorija != null)
            {
                DohvatiPodkategorije(odabranaKategorija.IdKategorija);
            }
        }
    }
}
