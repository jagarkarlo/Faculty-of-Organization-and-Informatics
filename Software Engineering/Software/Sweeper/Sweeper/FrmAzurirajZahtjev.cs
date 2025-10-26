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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Sweeper
{
    public partial class FrmAzurirajZahtjev : Form
    {
        public Zahtjev zahtjevi { get; set; }

        private List<Zaposlenik> zaposlenici;
        private List<Kategorija> kategorije;
        private List<Podkategorija> podkategorije;

        public FrmAzurirajZahtjev(Zahtjev stisnutiZahtjev)
        {
            Console.WriteLine(stisnutiZahtjev);
            InitializeComponent();
            zahtjevi = stisnutiZahtjev;
            Console.WriteLine(zahtjevi);
        }
        private void FrmAzurirajZahtjev_Load_1(object sender, EventArgs e)
        {
            txtNaziv.Text = zahtjevi.Naziv;
            txtTrajanje.Text = zahtjevi.PotrebnoVrijemeIzvodenja;
            dateTimePicker1.Value = zahtjevi.TerminObavljanja;

            DohvatiZaposlenike();
            DohvatiKategorije();
            var naziv = cboKategorija.SelectedValue;
            int idKategorije = KategorijaRepository.DohvatiKategorijuPremaNazivu(naziv).IdKategorija;

            DohvatiPodkategorije(idKategorije);
        }

        private void DohvatiZaposlenike()
        {
            zaposlenici = ZaposlenikRepository.DohvatiZaposlenike();
            cboZaposlenik.DataSource = zaposlenici;
        }

        private void DohvatiKategorije()
        {
            kategorije = KategorijaRepository.DohvatiKategorije();
            cboKategorija.DataSource = kategorije;
        }

        private void DohvatiPodkategorije(int idKategorija)
        {
            var kategorija = kategorije.Find(k => k.IdKategorija == idKategorija);
            if (kategorija != null)
            {
                string nazivKategorije = kategorija.NazivKategorije.ToString();
                if (nazivKategorije != "Čišćenje vanjskih površina i objekata")
                {
                    podkategorije = PodkategorijaRepository.DohvatiPodkategorije(kategorija.IdKategorija);
                    cboPodkategorija.DataSource = podkategorije;

                }
                else
                {
                    cboPodkategorija.DataSource = null;
                    cboPodkategorija.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            PokreniPregledZahtjeva();
        }

        private void PokreniPregledZahtjeva()
        {
            FrmPregledZahtjeva frmPregled = new FrmPregledZahtjeva();
            Hide();
            frmPregled.ShowDialog();
            Close();
        }

        private void btnAzurirajZahtjev_Click(object sender, EventArgs e)
        {
            var zahtjev = zahtjevi;

            String naziv = txtNaziv.Text;

            string potrebnoVrijemeIzvodenja = txtTrajanje.Text;

            DateTime VrijemeKreiranjaFormatiran = DateTime.Now;

            DateTime TerminObavljanjaFormatiran = dateTimePicker1.Value;

            var zaposlenik = cboZaposlenik.SelectedItem as Zaposlenik;

            var kategorija = cboKategorija.SelectedValue;
            int idKategorije = KategorijaRepository.DohvatiKategorijuPremaNazivu(kategorija).IdKategorija;

            var podkategorija = cboPodkategorija.SelectedValue;
            int idPodkategorije = PodkategorijaRepository.DohvatiPodkategorijuPremaNazivu(podkategorija).IdPodkategorija;

            ZahtjevRepository.AzurirajZahtjev(zahtjev, naziv, VrijemeKreiranjaFormatiran, zaposlenik, TerminObavljanjaFormatiran, potrebnoVrijemeIzvodenja, idKategorije, idPodkategorije);

            MessageBox.Show("Zahtjev je uspješno ažuriran.", "Ažuriranje zahtjeva", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            PokreniPregledZahtjeva();
        }

        private void cboKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategorija odabranaKategorija = cboKategorija.SelectedItem as Kategorija;
            if (odabranaKategorija != null)
            {
                DohvatiPodkategorije(odabranaKategorija.IdKategorija);
            }
        }
    }
}
