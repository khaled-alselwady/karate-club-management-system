namespace KarateClub.SubscriptionPeriods
{
    partial class frmShowSubscriptionPeriodsHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ucMemberCard1 = new KarateClub.Members.UserControls.ucMemberCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucMemberSubscriptionPeriods1 = new KarateClub.SubscriptionPeriods.UserControls.ucMemberSubscriptionPeriods();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(6, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(906, 39);
            this.lblTitle.TabIndex = 168;
            this.lblTitle.Text = "Subscription Periods History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMemberCard1
            // 
            this.ucMemberCard1.BackColor = System.Drawing.Color.White;
            this.ucMemberCard1.Location = new System.Drawing.Point(22, 79);
            this.ucMemberCard1.Name = "ucMemberCard1";
            this.ucMemberCard1.Size = new System.Drawing.Size(899, 363);
            this.ucMemberCard1.TabIndex = 169;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KarateClub.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(775, 812);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 37);
            this.btnClose.TabIndex = 177;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucMemberSubscriptionPeriods1
            // 
            this.ucMemberSubscriptionPeriods1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucMemberSubscriptionPeriods1.BackColor = System.Drawing.Color.White;
            this.ucMemberSubscriptionPeriods1.Location = new System.Drawing.Point(9, 449);
            this.ucMemberSubscriptionPeriods1.Name = "ucMemberSubscriptionPeriods1";
            this.ucMemberSubscriptionPeriods1.Size = new System.Drawing.Size(922, 355);
            this.ucMemberSubscriptionPeriods1.TabIndex = 178;
            // 
            // frmShowSubscriptionPeriodsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 854);
            this.Controls.Add(this.ucMemberSubscriptionPeriods1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucMemberCard1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowSubscriptionPeriodsHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Subscription Periods History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Members.UserControls.ucMemberCard ucMemberCard1;
        private System.Windows.Forms.Button btnClose;
        private UserControls.ucMemberSubscriptionPeriods ucMemberSubscriptionPeriods1;
    }
}