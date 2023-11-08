namespace KarateClub.Users.UserControls
{
    partial class ucUserCardWithFilter
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
            this.ucUserCard1 = new KarateClub.Users.UserControls.ucUserCard();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucUserCard1
            // 
            this.ucUserCard1.BackColor = System.Drawing.Color.White;
            this.ucUserCard1.Location = new System.Drawing.Point(5, 82);
            this.ucUserCard1.Name = "ucUserCard1";
            this.ucUserCard1.Size = new System.Drawing.Size(900, 314);
            this.ucUserCard1.TabIndex = 0;
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnAddNewUser);
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.label22);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(8, 2);
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
            this.label22.Size = new System.Drawing.Size(81, 20);
            this.label22.TabIndex = 114;
            this.label22.Text = "User ID :";
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.Image = global::KarateClub.Properties.Resources.AddPerson_32;
            this.btnAddNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewUser.Location = new System.Drawing.Point(435, 23);
            this.btnAddNewUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(44, 37);
            this.btnAddNewUser.TabIndex = 118;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::KarateClub.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(382, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(44, 37);
            this.btnFind.TabIndex = 117;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ucUserCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ucUserCard1);
            this.Name = "ucUserCardWithFilter";
            this.Size = new System.Drawing.Size(906, 395);
            this.Load += new System.EventHandler(this.ucUserCardWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucUserCard ucUserCard1;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnFind;
    }
}
