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
					Console.WriteLine("Selected Statistics");
					LoadStatistics();
					break;
				case 1:                 // Equipment
					Console.WriteLine("Selected Equipment");
					LoadEquipment();
					break;
				case 2:                 // Participants
					Console.WriteLine("Selected Drop Out Participants");
					LoadParticipantsDropOut();
					break;
				case 3:
					Console.WriteLine("Selected Enrolled Participants");
					LoadParticipantsEnrollment();
					break;
				case 4:
					Console.WriteLine("Selected On Team Participants");
					LoadParticipantsOnTeam();
					break;
				case 5:                 // Prizes
					Console.WriteLine("Selected Prizes");
					LoadPrizes();
					break;
				case 6:                 // Sponsors
					Console.WriteLine("Selected Sponsorships Events");
					LoadSponsorshipsEvents();
					break;
				case 7:
					Console.WriteLine("Selected Sponsorships Teams");
					LoadSponsorshipsTeams();
					break;
				case 8:                 // Stages
					Console.WriteLine("Selected Stages");
					LoadStages();
					break;
				case 9:                 // Stage Participations
					Console.WriteLine("Selected Stage Participations");
					LoadStagesParticipations();
					break;
				case 10:                 // Teams
					Console.WriteLine("Selected Teams");
					LoadTeams();
					break;
				case 11:                 // Documents
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
		// TODO FIXME SQL INJECTION ASAP (create a SP?)

		private void LoadStatistics() {
			//MessageBox.Show("Statistics");
			// TODO txtNAME.text = value from query
		}

		private void LoadEquipment() {
			equipmentList.Hide();

			// Given an event number, equipments id, category and participant ID and name for equipment for participants enrolled in the event
			Utils.ReadToListView("SELECT E.id, participantID, email, name, category, description FROM YACM.EQUIPMENT AS E JOIN (SELECT id, email, name FROM YACM.[User] AS U LEFT OUTER JOIN (SELECT * FROM YACM.ParticipantEnrollment WHERE eventNumber = " + E.Number + ") AS P ON P.participantID = U.id WHERE participantID IS NOT NULL) AS U ON U.id=participantID", equipmentList);  //OK

			equipmentList.Show();
		}

		private void LoadParticipantsDropOut() {
			participantsDropOutList.Hide();

			// Given an event number, return id, email, name
			Utils.ReadToListView("SELECT id, email, name FROM YACM.[User] JOIN YACM.ParticipantDropOut ON id=participantID WHERE eventNumber=" + E.Number, participantsDropOutList);		//OK

			participantsDropOutList.Show();
		}

		private void LoadParticipantsEnrollment() {
			participantsEnrollmentList.Hide();

			// Given an event number, return id, email, name
			Utils.ReadToListView("SELECT id, email, name FROM YACM.[User] JOIN YACM.ParticipantEnrollment ON id=participantID WHERE eventNumber=" + E.Number, participantsEnrollmentList);  //OK

			participantsEnrollmentList.Show();
		}

		private void LoadParticipantsOnTeam() {
			participantsOnTeamList.Hide();

			// Given an event number, return id, email, name, team info, start date and end date
			Utils.ReadToListView("SELECT participantID, email, name, teamName, startDate, endDate FROM (SELECT id, email, name FROM YACM.[User] AS U LEFT OUTER JOIN (SELECT * FROM YACM.ParticipantEnrollment WHERE eventNumber = " + E.Number + ") AS P ON P.participantID = U.id WHERE participantID IS NOT NULL) AS U JOIN YACM.ParticipantOnTeam AS P ON U.id=P.participantID", participantsOnTeamList);
			
			participantsOnTeamList.Show();
		}

		private void LoadPrizes() {
			prizesList.Hide();

			// Given an event number, return sponsor ID, sponsor Name, receiver ID, receiver name, value
			Utils.ReadToListView("SELECT id, sponsorID, receiverID, value FROM YACM.[Prize] WHERE eventNumber=" + E.Number, prizesList);

			prizesList.Show();
		}

		private void LoadSponsorshipsEvents() {
			sponsorshipEventsList.Hide();

			// Given an event number, return sponsor IDs, sponsor Name, receiver ID, receiver name, value
			Utils.ReadToListView("SELECT P.id, P.sponsorID, email AS sponsorEmail, name AS sponsorName, value FROM YACM.[Prize] AS P JOIN YACM.[User] AS U ON sponsorID=U.id WHERE eventNumber=" + E.Number, sponsorshipEventsList);

			sponsorshipEventsList.Show();
		}

		private void LoadSponsorshipsTeams() {
			//MessageBox.Show("Sponsors");
			sponsorshipTeamsList.Hide();

			// Given an event number, return sponsor IDs and teams names
			Utils.ReadToListView("SELECT * FROM YACM.[SponsorshipEvent] WHERE eventNumber=" + E.Number, sponsorshipTeamsList);

			sponsorshipTeamsList.Show();
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

		private void LoadTeams() {
			//MessageBox.Show("Teams");
			teamsList.Hide();

			// TODO Stored Procedure to, given an event number, return team name, number of participants on team, number of sponsors and total monetary value
			// TODO FIXME SQL INJECTION ASAP (create a SP?)

			Utils.ReadToListView("SELECT * FROM YACM.[Team]", teamsList);		//OK

			teamsList.Show();
		}

		private void LoadDocuments() {
			//MessageBox.Show("Documents");
			documentsList.Hide();

			// TODO Stored Procedure to, given an event number, return document id, type and content/path
			// TODO fixme sql injection asap (create a SP)

			Utils.ReadToListView("SELECT * FROM YACM.[Document] WHERE eventNumber=" + E.Number, documentsList);

			documentsList.Show();
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

		#region Events Management :: Participants Dropout
		private void AddParticipants_Click(object sender, EventArgs e) {
			DialogParticipantsDropOut dialog = new DialogParticipantsDropOut(E);
			dialog.Show();
			LoadParticipantsDropOut();
		}

		private void EditParticipants_Click(object sender, EventArgs e) {
			if (GetSelectedID(prizesList) != -1) {
				Participant P = DBLayer.Participants.Read(GetSelectedID(participantsDropOutList));
				DialogParticipantsDropOut dialog = new DialogParticipantsDropOut(E, P);
				dialog.Show();
				LoadParticipantsDropOut();
			}
			
		}

		private void RefreshParticipants_Click(object sender, EventArgs e) {
			LoadParticipantsDropOut();		
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
			LoadSponsorshipsEvents();
		}

		private void EditSponsors_Click(object sender, EventArgs e) {
			if (GetSelectedID(sponsorshipEventsList) != -1) {
				Sponsor S = DBLayer.Sponsors.Read(GetSelectedID(sponsorshipEventsList));
				DialogSponsors dialog = new DialogSponsors(E, S);
				dialog.Show();
				LoadSponsorshipsEvents();
			}
		}

		private void RefreshSponsors_Click(object sender, EventArgs e) {
			LoadSponsorshipsEvents();
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

		#region Auxiliar Methods
		private int GetSelectedID (ListView list) {
			int index = -1;
			if (list.SelectedItems != null) {
				ListViewItem firstSelectedItem = list.FocusedItem;
				index = Convert.ToInt32(firstSelectedItem.SubItems[0].Text.ToString());
				debugInfo.Text = "Selected ID is " + index;
			}
			return index;
		}
		#endregion

	}
}
