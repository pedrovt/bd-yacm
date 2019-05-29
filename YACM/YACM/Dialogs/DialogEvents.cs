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
	public partial class DialogEvents : Form
	{

		#region Instance Fields
		private Event E;
		private readonly int eventIndex;
		private readonly int eventsCount;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventIndex"></param>
		/// <param name="createMode"> true if Dialog is create from a Add Button</param>
		public DialogEvents(int eventIndex, bool createMode, int eventsCount) {
			InitializeComponent();

			this.E = new Event();
			this.eventIndex = eventIndex;
			this.toUpdate = false;
			this.eventsCount = eventsCount;

			if (createMode) {
				// Add an Event
				UnlockControls();
				ClearFields();
			}
			else {
				// Show Event Details
				ReadEvent(eventIndex);
				ShowEvent();
			}

			UpdateButtons(createMode);
		}
		#endregion

		#region Create, Read, Update, Delete methods
		private void CreateEvent(Event E) {
			DBLayer.Events.Create(E);
		}

		private void ReadEvent(int eventNumber) {
			E = DBLayer.Events.Read(eventNumber);

			if (E == null) {
				MessageBox.Show("Event with number " + eventNumber + " not found!");
				
			}
			else {
				ShowEvent();
			}

			LockControls();

			//currentContact = 0;

		}

		private void UpdateEvent(Event E) {
			DBLayer.Events.Update(E);
		}

		private void DeleteEvent(Event E) {
			DBLayer.Events.Delete(E);
		}

		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			if (toUpdate) {
				SaveEvent();
				if (canCommit) UpdateEvent(E);
			}
			else {
				SaveEvent();
				if (canCommit) CreateEvent(E);
			}
			if (canCommit) {		//Return to main
				this.Dispose();
			}
		}

		private void BttnEdit_Click(object sender, EventArgs e) {
			if (toUpdate) LockControls();
			else UnlockControls();
			toUpdate = !toUpdate;
		}

		private void BttnDelete_Click(object sender, EventArgs e) {
			DeleteEvent(E);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowEvent() {
			txtEndDate.Value = E.EndDate;
			txtID.Text = E.Number.ToString();
			txtBudget.Text = "-1"; //TODO
			txtVisibility.Checked = E.Visibility;
			txtBeginDate.Value = E.BeginningDate;
			txtName.Text = E.Name;
			txtManager.Text = E.ManagerID.ToString();
		}

		public void SaveEvent() {
			try {
				E.Number = Convert.ToInt32(txtID.Value);
				E.EndDate = txtEndDate.Value;
				E.Visibility = txtVisibility.Checked;
				E.BeginningDate = txtBeginDate.Value;
				E.Name = txtName.Text;
				E.ManagerID = Convert.ToInt32(txtManager.Text);
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}


		public void LockControls() {
			txtEndDate.Enabled = false;
			txtID.ReadOnly = true;
			txtBudget.ReadOnly = true;
			txtVisibility.Enabled = true;
			txtBeginDate.Enabled = false;
			txtName.ReadOnly = true;
			txtManager.ReadOnly = true;
		}

		public void UnlockControls() {
			txtEndDate.Enabled = true;
			txtID.ReadOnly = false;
			txtID.Minimum = eventsCount;
			txtBudget.ReadOnly = false;
			txtVisibility.Enabled = false;
			txtBeginDate.Enabled = true;
			txtName.ReadOnly = false;
			txtManager.ReadOnly = false;
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
			
			txtEndDate.Text = "";
			txtID.Value = eventsCount;
			txtID.Minimum = eventsCount;
			txtBudget.Text = "";
			txtVisibility.Text = "";
			txtBeginDate.Text = "";
			txtName.Text = "";
		}

		#endregion

		
	}
}
