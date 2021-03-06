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
	public partial class DialogSponsorshipEvent : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly SponsorshipEvent S;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogSponsorshipEvent(Event E, SponsorshipEvent S) {
			InitializeComponent();

			this.E = E;
			this.S = S;
			this.toUpdate = true;
			
			// Show Event Details
			ShowSponsorshipEvent();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogSponsorshipEvent(Event E) {
			InitializeComponent();
			this.E = E;
			this.S = new SponsorshipEvent();
			this.toUpdate = false;
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}

		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveSponsorshipEvent();
			if (canCommit) {

				if (toUpdate) DBLayer.SponsorshipEvents.Update(S);
				else DBLayer.SponsorshipEvents.Create(S);
				
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
			DBLayer.SponsorshipEvents.Delete(S);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowSponsorshipEvent() {
			txtSponsorID.Text = S.SponsorID.ToString();
			txtMonetaryValue.Text = S.MonetaryValue.ToString();
		}

		public void SaveSponsorshipEvent() {
			try {
				S.SponsorID = Convert.ToInt32(txtSponsorID.Text);
				S.MonetaryValue = Convert.ToInt32(txtMonetaryValue.Text);
				S.EventNumber = E.Number;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtSponsorID.Enabled = false;
			txtMonetaryValue.Enabled = false;
		}

		public void UnlockControls() {
			if (!toUpdate) txtSponsorID.Enabled = true;
			else if (toUpdate) txtSponsorID.Enabled = false;
			txtSponsorID.ReadOnly = false;
			txtMonetaryValue.Enabled = true;
			txtMonetaryValue.ReadOnly = false;
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
			txtMonetaryValue.Text = "";
		}

		#endregion

		
	}
}
