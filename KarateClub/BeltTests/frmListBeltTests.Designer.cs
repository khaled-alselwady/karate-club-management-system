namespace KarateClub.BeltTests
{
    partial class frmListBeltTests
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
            this.dgvBeltTestsList = new System.Windows.Forms.DataGridView();
            this.cbBeltRank = new System.Windows.Forms.ComboBox();
            this.cbResult = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsEditProfile = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.ShowTestDetailstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTestsHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewBeltTest = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeltTestsList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBeltTestsList
            // 
            this.dgvBeltTestsList.AllowUserToAddRows = false;
            this.dgvBeltTestsList.AllowUserToDeleteRows = false;
            this.dgvBeltTestsList.AllowUserToResizeRows = false;
            this.dgvBeltTestsList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBeltTestsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBeltTestsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBeltTestsList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBeltTestsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBeltTestsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBeltTestsList.Location = new System.Drawing.Point(15, 297);
            this.dgvBeltTestsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBeltTestsList.MultiSelect = false;
            this.dgvBeltTestsList.Name = "dgvBeltTestsList";
            this.dgvBeltTestsList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBeltTestsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBeltTestsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBeltTestsList.Size = new System.Drawing.Size(1128, 371);
            this.dgvBeltTestsList.TabIndex = 170;
            this.dgvBeltTestsList.TabStop = false;
            this.dgvBeltTestsList.DoubleClick += new System.EventHandler(this.dgvBeltTestsList_DoubleClick);
            // 
            // cbBeltRank
            // 
            this.cbBeltRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeltRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeltRank.FormattingEnabled = true;
            this.cbBeltRank.Location = new System.Drawing.Point(310, 260);
            this.cbBeltRank.Name = "cbBeltRank";
            this.cbBeltRank.Size = new System.Drawing.Size(213, 28);
            this.cbBeltRank.TabIndex = 169;
            this.cbBeltRank.SelectedIndexChanged += new System.EventHandler(this.cbBeltRank_SelectedIndexChanged);
            // 
            // cbResult
            // 
            this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Items.AddRange(new object[] {
            "All",
            "Pass",
            "Fail"});
            this.cbResult.Location = new System.Drawing.Point(310, 260);
            this.cbResult.Name = "cbResult";
            this.cbResult.Size = new System.Drawing.Size(113, 28);
            this.cbResult.TabIndex = 168;
            this.cbResult.SelectedIndexChanged += new System.EventHandler(this.cbResult_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 194);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1128, 39);
            this.lblTitle.TabIndex = 167;
            this.lblTitle.Text = "Manage Belt Tests";
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
            "Test ID",
            "Member Name",
            "Instructor Name",
            "Rank Name",
            "Payment ID",
            "Result"});
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
            this.txtSearch.Location = new System.Drawing.Point(310, 262);
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
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.Black;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowTestDetailstoolStripMenuItem1,
            this.addNewTestToolStripMenuItem,
            this.showTestsHistoryToolStripMenuItem});
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
            this.cmsEditProfile.Size = new System.Drawing.Size(231, 140);
            // 
            // ShowTestDetailstoolStripMenuItem1
            // 
            this.ShowTestDetailstoolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowTestDetailstoolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.ShowTestDetailstoolStripMenuItem1.Image = global::KarateClub.Properties.Resources.PersonDetails_32;
            this.ShowTestDetailstoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowTestDetailstoolStripMenuItem1.Name = "ShowTestDetailstoolStripMenuItem1";
            this.ShowTestDetailstoolStripMenuItem1.Size = new System.Drawing.Size(230, 38);
            this.ShowTestDetailstoolStripMenuItem1.Text = "   Show Test Details";
            this.ShowTestDetailstoolStripMenuItem1.Click += new System.EventHandler(this.ShowTestDetailstoolStripMenuItem1_Click);
            // 
            // addNewTestToolStripMenuItem
            // 
            this.addNewTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewTestToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addNewTestToolStripMenuItem.Image = global::KarateClub.Properties.Resources.Notes_32;
            this.addNewTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewTestToolStripMenuItem.Name = "addNewTestToolStripMenuItem";
            this.addNewTestToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.addNewTestToolStripMenuItem.Text = "   Take Next Belt Test";
            this.addNewTestToolStripMenuItem.Click += new System.EventHandler(this.addNewTestToolStripMenuItem_Click);
            // 
            // showTestsHistoryToolStripMenuItem
            // 
            this.showTestsHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showTestsHistoryToolStripMenuItem.Image = global::KarateClub.Properties.Resources.Calendar_32;
            this.showTestsHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showTestsHistoryToolStripMenuItem.Name = "showTestsHistoryToolStripMenuItem";
            this.showTestsHistoryToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.showTestsHistoryToolStripMenuItem.Text = "   Show Tests History";
            this.showTestsHistoryToolStripMenuItem.Click += new System.EventHandler(this.showTestsHistoryToolStripMenuItem_Click);
            // 
            // btnAddNewBeltTest
            // 
            this.btnAddNewBeltTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewBeltTest.Image = global::KarateClub.Properties.Resources.New_Application_64;
            this.btnAddNewBeltTest.Location = new System.Drawing.Point(1055, 221);
            this.btnAddNewBeltTest.Name = "btnAddNewBeltTest";
            this.btnAddNewBeltTest.Size = new System.Drawing.Size(88, 70);
            this.btnAddNewBeltTest.TabIndex = 171;
            this.btnAddNewBeltTest.UseVisualStyleBackColor = true;
            this.btnAddNewBeltTest.Click += new System.EventHandler(this.btnAddNewBeltTest_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::KarateClub.Properties.Resources.Application_Types_512;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(457, 28);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 161);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 166;
            this.pbPersonImage.TabStop = false;
            // 
            // frmListBeltTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1155, 724);
            this.Controls.Add(this.dgvBeltTestsList);
            this.Controls.Add(this.cbBeltRank);
            this.Controls.Add(this.btnAddNewBeltTest);
            this.Controls.Add(this.cbResult);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListBeltTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListBeltTests";
            this.Load += new System.EventHandler(this.frmListBeltTests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBeltTestsList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBeltTestsList;
        private System.Windows.Forms.ComboBox cbBeltRank;
        private System.Windows.Forms.ToolStripMenuItem showTestsHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTestToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNewBeltTest;
        private System.Windows.Forms.ComboBox cbResult;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolStripMenuItem ShowTestDetailstoolStripMenuItem1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
    }
}