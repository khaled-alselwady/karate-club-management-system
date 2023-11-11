namespace KarateClub.MembersInstructors.UserControls
{
    partial class ucMemberInstructorCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcMembersInstructors = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpMember = new System.Windows.Forms.TabPage();
            this.ucMemberCardWithFilter1 = new KarateClub.Members.UserControls.ucMemberCardWithFilter();
            this.btnMemberInfoNext = new System.Windows.Forms.Button();
            this.tpInstructor = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.ucInstructorCardWithFilter1 = new KarateClub.Instructors.UserControls.ucInstructorCardWithFilter();
            this.tcMembersInstructors.SuspendLayout();
            this.tpMember.SuspendLayout();
            this.tpInstructor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMembersInstructors
            // 
            this.tcMembersInstructors.Controls.Add(this.tpMember);
            this.tcMembersInstructors.Controls.Add(this.tpInstructor);
            this.tcMembersInstructors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMembersInstructors.ItemSize = new System.Drawing.Size(180, 40);
            this.tcMembersInstructors.Location = new System.Drawing.Point(3, 3);
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
            this.tcMembersInstructors.TabIndex = 168;
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
            this.tpInstructor.Controls.Add(this.button1);
            this.tpInstructor.Controls.Add(this.ucInstructorCardWithFilter1);
            this.tpInstructor.Location = new System.Drawing.Point(4, 44);
            this.tpInstructor.Name = "tpInstructor";
            this.tpInstructor.Padding = new System.Windows.Forms.Padding(3);
            this.tpInstructor.Size = new System.Drawing.Size(910, 499);
            this.tpInstructor.TabIndex = 1;
            this.tpInstructor.Text = "Select Instrutor";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::KarateClub.Properties.Resources.Next_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(775, 456);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 37);
            this.button1.TabIndex = 121;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
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
            // ucMemberInstructorCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcMembersInstructors);
            this.Name = "ucMemberInstructorCardWithFilter";
            this.Size = new System.Drawing.Size(923, 554);
            this.tcMembersInstructors.ResumeLayout(false);
            this.tpMember.ResumeLayout(false);
            this.tpInstructor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMembersInstructors;
        private System.Windows.Forms.TabPage tpMember;
        private Members.UserControls.ucMemberCardWithFilter ucMemberCardWithFilter1;
        private System.Windows.Forms.Button btnMemberInfoNext;
        private System.Windows.Forms.TabPage tpInstructor;
        private Instructors.UserControls.ucInstructorCardWithFilter ucInstructorCardWithFilter1;
        private System.Windows.Forms.Button button1;
    }
}
