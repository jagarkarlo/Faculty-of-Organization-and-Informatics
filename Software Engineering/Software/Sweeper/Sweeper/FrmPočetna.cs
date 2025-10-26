using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sweeper.Models;
using Sweeper.Repositories;

namespace Sweeper
{
    public partial class FrmPočetna : Form
    {
        public FrmPočetna()
        {
            InitializeComponent();
        }

        private void labelOdjava_Click(object sender, EventArgs e)
        {
            FrmLogin frmPrijava = new FrmLogin();
            Hide();
            frmPrijava.ShowDialog();
            Close();
        }

        private void labelPregledajZahtjeve_Click(object sender, EventArgs e)
        {
            FrmPregledZahtjeva frmPregledajZahtjev = new FrmPregledZahtjeva();
            Hide();
            frmPregledajZahtjev.ShowDialog();
            Close();
        }

        private void labelKreirajZahtjev_Click(object sender, EventArgs e)
        {
            FrmKreiranjeZahtjeva frmZahtjev = new FrmKreiranjeZahtjeva();
            Hide();
            frmZahtjev.ShowDialog();
            Close();
        }
    }
}
