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
	public partial class DialogStagesParticipations : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly StageParticipation S;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogStagesParticipations(Event E, StageParticipation S) {
			InitializeComponent();

			this.E = E;
			this.S = S;
			this.toUpdate = false;
			
			// Show Event Details
			ShowStageParticipation();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogStagesParticipations(Event E) {
			InitializeComponent();
			this.E = E;
			this.S = new StageParticipation();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}
		
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveStageParticipation();
			if (canCommit) {

				if (toUpdate) DBLayer.StagesParticipation.Update(S);
				else DBLayer.StagesParticipation.Create(S);
				
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
			DBLayer.StagesParticipation.Delete(S);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowStageParticipation() {
			txtParticipantID.Text = S.ParticipantID.ToString();
			txtDate.Value = S.StageDate;
			txtStartLocation.Text = S.StageStartLocation;
			txtEndLocation.Text = S.StageEndLocation;
			txtResult.Text = S.Result;
		}

		public void SaveStageParticipation() {
			try {
				S.ParticipantID = Convert.ToInt32(txtParticipantID.Text);
				S.StageDate = txtDate.Value;
				S.StageStartLocation = txtStartLocation.Text;
				S.StageEndLocation = txtEndLocation.Text;
				S.Result = txtResult.Text;
				S.EventNumber = E.Number;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtParticipantID.Enabled = false;
			txtDate.Enabled = false;
			txtStartLocation.Enabled = false;
			txtEndLocation.Enabled = false;
			txtResult.Enabled = false;
		}

		public void UnlockControls() {
			if (toUpdate && S.StageDate == null) {
				txtParticipantID.Enabled = false;
				txtDate.Enabled = false;
				txtStartLocation.Enabled = false;
				txtEndLocation.Enabled = false;
			}
			else {
				txtParticipantID.Enabled = true;
				txtDate.Enabled = true;
				txtStartLocation.Enabled = true;
				txtEndLocation.Enabled = true;
			}
			txtParticipantID.ReadOnly = false;
			txtStartLocation.ReadOnly = false;
			txtEndLocation.ReadOnly = false;
			txtResult.Enabled = true;
			txtResult.ReadOnly = false;

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
			txtDate.Text = "";
			txtStartLocation.Text = "";
			txtEndLocation.Text = "";
			txtResult.Text = "";
		}

		#endregion

		
	}
}
