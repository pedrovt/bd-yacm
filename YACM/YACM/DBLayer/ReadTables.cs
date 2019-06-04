using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	public class ReadTables
	{

		// TODO FIXME SQL INJECTION ASAP (use template from first method)
		public static void ReadEventsList(int userID, ListView eventsList) {
			SqlCommand cmd = new SqlCommand("SELECT number, name, beginningDate, endDate, visibility FROM YACM.Event WHERE managerID=@id", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", userID);

			Utils.ReadToListView(cmd, eventsList);

			Program.db.Close();
		}
		

		public static void ReadEventsListOld(int userID, ListView eventsList) {
			Utils.ReadToListView("SELECT number, name, beginningDate, endDate, visibility FROM YACM.Event WHERE managerID=" + userID, eventsList);
		}

		public static void ReadStatistics() {
			// TODO txtNAME.text = value from query
		}

		public static void ReadUsers(ListView usersList) {
			Utils.ReadToListView("(SELECT P.id, email, name, 'Manager' as 'type' FROM YACM.[User] AS U JOIN YACM.Manager AS P ON U.id = P.id) UNION (SELECT P.id, email, name, 'Sponsor' as 'type' FROM YACM.[User] AS U JOIN YACM.Sponsor AS P ON U.id = P.id) UNION (SELECT P.id, email, name, 'Participant' as 'type' FROM YACM.[User] AS U JOIN YACM.Participant AS P ON U.id = P.id )", usersList);
		}

		public static void ReadEquipments(ListView equipmentList, Event E) {
			equipmentList.Hide();

			// Given an event number, equipments id, category and participant ID and name for equipment for participants enrolled in the event
			Utils.ReadToListView("SELECT E.id, participantID, email, name, category, description FROM YACM.EQUIPMENT AS E JOIN (SELECT id, email, name FROM YACM.[User] AS U LEFT OUTER JOIN (SELECT * FROM YACM.ParticipantEnrollment WHERE eventNumber = " + E.Number + ") AS P ON P.participantID = U.id WHERE participantID IS NOT NULL) AS U ON U.id=participantID", equipmentList);  //OK

			equipmentList.Show();
		}

		public static void ReadParticipantsDropOut(ListView participantsDropOutList, Event E) {
			participantsDropOutList.Hide();

			// Given an event number, return id, email, name
			Utils.ReadToListView("SELECT id, email, name FROM YACM.[User] JOIN YACM.ParticipantDropOut ON id=participantID WHERE eventNumber=" + E.Number, participantsDropOutList);        //OK

			participantsDropOutList.Show();
		}

		public static void ReadParticipantsEnrollment(ListView participantsEnrollmentList, Event E) {
			participantsEnrollmentList.Hide();

			// Given an event number, return id, email, name
			Utils.ReadToListView("SELECT id, email, name FROM YACM.[User] JOIN YACM.ParticipantEnrollment ON id=participantID WHERE eventNumber=" + E.Number, participantsEnrollmentList);  //OK

			participantsEnrollmentList.Show();
		}

		public static void ReadParticipantsOnTeam(ListView participantsOnTeamList, Event E) {
			participantsOnTeamList.Hide();

			// Given an event number, return id, email, name, team info, start date and end date
			Utils.ReadToListView("SELECT participantID, email, name, teamName, startDate, endDate FROM (SELECT id, email, name FROM YACM.[User] AS U LEFT OUTER JOIN (SELECT * FROM YACM.ParticipantEnrollment WHERE eventNumber = " + E.Number + ") AS P ON P.participantID = U.id WHERE participantID IS NOT NULL) AS U JOIN YACM.ParticipantOnTeam AS P ON U.id=P.participantID", participantsOnTeamList);

			participantsOnTeamList.Show();
		}

		public static void ReadPrizes(ListView prizesList, Event E) {
			prizesList.Hide();

			// Given an event number, return sponsor ID, sponsor Name, receiver ID, receiver name, value
			Utils.ReadToListView("SELECT T.id, sponsorID, sponsorEmail, sponsorName, ReceiverID as receiverID, email as receiverEmail, name as receiverName, value FROM (SELECT P.id, P.sponsorID, P.ReceiverID, email AS sponsorEmail, name AS sponsorName, value FROM YACM.[Prize] AS P JOIN YACM.[User] AS U ON sponsorID=U.id WHERE eventNumber=" + E.Number + ") AS T JOIN YACM.[User] AS U ON T.receiverID=U.id", prizesList);

			prizesList.Show();
		}

		public static void ReadSponsorshipsEvents(ListView sponsorshipEventsList, Event E) {
			sponsorshipEventsList.Hide();

			// Given an event number, return sponsor IDs, sponsor Name, receiver ID, receiver name, value
			Utils.ReadToListView("SELECT sponsorID, email, name, monetaryValue FROM YACM.[SponsorshipEvent] JOIN YACM.[User] ON sponsorID=id WHERE eventNumber=" + E.Number, sponsorshipEventsList);

			sponsorshipEventsList.Show();
		}

		public static void ReadSponsorshipsTeams(ListView sponsorshipTeamsList, Event E) {
			sponsorshipTeamsList.Hide();

			// Return sponsor info and teams names
			Utils.ReadToListView("SELECT sponsorID, email, name, teamName, monetaryValue FROM YACM.SponsorshipTeam JOIN YACM.[User] ON sponsorID=id ", sponsorshipTeamsList);

			sponsorshipTeamsList.Show();
		}

		public static void ReadStages(ListView stagesList, Event E) {
			stagesList.Hide();

			// Given an event number, return date, start location, end location, distance
			Utils.ReadToListView("SELECT date, startLocation, endLocation, distance FROM YACM.[Stage] WHERE eventNumber=" + E.Number, stagesList);

			stagesList.Show();

		}

		public static void ReadStagesParticipations(ListView stagesParticipationsList, Event E) {
			stagesParticipationsList.Hide();

			// Given an event number, return participant and stage info and result
			Utils.ReadToListView("SELECT participantID, email, name, stageDate, stageStartLocation, stageEndLocation, result FROM YACM.[StageParticipation] JOIN YACM.[User] on participantID=id WHERE eventNumber=" + E.Number, stagesParticipationsList);

			stagesParticipationsList.Show();

		}

		public static void ReadTeams(ListView teamsList, Event E) {
			teamsList.Hide();

			// TODO Given an event number, return team name, number of participants on team, number of sponsors and total monetary value
			Utils.ReadToListView("SELECT * FROM YACM.[Team]", teamsList);

			teamsList.Show();
		}

		public static void ReadDocuments(ListView documentsList, Event E) {
			documentsList.Hide();

			// Given an event number, return document id, type and content/path
			Utils.ReadToListView("(SELECT D.id, 'text' as [type], content FROM (SELECT * FROM YACM.Document WHERE eventNumber = " + E.Number + ") AS D JOIN YACM.TextFile AS O ON D.id = O.id) UNION (SELECT D.id, 'other', path FROM (SELECT * FROM YACM.Document WHERE eventNumber = " + E.Number + ")  AS D JOIN YACM.OtherFile AS O ON D.id = O.id)", documentsList);

			documentsList.Show();
		}
		
	}
}
