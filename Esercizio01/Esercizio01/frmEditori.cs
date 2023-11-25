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
    public partial class frmEditori : Form
    {
        bool seleziona = true;

        public frmEditori()
        {
            InitializeComponent();
        }

        private void frmEditori_Load(object sender, EventArgs e)
        {
            clsEditoriController listaEditori = new clsEditoriController();

            caricaEditori(listaEditori.elencoEditori());
        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void caricaEditori(List<clsEditori> lista)
        {
            // Carico la DGV
            dgvEditori.DataSource = lista;
            dgvEditori.Columns[0].HeaderText = "Id";
            dgvEditori.Columns[1].HeaderText = "Nome";
            dgvEditori.Columns[2].HeaderText = "Validità";
            dgvEditori.ClearSelection();

            // Carico la COMBO
            cmbEditori.DataSource = lista;
            cmbEditori.DisplayMember = "NomeEditore";
            cmbEditori.ValueMember = "IdEditore";
            cmbEditori.SelectedIndex = -1;
        }

        private void chkAnnullati_CheckedChanged(object sender, EventArgs e)
        {
            visElencoEditori();
        }

        private void visElencoEditori()
        {
            clsEditoriController listaEditori = new clsEditoriController();

            dgvEditori.DataSource = null;
            cmbEditori.DataSource = null;

            if (chkAnnullati.Checked)
                caricaEditori(listaEditori.elencoEditoriAnnullati());
            else
                caricaEditori(listaEditori.elencoEditori());
        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            gestioneVideo(false);

            txtNomeEditore.Focus();
        }

        private void gestioneVideo(bool abilita)
        {
            grbElenco.Enabled = abilita;
            cmbEditori.Enabled = abilita;
            grpEditore.Enabled = !abilita;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            pulisciVideo();
        }

        private void pulisciVideo()
        {
            txtNomeEditore.Text = string.Empty;
            chkAnnullato.Checked = false;
            btnConferma.Text = "C O N F E R M A";
            gestioneVideo(true);
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            bool errore = false;

            if (chkDatiReparti())
            {
                clsEditoriController insEditore = new clsEditoriController();
                insEditore.Editore.NomeEditore = txtNomeEditore.Text;

                if (chkAnnullato.Checked) insEditore.Editore.ValEditore = 'A';

                if (btnConferma.Text == "C O N F E R M A") errore = insEditore.aggiungi();
                else errore = insEditore.modifica();

                if (!errore)
                {
                    pulisciVideo();
                    visElencoEditori();
                }

                MessageBox.Show(insEditore.msgErrore);
            }
        }

        private bool chkDatiReparti()
        {
            bool esito = true;


            if (txtNomeEditore.Text == string.Empty)
            {
                MessageBox.Show("Il Nome non è stato inserito");
                txtNomeEditore.Focus();
                esito = false;
            }

            return esito;
        }

        private void cmbEditori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEditori.SelectedIndex != -1 && cmbEditori.ValueMember != string.Empty && seleziona)
            {

                clsEditoriController detEditore = new clsEditoriController();
                clsEditori modEditore = new clsEditori();

                btnConferma.Text = "M O D I F I C A";

                detEditore.Editore.IdEditore = Convert.ToInt32(cmbEditori.SelectedValue);
                modEditore = detEditore.datiEditore();

                txtNomeEditore.Text = modEditore.NomeEditore;
                if (modEditore.ValEditore == 'A')
                    chkAnnullato.Checked = true;

                gestioneVideo(false);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
