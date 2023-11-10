namespace KarateClub.SubscriptionPeriods.UserControls
{
    partial class ucSubscriptionPeriodInfoWithFilter
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
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnFind = new FontAwesome.Sharp.IconButton();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.ucSubscriptionPeriodInfo1 = new KarateClub.SubscriptionPeriods.UserControls.ucSubscriptionPeriodInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.label22);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(3, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(891, 77);
            this.gbFilters.TabIndex = 18;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnFind.IconColor = System.Drawing.Color.Black;
            this.btnFind.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFind.IconSize = 35;
            this.btnFind.Location = new System.Drawing.Point(367, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(44, 37);
            this.btnFind.TabIndex = 117;
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
            this.label22.Size = new System.Drawing.Size(94, 20);
            this.label22.TabIndex = 114;
            this.label22.Text = "Period ID :";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(134, 29);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(214, 26);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // ucSubscriptionPeriodInfo1
            // 
            this.ucSubscriptionPeriodInfo1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucSubscriptionPeriodInfo1.BackColor = System.Drawing.Color.White;
            this.ucSubscriptionPeriodInfo1.Location = new System.Drawing.Point(3, 86);
            this.ucSubscriptionPeriodInfo1.Name = "ucSubscriptionPeriodInfo1";
            this.ucSubscriptionPeriodInfo1.Size = new System.Drawing.Size(899, 323);
            this.ucSubscriptionPeriodInfo1.TabIndex = 19;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucSubscriptionPeriodInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucSubscriptionPeriodInfo1);
            this.Controls.Add(this.gbFilters);
            this.Name = "ucSubscriptionPeriodInfoWithFilter";
            this.Size = new System.Drawing.Size(899, 407);
            this.Load += new System.EventHandler(this.ucSubscriptionPeriodInfoWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Label label22;
        private ucSubscriptionPeriodInfo ucSubscriptionPeriodInfo1;
        private System.Windows.Forms.TextBox txtFilterValue;
        private FontAwesome.Sharp.IconButton btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
