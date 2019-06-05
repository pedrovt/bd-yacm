using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	internal class ParticipantsDropOut
	{
		internal static void Create(User U, Event E) {
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "INSERT YACM.ParticipantDropOut (participantID, eventNumber) VALUES (@id, @eventID)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", U.ID);
			cmd.Parameters.AddWithValue("@eventID", E.Number);
			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to insert into database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}

		internal static ParticipantDropOut Read(int participantID, int eventNumber) {
			Debug.Assert(participantID > -1 && eventNumber > -1, "Participant ID or event Number Index Invalid. Can't Load Participant Drop out");

			ParticipantDropOut P = new ParticipantDropOut();

			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.ParticipantDropOut WHERE participantID = @participantID AND eventNumber = @eventNumber", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", participantID);
			cmd.Parameters.AddWithValue("@eventNumber", eventNumber);
			try {
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					P.ID = Convert.ToInt32(reader["participantID"].ToString());
				}
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to read from database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
			Program.db.Close();
			return P;
		}

		internal static void Delete(User U, Event E) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.ParticipantDropOut WHERE participantID=@id AND eventNumber=@eventID ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", U.ID);
			cmd.Parameters.AddWithValue("@eventID", E.Number);

			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete user in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}
	}
}