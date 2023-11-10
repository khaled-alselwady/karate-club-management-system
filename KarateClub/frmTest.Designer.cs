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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ucSubscriptionPeriodInfoWithFilter1 = new KarateClub.SubscriptionPeriods.UserControls.ucSubscriptionPeriodInfoWithFilter();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(958, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(907, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 101);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucSubscriptionPeriodInfoWithFilter1
            // 
            this.ucSubscriptionPeriodInfoWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucSubscriptionPeriodInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucSubscriptionPeriodInfoWithFilter1.FilterEnabled = true;
            this.ucSubscriptionPeriodInfoWithFilter1.Location = new System.Drawing.Point(4, 81);
            this.ucSubscriptionPeriodInfoWithFilter1.Name = "ucSubscriptionPeriodInfoWithFilter1";
            this.ucSubscriptionPeriodInfoWithFilter1.Size = new System.Drawing.Size(899, 407);
            this.ucSubscriptionPeriodInfoWithFilter1.TabIndex = 2;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1155, 724);
            this.Controls.Add(this.ucSubscriptionPeriodInfoWithFilter1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private SubscriptionPeriods.UserControls.ucSubscriptionPeriodInfoWithFilter ucSubscriptionPeriodInfoWithFilter1;
    }
}