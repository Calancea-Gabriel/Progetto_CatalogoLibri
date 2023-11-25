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
    public partial class frmRicercaByReparto : Form
    {
        private int IdLibroGlobale;

        public frmRicercaByReparto()
        {
            InitializeComponent();
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRicercaByReparto_Load(object sender, EventArgs e)
        {
            // Carico la COMBO delle offerte
            clsOfferteController ListaOfferte = new clsOfferteController();
            clsEditoriController listaEditori = new clsEditoriController();
            clsRepartiController ListaReparti = new clsRepartiController();

            // ----- Reparti (visualizza sulla dgv) -----
            cmbReparti.DataSource = ListaReparti.elencoRepartiLibri();
            cmbReparti.DisplayMember = "DesReparto";
            cmbReparti.ValueMember = "CodReparto";
            cmbReparti.SelectedIndex = -1;

            // ----- Editori -----
            cmbEditore.DataSource = listaEditori.elencoEditoriLibri();
            cmbEditore.DisplayMember = "NomeEditore";
            cmbEditore.ValueMember = "IdEditore";
            cmbEditore.SelectedIndex = -1;

            // ----- Reparti (Modifica) -----
            cmbCodRep.DataSource = ListaReparti.elencoRepartiLibri();
            cmbCodRep.DisplayMember = "DesReparto";
            cmbCodRep.ValueMember = "CodReparto";
            cmbCodRep.SelectedIndex = -1;

            // ----- Offerte -----
            cmbIdOff.DataSource = ListaOfferte.elencoOfferteLibri();
            cmbIdOff.DisplayMember = "DesOfferta";
            cmbIdOff.ValueMember = "IdOfferta";
            cmbIdOff.SelectedIndex = -1;
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
        }

        private void dgvLibri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblInformazione.Text = "Modifica il libro selezionato oppure premi ANNULLA";

            grpElenco.Enabled = false;
            grpModifica.Enabled = true;

            IdLibroGlobale = Convert.ToInt32(dgvLibri.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtTitolo.Text = dgvLibri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtImg.Text = dgvLibri.Rows[e.RowIndex].Cells[2].Value.ToString();
            nudPrezzo.Text = dgvLibri.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpDataLibro.Text = Convert.ToDateTime(dgvLibri.Rows[e.RowIndex].Cells[4].Value).ToString("dd/MM/yyyy");
            nudNPagine.Value = Convert.ToInt32(dgvLibri.Rows[e.RowIndex].Cells[5].Value.ToString());
            cmbCodRep.SelectedValue = dgvLibri.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbIdOff.SelectedValue = Convert.ToInt32(dgvLibri.Rows[e.RowIndex].Cells[7].Value);
            cmbEditore.SelectedValue = Convert.ToInt32(dgvLibri.Rows[e.RowIndex].Cells[8].Value);

            if (dgvLibri.Rows[e.RowIndex].Cells[9].Value.ToString() == "A")
                chkAnnullato.Checked = true;
            else
                chkAnnullato.Checked = false;
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            bool errore = false;
            clsLibriController modLibro = new clsLibriController();
            modLibro.Libro.IdLibro = IdLibroGlobale;
            modLibro.Libro.TitLibro = txtTitolo.Text;
            modLibro.Libro.ImgLibro = txtImg.Text;
            modLibro.Libro.PrzLibro = nudPrezzo.Value;
            modLibro.Libro.DataLibro = dtpDataLibro.Value;
            modLibro.Libro.NPagLibro = Convert.ToInt32(nudNPagine.Value);
            modLibro.Libro.CodRepLibro = cmbCodRep.SelectedValue.ToString();
            modLibro.Libro.IdOffLibro = Convert.ToInt32(cmbIdOff.SelectedValue);
            modLibro.Libro.IdEdiLibro = Convert.ToInt32(cmbEditore.SelectedValue);
            if (chkAnnullato.Checked) modLibro.Libro.ValLibro = 'A';

            modLibro.modifica();

            if (!errore) visElencoLibri();

            grpElenco.Enabled = true;
            grpModifica.Enabled = false;

            pulisciVideo();

            MessageBox.Show(modLibro.msgErrore);
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            lblInformazione.Text = "Selezionare un libro dalla tabella per modificarlo";

            grpElenco.Enabled = true;
            grpModifica.Enabled = false;

            pulisciVideo();
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

        private void visElencoLibri()
        {
            clsLibriController insLibro = new clsLibriController();
            insLibro.Libro.CodRepLibro = cmbReparti.SelectedValue.ToString();

            dgvLibri.DataSource = null;

            if (chkAnnullati.Checked) caricaLibri(insLibro.elencoLibriByRepartoAnnullati());
            else caricaLibri(insLibro.elencoLibriByReparto());
        }

        private void chkAnnullati_CheckedChanged(object sender, EventArgs e)
        {
            visElencoLibri();
        }

        private void cmbReparti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReparti.SelectedIndex != -1 && cmbReparti.ValueMember != string.Empty)
            {
                lblInformazione.Text = "Selezionare un libro dalla tabella per modificarlo";
                pulisciVideo();
                clsLibriController insLibro = new clsLibriController();
                insLibro.Libro.CodRepLibro = cmbReparti.SelectedValue.ToString();
                caricaLibri(insLibro.elencoLibriByReparto());
                if (!chkAnnullati.Enabled) chkAnnullati.Enabled = true; 
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
