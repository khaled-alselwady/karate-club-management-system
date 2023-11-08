namespace KarateClub.Instructors.UserControls
{
    partial class ucInstructorCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.ucInstructorCard1 = new KarateClub.Instructors.UserControls.ucInstructorCard();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddNewInstructor = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucInstructorCard1
            // 
            this.ucInstructorCard1.Location = new System.Drawing.Point(3, 81);
            this.ucInstructorCard1.Name = "ucInstructorCard1";
            this.ucInstructorCard1.Size = new System.Drawing.Size(899, 317);
            this.ucInstructorCard1.TabIndex = 0;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnAddNewInstructor);
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.label22);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(7, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(891, 77);
            this.gbFilters.TabIndex = 18;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 31);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(121, 20);
            this.label22.TabIndex = 114;
            this.label22.Text = "Instructor ID :";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(148, 29);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(214, 26);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAddNewInstructor
            // 
            this.btnAddNewInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewInstructor.Image = global::KarateClub.Properties.Resources.AddPerson_32;
            this.btnAddNewInstructor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewInstructor.Location = new System.Drawing.Point(441, 22);
            this.btnAddNewInstructor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewInstructor.Name = "btnAddNewInstructor";
            this.btnAddNewInstructor.Size = new System.Drawing.Size(44, 37);
            this.btnAddNewInstructor.TabIndex = 116;
            this.btnAddNewInstructor.UseVisualStyleBackColor = true;
            this.btnAddNewInstructor.Click += new System.EventHandler(this.btnAddNewInstructor_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::KarateClub.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(388, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(44, 37);
            this.btnFind.TabIndex = 115;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ucInstructorCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ucInstructorCard1);
            this.Name = "ucInstructorCardWithFilter";
            this.Size = new System.Drawing.Size(904, 394);
            this.Load += new System.EventHandler(this.ucInstructorCardWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucInstructorCard ucInstructorCard1;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAddNewInstructor;
        private System.Windows.Forms.Button btnFind;
    }
}
