using FontAwesome.Sharp;
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
using KarateClub.Users;
using KarateClub.Global_Classes;
using KarateClub.Login;
using KarateClub_Business;
using System.Resources;
using KarateClub.Properties;
using KarateClub.MembersInstructors;
using KarateClub.BeltRanks;
using KarateClub.SubscriptionPeriods;
using KarateClub.BeltTests;
using KarateClub.Payment;
using KarateClub.Permissions;

namespace KarateClub.Main
{
    public partial class frmMainMenu : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private Form _frmLoginForm;
        public Form frmDeniedMassage = new frmAccessDeniedMessage();

        public frmMainMenu(Form loginForm)
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 58);
            panelMainMenu.Controls.Add(leftBorderBtn);

            this._frmLoginForm = loginForm;
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
                //currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //currentBtn.ImageAlign = ContentAlignment.MiddleRight;
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
                //currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                //currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
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

            RefreshUserInfo(clsGlobal.CurrentUser.UserID);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // this method will show the context menu by clicking on the left click instead of the right click

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
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageMembers))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListMembers());
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageInstructors))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListInstructors());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageUsers))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListUsers());
            RefreshUserInfo(clsGlobal.CurrentUser.UserID);
        }

        private void btnMemberInstructors_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageMembersInstructors))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListMembersInstructors());
        }

        private void btnBeltRanks_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageBeltRanks))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListBeltRanks());
        }

        private void btnSubscriptionPeriods_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageSubscriptionPeriods))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListSubscriptionPeriod());
        }

        private void btnBeltTests_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageBeltTests))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListBeltTests());
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManagePayments))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            ActivateButton(sender);
            OpenChildForm(new frmListPayments());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            currentBtn = btnDashboard;
            leftBorderBtn.BackColor = Color.FromArgb(241, 158, 2);
            leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = Color.FromArgb(241, 158, 2);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();
            OpenChildForm(new frmDashboard());

            if (clsGlobal.CurrentUser.ImagePath != "")
            {
                pbUserImage.ImageLocation = clsGlobal.CurrentUser.ImagePath;
            }

            lblName.Text = clsGlobal.CurrentUser.Username;
        }

        private void RefreshUserInfo(int UserID)
        {
            clsGlobal.CurrentUser = clsUser.Find(UserID);

            if (clsGlobal.CurrentUser == null)
                return;

            if (clsGlobal.CurrentUser.ImagePath != "")
            {
                pbUserImage.ImageLocation = clsGlobal.CurrentUser.ImagePath;
            }
            else
            {
                if (clsGlobal.CurrentUser.Gender == clsPerson.enGender.Male)
                    pbUserImage.Image = Resources.DefaultMale;
                else
                    pbUserImage.Image = Resources.DefaultFemale;
            }

            lblName.Text = clsGlobal.CurrentUser.Username;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails ShowCurrentUserDetails = new frmShowUserDetails(clsGlobal.CurrentUser.UserID, false);
            ShowCurrentUserDetails.ShowDialog();

            RefreshUserInfo(clsGlobal.CurrentUser.UserID);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePasswordToCurrentUser = new frmChangePassword(clsGlobal.CurrentUser.UserID, false);
            ChangePasswordToCurrentUser.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.ShowDialog();
            this.Close();
        }
    }
}
