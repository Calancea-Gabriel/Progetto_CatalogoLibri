namespace Esercizio01
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anagraficheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repartiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offerteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificareLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repartoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 140);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anagraficheToolStripMenuItem,
            this.libriToolStripMenuItem,
            this.chiudiToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anagraficheToolStripMenuItem
            // 
            this.anagraficheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repartiToolStripMenuItem,
            this.offerteToolStripMenuItem,
            this.editoriToolStripMenuItem,
            this.autoriToolStripMenuItem});
            this.anagraficheToolStripMenuItem.Name = "anagraficheToolStripMenuItem";
            this.anagraficheToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.anagraficheToolStripMenuItem.Text = "Anagrafiche";
            // 
            // repartiToolStripMenuItem
            // 
            this.repartiToolStripMenuItem.Name = "repartiToolStripMenuItem";
            this.repartiToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.repartiToolStripMenuItem.Text = "Reparti";
            this.repartiToolStripMenuItem.Click += new System.EventHandler(this.repartiToolStripMenuItem_Click);
            // 
            // offerteToolStripMenuItem
            // 
            this.offerteToolStripMenuItem.Name = "offerteToolStripMenuItem";
            this.offerteToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.offerteToolStripMenuItem.Text = "Offerte";
            this.offerteToolStripMenuItem.Click += new System.EventHandler(this.offerteToolStripMenuItem_Click);
            // 
            // editoriToolStripMenuItem
            // 
            this.editoriToolStripMenuItem.Name = "editoriToolStripMenuItem";
            this.editoriToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.editoriToolStripMenuItem.Text = "Editori";
            this.editoriToolStripMenuItem.Click += new System.EventHandler(this.editoriToolStripMenuItem_Click);
            // 
            // autoriToolStripMenuItem
            // 
            this.autoriToolStripMenuItem.Name = "autoriToolStripMenuItem";
            this.autoriToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.autoriToolStripMenuItem.Text = "Autori";
            this.autoriToolStripMenuItem.Click += new System.EventHandler(this.autoriToolStripMenuItem_Click);
            // 
            // libriToolStripMenuItem
            // 
            this.libriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoLibroToolStripMenuItem,
            this.modificareLibroToolStripMenuItem});
            this.libriToolStripMenuItem.Name = "libriToolStripMenuItem";
            this.libriToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.libriToolStripMenuItem.Text = "Libri";
            // 
            // nuovoLibroToolStripMenuItem
            // 
            this.nuovoLibroToolStripMenuItem.Name = "nuovoLibroToolStripMenuItem";
            this.nuovoLibroToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nuovoLibroToolStripMenuItem.Text = "Nuovo Libro";
            this.nuovoLibroToolStripMenuItem.Click += new System.EventHandler(this.nuovoLibroToolStripMenuItem_Click);
            // 
            // modificareLibroToolStripMenuItem
            // 
            this.modificareLibroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repartoToolStripMenuItem,
            this.offertaToolStripMenuItem});
            this.modificareLibroToolStripMenuItem.Name = "modificareLibroToolStripMenuItem";
            this.modificareLibroToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.modificareLibroToolStripMenuItem.Text = "Modificare Libro";
            // 
            // repartoToolStripMenuItem
            // 
            this.repartoToolStripMenuItem.Name = "repartoToolStripMenuItem";
            this.repartoToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.repartoToolStripMenuItem.Text = "Reparto";
            this.repartoToolStripMenuItem.Click += new System.EventHandler(this.repartoToolStripMenuItem_Click);
            // 
            // offertaToolStripMenuItem
            // 
            this.offertaToolStripMenuItem.Name = "offertaToolStripMenuItem";
            this.offertaToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.offertaToolStripMenuItem.Text = "Offerta";
            this.offertaToolStripMenuItem.Click += new System.EventHandler(this.offertaToolStripMenuItem_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(384, 206);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 245);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 245);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione CATALOGO LIBRI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anagraficheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repartiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offerteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificareLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repartoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offertaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiudiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

