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
	public partial class DialogParticipantsEnrollment : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly ParticipantEnrollment P;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogParticipantsEnrollment(Event E, ParticipantEnrollment P) {
			InitializeComponent();

			this.E = E;
			this.P = P;
			this.toUpdate = false;
			
			// Show Event Details
			ShowParticipantEnrollment();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogParticipantsEnrollment(Event E) {
			InitializeComponent();
			this.E = E;
			this.P = new ParticipantEnrollment();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}
		
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveUser();
			if (canCommit) {

				if (toUpdate) DBLayer.ParticipantsEnrollments.Update(P);
				else DBLayer.ParticipantsEnrollments.Create(P);
				
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
			DBLayer.ParticipantsEnrollments.Delete(P);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowParticipantEnrollment() {
			txtParticipantID.Text = P.ParticipantID.ToString();
			txtDorsal.Text = P.Dorsal.ToString();
			txtTeamName.Text = P.TeamName.ToString();
		}

		public void SaveUser() {
			try {
				P.ParticipantID = Convert.ToInt32(txtParticipantID.Text);
				P.Dorsal = Convert.ToInt32(txtDorsal.Text);
				P.TeamName = txtTeamName.Text;
				P.EventNumber = E.Number;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtParticipantID.Enabled = false;
			txtTeamName.Enabled = false;
			txtDorsal.Enabled = false;
		}

		public void UnlockControls() {
			if (toUpdate) txtParticipantID.Enabled = false;
			else txtParticipantID.Enabled = true;
			txtParticipantID.ReadOnly = false;
			txtTeamName.Enabled = true;
			txtTeamName.ReadOnly = false;
			txtDorsal.Enabled = true;
			txtDorsal.ReadOnly = false;
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
			txtParticipantID.Text = "";
			txtTeamName.Text = "";
			txtDorsal.Text= "";
		}

		#endregion

		
	}
}
