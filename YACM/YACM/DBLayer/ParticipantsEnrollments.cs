using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	internal class ParticipantsEnrollments
	{
		
		internal static void Create(ParticipantEnrollment P) {
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "INSERT YACM.ParticipantEnrollment(participantID, eventNumber, teamName, dorsal) VALUES (@participantID, @eventNumber, @teamName, @dorsal)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", P.ParticipantID);
			cmd.Parameters.AddWithValue("@eventNumber", P.EventNumber);
			cmd.Parameters.AddWithValue("@teamName", P.TeamName);
			cmd.Parameters.AddWithValue("@dorsal", P.Dorsal);

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

		internal static ParticipantEnrollment Read(int participantID, int eventNumber) {
			Debug.Assert(participantID > -1 && eventNumber > -1, "Participant ID or event Number Index Invalid. Can't Load Participant Enrollment");

			ParticipantEnrollment P = new ParticipantEnrollment();

			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.ParticipantEnrollment WHERE participantID = @participantID AND eventNumber = @eventNumber", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", participantID);
			cmd.Parameters.AddWithValue("@eventNumber", eventNumber);
			try {
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					P.ParticipantID = Convert.ToInt32(reader["participantID"].ToString());
					P.EventNumber = Convert.ToInt32(reader["eventNumber"].ToString());
					P.TeamName = reader["teamName"].ToString();
					P.Dorsal = Convert.ToInt32(reader["dorsal"].ToString());
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

		internal static void Update(ParticipantEnrollment P) {
			int rows = 0;

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE YACM.ParticipantEnrollment SET teamName=@teamName, dorsal=@dorsal";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@teamName", P.TeamName);
			cmd.Parameters.AddWithValue("@dorsal", P.Dorsal);
			cmd.Connection = Program.db.Open();
			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update user in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

				Program.db.Close();
			}
		}

		internal static void Delete(ParticipantEnrollment P) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.ParticipantEnrollment WHERE participantID=@participantID AND eventNumber=@eventNumber ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", P.ParticipantID);
			cmd.Parameters.AddWithValue("@eventNumber", P.EventNumber);

			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete participant in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}

		
	}
}