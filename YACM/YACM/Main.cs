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
		private int userID;
		#endregion

		#region CTOR and Load
		public Main(int id, String user) {
			InitializeComponent();

			eventIndex = -1;
			userID = id;

			labelTitle.Text = "Welcome back, " + user;

			eventManagement.Hide();
		}

		private void Main_Load(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadEventsList(userID, eventsList);
			DBLayer.ReadTables.ReadUsers(usersList);
            DBLayer.ReadTables.ReadOtherEvents(userID, otherEventList);
			DBLayer.ReadTables.ReadAllTeams(allTeamsList);
		}

		#endregion

		// ----------------------------------------
		#region Main Event Handlers
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
			DBLayer.ReadTables.ReadStatistics();
		}

		private void EventManagement_SelectedIndexChanged(object sender, EventArgs e) {
			switch (eventManagement.SelectedIndex) {
				case 0:                 // About
					Console.WriteLine("Selected Statistics");
					DBLayer.ReadTables.ReadStatistics();
					break;
				case 1:                 // Equipment
					Console.WriteLine("Selected Equipment");
					DBLayer.ReadTables.ReadEquipments(equipmentList, E);
					break;
				case 2:                 // Participants Drop Out
					Console.WriteLine("Selected Drop Out Participants");
					DBLayer.ReadTables.ReadParticipantsDropOut(participantsDropOutList, E);
					break;
				case 3:					// Participants Enrollment
					Console.WriteLine("Selected Enrolled Participants");
					DBLayer.ReadTables.ReadParticipantsEnrollment(participantsEnrollmentList, E);
					break;
				case 4:					// Participants on Team
					Console.WriteLine("Selected On Team Participants");
					DBLayer.ReadTables.ReadParticipantsOnTeam(participantsOnTeamList, E);
					break;
				case 5:                 // Prizes
					Console.WriteLine("Selected Prizes");
					DBLayer.ReadTables.ReadPrizes(prizesList, E);
					break;
				case 6:                 // Sponsorship Events
					Console.WriteLine("Selected Sponsorships Events");
					DBLayer.ReadTables.ReadSponsorshipsEvents(sponsorshipEventsList, E);
					break;
				case 7:
					Console.WriteLine("Selected Sponsorships Teams");
					DBLayer.ReadTables.ReadSponsorshipsTeams(sponsorshipTeamsList, E);
					break;
				case 8:                 // Stages
					Console.WriteLine("Selected Stages");
					DBLayer.ReadTables.ReadStages(stagesList, E);
					break;
				case 9:                 // Stage Participations
					Console.WriteLine("Selected Stage Participations");
					DBLayer.ReadTables.ReadStagesParticipations(stagesParticipationsList, E);
					break;
				case 10:                 // Teams
					Console.WriteLine("Selected Teams");
					DBLayer.ReadTables.ReadTeams(teamsList, E);
					break;
				case 11:                 // Documents
					Console.WriteLine("Selected Documents");
					DBLayer.ReadTables.ReadDocuments(documentsList, E);
					break;

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
		// Add, Edit, Refresh Buttons
		#region Add Buttons
		private void AddEvent_Click(object sender, EventArgs e) {
			DialogEvents dialog = new DialogEvents();
			dialog.Show();
		}

		private void AddEquipment_Click(object sender, EventArgs e) {
			DialogEquipment dialog = new DialogEquipment(E);
			dialog.Show();
		}

		private void AddParticipantsDropOut_Click(object sender, EventArgs e) {
			DialogParticipantsDropOut dialog = new DialogParticipantsDropOut(E);
			dialog.Show();
		}

		private void AddParticipantsEnrollment_Click(object sender, EventArgs e) {
			DialogParticipantsEnrollment dialog = new DialogParticipantsEnrollment(E);
			dialog.Show();
		}

		private void AddParticipantsOnTeam_Click(object sender, EventArgs e) {
			DialogParticipantsOnTeam dialog = new DialogParticipantsOnTeam(E);
			dialog.Show();
		}

		private void AddPrizes_Click(object sender, EventArgs e) {
			DialogPrize dialog = new DialogPrize(E);
			dialog.Show();
		}

		private void AddSponsorshipEvents_Click(object sender, EventArgs e) {
			DialogSponsorshipEvent dialog = new DialogSponsorshipEvent(E);
			dialog.Show();
		}

		private void AddSponsorshipTeams_Click(object sender, EventArgs e) {
			DialogSponsorshipTeam dialog = new DialogSponsorshipTeam(E);
			dialog.Show();
		}

		private void AddStages_Click(object sender, EventArgs e) {
			DialogStages dialog = new DialogStages(E);
			dialog.Show();
		}

		private void AddStagesParticipations_Click(object sender, EventArgs e) {
			DialogStagesParticipations dialog = new DialogStagesParticipations(E);
			dialog.Show();
		}

		private void AddTeams_Click(object sender, EventArgs e) {
			DialogTeams dialog = new DialogTeams();
			dialog.Show();
		}

		private void AddDocuments_Click(object sender, EventArgs e) {
			DialogDocuments dialog = new DialogDocuments(E);
			dialog.Show();
		}

		#endregion

		#region Edit Buttons
		private void EditEvent_Click(object sender, EventArgs e) {
			if (eventIndex >= 0) {
				DialogEvents dialog = new DialogEvents(E);
				dialog.Show();
			}
		}

		private void EditEquipment_Click(object sender, EventArgs e) {
			if (GetSelectedID(equipmentList) != -1) {
				Equipment EQ = DBLayer.Equipments.Read(GetSelectedID(equipmentList));
				DialogEquipment dialog = new DialogEquipment(E, EQ);
				dialog.Show();	
			}
		}

		private void EditParticipantsDropOut_Click(object sender, EventArgs e) {
			if (GetSelectedID(participantsDropOutList) != -1) {
				ParticipantDropOut P = DBLayer.ParticipantsDropOut.Read(GetSelectedID(participantsDropOutList), E.Number);
				DialogParticipantsDropOut dialog = new DialogParticipantsDropOut(E, P);
				dialog.Show();
			}
		}

		private void EditParticipantsEnrollment_Click(object sender, EventArgs e) {
			if (GetSelectedID(participantsEnrollmentList) != -1) {
				ParticipantEnrollment P = DBLayer.ParticipantsEnrollments.Read(GetSelectedID(participantsEnrollmentList), E.Number);
				DialogParticipantsEnrollment dialog = new DialogParticipantsEnrollment(E, P);
				dialog.Show();
			}
		}

		private void EditParticipantsOnTeam_Click(object sender, EventArgs e) {
			if (participantsOnTeamList.FocusedItem != null) {
				// Get primary keys
				ListViewItem firstSelectedItem = participantsOnTeamList.FocusedItem;
				int participantID = Convert.ToInt32(firstSelectedItem.SubItems[0].Text);
				string teamName = firstSelectedItem.SubItems[3].Text;
				
				ParticipantOnTeam P = DBLayer.ParticipantsOnTeam.Read(participantID, teamName);

				DialogParticipantsOnTeam dialog = new DialogParticipantsOnTeam(E, P);
				dialog.Show();
			}
		}

		private void EditPrizes_Click(object sender, EventArgs e) {
			if (GetSelectedID(prizesList) != -1) {
				Prize P = DBLayer.Prizes.Read(GetSelectedID(prizesList));
				DialogPrize dialog = new DialogPrize(E, P);
				dialog.Show();
			}
		}

		private void EditSponsorshipEvents_Click(object sender, EventArgs e) {
			if (GetSelectedID(sponsorshipEventsList) != -1) {
				SponsorshipEvent S = DBLayer.SponsorshipEvents.Read(GetSelectedID(sponsorshipEventsList), E.Number);
				DialogSponsorshipEvent dialog = new DialogSponsorshipEvent(E, S);
				dialog.Show();
			}
		}

		private void EditSponsorshipTeams_Click(object sender, EventArgs e) {
			if (sponsorshipTeamsList.FocusedItem != null) {
				// Get primary keys
				ListViewItem firstSelectedItem = sponsorshipTeamsList.FocusedItem;

				int sponsorID = Convert.ToInt32(firstSelectedItem.SubItems[0].Text);
				string teamName = firstSelectedItem.SubItems[3].Text;

				SponsorshipTeam S = DBLayer.SponsorshipTeams.Read(sponsorID, teamName);

				DialogSponsorshipTeam dialog = new DialogSponsorshipTeam(E, S);
				dialog.Show();
			}
		}

		private void EditStages_Click(object sender, EventArgs e) {
			if (stagesList.FocusedItem != null) {
				// Get primary keys
				ListViewItem firstSelectedItem = stagesList.FocusedItem;
				DateTime date = Convert.ToDateTime(firstSelectedItem.SubItems[0].Text);
				string startLocation = firstSelectedItem.SubItems[1].Text;
				string endLocation = firstSelectedItem.SubItems[2].Text;

				Stage S = DBLayer.Stages.Read(date, startLocation, endLocation);

				DialogStages dialog = new DialogStages(E, S);
				dialog.Show();
			}
		}

		private void EditStagesParticipations_Click(object sender, EventArgs e) {
			if (stagesParticipationsList.FocusedItem != null) {
				// Get primary keys
				ListViewItem firstSelectedItem = stagesParticipationsList.FocusedItem;
				int participantID = Convert.ToInt32(firstSelectedItem.SubItems[0].Text);
				DateTime stageDate = Convert.ToDateTime(firstSelectedItem.SubItems[3].Text);
				string stageStartLocation = firstSelectedItem.SubItems[4].Text;
				string stageEndLocation = firstSelectedItem.SubItems[5].Text;

				StageParticipation S = DBLayer.StagesParticipation.Read(participantID, E.Number, stageDate, stageStartLocation, stageEndLocation);
				DialogStagesParticipations dialog = new DialogStagesParticipations(E, S);
				dialog.Show();
			}
		}

		private void EditTeams_Click(object sender, EventArgs e) {
			if (allTeamsList.FocusedItem != null) {
				ListViewItem firstSelectedItem = allTeamsList.FocusedItem;
				string teamName = firstSelectedItem.SubItems[0].Text;
				Team T = DBLayer.Teams.Read(teamName);
				DialogTeams dialog = new DialogTeams(E, T);
				dialog.Show();
			}
		}
		
		private void EditDocuments_Click(object sender, EventArgs e) {
			if (GetSelectedID(documentsList) != -1) {
				Document D = DBLayer.Documents.Read(GetSelectedID(documentsList), ParseDocumentType(documentsList));
				DialogDocuments dialog = new DialogDocuments(E, D);
				dialog.Show();
			}
		}

		#endregion

		#region Refresh Buttons Click Handlers
		private void RefreshEvents_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadEventsList(userID, eventsList);
			eventManagement.Hide();
		}

		private void RefreshEquipment_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadEquipments(equipmentList, E);
		}

		private void RefreshParticipantsDropOut_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadParticipantsDropOut(participantsDropOutList, E);
		}

		private void RefreshParticipantsEnrollment_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadParticipantsEnrollment(participantsEnrollmentList, E);
		}

		private void RefreshParticipantsOnTeam_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadParticipantsOnTeam(participantsOnTeamList, E);
		}

		private void RefreshPrizes_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadPrizes(prizesList, E);
		}

		private void RefreshSponsorshipEvents_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadSponsorshipsEvents(sponsorshipEventsList, E);
		}

		private void RefreshSponsorshipTeams_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadSponsorshipsTeams(sponsorshipTeamsList, E);
		}

		private void RefreshStages_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadStages(stagesList, E);
		}

		private void RefreshStagesParticipations_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadStagesParticipations(stagesParticipationsList, E);
		}

		private void RefreshTeams_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadAllTeams(allTeamsList);
		}

		private void RefreshDocuments_Click(object sender, EventArgs e) {
			DBLayer.ReadTables.ReadDocuments(documentsList, E);
		}


		#endregion

		#region Auxiliar Methods
		private int GetSelectedID (ListView list) {
			int index = -1;
			if (list.FocusedItem != null) {
				ListViewItem firstSelectedItem = list.FocusedItem;
				index = Convert.ToInt32(firstSelectedItem.SubItems[0].Text.ToString());
				debugInfo.Text = "Selected ID is " + index;
			}
			return index;
		}

		private DocumentType ParseDocumentType(ListView list) {
			if (list.SelectedItems != null) {
				ListViewItem firstSelectedItem = list.FocusedItem;
				string type = firstSelectedItem.SubItems[1].Text.ToString();
				switch (type) {
					case "text":
						return DocumentType.Text;
					case "other":
						return DocumentType.Other;
				}
			}
			return DocumentType.Other;
		}
		#endregion

	}
}
