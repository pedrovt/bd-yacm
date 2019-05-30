using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
	public partial class Main : Form
	{

		#region Instance Fields
		private Event E;
		private int eventIndex;
		#endregion

		#region CTOR and Load
		public Main(String user) {
			InitializeComponent();

			eventIndex = -1;
			labelTitle.Text = "Welcome back, " + user;

			eventManagement.Hide();
		}

		private void Main_Load(object sender, EventArgs e) {
			ReadEventsList();
		}

		private void ReadEventsList() {
			Utils.ReadToListView("SELECT * FROM YACM.Event", eventsList);
		}

		#endregion

		#region Events List Event Handlers
		private void EventsList_SelectedIndexChanged(object sender, EventArgs e) {
			
			if (eventsList.SelectedItems != null) {
				ListViewItem firstSelectedItem = eventsList.FocusedItem;
				eventIndex = Convert.ToInt32(firstSelectedItem.SubItems[0].Text.ToString());
				debugInfo.Text = "Selected Event ID is " + eventIndex;
			}

			// Read Event
			E = DBLayer.Events.Read(eventIndex);

			if (E == null) {
				MessageBox.Show("Event with number " + eventIndex + " not found!");
			}

			// Read Event Details
			eventManagement.Show();
			EventManagement_SelectedIndexChanged(sender, e);		// Update
			LoadAbout();
		}

		private void EventManagement_SelectedIndexChanged(object sender, EventArgs e) {
			switch (eventManagement.SelectedIndex) {
				case 0:                 // About
					Console.WriteLine("Selected About");
					LoadAbout();
					break;
				case 1:                 // Equipment
					Console.WriteLine("Selected Equipment");
					LoadEquipment();
					break;
				case 2:                 // Participants
					Console.WriteLine("Selected Participants");
					LoadParticipants();
					break;
				case 3:                 // Prizes
					Console.WriteLine("Selected Prizes");
					LoadPrizes();
					break;
				case 4:                 // Sponsors
					Console.WriteLine("Selected Sponsors");
					LoadSponsors();
					break;
				case 5:                 // Stages
					Console.WriteLine("Selected Stages");
					LoadStages();
					break;
				case 6:                 // Teams
					Console.WriteLine("Selected Teams");
					LoadTeams();
					break;
				case 7:                 // Documents
					Console.WriteLine("Selected Documents");
					LoadDocuments();
					break;

			}
		}
		#endregion

		#region Events List Toolstrip Event Handlers

		private void AddEvent_Click(object sender, EventArgs e) {
			DialogEvents dialog = new DialogEvents();
			dialog.Show();
			ReadEventsList();
		}

		

		private void RefreshEvents_Click(object sender, EventArgs e) {
			ReadEventsList();
			eventManagement.Hide();
		}

		private void EditEvent_Click(object sender, EventArgs e) {
			if (eventIndex >= 0) {
				DialogEvents dialog = new DialogEvents(E);
				dialog.Show();
				ReadEventsList();
			}
		}

		private void Logout_Click(object sender, EventArgs e) {
			Login login = new Login();
			this.Hide();
			login.ShowDialog();
			this.Close();
			this.Dispose();
		}

		#endregion

		#region Events Management Tabs Logic
		// All these methods have access to Event E

		private void LoadDocuments() {
			//MessageBox.Show("Documents");
		}

		private void LoadTeams() {
			//MessageBox.Show("Teams");
		}

		private void LoadStages() {
			//MessageBox.Show("Stages");
		}

		private void LoadSponsors() {
			//MessageBox.Show("Sponsors");
		}

		private void LoadPrizes() {
			//MessageBox.Show("Prizes");
		}

		private void LoadParticipants() {
			//MessageBox.Show("Participants");

			participantsList.Hide();

			Utils.ReadToListView("SELECT id, email, name, password FROM YACM.[User] JOIN YACM.ParticipantEnrollment ON id=participantID WHERE eventNumber=" + E.Number, participantsList);   //TODO FIXME SQL INJECTION ASAP (create a SP?)

			// Not supposed to show passwords!
			Utils.HideColumn(3, participantsList);

			participantsList.Show();
		}

		private void LoadEquipment() {
			//MessageBox.Show("Equipment");
			Utils.ReadToListView("SELECT * FROM YACM.EQUIPMENT", equipmentList);
		}

		private void LoadAbout() {
			//MessageBox.Show("About");
			eventName.Text = E.Name;
			 
		}


		#endregion

		#region Events Management :: Participants 
		private void ToolStripMenuItem4_Click(object sender, EventArgs e) {

		}

		private void ToolStripMenuItem5_Click(object sender, EventArgs e) {

		}

		private void ToolStripMenuItem6_Click(object sender, EventArgs e) {

		}
		
		#endregion
	}
}
