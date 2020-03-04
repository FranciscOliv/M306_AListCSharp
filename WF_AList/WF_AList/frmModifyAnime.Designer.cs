namespace WF_AList
{
    partial class frmModifyAnime
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnModifyCover = new System.Windows.Forms.Button();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblAnimeName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.pbxAnimeImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnimeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(247, 233);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(244, 61);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description";
            // 
            // btnModifyCover
            // 
            this.btnModifyCover.Location = new System.Drawing.Point(247, 204);
            this.btnModifyCover.Name = "btnModifyCover";
            this.btnModifyCover.Size = new System.Drawing.Size(215, 23);
            this.btnModifyCover.TabIndex = 10;
            this.btnModifyCover.Text = "Modifier l\'image";
            this.btnModifyCover.UseVisualStyleBackColor = true;
            this.btnModifyCover.Click += new System.EventHandler(this.btnModifyCover_Click);
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(247, 77);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDescription.Size = new System.Drawing.Size(215, 107);
            this.tbxDescription.TabIndex = 9;
            // 
            // lblAnimeName
            // 
            this.lblAnimeName.AutoSize = true;
            this.lblAnimeName.Location = new System.Drawing.Point(244, 12);
            this.lblAnimeName.Name = "lblAnimeName";
            this.lblAnimeName.Size = new System.Drawing.Size(29, 13);
            this.lblAnimeName.TabIndex = 8;
            this.lblAnimeName.Text = "Nom";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(247, 28);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(215, 20);
            this.tbxName.TabIndex = 7;
            // 
            // pbxAnimeImage
            // 
            this.pbxAnimeImage.Location = new System.Drawing.Point(12, 12);
            this.pbxAnimeImage.Name = "pbxAnimeImage";
            this.pbxAnimeImage.Size = new System.Drawing.Size(226, 244);
            this.pbxAnimeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAnimeImage.TabIndex = 14;
            this.pbxAnimeImage.TabStop = false;
            // 
            // frmModifyAnime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 271);
            this.Controls.Add(this.pbxAnimeImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnModifyCover);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblAnimeName);
            this.Controls.Add(this.tbxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmModifyAnime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier un anime";
            this.Load += new System.EventHandler(this.frmModifyAnime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAnimeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnModifyCover;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblAnimeName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.PictureBox pbxAnimeImage;
    }
}