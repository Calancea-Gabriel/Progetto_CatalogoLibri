namespace Esercizio01
{
    partial class frmRicercaByReparto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chiudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grpModifica = new System.Windows.Forms.GroupBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEditore = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbIdOff = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAnnullato = new System.Windows.Forms.CheckBox();
            this.cmbCodRep = new System.Windows.Forms.ComboBox();
            this.nudNPagine = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDataLibro = new System.Windows.Forms.DateTimePicker();
            this.nudPrezzo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitolo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpElenco = new System.Windows.Forms.GroupBox();
            this.chkAnnullati = new System.Windows.Forms.CheckBox();
            this.dgvLibri = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReparti = new System.Windows.Forms.ComboBox();
            this.lblInformazione = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.grpModifica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNPagine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrezzo)).BeginInit();
            this.grpElenco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibri)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiudiToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chiudiToolStripMenuItem
            // 
            this.chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
            this.chiudiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.chiudiToolStripMenuItem.Text = "Chiudi";
            this.chiudiToolStripMenuItem.Click += new System.EventHandler(this.chiudiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // grpModifica
            // 
            this.grpModifica.Controls.Add(this.btnAnnulla);
            this.grpModifica.Controls.Add(this.btnModifica);
            this.grpModifica.Controls.Add(this.label8);
            this.grpModifica.Controls.Add(this.cmbEditore);
            this.grpModifica.Controls.Add(this.label7);
            this.grpModifica.Controls.Add(this.cmbIdOff);
            this.grpModifica.Controls.Add(this.label6);
            this.grpModifica.Controls.Add(this.chkAnnullato);
            this.grpModifica.Controls.Add(this.cmbCodRep);
            this.grpModifica.Controls.Add(this.nudNPagine);
            this.grpModifica.Controls.Add(this.label5);
            this.grpModifica.Controls.Add(this.label4);
            this.grpModifica.Controls.Add(this.dtpDataLibro);
            this.grpModifica.Controls.Add(this.nudPrezzo);
            this.grpModifica.Controls.Add(this.label3);
            this.grpModifica.Controls.Add(this.txtImg);
            this.grpModifica.Controls.Add(this.label2);
            this.grpModifica.Controls.Add(this.txtTitolo);
            this.grpModifica.Controls.Add(this.label9);
            this.grpModifica.Enabled = false;
            this.grpModifica.Location = new System.Drawing.Point(879, 30);
            this.grpModifica.Name = "grpModifica";
            this.grpModifica.Size = new System.Drawing.Size(347, 460);
            this.grpModifica.TabIndex = 17;
            this.grpModifica.TabStop = false;
            this.grpModifica.Text = "Modifica L\'offerta";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.BackColor = System.Drawing.Color.LightCoral;
            this.btnAnnulla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulla.Location = new System.Drawing.Point(178, 405);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(144, 37);
            this.btnAnnulla.TabIndex = 50;
            this.btnAnnulla.Text = "A N N U L L A";
            this.btnAnnulla.UseVisualStyleBackColor = false;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.BackColor = System.Drawing.Color.LightGreen;
            this.btnModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifica.Location = new System.Drawing.Point(12, 405);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(144, 37);
            this.btnModifica.TabIndex = 49;
            this.btnModifica.Text = "M O D I F I C A";
            this.btnModifica.UseVisualStyleBackColor = false;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Editore";
            // 
            // cmbEditore
            // 
            this.cmbEditore.FormattingEnabled = true;
            this.cmbEditore.Location = new System.Drawing.Point(62, 256);
            this.cmbEditore.Name = "cmbEditore";
            this.cmbEditore.Size = new System.Drawing.Size(208, 21);
            this.cmbEditore.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Offerta Libro";
            // 
            // cmbIdOff
            // 
            this.cmbIdOff.FormattingEnabled = true;
            this.cmbIdOff.Location = new System.Drawing.Point(88, 229);
            this.cmbIdOff.Name = "cmbIdOff";
            this.cmbIdOff.Size = new System.Drawing.Size(208, 21);
            this.cmbIdOff.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Codice Reparto";
            // 
            // chkAnnullato
            // 
            this.chkAnnullato.AutoSize = true;
            this.chkAnnullato.Location = new System.Drawing.Point(20, 293);
            this.chkAnnullato.Name = "chkAnnullato";
            this.chkAnnullato.Size = new System.Drawing.Size(70, 17);
            this.chkAnnullato.TabIndex = 43;
            this.chkAnnullato.Text = "Annullato";
            this.chkAnnullato.UseVisualStyleBackColor = true;
            // 
            // cmbCodRep
            // 
            this.cmbCodRep.FormattingEnabled = true;
            this.cmbCodRep.Location = new System.Drawing.Point(104, 202);
            this.cmbCodRep.Name = "cmbCodRep";
            this.cmbCodRep.Size = new System.Drawing.Size(208, 21);
            this.cmbCodRep.TabIndex = 42;
            // 
            // nudNPagine
            // 
            this.nudNPagine.Location = new System.Drawing.Point(103, 176);
            this.nudNPagine.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudNPagine.Name = "nudNPagine";
            this.nudNPagine.Size = new System.Drawing.Size(208, 20);
            this.nudNPagine.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Numero Pagine";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Data";
            // 
            // dtpDataLibro
            // 
            this.dtpDataLibro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataLibro.Location = new System.Drawing.Point(53, 150);
            this.dtpDataLibro.Name = "dtpDataLibro";
            this.dtpDataLibro.Size = new System.Drawing.Size(208, 20);
            this.dtpDataLibro.TabIndex = 38;
            // 
            // nudPrezzo
            // 
            this.nudPrezzo.Location = new System.Drawing.Point(62, 124);
            this.nudPrezzo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudPrezzo.Name = "nudPrezzo";
            this.nudPrezzo.Size = new System.Drawing.Size(208, 20);
            this.nudPrezzo.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Prezzo";
            // 
            // txtImg
            // 
            this.txtImg.Location = new System.Drawing.Point(75, 98);
            this.txtImg.Name = "txtImg";
            this.txtImg.Size = new System.Drawing.Size(208, 20);
            this.txtImg.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Immagine";
            // 
            // txtTitolo
            // 
            this.txtTitolo.Location = new System.Drawing.Point(56, 72);
            this.txtTitolo.Name = "txtTitolo";
            this.txtTitolo.Size = new System.Drawing.Size(208, 20);
            this.txtTitolo.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Titolo";
            // 
            // grpElenco
            // 
            this.grpElenco.Controls.Add(this.lblInformazione);
            this.grpElenco.Controls.Add(this.chkAnnullati);
            this.grpElenco.Controls.Add(this.dgvLibri);
            this.grpElenco.Controls.Add(this.label1);
            this.grpElenco.Controls.Add(this.cmbReparti);
            this.grpElenco.Location = new System.Drawing.Point(12, 30);
            this.grpElenco.Name = "grpElenco";
            this.grpElenco.Size = new System.Drawing.Size(861, 460);
            this.grpElenco.TabIndex = 16;
            this.grpElenco.TabStop = false;
            this.grpElenco.Text = "Elenco Libri By Offerta";
            // 
            // chkAnnullati
            // 
            this.chkAnnullati.AutoSize = true;
            this.chkAnnullati.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAnnullati.Enabled = false;
            this.chkAnnullati.Location = new System.Drawing.Point(789, 33);
            this.chkAnnullati.Name = "chkAnnullati";
            this.chkAnnullati.Size = new System.Drawing.Size(66, 17);
            this.chkAnnullati.TabIndex = 51;
            this.chkAnnullati.Text = "Annullati";
            this.chkAnnullati.UseVisualStyleBackColor = true;
            this.chkAnnullati.CheckedChanged += new System.EventHandler(this.chkAnnullati_CheckedChanged);
            // 
            // dgvLibri
            // 
            this.dgvLibri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibri.Location = new System.Drawing.Point(6, 56);
            this.dgvLibri.MultiSelect = false;
            this.dgvLibri.Name = "dgvLibri";
            this.dgvLibri.ReadOnly = true;
            this.dgvLibri.Size = new System.Drawing.Size(849, 386);
            this.dgvLibri.TabIndex = 0;
            this.dgvLibri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLibri_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reparto";
            // 
            // cmbReparti
            // 
            this.cmbReparti.FormattingEnabled = true;
            this.cmbReparti.Location = new System.Drawing.Point(53, 29);
            this.cmbReparti.Name = "cmbReparti";
            this.cmbReparti.Size = new System.Drawing.Size(167, 21);
            this.cmbReparti.TabIndex = 0;
            this.cmbReparti.SelectedIndexChanged += new System.EventHandler(this.cmbReparti_SelectedIndexChanged);
            // 
            // lblInformazione
            // 
            this.lblInformazione.AutoSize = true;
            this.lblInformazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformazione.ForeColor = System.Drawing.Color.DarkRed;
            this.lblInformazione.Location = new System.Drawing.Point(246, 26);
            this.lblInformazione.Name = "lblInformazione";
            this.lblInformazione.Size = new System.Drawing.Size(306, 24);
            this.lblInformazione.TabIndex = 53;
            this.lblInformazione.Text = "Scegli Il Reparto da visualizzare";
            // 
            // frmRicercaByReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1238, 502);
            this.Controls.Add(this.grpModifica);
            this.Controls.Add(this.grpElenco);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmRicercaByReparto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRicercaByReparto";
            this.Load += new System.EventHandler(this.frmRicercaByReparto_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpModifica.ResumeLayout(false);
            this.grpModifica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNPagine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrezzo)).EndInit();
            this.grpElenco.ResumeLayout(false);
            this.grpElenco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chiudiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.GroupBox grpModifica;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEditore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbIdOff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAnnullato;
        private System.Windows.Forms.ComboBox cmbCodRep;
        private System.Windows.Forms.NumericUpDown nudNPagine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDataLibro;
        private System.Windows.Forms.NumericUpDown nudPrezzo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitolo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpElenco;
        private System.Windows.Forms.CheckBox chkAnnullati;
        private System.Windows.Forms.DataGridView dgvLibri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReparti;
        private System.Windows.Forms.Label lblInformazione;
    }
}