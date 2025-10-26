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
    public partial class FrmPregledZahtjeva : Form
    {
        public FrmPregledZahtjeva()
        {
            InitializeComponent();
        }

        private void FrmPregledZahtjeva_Load(object sender, EventArgs e)
        {
            PrikaziZahtjeve();
        }

        private void PrikaziZahtjeve()
        {
            var zahtjevi = ZahtjevRepository.DohvatiZahtjeve();
            dgvZahtjevi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvZahtjevi.DataSource = zahtjevi;
            dgvZahtjevi.Columns[0].HeaderText = "Redni broj zahtjeva";
            dgvZahtjevi.Columns[1].HeaderText = "Ime i prezime klijenta";
            dgvZahtjevi.Columns[2].HeaderText = "Vrijeme kreiranja zahtjeva";
            dgvZahtjevi.Columns[3].HeaderText = "Potrebno vrijeme izvodenja";
            dgvZahtjevi.Columns[4].HeaderText = "Termin obavljanja";
            dgvZahtjevi.Columns[5].HeaderText = "Zaposlenik";
            dgvZahtjevi.Columns[6].HeaderText = "Kategorija";
            dgvZahtjevi.Columns[7].HeaderText = "Podkategorija";
        }

        private void txtNazivZahtjeva_TextChanged(object sender, EventArgs e)
        {
            var zahtjeviNaziv = ZahtjevRepository.PretražiNazivZahtjeva(txtNazivZahtjeva.Text);
            dgvZahtjevi.DataSource = zahtjeviNaziv;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Zahtjev stisnutiZahtjev = dgvZahtjevi.CurrentRow.DataBoundItem as Zahtjev;
            FrmAzurirajZahtjev frm = new FrmAzurirajZahtjev(stisnutiZahtjev);

            Hide();
            frm.ShowDialog();
            Close();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmPočetna frmPočetna = new FrmPočetna();
            Hide();
            frmPočetna.ShowDialog();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Zahtjev zahtjev = dgvZahtjevi.CurrentRow.DataBoundItem as Zahtjev;
            ZahtjevRepository.IzbrisiZahtjev(zahtjev);
            PrikaziZahtjeve();
        }
    }
}
