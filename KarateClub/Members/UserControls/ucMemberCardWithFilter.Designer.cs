namespace KarateClub.Members.UserControls
{
    partial class ucMemberCardWithFilter
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
            this.ucMemberCard1 = new KarateClub.Members.UserControls.ucMemberCard();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.btnAddNewMember = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucMemberCard1
            // 
            this.ucMemberCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucMemberCard1.BackColor = System.Drawing.Color.White;
            this.ucMemberCard1.Location = new System.Drawing.Point(3, 86);
            this.ucMemberCard1.Name = "ucMemberCard1";
            this.ucMemberCard1.Size = new System.Drawing.Size(959, 267);
            this.ucMemberCard1.TabIndex = 0;
            this.ucMemberCard1.Load += new System.EventHandler(this.ucMemberCard1_Load);
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.label22);
            this.gbFilters.Controls.Add(this.btnAddNewMember);
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(3, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(955, 77);
            this.gbFilters.TabIndex = 17;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(141, 29);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(214, 26);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // btnAddNewMember
            // 
            this.btnAddNewMember.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewMember.Image = global::KarateClub.Properties.Resources.Add_Person_40;
            this.btnAddNewMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewMember.Location = new System.Drawing.Point(422, 14);
            this.btnAddNewMember.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewMember.Name = "btnAddNewMember";
            this.btnAddNewMember.Size = new System.Drawing.Size(49, 49);
            this.btnAddNewMember.TabIndex = 20;
            this.btnAddNewMember.UseVisualStyleBackColor = true;
            this.btnAddNewMember.Click += new System.EventHandler(this.btnAddNewMember_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::KarateClub.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(362, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(53, 49);
            this.btnFind.TabIndex = 18;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 31);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 20);
            this.label22.TabIndex = 114;
            this.label22.Text = "Member ID :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucMemberCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ucMemberCard1);
            this.Name = "ucMemberCardWithFilter";
            this.Size = new System.Drawing.Size(961, 350);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucMemberCard ucMemberCard1;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnAddNewMember;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
