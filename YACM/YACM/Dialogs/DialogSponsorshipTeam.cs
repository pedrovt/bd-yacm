﻿using System;
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
		private readonly Sponsor S;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogSponsorshipTeam(Event E, Sponsor S) {
			InitializeComponent();

			this.E = E;
			this.S = S;
			this.toUpdate = false;
			
			// Show Event Details
			ShowEvent();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogSponsorshipTeam(Event E) {
			InitializeComponent();
			this.E = E;
			this.S = new Sponsor();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}

		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveEvent();
			if (canCommit) {

				if (toUpdate) DBLayer.Events.Update(E);
				else DBLayer.Events.Create(E);
				
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
			DBLayer.Events.Delete(E);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowEvent() {
			/*txtEndDate.Value = E.EndDate;
			txtID.Text = E.Number.ToString();
			txtMonetaryValue.Text = "-1"; //TODO
			txtVisibility.Checked = E.Visibility;
			txtBeginDate.Value = E.BeginningDate;
			txtSponsorID.Text = E.Name;
			txtTeamName.Text = E.ManagerID.ToString();
			*/
		}

		public void SaveEvent() {
			try {
				/*E.Number = Convert.ToInt32(txtID.Value);
				E.EndDate = txtEndDate.Value;
				E.Visibility = txtVisibility.Checked;
				E.BeginningDate = txtBeginDate.Value;
				E.Name = txtSponsorID.Text;
				E.ManagerID = Convert.ToInt32(txtTeamName.Text);
				*/
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
