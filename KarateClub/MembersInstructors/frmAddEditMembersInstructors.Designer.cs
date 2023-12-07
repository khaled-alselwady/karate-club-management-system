namespace KarateClub.MembersInstructors
{
    partial class frmAddEditMembersInstructors
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
            this.tcMembersInstructors = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpMember = new System.Windows.Forms.TabPage();
            this.ucMemberCardWithFilter1 = new KarateClub.Members.UserControls.ucMemberCardWithFilter();
            this.btnMemberInfoNext = new System.Windows.Forms.Button();
            this.tpInstructor = new System.Windows.Forms.TabPage();
            this.ucInstructorCardWithFilter1 = new KarateClub.Instructors.UserControls.ucInstructorCardWithFilter();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpAssignDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblMembersInstructorsID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tcMembersInstructors.SuspendLayout();
            this.tpMember.SuspendLayout();
            this.tpInstructor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(923, 48);
            this.lblTitle.TabIndex = 166;
            this.lblTitle.Text = "Tilte";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcMembersInstructors
            // 
            this.tcMembersInstructors.Controls.Add(this.tpMember);
            this.tcMembersInstructors.Controls.Add(this.tpInstructor);
            this.tcMembersInstructors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMembersInstructors.ItemSize = new System.Drawing.Size(180, 40);
            this.tcMembersInstructors.Location = new System.Drawing.Point(8, 84);
            this.tcMembersInstructors.Name = "tcMembersInstructors";
            this.tcMembersInstructors.SelectedIndex = 0;
            this.tcMembersInstructors.Size = new System.Drawing.Size(918, 547);
            this.tcMembersInstructors.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcMembersInstructors.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcMembersInstructors.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcMembersInstructors.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcMembersInstructors.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcMembersInstructors.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcMembersInstructors.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcMembersInstructors.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcMembersInstructors.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcMembersInstructors.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcMembersInstructors.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcMembersInstructors.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcMembersInstructors.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcMembersInstructors.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcMembersInstructors.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcMembersInstructors.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcMembersInstructors.TabIndex = 167;
            this.tcMembersInstructors.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcMembersInstructors.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tcMembersInstructors.SelectedIndexChanged += new System.EventHandler(this.tcMembersInstructors_SelectedIndexChanged);
            // 
            // tpMember
            // 
            this.tpMember.BackColor = System.Drawing.Color.White;
            this.tpMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpMember.Controls.Add(this.ucMemberCardWithFilter1);
            this.tpMember.Controls.Add(this.btnMemberInfoNext);
            this.tpMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpMember.Location = new System.Drawing.Point(4, 44);
            this.tpMember.Name = "tpMember";
            this.tpMember.Padding = new System.Windows.Forms.Padding(3);
            this.tpMember.Size = new System.Drawing.Size(910, 499);
            this.tpMember.TabIndex = 0;
            this.tpMember.Text = "Selecte Member";
            // 
            // ucMemberCardWithFilter1
            // 
            this.ucMemberCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucMemberCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucMemberCardWithFilter1.FilterEnabled = true;
            this.ucMemberCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucMemberCardWithFilter1.Location = new System.Drawing.Point(4, 3);
            this.ucMemberCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucMemberCardWithFilter1.Name = "ucMemberCardWithFilter1";
            this.ucMemberCardWithFilter1.ShowAddMemberButton = true;
            this.ucMemberCardWithFilter1.Size = new System.Drawing.Size(899, 442);
            this.ucMemberCardWithFilter1.TabIndex = 121;
            this.ucMemberCardWithFilter1.OnMemberSelected += new System.Action<int>(this.ucMemberCardWithFilter1_OnMemberSelected);
            // 
            // btnMemberInfoNext
            // 
            this.btnMemberInfoNext.Enabled = false;
            this.btnMemberInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMemberInfoNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberInfoNext.Image = global::KarateClub.Properties.Resources.Next_32;
            this.btnMemberInfoNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMemberInfoNext.Location = new System.Drawing.Point(772, 454);
            this.btnMemberInfoNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMemberInfoNext.Name = "btnMemberInfoNext";
            this.btnMemberInfoNext.Size = new System.Drawing.Size(126, 37);
            this.btnMemberInfoNext.TabIndex = 120;
            this.btnMemberInfoNext.Text = "Next";
            this.btnMemberInfoNext.UseVisualStyleBackColor = true;
            this.btnMemberInfoNext.Click += new System.EventHandler(this.btnMemberInfoNext_Click);
            // 
            // tpInstructor
            // 
            this.tpInstructor.BackColor = System.Drawing.Color.White;
            this.tpInstructor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpInstructor.Controls.Add(this.ucInstructorCardWithFilter1);
            this.tpInstructor.Location = new System.Drawing.Point(4, 44);
            this.tpInstructor.Name = "tpInstructor";
            this.tpInstructor.Padding = new System.Windows.Forms.Padding(3);
            this.tpInstructor.Size = new System.Drawing.Size(910, 499);
            this.tpInstructor.TabIndex = 1;
            this.tpInstructor.Text = "Select Instrutor";
            // 
            // ucInstructorCardWithFilter1
            // 
            this.ucInstructorCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucInstructorCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucInstructorCardWithFilter1.FilterEnabled = true;
            this.ucInstructorCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucInstructorCardWithFilter1.Location = new System.Drawing.Point(1, 4);
            this.ucInstructorCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucInstructorCardWithFilter1.Name = "ucInstructorCardWithFilter1";
            this.ucInstructorCardWithFilter1.ShowAddInstructorButton = true;
            this.ucInstructorCardWithFilter1.Size = new System.Drawing.Size(904, 394);
            this.ucInstructorCardWithFilter1.TabIndex = 0;
            this.ucInstructorCardWithFilter1.OnInstructorSelected += new System.Action<int>(this.ucInstructorCardWithFilter1_OnInstructorSelected);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KarateClub.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(767, 745);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 37);
            this.btnSave.TabIndex = 169;
            this.btnSave.Text = "   Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KarateClub.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(603, 745);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 37);
            this.btnClose.TabIndex = 168;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpAssignDate
            // 
            this.dtpAssignDate.Checked = true;
            this.dtpAssignDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.dtpAssignDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAssignDate.ForeColor = System.Drawing.Color.White;
            this.dtpAssignDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAssignDate.Location = new System.Drawing.Point(266, 680);
            this.dtpAssignDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAssignDate.MinDate = new System.DateTime(2023, 11, 8, 0, 0, 0, 0);
            this.dtpAssignDate.Name = "dtpAssignDate";
            this.dtpAssignDate.Size = new System.Drawing.Size(152, 36);
            this.dtpAssignDate.TabIndex = 170;
            this.dtpAssignDate.Value = new System.DateTime(2023, 11, 8, 23, 9, 0, 486);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 685);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 171;
            this.label1.Text = "Assign Date:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KarateClub.Properties.Resources.id;
            this.pictureBox2.Location = new System.Drawing.Point(222, 642);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 179;
            this.pictureBox2.TabStop = false;
            // 
            // lblMembersInstructorsID
            // 
            this.lblMembersInstructorsID.AutoSize = true;
            this.lblMembersInstructorsID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembersInstructorsID.Location = new System.Drawing.Point(262, 644);
            this.lblMembersInstructorsID.Name = "lblMembersInstructorsID";
            this.lblMembersInstructorsID.Size = new System.Drawing.Size(53, 20);
            this.lblMembersInstructorsID.TabIndex = 178;
            this.lblMembersInstructorsID.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 644);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 20);
            this.label2.TabIndex = 177;
            this.label2.Text = "Members-Instructors ID:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::KarateClub.Properties.Resources.Calendar_32;
            this.pictureBox3.Location = new System.Drawing.Point(222, 685);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 180;
            this.pictureBox3.TabStop = false;
            // 
            // frmAddEditMembersInstructors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 785);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblMembersInstructorsID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpAssignDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcMembersInstructors);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditMembersInstructors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Members-Instructors";
            this.Activated += new System.EventHandler(this.frmAddEditMembersInstructors_Activated);
            this.Load += new System.EventHandler(this.frmAddEditMembersInstructors_Load);
            this.tcMembersInstructors.ResumeLayout(false);
            this.tpMember.ResumeLayout(false);
            this.tpInstructor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage tpMember;
        private System.Windows.Forms.TabPage tpInstructor;
        private System.Windows.Forms.Button btnMemberInfoNext;
        private Members.UserControls.ucMemberCardWithFilter ucMemberCardWithFilter1;
        private Instructors.UserControls.ucInstructorCardWithFilter ucInstructorCardWithFilter1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpAssignDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMembersInstructorsID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2TabControl tcMembersInstructors;
    }
}