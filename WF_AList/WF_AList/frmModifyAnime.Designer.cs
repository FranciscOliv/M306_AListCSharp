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
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(125, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(15, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description";
            // 
            // btnModifyCover
            // 
            this.btnModifyCover.Location = new System.Drawing.Point(15, 187);
            this.btnModifyCover.Name = "btnModifyCover";
            this.btnModifyCover.Size = new System.Drawing.Size(215, 23);
            this.btnModifyCover.TabIndex = 10;
            this.btnModifyCover.Text = "Modifier l\'image";
            this.btnModifyCover.UseVisualStyleBackColor = true;
            this.btnModifyCover.Click += new System.EventHandler(this.btnModifyCover_Click);
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(15, 74);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(215, 107);
            this.tbxDescription.TabIndex = 9;
            // 
            // lblAnimeName
            // 
            this.lblAnimeName.AutoSize = true;
            this.lblAnimeName.Location = new System.Drawing.Point(12, 9);
            this.lblAnimeName.Name = "lblAnimeName";
            this.lblAnimeName.Size = new System.Drawing.Size(29, 13);
            this.lblAnimeName.TabIndex = 8;
            this.lblAnimeName.Text = "Nom";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(15, 25);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(215, 20);
            this.tbxName.TabIndex = 7;
            // 
            // frmModifyAnime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 257);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnModifyCover);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblAnimeName);
            this.Controls.Add(this.tbxName);
            this.Name = "frmModifyAnime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmModifyAnime";
            this.Load += new System.EventHandler(this.frmModifyAnime_Load);
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
    }
}