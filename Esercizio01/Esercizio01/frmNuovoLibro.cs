using Esercizio01.Control;
using Esercizio01.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esercizio01
{
    public partial class frmNuovoLibro : Form
    {
        public frmNuovoLibro()
        {
            InitializeComponent();
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNuovoLibro_Load(object sender, EventArgs e)
        {
            clsLibriController listaLibri = new clsLibriController();

            caricaLibri(listaLibri.elencoLibri());
        }

        private void caricaLibri(List<clsLibri> lista)
        {

            // Carico la DGV
            dgvLibri.DataSource = lista;
            dgvLibri.Columns[0].HeaderText = "Id";
            dgvLibri.Columns[1].HeaderText = "Titolo";
            dgvLibri.Columns[2].HeaderText = "Img";
            dgvLibri.Columns[3].HeaderText = "Prezzo";
            dgvLibri.Columns[4].HeaderText = "Data";
            dgvLibri.Columns[5].HeaderText = "N° Pagine";
            dgvLibri.Columns[6].HeaderText = "Codice Reparto";
            dgvLibri.Columns[7].HeaderText = "Id Offerta";
            dgvLibri.Columns[8].HeaderText = "Id Editore";
            dgvLibri.Columns[9].HeaderText = "Validità";
            dgvLibri.ClearSelection();

            // Carico la COMBO degli Editori, Offerte e Reparti
            clsEditoriController listaEditori = new clsEditoriController();
            clsOfferteController ListaOfferte = new clsOfferteController();
            clsRepartiController ListaReparti = new clsRepartiController();

            // ----- Editori -----
            cmbEditore.DataSource = listaEditori.elencoEditoriLibri();
            cmbEditore.DisplayMember = "NomeEditore";
            cmbEditore.ValueMember = "IdEditore";
            cmbEditore.SelectedIndex = -1;

            // ----- Offerte -----
            cmbIdOff.DataSource = ListaOfferte.elencoOfferteLibri();
            cmbIdOff.DisplayMember = "DesOfferta";
            cmbIdOff.ValueMember = "IdOfferta";
            cmbIdOff.SelectedIndex = -1;

            // ----- Reparti -----
            cmbCodRep.DataSource = ListaReparti.elencoRepartiLibri();
            cmbCodRep.DisplayMember = "DesReparto";
            cmbCodRep.ValueMember = "CodReparto";
            cmbCodRep.SelectedIndex = -1;
        }

        private void pulisciVideo()
        {
            txtTitolo.Text = string.Empty;
            txtImg.Text = string.Empty;
            nudPrezzo.Value = 0;
            dtpDataLibro.Value = DateTime.Now;
            nudNPagine.Value = 0;
            cmbCodRep.SelectedIndex = -1;
            cmbIdOff.SelectedIndex = -1;
            cmbEditore.SelectedIndex = -1;
            chkAnnullato.Checked = false;
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            bool errore = false;

            clsLibriController insLibro = new clsLibriController();
            insLibro.Libro.TitLibro = txtTitolo.Text;
            insLibro.Libro.ImgLibro = txtImg.Text;
            insLibro.Libro.PrzLibro = nudPrezzo.Value;
            insLibro.Libro.DataLibro = dtpDataLibro.Value;
            insLibro.Libro.NPagLibro = Convert.ToInt32(nudNPagine.Value);
            insLibro.Libro.CodRepLibro = cmbCodRep.SelectedValue.ToString();
            insLibro.Libro.IdOffLibro = Convert.ToInt32(cmbIdOff.SelectedValue);
            insLibro.Libro.IdEdiLibro = Convert.ToInt32(cmbEditore.SelectedValue);

            // Gestisco il valore della validità
            if (chkAnnullato.Checked) insLibro.Libro.ValLibro = 'A';

            // Controllo se devo inserire o modificare
            errore = insLibro.aggiungi();

            if (!errore)
            {
                pulisciVideo();
                visElencoLibri();
            }

            MessageBox.Show(insLibro.msgErrore);

        }

        private void visElencoLibri()
        {
            clsLibriController listaOfferte = new clsLibriController();

            dgvLibri.DataSource = null;

            if (chkAnnullati.Checked)
                caricaLibri(listaOfferte.elencoLibriAnnullati());
            else
                caricaLibri(listaOfferte.elencoLibri());
        }


        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            pulisciVideo();
        }

        private void chkAnnullati_CheckedChanged(object sender, EventArgs e)
        {
            visElencoLibri();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
