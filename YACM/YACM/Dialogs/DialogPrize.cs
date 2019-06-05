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
	public partial class DialogPrize : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly Prize P;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogPrize(Event E, Prize P) {
			InitializeComponent();

			this.E = E;
			this.P = P;
			this.toUpdate = false;
			
			// Show Event Details
			ShowPrize();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogPrize(Event E) {
			InitializeComponent();
			this.E = E;
			this.P = new Prize();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}

		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveEvent();
			if (canCommit) {

				if (toUpdate) DBLayer.Prizes.Update(P);
				else DBLayer.Prizes.Create(P);
				
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
			DBLayer.Prizes.Delete(P);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowPrize() {
			txtID.Value = P.ID;
			txtSponsorID.Text = P.SponsorID.ToString();
			txtReceiverID.Text = P.ReceiverID.ToString();
			txtValue.Text = P.Value.ToString();
			
		}

		public void SaveEvent() {
			try {
				P.ID = Convert.ToInt32(txtID.Value);
				P.SponsorID = Convert.ToInt32(txtSponsorID.Text);
				P.ReceiverID = Convert.ToInt32(txtReceiverID.Text);
				P.EventNumber = E.Number;
				P.Value	= Convert.ToInt32(txtValue.Text);
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtID.Enabled = false;
			txtSponsorID.Enabled = false;
			txtReceiverID.Enabled = false;
			txtValue.Enabled = false;
		}

		public void UnlockControls() {
			if (toUpdate) txtID.Enabled = false;
			else txtID.Enabled = true;
			txtID.ReadOnly = false;
			txtSponsorID.Enabled = true;
			txtSponsorID.ReadOnly = false;
			txtReceiverID.Enabled = true;
			txtReceiverID.ReadOnly = false;
			txtValue.Enabled = true;
			txtValue.ReadOnly = false;
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

			txtID.Text = "";
			txtSponsorID.Text = "";
			txtReceiverID.Text = "";
			txtValue.Text = "";
		}

		#endregion

		
	}
}
