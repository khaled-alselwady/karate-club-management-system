namespace KarateClub.Instructors
{
    partial class frmShowTrainedMembersByInstructor
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
            this.ucInstructorCard1 = new KarateClub.Instructors.UserControls.ucInstructorCard();
            this.ucTrainedMembersByInstructor1 = new KarateClub.MembersInstructors.UserControls.ucTrainedMembersByInstructor();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(81)))), ((int)(((byte)(4)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(895, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Trained Members By Instructor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucInstructorCard1
            // 
            this.ucInstructorCard1.Location = new System.Drawing.Point(15, 77);
            this.ucInstructorCard1.Name = "ucInstructorCard1";
            this.ucInstructorCard1.Size = new System.Drawing.Size(899, 317);
            this.ucInstructorCard1.TabIndex = 5;
            // 
            // ucTrainedMembersByInstructor1
            // 
            this.ucTrainedMembersByInstructor1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucTrainedMembersByInstructor1.BackColor = System.Drawing.Color.White;
            this.ucTrainedMembersByInstructor1.Location = new System.Drawing.Point(5, 418);
            this.ucTrainedMembersByInstructor1.Name = "ucTrainedMembersByInstructor1";
            this.ucTrainedMembersByInstructor1.Size = new System.Drawing.Size(925, 356);
            this.ucTrainedMembersByInstructor1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::KarateClub.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(774, 782);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 37);
            this.btnClose.TabIndex = 120;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowTrainedMembersByInstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 821);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucTrainedMembersByInstructor1);
            this.Controls.Add(this.ucInstructorCard1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowTrainedMembersByInstructor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Trained Members By Instructor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControls.ucInstructorCard ucInstructorCard1;
        private MembersInstructors.UserControls.ucTrainedMembersByInstructor ucTrainedMembersByInstructor1;
        private System.Windows.Forms.Button btnClose;
    }
}