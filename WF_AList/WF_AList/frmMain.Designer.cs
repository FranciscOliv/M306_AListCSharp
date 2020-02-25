namespace WF_AList
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.msFrmMain = new System.Windows.Forms.MenuStrip();
            this.animeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblErrors = new System.Windows.Forms.Label();
            this.msFrmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msFrmMain
            // 
            this.msFrmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animeToolStripMenuItem});
            this.msFrmMain.Location = new System.Drawing.Point(0, 0);
            this.msFrmMain.Name = "msFrmMain";
            this.msFrmMain.Size = new System.Drawing.Size(800, 24);
            this.msFrmMain.TabIndex = 0;
            // 
            // animeToolStripMenuItem
            // 
            this.animeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem});
            this.animeToolStripMenuItem.Name = "animeToolStripMenuItem";
            this.animeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.animeToolStripMenuItem.Text = "Anime";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(94, 194);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(35, 13);
            this.lblErrors.TabIndex = 1;
            this.lblErrors.Text = "label1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.msFrmMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.msFrmMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AList";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msFrmMain.ResumeLayout(false);
            this.msFrmMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msFrmMain;
        private System.Windows.Forms.ToolStripMenuItem animeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.Label lblErrors;
    }
}

