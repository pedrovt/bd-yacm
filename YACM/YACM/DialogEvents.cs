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
		private bool toUpdate;
		#endregion

		#region CTOR
		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventIndex"></param>
		/// <param name="createMode"> true if Dialog is create from a Add Button</param>
		public DialogEvents(int eventIndex, bool createMode) {
			InitializeComponent();

			this.eventIndex = eventIndex;
			this.toUpdate = false;

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

			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "INSERT YACM.Event (number, name, beginningDate, endDate, visiblity, managerID) " + "VALUES (@number, @name, @beginningDate, @endDate, @visibility, @managerID) ";
			cmd.Parameters.Clear();

			cmd.Parameters.AddWithValue("@number", this.E.Number);
			cmd.Parameters.AddWithValue("@name", this.E.Name);
			cmd.Parameters.AddWithValue("@beginningDate", this.E.BeginningDate);
			cmd.Parameters.AddWithValue("@endDate", this.E.EndDate);
			cmd.Parameters.AddWithValue("@visibility", this.E.Visibility);
			cmd.Parameters.AddWithValue("@managerID", this.E.ManagerID);

			cmd.Connection = Program.db.getDBConnection();

			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw new Exception("Failed to update in database. \n Error message: \n" + ex.Message);
			}
			finally {
				Program.db.closeDBConnection();
			}
		}

		private void ReadEvent(int eventNumber) {
			Debug.Assert(eventNumber > -1, "Event Index Invalid. Can't Load Event");

			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Event WHERE number = @eventIndex", Program.db.getDBConnection());

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@eventIndex", eventNumber);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read()) {
				E = new Event();
				E.Number = Convert.ToInt32(reader["number"].ToString());
				E.Name = reader["name"].ToString();
				E.BeginningDate = Convert.ToDateTime(reader["beginningDate"].ToString());
				E.EndDate = Convert.ToDateTime(reader["endDate"].ToString());
				E.Visibility = Convert.ToBoolean(reader["visibility"].ToString());
				E.ManagerID = Convert.ToInt32(reader["managerID"].ToString());
			}

			Program.db.closeDBConnection();

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
			int rows = 0;


			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "UPDATE YACM.Event " + "SET number = @number, " + "    name = @name, " + "    beginningDate = @beginningDate, " + "    endDate = @endDate, " + "    visibility = @visibility, " + "    managerID = @managerID " + "WHERE number = @number";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@number", E.Number);
			cmd.Parameters.AddWithValue("@name", E.Name);
			cmd.Parameters.AddWithValue("@beginningDate", E.BeginningDate);
			cmd.Parameters.AddWithValue("@endDate", E.EndDate);
			cmd.Parameters.AddWithValue("@visibility", E.Visibility);
			cmd.Parameters.AddWithValue("@managerID", E.ManagerID);

			cmd.Connection = Program.db.getDBConnection();


			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw new Exception("Failed to update event in database. \n Error message: \n" + ex.Message);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

			Program.db.closeDBConnection();
			}
		}

		private void DeleteEvent(Event E) {

			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.Event WHERE number=@number ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@number", E.Number);
			cmd.Connection = Program.db.getDBConnection();

			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw new Exception("Failed to delete event in database. \n Error Message: \n" + ex.Message);
			}
			finally {
				Program.db.closeDBConnection();
			}
		}
		#endregion

		#region Event Handlers
		private void BttnOK_Click(object sender, EventArgs e) {
			if (toUpdate) {
				SaveEvent();
				UpdateEvent(E);
			}
			this.Dispose();
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
			E.Number = Convert.ToInt32(txtID.Text);
			E.EndDate = txtEndDate.Value;
			E.Visibility = txtVisibility.Checked;
			E.BeginningDate = txtBeginDate.Value;
			E.Name = txtName.Text;
			E.ManagerID = Convert.ToInt32(txtManager.Text);
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
			txtBudget.ReadOnly = false;
			txtVisibility.Enabled = false;
			txtBeginDate.Enabled = true;
			txtName.ReadOnly = false;
			txtManager.ReadOnly = false;
		}

		private void UpdateButtons(bool create) {
			bttnCancel.Enabled = true;
			bttnCancel.Visible = true;

			if (create) {
				bttnAdd.Enabled = true;
				bttnAdd.Visible = true;


				bttnOK.Enabled = false;
				bttnEdit.Enabled = false;
				bttnDelete.Enabled = false;

				bttnOK.Visible = false;
				bttnEdit.Visible = false;
				bttnDelete.Visible = false;
			}
			else {
				bttnAdd.Enabled = false;
				bttnAdd.Visible = false;


				bttnOK.Enabled = true;
				bttnEdit.Enabled = true;
				bttnDelete.Enabled = true;

				bttnOK.Visible = true;
				bttnEdit.Visible = true;
				bttnDelete.Visible = true;
			}
		}

		public void ClearFields() {
			txtEndDate.Text = "";
			txtID.Text = "";
			txtBudget.Text = "";
			txtVisibility.Text = "";
			txtBeginDate.Text = "";
			txtName.Text = "";
		}

		#endregion

		
	}
}
