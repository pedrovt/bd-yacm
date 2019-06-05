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
	public partial class DialogEquipment : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly Equipment EQ;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogEquipment(Event E, Equipment EQ) {
			InitializeComponent();

			this.E = E;
			this.EQ = EQ;
			this.toUpdate = false;
			
			// Show Event Details
			ShowEquipment();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogEquipment(Event E) {
			InitializeComponent();
			this.E = E;
			this.EQ = new Equipment();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}
		
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveEvent();
			if (canCommit) {

				if (toUpdate) DBLayer.Equipments.Update(EQ);
				else DBLayer.Equipments.Create(EQ);
				
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
			DBLayer.Equipments.Delete(EQ);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion

		#region Auxilar Methods
		public void ShowEquipment() {
			txtID.Value = EQ.ID;
			txtParticipant.Text = Convert.ToString(EQ.ParticipantID);
			txtCategory.Text = EQ.Category;
			txtDescription.Text = EQ.Description;
		}

		public void SaveEvent() {
			try {
				EQ.ID = Convert.ToInt32(txtID.Value);
				EQ.ParticipantID = Convert.ToInt32(txtParticipant.Text);
				EQ.Category = txtCategory.Text;
				EQ.Description = txtDescription.Text;
				EQ.EventID = E.Number;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtID.Enabled = false;
			txtParticipant.Enabled = false;
			txtCategory.Enabled = false;
			txtDescription.Enabled = false;
		}

		public void UnlockControls() {
			txtID.Enabled = false;
			txtParticipant.Enabled = true;
			txtParticipant.ReadOnly = false;
			txtCategory.Enabled = true;
			txtCategory.ReadOnly = false;
			txtDescription.Enabled = true;
			txtDescription.ReadOnly = false;
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
			txtParticipant.Text = "";
			txtCategory.Text = "";
			txtDescription.Text = "";
		}

		#endregion

		
	}
}
