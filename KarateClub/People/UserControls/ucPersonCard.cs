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

namespace KarateClub.People.UserControls
{
    public partial class ucPersonCard : UserControl
    {
        private int? _PersonID = null;
        private clsPerson _Person;

        public int? PersonID => _PersonID;
        public clsPerson Person => _Person;

        public ucPersonCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            this._PersonID = null;
            this._Person = null;

            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblGender.Text = "[????]";
            lblAddress.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            pbPersonImage.Image = Resources.DefaultMale;
        }

        private void _LoadMemberImage()
        {
            if (_Person.ImagePath != null)
            {
                if (File.Exists(_Person.ImagePath))
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_Person.Gender == (byte)clsPerson.enGender.Male)
                    pbPersonImage.Image = Resources.DefaultMale;
                else
                    pbPersonImage.Image = Resources.DefaultFemale;
            }
        }

        private void _FillMemberInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.Name;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblGender.Text = _Person.GenderName;
            lblAddress.Text = _Person.Address;
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;

            _LoadMemberImage();
        }

        public void LoadPersonInfo(int? PersonID)
        {
            this._PersonID = PersonID;

            if (!PersonID.HasValue)
            {
                MessageBox.Show("There is no person with this ID", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Person = clsPerson.Find(this._PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"There is no person with id = {PersonID}", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillMemberInfo();



        }
    }
}
