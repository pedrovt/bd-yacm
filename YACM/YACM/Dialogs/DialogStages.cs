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
	public partial class DialogStages : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly Stage S;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Event
		/// </summary>
		/// <param name="E">Event</param>
		public DialogStages(Event E, Stage S) {
			InitializeComponent();

			this.E = E;
			this.S = S;
			this.toUpdate = false;
			
			// Show Event Details
			ShowSponsor();
			LockControls();
			UpdateButtons(false);
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogStages(Event E) {
			InitializeComponent();
			this.E = E;
			this.S = new Stage();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}

	
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveSponsor();
			if (canCommit) {

				if (toUpdate) DBLayer.Stages.Update(S);
				else DBLayer.Stages.Create(S);
				
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
			DBLayer.Stages.Delete(S);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowSponsor() {
			txtDate.Value = S.Date;
			txtStart.Text = S.StartLocation;
			txtEnd.Text = S.EndLocation;
			txtDistance.Text = S.Distance.ToString();
		}

		public void SaveSponsor() {
			try {
				S.Date = Convert.ToDateTime(txtDate.Value);
				S.StartLocation = txtStart.Text;
				S.EndLocation = txtEnd.Text;
				S.Distance = Convert.ToInt32(txtDistance.Text);
				S.EventID = E.Number;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtDate.Enabled = false;
			txtStart.Enabled = false;
			txtEnd.Enabled = false;
			txtDistance.Enabled = false;
		}

		public void UnlockControls() {
			txtDate.Enabled = false;
			txtStart.Enabled = false;
			txtEnd.Enabled = false;
			txtDistance.Enabled = true;
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
			txtDate.Text = "";
			txtStart.Text = "";
			txtEnd.Text = "";
			txtDistance.Text = "";
		}

		#endregion

		
	}
}
