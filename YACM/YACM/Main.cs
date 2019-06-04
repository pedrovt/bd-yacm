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

		// ----------------------------------------
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
			LoadStatistics();
		}

		private void EventManagement_SelectedIndexChanged(object sender, EventArgs e) {
			switch (eventManagement.SelectedIndex) {
				case 0:                 // About
					Console.WriteLine("Selected About");
					LoadStatistics();
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
				case 6:                 // Stage Participations
					Console.WriteLine("Selected Stage Participations");
					LoadStagesParticipations();
					break;
				case 7:                 // Teams
					Console.WriteLine("Selected Teams");
					LoadTeams();
					break;
				case 8:                 // Documents
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

		// ----------------------------------------
		// Load of list views
		#region Events Management Tabs Logic
		// All these methods have access to Event E

		private void LoadDocuments() {
			//MessageBox.Show("Documents");
			documentsList.Hide();

			// TODO Stored Procedure to, given an event number, return document id, type and content/path
			// TODO fixme sql injection asap (create a SP)

			Utils.ReadToListView("SELECT * FROM YACM.[Document] WHERE eventNumber=" + E.Number, documentsList);
			
			documentsList.Show();
		}

		private void LoadTeams() {
			//MessageBox.Show("Teams");
			teamsList.Hide();

			// TODO Stored Procedure to, given an event number, return team name, number of participants on team, number of sponsors and total monetary value
			// TODO FIXME SQL INJECTION ASAP (create a SP?)

			Utils.ReadToListView("SELECT * FROM YACM.[Team]", teamsList);

			teamsList.Show();
		}

		private void LoadStages() {
			//MessageBox.Show("Stages");
			stagesList.Hide();

			// TODO Stored Procedure to, given an event number, return date, start location, end location, distance
			// TODO FIXME SQL INJECTION ASAP (create a SP?)

			Utils.ReadToListView("SELECT * FROM YACM.[Stage] WHERE eventNumber=" + E.Number, stagesList);

			stagesList.Show();

		}

		private void LoadStagesParticipations() {
			//MessageBox.Show("Stage Participations");
			stagesParticipationsList.Hide();

			// TODO Stored Procedure to, given an event number, return date, start location, end location, distance
			// TODO FIXME SQL INJECTION ASAP (create a SP?)

			Utils.ReadToListView("SELECT * FROM YACM.[StageParticipation] WHERE eventNumber=" + E.Number, stagesParticipationsList);

			stagesParticipationsList.Show();

		}

		private void LoadSponsors() {
			//MessageBox.Show("Sponsors");
			sponsorsList.Hide();
			
			// TODO Stored Procedure to, given an event number, return sponsor IDs, sponsor Name, receiver ID, receiver name, value
			// TODO FIXME SQL INJECTION ASAP (create a SP?)

			Utils.ReadToListView("SELECT * FROM YACM.[SponsorshipEvent] WHERE eventNumber=" + E.Number, sponsorsList);  

			sponsorsList.Show();
		}

		private void LoadPrizes() {
			//MessageBox.Show("Prizes");
			prizesList.Hide();

			// TODO Stored Procedure to, given an event number, return sponsor ID, sponsor Name, receiver ID, receiver name, value
			// TODO FIXME SQL INJECTION ASAP (create a SP?)
			Utils.ReadToListView("SELECT id, sponsorID, receiverID, value FROM YACM.[Prize] WHERE eventNumber=" + E.Number, prizesList);   
			
			prizesList.Show();
		}

		private void LoadParticipants() {
			//MessageBox.Show("Participants");
			participantsList.Hide();

			// TODO Stored Procedure to, given an event number, return id, email, name and status (drop out, enrollment, on team and team name, start and end date)
			// TODO FIXME SQL INJECTION ASAP (create a SP?)
			Utils.ReadToListView("SELECT id, email, name FROM YACM.[User] JOIN YACM.ParticipantEnrollment ON id=participantID WHERE eventNumber=" + E.Number, participantsList);   

			// Not supposed to show passwords! --> forgot I could simply remove from SELECT 
			// Utils.HideColumn(3, participantsList);

			participantsList.Show();
		}

		private void LoadEquipment() {
			//MessageBox.Show("Equipment");
			equipmentList.Hide();

			// TODO Stored Procedure to, given an event number, equipments id, category and participant ID and name
			// TODO FIXME SQL INJECTION ASAP (create a SP?)
			Utils.ReadToListView("SELECT * FROM YACM.EQUIPMENT", equipmentList);

			equipmentList.Show();
		}

		private void LoadStatistics() {
			//MessageBox.Show("Statistics");

		}


		#endregion

		// ----------------------------------------
		// Add, Edit, Refresh Buttons

		#region Events Management :: Equipments 
		private void AddEquipment_Click(object sender, EventArgs e) {
			DialogEquipment dialog = new DialogEquipment(E);
			dialog.Show();
			LoadEquipment();
		}

		private void EditEquipment_Click(object sender, EventArgs e) {
			if (GetSelectedID(equipmentList) != -1) {
				Equipment EQ = DBLayer.Equipments.Read(GetSelectedID(equipmentList));
				DialogEquipment dialog = new DialogEquipment(E, EQ);
				dialog.Show();
				LoadEquipment();
			}
		}

		private void RefreshEquipment_Click(object sender, EventArgs e) {
			LoadEquipment();
		}

		#endregion

		#region Events Management :: Participants
		private void AddParticipants_Click(object sender, EventArgs e) {
			DialogParticipants dialog = new DialogParticipants();
			dialog.Show();
			LoadParticipants();
		}

		private void EditParticipants_Click(object sender, EventArgs e) {
			DialogParticipants dialog = new DialogParticipants(E);
			dialog.Show();
			LoadParticipants();
		}

		private void RefreshParticipants_Click(object sender, EventArgs e) {
			LoadParticipants();		
		}

		#endregion

		#region Events Management :: Prizes
		private void AddPrizes_Click(object sender, EventArgs e) {
			DialogPrize dialog = new DialogPrize(E);
			dialog.Show();
			LoadPrizes();
		}

		private void EditPrizes_Click(object sender, EventArgs e) {
			if (GetSelectedID(prizesList) != -1) {
				Prize P = DBLayer.Prizes.Read(GetSelectedID(prizesList));
				DialogPrize dialog = new DialogPrize(E, P);
				dialog.Show();
				LoadPrizes();
			}
		}

		private void RefreshPrizes_Click(object sender, EventArgs e) {
			LoadPrizes();
		}

		#endregion

		#region Events Management :: Sponsors
		private void AddSponsors_Click(object sender, EventArgs e) {
			DialogSponsors dialog = new DialogSponsors(E);
			dialog.Show();
			LoadSponsors();
		}

		private void EditSponsors_Click(object sender, EventArgs e) {
			if (GetSelectedID(sponsorsList) != -1) {
				Sponsor S = DBLayer.Sponsors.Read(GetSelectedID(sponsorsList));
				DialogSponsors dialog = new DialogSponsors(E, S);
				dialog.Show();
				LoadSponsors();
			}
		}

		private void RefreshSponsors_Click(object sender, EventArgs e) {
			LoadSponsors();
		}
		#endregion

		#region Events Management :: Stages
		private void AddStages_Click(object sender, EventArgs e) {
			DialogStages dialog = new DialogStages(E);
			dialog.Show();
			LoadStages();
		}

		private void EditStages_Click(object sender, EventArgs e) {
			if (stagesList.SelectedItems != null) {
				ListViewItem firstSelectedItem = stagesList.FocusedItem;
				DateTime date = Convert.ToDateTime(firstSelectedItem.SubItems[0].Text);
				string startLocation = firstSelectedItem.SubItems[1].Text;
				string endLocation = firstSelectedItem.SubItems[2].Text;
				Stage S = DBLayer.Stages.Read(date, startLocation, endLocation);
				DialogStages dialog = new DialogStages(E, S);
				dialog.Show();
				LoadStages();
			}
			
		}

		private void RefreshStages_Click(object sender, EventArgs e) {
			LoadStages();
		}

		#endregion

		#region Events Management :: Stages Participations [DEPRECATED]
		private void AddStagesParticipations_Click(object sender, EventArgs e) {
			DialogStagesParticipations dialog = new DialogStagesParticipations();
			dialog.Show();
			LoadStagesParticipations();
		}

		private void EditStagesParticipations_Click(object sender, EventArgs e) {
			DialogStagesParticipations dialog = new DialogStagesParticipations(E);
			dialog.Show();
			LoadStagesParticipations();


		}

		private void RefreshStagesParticipations_Click(object sender, EventArgs e) {
			LoadStagesParticipations();
		}
		#endregion

		#region Events Management :: Teams
		private void AddTeams_Click(object sender, EventArgs e) {
			DialogTeams dialog = new DialogTeams();
			dialog.Show();
			LoadTeams();
		}

		private void EditTeams_Click(object sender, EventArgs e) {
			if (teamsList.SelectedItems != null) {
				ListViewItem firstSelectedItem = teamsList.FocusedItem;
				string name = firstSelectedItem.SubItems[0].Text;
				Team T = DBLayer.Teams.Read(name);
				DialogTeams dialog = new DialogTeams(E, T);
				dialog.Show();
				LoadTeams();
			}
		}

		private void RefreshTeams_Click(object sender, EventArgs e) {
			LoadTeams();
		}
		#endregion

		#region Events Management :: Documents
		private void AddDocuments_Click(object sender, EventArgs e) {
			DialogDocuments dialog = new DialogDocuments(E);
			dialog.Show();
			LoadDocuments();
		}

		private void EditDocuments_Click(object sender, EventArgs e) {
			if (GetSelectedID(documentsList) != -1) {
				// DEBUG
				// Document D = new Document(1, DocumentType.Text, "Hello");
				Document D = DBLayer.Documents.Read(GetSelectedID(documentsList));
				DialogDocuments dialog = new DialogDocuments(E, D);
				dialog.Show();
				LoadDocuments();
			}
		}

		private void RefreshDocuments_Click(object sender, EventArgs e) {
			LoadDocuments();
		}
		#endregion


		private int GetSelectedID (ListView list) {
			int index = -1;
			if (list.SelectedItems != null) {
				ListViewItem firstSelectedItem = list.FocusedItem;
				index = Convert.ToInt32(firstSelectedItem.SubItems[0].Text.ToString());
				debugInfo.Text = "Selected ID is " + index;
			}
			return index;
		}
		
	}
}
