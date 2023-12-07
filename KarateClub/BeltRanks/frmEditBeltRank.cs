using KarateClub.Global_Classes;
using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace KarateClub.BeltRanks
{
    public partial class frmEditBeltRank : Form
    {
        private int _BeltRankID = -1;
        private clsBeltRank _BeltRank;

        public frmEditBeltRank(int BeltRankID)
        {
            InitializeComponent();

            this._BeltRankID = BeltRankID;
        }

        private void _LoadData()
        {
            _BeltRank = clsBeltRank.Find(this._BeltRankID);

            if (_BeltRank == null)
            {
                MessageBox.Show("There is no belt rank with ID = " + this._BeltRankID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblBeltID.Text = _BeltRank.RankID.ToString();
            txtBeltName.Text = _BeltRank.RankName;
            txtBeltFees.Text = _BeltRank.TestFees.ToString("F0");
        }

        private void txtBeltFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBeltFees.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtBeltFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                ErrorProvider1.SetError(txtBeltFees, null);

            };


            if (!clsValidation.IsNumber(txtBeltFees.Text))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtBeltFees, "Invalid Number.");
            }
            else
            {
                ErrorProvider1.SetError(txtBeltFees, null);
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBeltName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBeltName.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtBeltName, "Belt name cannot be empty!");
                return;
            }
            else
            {
                ErrorProvider1.SetError(txtBeltName, null);
            }

            if (_BeltRank.RankName != txtBeltName.Text.Trim() &&
                clsBeltRank.DoesRankExist(txtBeltName.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtBeltName, "Belt name already exists!");
            }
            else
            {
                ErrorProvider1.SetError(txtBeltName, null);
            }

        }

        private void frmEditBeltRank_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the Error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _BeltRank.RankName = txtBeltName.Text.Trim();
            _BeltRank.TestFees = decimal.Parse(txtBeltFees.Text.Trim());


            if (_BeltRank.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
