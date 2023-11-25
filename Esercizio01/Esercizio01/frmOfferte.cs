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
    public partial class frmOfferte : Form
    {
        bool seleziona = true;

        public frmOfferte()
        {
            InitializeComponent();
        }
        private void frmOfferte_Load(object sender, EventArgs e)
        {
            clsOfferteController listaOfferte = new clsOfferteController();

            caricaOfferte(listaOfferte.elencoOfferte());
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void caricaOfferte(List<clsOfferte> lista)
        {
            // Carico la DGV
            dgvOfferte.DataSource = lista;
            dgvOfferte.Columns[0].HeaderText = "Id";
            dgvOfferte.Columns[1].HeaderText = "Descrizione";
            dgvOfferte.Columns[2].HeaderText = "Sconto";
            dgvOfferte.Columns[3].HeaderText = "Validità";
            dgvOfferte.ClearSelection();

            // Carico la COMBO
            seleziona = false;
            cmbOfferte.DataSource = lista;
            cmbOfferte.DisplayMember = "DesOfferta";
            cmbOfferte.ValueMember = "IdOfferta";
            cmbOfferte.SelectedIndex = -1;
            seleziona = true;
        }

        private void cmbOfferte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOfferte.SelectedIndex != -1 && cmbOfferte.ValueMember != string.Empty && seleziona)
            {
                clsOfferteController detOfferta = new clsOfferteController();
                clsOfferte modOfferta = new clsOfferte();
                btnConferma.Text = "M O D I F I C A";

                detOfferta.Offerta.IdOfferta = Convert.ToInt16(cmbOfferte.SelectedValue);
                modOfferta = detOfferta.datiOfferta();

                txtDescrizione.Text = modOfferta.DesOfferta;
                nudSconto.Value = modOfferta.ScontoOfferta;
                if (modOfferta.ValOfferta == 'A')
                    chkAnnullato.Checked = true;

                gestioneVideo(false);
            }
        }

        private void gestioneVideo(bool abilita)
        {
            grbElenco.Enabled = abilita;
            cmbOfferte.Enabled = abilita;
            grpOfferta.Enabled = !abilita;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            pulisciVideo();
        }

        private void pulisciVideo()
        {
            txtDescrizione.Text = string.Empty;
            nudSconto.Value = 0;
            chkAnnullato.Checked = false;
            btnConferma.Text = "C O N F E R M A";
            gestioneVideo(true);
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            bool errore = false;

            if (chkDatiOfferte())
            {
                clsOfferteController insOfferta = new clsOfferteController();
                insOfferta.Offerta.IdOfferta = Convert.ToInt16(cmbOfferte.SelectedValue);
                insOfferta.Offerta.DesOfferta = txtDescrizione.Text;
                insOfferta.Offerta.ScontoOfferta = Convert.ToInt16(nudSconto.Value);

                // Gestisco il valore della validità
                if (chkAnnullato.Checked) insOfferta.Offerta.ValOfferta = 'A';

                // Controllo se devo inserire o modificare
                if (btnConferma.Text == "C O N F E R M A") errore = insOfferta.aggiungi();
                else errore = insOfferta.modifica();
                
                if (!errore)
                {
                    pulisciVideo();
                    visElencoOfferte();
                }
                
                MessageBox.Show(insOfferta.msgErrore);

            }
        }

        private bool chkDatiOfferte()
        {
            bool esito = true;

            if (txtDescrizione.Text == string.Empty)
            {
                MessageBox.Show("La Descrizione non è stata inserita");
                txtDescrizione.Focus();
                esito = false;
            }

            else
            {
                if (btnConferma.Text == "C O N F E R M A")
                {
                    // Controllo la duplicazione della descrizione dell'offerta
                    clsOfferteController detOfferta = new clsOfferteController();
                    detOfferta.Offerta.DesOfferta = txtDescrizione.Text;
                    if (!detOfferta.chkOfferta())
                    {
                        MessageBox.Show(detOfferta.msgErrore);
                        txtDescrizione.Focus();
                        esito = false;
                    }
                }

            }


            return esito;
        }

        private void visElencoOfferte()
        {
            clsOfferteController listaOfferte = new clsOfferteController();

            dgvOfferte.DataSource = null;
            cmbOfferte.DataSource = null;

            if (chkAnnullati.Checked)
                caricaOfferte(listaOfferte.elencoOfferteAnnullate());
            else
                caricaOfferte(listaOfferte.elencoOfferte());
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            gestioneVideo(false);

            txtDescrizione.Focus();
        }

        private void chkAnnullati_CheckedChanged(object sender, EventArgs e)
        {
            visElencoOfferte();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
