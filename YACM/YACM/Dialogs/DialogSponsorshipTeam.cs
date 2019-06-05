using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM
{

	/// <summary>
	/// Yet Another Cycling Manager (YACM)
	/// Databases Final Project
	/// Paulo Vasconcelos	paulobvasconcelos@ua.pt
	/// Pedro Teixeira		pedro.teix@ua.pt
	/// 09-May-2019
	/// </summary>
	public partial class DialogSponsorshipTeam : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly SponsorshipTeam S;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogSponsorshipTeam(Event E, SponsorshipTeam S) {
			InitializeComponent();

			this.E = E;
			this.S = S;
			this.toUpdate = false;
			
			// Show Event Details
			ShowSponsorshipTeam();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogSponsorshipTeam(Event E) {
			InitializeComponent();
			this.E = E;
			this.S = new SponsorshipTeam();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}

		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveSponsorshipTeam();
			if (canCommit) {

				if (toUpdate) DBLayer.SponsorshipTeams.Update(S);
				else DBLayer.SponsorshipTeams.Create(S);
				
				//Return to main
				this.Dispose();
				
			}
		}

		private void BttnEdit_Click(object sender, EventArgs e) {
			if (toUpdate) LockControls();
			else UnlockControls();
			toUpdate = !toUpdate;
		}

		private void BttnDelete_Click(object sender, EventArgs e) {
			DBLayer.SponsorshipTeams.Delete(S);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowSponsorshipTeam() {
			txtSponsorID.Text = S.SponsorID.ToString();
			txtMonetaryValue.Text = S.MonetaryValue.ToString();
			txtTeamName.Text = S.TeamName;
		}

		public void SaveSponsorshipTeam() {
			try {
				S.SponsorID = Convert.ToInt32(txtSponsorID.Text);
				S.MonetaryValue = Convert.ToDouble(txtMonetaryValue.Text);
				S.TeamName = txtTeamName.Text;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtSponsorID.Enabled = false;
			txtTeamName.Enabled = false;
			txtMonetaryValue.Enabled = false;
		}

		public void UnlockControls() {
			txtSponsorID.Enabled = false;
			txtTeamName.Enabled = false;
			txtMonetaryValue.Enabled = true;
		}

		private void UpdateButtons(bool create) {
			bttnCancel.Enabled = true;
			bttnCancel.Visible = true;
			bttnOK.Enabled = true;
			bttnOK.Visible = true;

			if (create) {
				bttnEdit.Enabled = false;
				bttnEdit.Visible = false;

				bttnDelete.Enabled = false;
				bttnDelete.Visible = false;
			}
			else {
				bttnEdit.Enabled = true;
				bttnEdit.Visible = true;

				bttnDelete.Enabled = true;
				bttnDelete.Visible = true;
			}
		}

		public void ClearFields() 
		{
			txtSponsorID.Text = "";
			txtTeamName.Text = "";
			txtMonetaryValue.Text = "";	
		}

		#endregion

		
	}
}
