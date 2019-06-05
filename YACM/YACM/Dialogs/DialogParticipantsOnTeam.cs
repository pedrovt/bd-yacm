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
	public partial class DialogParticipantsOnTeam : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly ParticipantOnTeam P;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogParticipantsOnTeam(Event E, ParticipantOnTeam P) {
			InitializeComponent();

			this.E = E;
			this.P = P;
			this.toUpdate = false;
			
			// Show Event Details
			ShowEvent();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogParticipantsOnTeam(Event E) {
			InitializeComponent();
			this.E = E;
			this.P = new ParticipantOnTeam();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}
		
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveUser();
			if (canCommit) {

				if (toUpdate) DBLayer.ParticipantsOnTeam.Update(P);
				else DBLayer.ParticipantsOnTeam.Create(P);
				
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
			DBLayer.ParticipantsOnTeam.Delete(P);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowEvent() {
			txtParticipantID.Text = P.ParticipantID.ToString();
			start.Value = P.StartDate;
			end.Value = P.EndDate;
			txtTeamName.Text = P.TeamName;
		}

		public void SaveUser() {
			try {
				P.ParticipantID = Convert.ToInt32(txtParticipantID.Text);
				P.StartDate = start.Value;
				P.EndDate = end.Value;
				P.TeamName = txtTeamName.Text;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtParticipantID.Enabled = false;
			txtTeamName.Enabled = false;
			start.Enabled = false;
			end.Enabled = false;
		}

		public void UnlockControls() {
			txtParticipantID.Enabled = false;
			txtTeamName.Enabled = false;
			start.Enabled = true;
			end.Enabled = true; 
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

		public void ClearFields() {
			txtParticipantID.Text = "";
			txtTeamName.Text = "";
			start.Value = DateTime.Now;
			end.Value = DateTime.Now;
		}
		#endregion

		
	}
}
