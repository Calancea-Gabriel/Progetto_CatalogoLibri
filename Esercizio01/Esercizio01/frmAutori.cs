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
    public partial class frmAutori : Form
    {
        bool seleziona = true;

        public frmAutori()
        {
            InitializeComponent();
        }
        private void frmAutori_Load(object sender, EventArgs e)
        {
            clsAutoriController listaAutori = new clsAutoriController();

            caricaAutori(listaAutori.elencoAutori());
        }

        private void caricaAutori(List<clsAutori> lista)
        {
            // Carico la DGV
            dgvAutori.DataSource = lista;
            dgvAutori.Columns[0].HeaderText = "Id";
            dgvAutori.Columns[1].HeaderText = "Cognome";
            dgvAutori.Columns[2].HeaderText = "Nome";
            dgvAutori.Columns[3].HeaderText = "Data Nascita";
            dgvAutori.Columns[4].HeaderText = "Foto";
            dgvAutori.Columns[5].HeaderText = "Validità";
            dgvAutori.ClearSelection();

            // Carico la COMBO
            seleziona = false;
            cmbAutori.DataSource = lista;
            cmbAutori.DisplayMember = "idAutore";
            cmbAutori.ValueMember = "idAutore";
            cmbAutori.SelectedIndex = -1;
            seleziona = true;
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            gestioneVideo(false);

            txtCognome.Focus();
        }

        private void chkAnnullati_CheckedChanged(object sender, EventArgs e)
        {
            visElencoAutori();
        }

        private void cmbAutori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAutori.SelectedIndex != -1 && cmbAutori.ValueMember != string.Empty && seleziona)
            {

                clsAutoriController detAutore = new clsAutoriController();
                clsAutori modAutore = new clsAutori();
                btnConferma.Text = "M O D I F I C A";

                detAutore.Autore.IdAutore = Convert.ToInt32(cmbAutori.SelectedValue);
                modAutore = detAutore.datiAutore();
                txtCognome.Text = modAutore.CognAutore;
                txtNome.Text = modAutore.NomeAutore;
                dtpDatNas.Value = modAutore.DatNasAutore;
                txtFoto.Text = modAutore.FotoAutore;

                if (modAutore.ValAutore == 'A')
                    chkAnnullato.Checked = true;

                gestioneVideo(false);
            }
        }

        private void gestioneVideo(bool abilita)
        {
            grbElenco.Enabled = abilita;
            cmbAutori.Enabled = abilita;
            grpAutore.Enabled = !abilita;
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            bool errore = false;

            if (chkDatiAutori())
            {
                clsAutoriController insAutore = new clsAutoriController();
                insAutore.Autore.IdAutore = Convert.ToInt32(cmbAutori.SelectedValue);
                insAutore.Autore.CognAutore = txtCognome.Text;
                insAutore.Autore.NomeAutore = txtNome.Text;
                insAutore.Autore.DatNasAutore = dtpDatNas.Value;
                insAutore.Autore.FotoAutore = txtFoto.Text;

                // Gestisco il valore della validità
                if (chkAnnullato.Checked) insAutore.Autore.ValAutore = 'A';

                // Controllo se devo inserire o modificare
                if (btnConferma.Text == "C O N F E R M A") errore = insAutore.aggiungi();
                else errore = insAutore.modifica();

                if (!errore)
                {
                    pulisciVideo();
                    visElencoAutori();
                }

                MessageBox.Show(insAutore.msgErrore);

            }
        }

        private void visElencoAutori()
        {
            clsAutoriController listaAutori = new clsAutoriController();

            dgvAutori.DataSource = null;
            cmbAutori.DataSource = null;

            if (chkAnnullati.Checked)
                caricaAutori(listaAutori.elencoAutoriAnnullati());
            else
                caricaAutori(listaAutori.elencoAutori());
        }

        private bool chkDatiAutori()
        {
            bool esito = true;

            if (txtCognome.Text == string.Empty)
            {
                MessageBox.Show("Il Cognome non è stato inserito");
                txtCognome.Focus();
                esito = false;
            }
            else if (txtNome.Text == string.Empty)
            {
                MessageBox.Show("Il Nome non è stato inserito");
                txtNome.Focus();
                esito = false;
            }
            else if (txtFoto.Text == string.Empty )
            {
                MessageBox.Show("La foto non è stata inserita");
                txtFoto.Focus();
                esito = false;
            }

            /* Non controllo se mentre inserisco un nuovo autore,
               il codice è già presente perchè è improbabile che
               ci siano due persone con gli stessi dati */

            return esito;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            pulisciVideo();
        }

        private void pulisciVideo()
        {
            txtCognome.Text = string.Empty;
            txtNome.Text = string.Empty;
            dtpDatNas.Value = DateTime.Now;
            txtFoto.Text = string.Empty;
            chkAnnullato.Checked = false;
            btnConferma.Text = "C O N F E R M A";
            gestioneVideo(true);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
