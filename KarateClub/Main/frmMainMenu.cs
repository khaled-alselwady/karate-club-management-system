﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KarateClub.Dashboard;
using KarateClub.Members;
using KarateClub.Instructors;

namespace KarateClub.Main
{
    public partial class frmMainMenu : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public frmMainMenu()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 58);
            panelMainMenu.Controls.Add(leftBorderBtn);
        }

        public void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;

                leftBorderBtn.BackColor = Color.FromArgb(241, 158, 2);
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                //currentBtn.BackColor = Color.FromArgb(43, 38, 42);
                //currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.FromArgb(241, 158, 2);
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button

                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                //IconCurrentChildForm.IconChar = currentBtn.IconChar;
                //IconCurrentChildForm.IconColor = color;
            }
        }

        public void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(38, 32, 37);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                //lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                // lblTitleChildForm.Text = childForm.Text;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // Get the location of the button on the screen
            Point location = btnMenu.PointToScreen(new Point(0, btnMenu.Height));

            // Show the context menu at the calculated location
            cmsEditProfile.Show(location);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmDashboard());
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmListMembers());
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmListInstructors());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }

        private void btnMemberInstructors_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }

        private void btnBeltRanks_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }

        private void btnSubscriptionPeriods_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }

        private void btnBeltTests_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Form());
        }
    }
}