using KarateClub.Global_Classes;
using KarateClub.Properties;
using KarateClub_Business;
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

namespace KarateClub.Instructors
{
    public partial class frmAddEditInstructor : Form
    {
        public Action<int?> GetInstructorID;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int? _InstructorID = null;
        private clsInstructor _Instructor;

        public frmAddEditInstructor()
        {
            InitializeComponent();

            this._Mode = enMode.AddNew;
        }

        public frmAddEditInstructor(int? InstructorID)
        {
            InitializeComponent();

            this._InstructorID = InstructorID;
            this._Mode = enMode.Update;
        }

        private void _ResetFields()
        {
            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtQualifications.Text = "";
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Instructor";
                this.Text = "Add New Instructor";
                _Instructor = new clsInstructor();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Instructor";
                this.Text = "Update Instructor";
            }

            //set default image for the Instructor
            if (rbMale.Checked)
                pbInstructorImage.Image = Resources.DefaultMale;
            else
                pbInstructorImage.Image = Resources.DefaultFemale;

            //hide/show the remove link in case there is no image for the member
            llRemoveImage.Visible = (pbInstructorImage.ImageLocation != null);

            //should not allow adding age less than 18 years
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
        }

        private void _FillFieldsWithPersonInfo()
        {
            lblInstructorID.Text = _Instructor.InstructorID.ToString();
            txtName.Text = _Instructor.Name;
            txtEmail.Text = _Instructor.Email;
            txtAddress.Text = _Instructor.Address;
            txtPhone.Text = _Instructor.Phone;
            dtpDateOfBirth.Value = _Instructor.DateOfBirth;
            txtQualifications.Text = _Instructor.Qualification;

            if (_Instructor.Gender == (byte)clsPerson.enGender.Male)
            {
                rbMale.Checked = true;
                pbInstructorImage.Image = Resources.DefaultMale;
            }

            else
            {
                rbFemale.Checked = true;
                pbInstructorImage.Image = Resources.DefaultFemale;
            }
        }

        private void _LoadData()
        {
            _Instructor = clsInstructor.Find(_InstructorID);

            if (_Instructor == null)
            {
                MessageBox.Show("No Instructor with ID = " + _InstructorID,
                    "Instructor Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            _FillFieldsWithPersonInfo();

            //load person image in case it was set.
            if (_Instructor.ImagePath != null)
                pbInstructorImage.ImageLocation = _Instructor.ImagePath;

            //hide/show the remove link in case there is no image for the person
            llRemoveImage.Visible = (_Instructor.ImagePath != null);
        }

        private bool _HandleMemberImage()
        {
            // this procedure will handle the person image,
            // it will take care of deleting the old image from the folder
            // in case the image changed, and it will rename the new image with guid and 
            // place it in the images folder.

            // _Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Instructor.ImagePath != pbInstructorImage.ImageLocation)
            {

                if (_Instructor.ImagePath != null)
                {
                    // first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Instructor.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        // log it later   
                    }
                }

                if (pbInstructorImage.ImageLocation != null)
                {
                    // then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbInstructorImage.ImageLocation;

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbInstructorImage.ImageLocation = SourceImageFile;

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
            _Instructor.Name = txtName.Text.Trim();
            _Instructor.Email = txtEmail.Text.Trim();
            _Instructor.Address = txtAddress.Text.Trim();
            _Instructor.Phone = txtPhone.Text.Trim();
            _Instructor.Qualification = txtQualifications.Text.Trim();
            _Instructor.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Instructor.DateOfBirth = dtpDateOfBirth.Value;

            if (pbInstructorImage.ImageLocation != null)
                _Instructor.ImagePath = pbInstructorImage.ImageLocation;
            else
                _Instructor.ImagePath = null;
        }

        private void _SaveInstructor()
        {
            _FillMemberObjectWithFieldsData();

            if (_Instructor.Save())
            {
                lblTitle.Text = "Update Instructor";
                lblInstructorID.Text = _Instructor.InstructorID.ToString();
                this.Text = "Update Instructor";

                // change form mode to update
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                GetInstructorID?.Invoke(_Instructor.InstructorID);
            }
            else
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditInstructor_Load(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
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

            _SaveInstructor();
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
            if (pbInstructorImage.ImageLocation == null)
                pbInstructorImage.Image = Resources.DefaultMale;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbInstructorImage.ImageLocation == null)
                pbInstructorImage.Image = Resources.DefaultFemale;
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
            pbInstructorImage.ImageLocation = null;

            if (rbMale.Checked)
                pbInstructorImage.Image = Resources.DefaultMale;
            else
                pbInstructorImage.Image = Resources.DefaultFemale;

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
                pbInstructorImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }
    }
}
