using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Esercizio01.Control;
using Esercizio01.Model;

namespace Esercizio01
{
    public partial class frmReparti : Form
    {

        bool seleziona = true;

        public frmReparti()
        {
            InitializeComponent();
        }

        private void frmReparti_Load(object sender, EventArgs e)
        {
            clsRepartiController listaReparti = new clsRepartiController();

            caricaReparti(listaReparti.elencoReparti());
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void caricaReparti(List<clsReparti> lista)
        {
            // Carico la DGV
            dgvReparti.DataSource = lista;
            dgvReparti.Columns[0].HeaderText = "Codice";
            dgvReparti.Columns[1].HeaderText = "Descrizione";
            dgvReparti.Columns[2].HeaderText = "Validità";
            dgvReparti.ClearSelection();

            // Carico la COMBO
            seleziona = false;
            cmbReparti.DataSource = lista;
            cmbReparti.DisplayMember = "DesReparto";
            cmbReparti.ValueMember = "CodReparto";
            cmbReparti.SelectedIndex = -1;
            seleziona = true;
        }

        private void chkAnnullati_CheckedChanged(object sender, EventArgs e)
        {
            visElencoReparti();
        }

        private void visElencoReparti()
        {
            clsRepartiController listaReparti = new clsRepartiController();

            dgvReparti.DataSource = null;
            cmbReparti.DataSource = null;

            if (chkAnnullati.Checked)
                caricaReparti(listaReparti.elencoRepartiAnnullati());
            else
                caricaReparti(listaReparti.elencoReparti());
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            gestioneVideo(false);

            txtCodice.Focus();
        }



        private void gestioneVideo(bool abilita)
        {
            grbElenco.Enabled = abilita;
            cmbReparti.Enabled = abilita;
            grbReparto.Enabled = !abilita;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            pulisciVideo();
        }

        private void pulisciVideo()
        {
            txtCodice.Text = string.Empty;
            txtDescrizione.Text = string.Empty;
            chkAnnullato.Checked = false;
            btnConferma.Text = "C O N F E R M A";
            gestioneVideo(true);
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            bool errore = false;

            if (chkDatiReparti())
            {
                clsRepartiController insReparto = new clsRepartiController();
                insReparto.Reparto.CodReparto = txtCodice.Text;
                insReparto.Reparto.DesReparto = txtDescrizione.Text;

                if (chkAnnullato.Checked) insReparto.Reparto.ValReparto = 'A';

                if (btnConferma.Text == "C O N F E R M A") errore = insReparto.aggiungi();
                else errore = insReparto.modifica();
                
                if (!errore)
                {
                    pulisciVideo();
                    visElencoReparti();
                }
                
                MessageBox.Show(insReparto.msgErrore);
            }
        }

        private bool chkDatiReparti()
        {
            bool esito = true;
            

            if (txtCodice.Text == string.Empty)
            {
                MessageBox.Show("Il Codice non è stato inserito");
                txtCodice.Focus();
                esito = false;
            }
            else if (txtDescrizione.Text == string.Empty)
            {
                MessageBox.Show("La Descrizione non è stata inserita");
                txtDescrizione.Focus();
                esito = false;
            }
            else
            {
                
                if (btnConferma.Text == "C O N F E R M A")
                {
                    // Controllo la duplicazione del Codice Reparto
                    clsRepartiController detReparto = new clsRepartiController();
                    detReparto.Reparto.CodReparto = txtCodice.Text;
                    if (!detReparto.chkReparto())
                    {
                        MessageBox.Show(detReparto.msgErrore);
                        txtCodice.Focus();
                        esito = false;
                    }
                }
                
            }
            

            return esito;
        }

        private void cmbReparti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReparti.SelectedIndex != -1 && cmbReparti.ValueMember != string.Empty && seleziona)
            {

                clsRepartiController detReparto = new clsRepartiController();
                clsReparti modReparto = new clsReparti();

                btnConferma.Text = "M O D I F I C A";

                detReparto.Reparto.CodReparto = cmbReparti.SelectedValue.ToString();
                modReparto = detReparto.datiReparto();

                txtCodice.Text = modReparto.CodReparto;
                txtDescrizione.Text = modReparto.DesReparto;
                if (modReparto.ValReparto == 'A')
                    chkAnnullato.Checked = true;

                gestioneVideo(false);
                txtCodice.ReadOnly = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
