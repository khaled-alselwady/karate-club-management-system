using KarateClub.Global_Classes;
using KarateClub.Properties;
using KarateClub_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Members
{
    public partial class frmAddEditMember : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int MemberID);
        // Declare an event using the delegate
        public event DataBackEventHandler MemberIDBack;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int _MemberID = -1;
        private clsMember _Member;

        public frmAddEditMember()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditMember(int MemberID)
        {
            InitializeComponent();

            _MemberID = MemberID;
            _Mode = enMode.Update;
        }

        private void _FillBeltRanksInComboBox()
        {
            DataTable _dtBeltRanks = clsBeltRank.GetAllBeltRanksName();

            foreach (DataRow drBeltRank in _dtBeltRanks.Rows)
            {
                cbLastBeltRank.Items.Add(drBeltRank["RankName"].ToString());
            }
        }

        private void _ResetFields()
        {
            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtEmergencyContact.Text = "";
        }

        private void _ResetDefaultValues()
        {
            _FillBeltRanksInComboBox();           

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Member";
                this.Text = "Add New Member";
                _Member = new clsMember();
                chkIsActive.Enabled = false; 
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Member";
                this.Text = "Update Member";
            }

            //set default image for the member
            if (rbMale.Checked)
                pbMemberImage.Image = Resources.DefaultMale;
            else
                pbMemberImage.Image = Resources.DefaultFemale;

            //hide/show the remove link in case there is no image for the member
            llRemoveImage.Visible = (pbMemberImage.ImageLocation != null);

            //should not allow adding age less than 6 years
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-6);

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default belt rank to Jordan
            cbLastBeltRank.SelectedIndex = cbLastBeltRank.FindString("White Belt");     
        }

        private void _FillFieldsWithMemberInfo()
        {
            lblMemberID.Text = _Member.MemberID.ToString();
            txtName.Text = _Member.Name;
            txtEmail.Text = _Member.Email;
            txtAddress.Text = _Member.Address;
            txtPhone.Text = _Member.Phone;
            dtpDateOfBirth.Value = _Member.DateOfBirth;
            txtEmergencyContact.Text = _Member.EmergencyContactInfo;

            if (_Member.Gender == (byte)clsPerson.enGender.Male)
            {
                rbMale.Checked = true;
                pbMemberImage.Image = Resources.DefaultMale;
            }

            else
            {
                rbFemale.Checked = true;
                pbMemberImage.Image = Resources.DefaultFemale;
            }

            chkIsActive.Checked = _Member.IsActive;

            // To show the name of the Belt rank
            cbLastBeltRank.SelectedIndex = cbLastBeltRank.FindString(_Member.LastBeltRankInfo.RankName);
        }

        private void _LoadData()
        {
            _Member = clsMember.Find(_MemberID);

            if (_Member == null)
            {
                MessageBox.Show("No member with ID = " + _MemberID, "Member Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            _FillFieldsWithMemberInfo();

            //load person image in case it was set.
            if (_Member.ImagePath != "")
                pbMemberImage.ImageLocation = _Member.ImagePath;

            //hide/show the remove link in case there is no image for the person
            llRemoveImage.Visible = (_Member.ImagePath != "");
        }

        private bool _HandleMemberImage()
        {
            // this procedure will handle the person image,
            // it will take care of deleting the old image from the folder
            // in case the image changed, and it will rename the new image with guid and 
            // place it in the images folder.

            // _Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Member.ImagePath != pbMemberImage.ImageLocation)
            {

                if (_Member.ImagePath != "")
                {
                    // first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Member.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        // log it later   
                    }
                }

                if (pbMemberImage.ImageLocation != null)
                {
                    // then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbMemberImage.ImageLocation;

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbMemberImage.ImageLocation = SourceImageFile;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void _FillMemberObjectWithFieldsData()
        {
            _Member.Name = txtName.Text.Trim();
            _Member.Email = txtEmail.Text.Trim();
            _Member.Address = txtAddress.Text.Trim();
            _Member.Phone = txtPhone.Text.Trim();
            _Member.EmergencyContactInfo = txtEmergencyContact.Text.Trim();
            _Member.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Member.DateOfBirth = dtpDateOfBirth.Value;
            _Member.LastBeltRankID = clsBeltRank.Find(cbLastBeltRank.Text).RankID;
            _Member.IsActive = chkIsActive.Checked;

            if (pbMemberImage.ImageLocation != null)
                _Member.ImagePath = pbMemberImage.ImageLocation;
            else
                _Member.ImagePath = "";
        }

        private void _SavePerson()
        {
            _FillMemberObjectWithFieldsData();

            if (_Member.Save())
            {
                lblTitle.Text = "Update Member";
                lblMemberID.Text = _Member.MemberID.ToString();
                this.Text = "Update Member";

                // change form mode to update
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                MemberIDBack?.Invoke(this, _Member.MemberID);
            }
            else
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmAddEditMember_Load(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleMemberImage())
                return;

            _SavePerson();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((TextBox)sender), null);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbMemberImage.ImageLocation == null)
                pbMemberImage.Image = Resources.DefaultMale;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbMemberImage.ImageLocation == null)
                pbMemberImage.Image = Resources.DefaultFemale;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbMemberImage.ImageLocation = null;

            if (rbMale.Checked)
                pbMemberImage.Image = Resources.DefaultMale;
            else
                pbMemberImage.Image = Resources.DefaultFemale;

            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbMemberImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }
    }
}
