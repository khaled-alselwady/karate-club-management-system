namespace KarateClub.Instructors.UserControls
{
    partial class ucInstructorCard
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblQualifications = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.llEditInstructorInfo = new System.Windows.Forms.LinkLabel();
            this.label22 = new System.Windows.Forms.Label();
            this.lblInstructorID = new System.Windows.Forms.Label();
            this.ucPersonCard1 = new KarateClub.People.UserControls.ucPersonCard();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblQualifications);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.llEditInstructorInfo);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lblInstructorID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 233);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(887, 76);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instructor Information";
            // 
            // lblQualifications
            // 
            this.lblQualifications.AutoSize = true;
            this.lblQualifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualifications.Location = new System.Drawing.Point(490, 37);
            this.lblQualifications.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQualifications.Name = "lblQualifications";
            this.lblQualifications.Size = new System.Drawing.Size(53, 20);
            this.lblQualifications.TabIndex = 142;
            this.lblQualifications.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(320, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 20);
            this.label8.TabIndex = 140;
            this.label8.Text = "Qualifications:";
            // 
            // llEditInstructorInfo
            // 
            this.llEditInstructorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llEditInstructorInfo.AutoSize = true;
            this.llEditInstructorInfo.Enabled = false;
            this.llEditInstructorInfo.Location = new System.Drawing.Point(745, 51);
            this.llEditInstructorInfo.Name = "llEditInstructorInfo";
            this.llEditInstructorInfo.Size = new System.Drawing.Size(141, 20);
            this.llEditInstructorInfo.TabIndex = 139;
            this.llEditInstructorInfo.TabStop = true;
            this.llEditInstructorInfo.Text = "Edit Instructor Info";
            this.llEditInstructorInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditInstructorInfo_LinkClicked);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 37);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(121, 20);
            this.label22.TabIndex = 113;
            this.label22.Text = "Instructor ID :";
            // 
            // lblInstructorID
            // 
            this.lblInstructorID.AutoSize = true;
            this.lblInstructorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructorID.Location = new System.Drawing.Point(140, 37);
            this.lblInstructorID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstructorID.Name = "lblInstructorID";
            this.lblInstructorID.Size = new System.Drawing.Size(53, 20);
            this.lblInstructorID.TabIndex = 127;
            this.lblInstructorID.Text = "[????]";
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.Location = new System.Drawing.Point(3, 3);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(895, 231);
            this.ucPersonCard1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(452, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 141;
            this.pictureBox1.TabStop = false;
            // 
            // ucInstructorCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucPersonCard1);
            this.Name = "ucInstructorCard";
            this.Size = new System.Drawing.Size(899, 317);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private People.UserControls.ucPersonCard ucPersonCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblQualifications;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel llEditInstructorInfo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblInstructorID;
    }
}
