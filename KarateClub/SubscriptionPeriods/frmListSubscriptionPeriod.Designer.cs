namespace KarateClub.SubscriptionPeriods
{
    partial class frmListSubscriptionPeriod
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSubscriptionPeriodsList = new System.Windows.Forms.DataGridView();
            this.cmsEditProfile = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIsPaid = new System.Windows.Forms.ComboBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.cbIsExpired = new System.Windows.Forms.ComboBox();
            this.btnRenewPeriod = new System.Windows.Forms.PictureBox();
            this.btnAddNewSubscriptionPeriodID = new System.Windows.Forms.Button();
            this.ShowPeriodDetailstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenewtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showPeriodHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionPeriodsList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRenewPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubscriptionPeriodsList
            // 
            this.dgvSubscriptionPeriodsList.AllowUserToAddRows = false;
            this.dgvSubscriptionPeriodsList.AllowUserToDeleteRows = false;
            this.dgvSubscriptionPeriodsList.AllowUserToResizeRows = false;
            this.dgvSubscriptionPeriodsList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubscriptionPeriodsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubscriptionPeriodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscriptionPeriodsList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubscriptionPeriodsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubscriptionPeriodsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSubscriptionPeriodsList.Location = new System.Drawing.Point(15, 297);
            this.dgvSubscriptionPeriodsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSubscriptionPeriodsList.MultiSelect = false;
            this.dgvSubscriptionPeriodsList.Name = "dgvSubscriptionPeriodsList";
            this.dgvSubscriptionPeriodsList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubscriptionPeriodsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubscriptionPeriodsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubscriptionPeriodsList.Size = new System.Drawing.Size(1128, 371);
            this.dgvSubscriptionPeriodsList.TabIndex = 170;
            this.dgvSubscriptionPeriodsList.TabStop = false;
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.Black;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPeriodDetailstoolStripMenuItem1,
            this.addNewMemberToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.payToolStripMenuItem,
            this.RenewtoolStripMenuItem1,
            this.showPeriodHistoryToolStripMenuItem});
            this.cmsEditProfile.Name = "guna2ContextMenuStrip1";
            this.cmsEditProfile.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsEditProfile.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.ColorTable = null;
            this.cmsEditProfile.RenderStyle.RoundedEdges = true;
            this.cmsEditProfile.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsEditProfile.Size = new System.Drawing.Size(240, 270);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 194);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1128, 39);
            this.lblTitle.TabIndex = 167;
            this.lblTitle.Text = "Manage Subscription Periods";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(113, 677);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 165;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 677);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 164;
            this.label2.Text = "# Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Period ID",
            "Member Name",
            "Is Paid",
            "Payment ID",
            "Is Active",
            "Is Expired"});
            this.cbFilter.Location = new System.Drawing.Point(88, 262);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(210, 28);
            this.cbFilter.TabIndex = 162;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(315, 262);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(256, 26);
            this.txtSearch.TabIndex = 161;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 160;
            this.label1.Text = "Filter By:";
            // 
            // cbIsPaid
            // 
            this.cbIsPaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsPaid.FormattingEnabled = true;
            this.cbIsPaid.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsPaid.Location = new System.Drawing.Point(315, 262);
            this.cbIsPaid.Name = "cbIsPaid";
            this.cbIsPaid.Size = new System.Drawing.Size(113, 28);
            this.cbIsPaid.TabIndex = 168;
            this.cbIsPaid.SelectedIndexChanged += new System.EventHandler(this.cbIsPaid_SelectedIndexChanged);
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(315, 262);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(113, 28);
            this.cbIsActive.TabIndex = 172;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // cbIsExpired
            // 
            this.cbIsExpired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsExpired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsExpired.FormattingEnabled = true;
            this.cbIsExpired.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsExpired.Location = new System.Drawing.Point(315, 262);
            this.cbIsExpired.Name = "cbIsExpired";
            this.cbIsExpired.Size = new System.Drawing.Size(113, 28);
            this.cbIsExpired.TabIndex = 174;
            this.cbIsExpired.SelectedIndexChanged += new System.EventHandler(this.cbIsExpired_SelectedIndexChanged);
            // 
            // btnRenewPeriod
            // 
            this.btnRenewPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRenewPeriod.Image = global::KarateClub.Properties.Resources.renew_subscripion;
            this.btnRenewPeriod.Location = new System.Drawing.Point(948, 221);
            this.btnRenewPeriod.Name = "btnRenewPeriod";
            this.btnRenewPeriod.Size = new System.Drawing.Size(88, 70);
            this.btnRenewPeriod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRenewPeriod.TabIndex = 173;
            this.btnRenewPeriod.TabStop = false;
            this.btnRenewPeriod.Click += new System.EventHandler(this.btnRenewPeriod_Click);
            this.btnRenewPeriod.MouseEnter += new System.EventHandler(this.btnRenewPeriod_MouseEnter);
            this.btnRenewPeriod.MouseLeave += new System.EventHandler(this.btnRenewPeriod_MouseLeave);
            // 
            // btnAddNewSubscriptionPeriodID
            // 
            this.btnAddNewSubscriptionPeriodID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewSubscriptionPeriodID.Image = global::KarateClub.Properties.Resources.New_Application_64;
            this.btnAddNewSubscriptionPeriodID.Location = new System.Drawing.Point(1055, 221);
            this.btnAddNewSubscriptionPeriodID.Name = "btnAddNewSubscriptionPeriodID";
            this.btnAddNewSubscriptionPeriodID.Size = new System.Drawing.Size(88, 70);
            this.btnAddNewSubscriptionPeriodID.TabIndex = 171;
            this.btnAddNewSubscriptionPeriodID.UseVisualStyleBackColor = true;
            this.btnAddNewSubscriptionPeriodID.Click += new System.EventHandler(this.btnAddNewSubscriptionPeriodID_Click);
            // 
            // ShowPeriodDetailstoolStripMenuItem1
            // 
            this.ShowPeriodDetailstoolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ShowPeriodDetailstoolStripMenuItem1.Image = global::KarateClub.Properties.Resources.PersonDetails_32;
            this.ShowPeriodDetailstoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPeriodDetailstoolStripMenuItem1.Name = "ShowPeriodDetailstoolStripMenuItem1";
            this.ShowPeriodDetailstoolStripMenuItem1.Size = new System.Drawing.Size(239, 38);
            this.ShowPeriodDetailstoolStripMenuItem1.Text = "   Show Period Details";
            this.ShowPeriodDetailstoolStripMenuItem1.Click += new System.EventHandler(this.ShowPeriodDetailstoolStripMenuItem1_Click);
            // 
            // addNewMemberToolStripMenuItem
            // 
            this.addNewMemberToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewMemberToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addNewMemberToolStripMenuItem.Image = global::KarateClub.Properties.Resources.Add_Person_40;
            this.addNewMemberToolStripMenuItem.Name = "addNewMemberToolStripMenuItem";
            this.addNewMemberToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.addNewMemberToolStripMenuItem.Text = "   Add New Period";
            this.addNewMemberToolStripMenuItem.Click += new System.EventHandler(this.addNewMemberToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Image = global::KarateClub.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.editToolStripMenuItem.Text = "   Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteToolStripMenuItem.Image = global::KarateClub.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.deleteToolStripMenuItem.Text = "   Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // payToolStripMenuItem
            // 
            this.payToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.payToolStripMenuItem.Image = global::KarateClub.Properties.Resources.money_32;
            this.payToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.payToolStripMenuItem.Name = "payToolStripMenuItem";
            this.payToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.payToolStripMenuItem.Text = "   Pay";
            this.payToolStripMenuItem.Click += new System.EventHandler(this.payToolStripMenuItem_Click);
            // 
            // RenewtoolStripMenuItem1
            // 
            this.RenewtoolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.RenewtoolStripMenuItem1.Image = global::KarateClub.Properties.Resources.Renew_Driving_License_32;
            this.RenewtoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RenewtoolStripMenuItem1.Name = "RenewtoolStripMenuItem1";
            this.RenewtoolStripMenuItem1.Size = new System.Drawing.Size(239, 38);
            this.RenewtoolStripMenuItem1.Text = "   Renew Period";
            this.RenewtoolStripMenuItem1.Click += new System.EventHandler(this.RenewtoolStripMenuItem1_Click);
            // 
            // showPeriodHistoryToolStripMenuItem
            // 
            this.showPeriodHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showPeriodHistoryToolStripMenuItem.Image = global::KarateClub.Properties.Resources.Calendar_321;
            this.showPeriodHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPeriodHistoryToolStripMenuItem.Name = "showPeriodHistoryToolStripMenuItem";
            this.showPeriodHistoryToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.showPeriodHistoryToolStripMenuItem.Text = "   Show Period History";
            this.showPeriodHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPeriodHistoryToolStripMenuItem_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::KarateClub.Properties.Resources.subscription_period;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(457, 28);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 161);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 166;
            this.pbPersonImage.TabStop = false;
            // 
            // frmListSubscriptionPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1155, 724);
            this.Controls.Add(this.cbIsExpired);
            this.Controls.Add(this.btnRenewPeriod);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnAddNewSubscriptionPeriodID);
            this.Controls.Add(this.dgvSubscriptionPeriodsList);
            this.Controls.Add(this.cbIsPaid);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListSubscriptionPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListSubscriptionPeriod";
            this.Load += new System.EventHandler(this.frmListSubscriptionPeriod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionPeriodsList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRenewPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMemberToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNewSubscriptionPeriodID;
        private System.Windows.Forms.DataGridView dgvSubscriptionPeriodsList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ComboBox cbIsPaid;
        private System.Windows.Forms.ToolStripMenuItem payToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.ToolStripMenuItem showPeriodHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenewtoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowPeriodDetailstoolStripMenuItem1;
        private System.Windows.Forms.PictureBox btnRenewPeriod;
        private System.Windows.Forms.ComboBox cbIsExpired;
    }
}