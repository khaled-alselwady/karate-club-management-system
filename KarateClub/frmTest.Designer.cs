namespace KarateClub
{
    partial class frmTest
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
            this.ucMemberInstructorCardWithFilter1 = new KarateClub.MembersInstructors.UserControls.ucMemberInstructorCardWithFilter();
            this.SuspendLayout();
            // 
            // ucMemberInstructorCardWithFilter1
            // 
            this.ucMemberInstructorCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucMemberInstructorCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucMemberInstructorCardWithFilter1.Location = new System.Drawing.Point(85, 58);
            this.ucMemberInstructorCardWithFilter1.Name = "ucMemberInstructorCardWithFilter1";
            this.ucMemberInstructorCardWithFilter1.Size = new System.Drawing.Size(923, 554);
            this.ucMemberInstructorCardWithFilter1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1155, 724);
            this.Controls.Add(this.ucMemberInstructorCardWithFilter1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.Activated += new System.EventHandler(this.frmTest_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private MembersInstructors.UserControls.ucMemberInstructorCardWithFilter ucMemberInstructorCardWithFilter1;
    }
}