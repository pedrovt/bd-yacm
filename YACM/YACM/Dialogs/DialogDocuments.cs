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
	public partial class DialogDocuments : Form
	{

		#region Instance Fields
		private readonly Event E;
		private readonly Document D;
		private bool toUpdate;
		private bool canCommit;
		#endregion

		#region CTOR
		/// <summary>
		/// Constructor for a Dialog for an Existing Document
		/// </summary>
		/// <param name="E">Event</param>
		public DialogDocuments(Event E, Document D) {
			InitializeComponent();

			this.E = E;
			this.D = D;
			this.toUpdate = false;
			
			// Show Event Details
			ShowDocument();
			LockControls();
			UpdateButtons(false);

			if (D.Type == DocumentType.Text) {
				txtType.SelectedIndex = 0;
				txtPath.Hide();
				Label2.Hide();
				txtContents.Show();
				label8.Show();
			}
			else if (D.Type == DocumentType.Other) { 
				txtType.SelectedIndex = 1;
				txtPath.Show();
				Label2.Show();
				txtContents.Hide();
				label8.Hide();
			}
			else {
				txtPath.Hide();
				Label2.Hide();
				txtContents.Hide();
				label8.Hide();
			}
		}

		/// <summary>
		/// Constructor for a Dialog to create a new Event
		/// </summary>
		public DialogDocuments(Event E) {
			InitializeComponent();

			this.E = E;
			this.D = new Document();
			ClearFields();
			UnlockControls();
			UpdateButtons(true);
		}
		
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			SaveDocument();
			if (canCommit) {

				if (toUpdate) DBLayer.Documents.Update(D);
				else DBLayer.Documents.Create(D);
				
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
			DBLayer.Documents.Delete(D);
			this.Dispose();
		}

		private void BttnCancel_Click(object sender, EventArgs e) {
			this.Dispose();
		}

		#endregion
		
		#region Auxilar Methods
		public void ShowDocument() {
			txtID.Value = D.ID;

			if (D.Type == DocumentType.Text) {
				txtType.SelectedIndex = 0;
				txtPath.Hide();
				Label2.Hide();
				txtContents.Show();
				label8.Show();
			}
			else {
				txtType.SelectedIndex = 1;
				txtPath.Show();
				Label2.Show();
				txtContents.Hide();
				label8.Hide();
			}

			txtPath.Text = D.Path;
			txtContents.Text = D.Contents;
			
		}

		public void SaveDocument() {
			D.EventID = E.Number;
			try {
				if (txtType.SelectedIndex == 0) {
					D.Type = DocumentType.Text;
				}
				else {
					D.Type = DocumentType.Other;
				}

				D.Path = txtPath.Text;
				D.Contents = txtContents.Text;
				canCommit = true;
			} catch (Exception) {
				MessageBox.Show("Error while saving entry. Please check if you added all the required info in the right format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				canCommit = false;
			}
		}

		public void LockControls() {
			txtID.Enabled		= false;
			txtType.Enabled		= false;
			txtPath.Enabled		= false;
			txtContents.Enabled = false;
		}

		public void UnlockControls() {
			txtID.Enabled		= false;
			txtType.Enabled		= true;
			txtPath.Enabled		= true;
			txtContents.Enabled = true;
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
			txtType.Text = "";
			txtPath.Text = "";
			txtContents.Text = "";
		}


		#endregion

		private void TxtType_SelectedIndexChanged(object sender, EventArgs e) {
			if (txtType.SelectedIndex == 0) {
				txtPath.Hide();
				Label2.Hide();
				txtContents.Show();
				label8.Show();
			}
			else if (txtType.SelectedIndex == 1) {				
				txtPath.Show();
				Label2.Show();
				txtContents.Hide();
				label8.Hide();
			}
		}
	}
}
