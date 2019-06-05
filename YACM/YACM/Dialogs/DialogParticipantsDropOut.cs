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
	public partial class DialogParticipantsDropOut : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly User U;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogParticipantsDropOut(Event E, User U) {
			InitializeComponent();

			this.E = E;
			this.U = U;
			this.toUpdate = false;
			
			// Show Event Details
			ShowUser();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogParticipantsDropOut(Event E) {
			InitializeComponent();
			this.E = E;
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}
		
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			//SaveUser();
			if (canCommit) {

				//if (toUpdate) DBLayer.ParticipantsDropOut.Update(U, E);
				if (!toUpdate) DBLayer.ParticipantsDropOut.Create(U, E);
				
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
			DBLayer.ParticipantsDropOut.Delete(U, E);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowUser() {
			txtParticipantID.Text = U.ID.ToString();
		}

		public void LockControls() {
			txtParticipantID.Enabled = false;
			txtParticipantID.ReadOnly = true;
		}

		public void UnlockControls() {
			txtParticipantID.Enabled = true;
			txtParticipantID.ReadOnly = false;
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
				bttnEdit.Enabled = false;
				bttnEdit.Visible = false;

				bttnDelete.Enabled = true;
				bttnDelete.Visible = true;
			}
		}

		public void ClearFields() {
			txtParticipantID.Text = "";
		}

		#endregion

		
	}
}
