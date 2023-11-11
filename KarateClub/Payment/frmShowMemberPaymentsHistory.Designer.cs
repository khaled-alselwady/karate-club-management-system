namespace KarateClub.Payment
{
    partial class frmShowMemberPaymentsHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucMemberCard1 = new KarateClub.Members.UserControls.ucMemberCard();
            this.ucMemberPayments1 = new KarateClub.Payment.UserControls.ucMemberPayments();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(916, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Member Payments History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMemberCard1
            // 
            this.ucMemberCard1.BackColor = System.Drawing.Color.White;
            this.ucMemberCard1.Location = new System.Drawing.Point(12, 57);
            this.ucMemberCard1.Name = "ucMemberCard1";
            this.ucMemberCard1.Size = new System.Drawing.Size(895, 358);
            this.ucMemberCard1.TabIndex = 5;
            // 
            // ucMemberPayments1
            // 
            this.ucMemberPayments1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucMemberPayments1.BackColor = System.Drawing.Color.White;
            this.ucMemberPayments1.Location = new System.Drawing.Point(0, 434);
            this.ucMemberPayments1.Name = "ucMemberPayments1";
            this.ucMemberPayments1.Size = new System.Drawing.Size(920, 356);
            this.ucMemberPayments1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KarateClub.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(764, 798);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 37);
            this.btnClose.TabIndex = 120;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowMemberPaymentsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 839);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucMemberPayments1);
            this.Controls.Add(this.ucMemberCard1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowMemberPaymentsHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Member Payments History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Members.UserControls.ucMemberCard ucMemberCard1;
        private UserControls.ucMemberPayments ucMemberPayments1;
        private System.Windows.Forms.Button btnClose;
    }
}