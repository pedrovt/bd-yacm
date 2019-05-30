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
		private int eventsCount;
		private int eventIndex;
		#endregion

		#region CTOR and Load
		public Main(String user) {
			InitializeComponent();

			eventsCount = -1;
			eventIndex = -1;
			labelTitle.Text = "Welcome back, " + user;

			eventManagement.Hide();
		}

		private void Main_Load(object sender, EventArgs e) {
			ReadEvents();
		}

		#endregion

		#region CRUD methods
		private void ReadEvents() {
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Event", Program.db.Open());
			SqlDataReader reader = cmd.ExecuteReader();
			

			// Creating the columns in the List View
			int numFields = reader.FieldCount;
			String field;
			eventsList.Columns.Clear();      // clear previous columns, if needed
			for (int i = 0; i < numFields; i++) {
				field = reader.GetName(i);

				eventsList.Columns.Add(field);
			}

			// Loading the data
			eventsList.Items.Clear();        // clear previous items, if needed
			eventsCount = 0;
			while (reader.Read()) {
				ListViewItem item = eventsList.Items.Add(reader[0].ToString());
				for (int i = 1; i < numFields; i++) {
					item.SubItems.Add(reader[i].ToString().TrimEnd());
				}
				
			}

			// Adjusting the columns width
			for (int i = 0; i < numFields; i++) {
				eventsList.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			}

			Program.db.Close();

		}
		
		private void ReadEventDetails() {
			eventManagement.Show();
			LoadAbout();
		}
		#endregion

		#region Event Handlers
		private void EventsList_SelectedIndexChanged(object sender, EventArgs e) {
			
			if (eventsList.SelectedItems != null) {
				ListViewItem firstSelectedItem = eventsList.FocusedItem;
				eventIndex = Convert.ToInt32(firstSelectedItem.SubItems[0].Text.ToString());
				debugInfo.Text = "Selected Event ID is " + eventIndex;
			}

			ReadEventDetails();
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

		#region Toolstrip Event Handlers

		private void AddEvent_Click(object sender, EventArgs e) {
			DialogEvents dialog = new DialogEvents(eventIndex, true, eventsCount);
			dialog.Show();
			ReadEvents();
		}

		private void RefreshEvents_Click(object sender, EventArgs e) {
			ReadEvents();
		}

		private void EditEvent_Click(object sender, EventArgs e) {
			if (eventIndex >= 0) {
				DialogEvents dialog = new DialogEvents(eventIndex, false, eventsCount);
				dialog.Show();
				ReadEvents();
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
		private void LoadDocuments() {
			MessageBox.Show("Documents");
		}

		private void LoadTeams() {
			MessageBox.Show("Teams");
		}

		private void LoadStages() {
			MessageBox.Show("Stages");
		}

		private void LoadSponsors() {
			MessageBox.Show("Sponsors");
		}

		private void LoadPrizes() {
			MessageBox.Show("Prizes");
		}

		private void LoadParticipants() {
			MessageBox.Show("Participants");
		}

		private void LoadEquipment() {
			MessageBox.Show("Equipment");
		}

		private void LoadAbout() {
			MessageBox.Show("About");
			 
		}

		#endregion
	}
}
