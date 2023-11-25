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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chiudiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void repartiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReparti frm = new frmReparti();
            frm.ShowDialog();
        }

        private void offerteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOfferte frm = new frmOfferte();
            frm.ShowDialog();

        }

        private void autoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutori frm = new frmAutori();
            frm.ShowDialog();
        }

        private void nuovoLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuovoLibro frm = new frmNuovoLibro();
            frm.ShowDialog();
        }

        private void repartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRicercaByReparto frm = new frmRicercaByReparto();
            frm.ShowDialog();
        }

        private void offertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRicercaByOfferta frm = new frmRicercaByOfferta();
            frm.ShowDialog();
        }

        private void editoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditori frm = new frmEditori();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfo frm = new frmInfo();
            frm.ShowDialog();
        }
    }
}
