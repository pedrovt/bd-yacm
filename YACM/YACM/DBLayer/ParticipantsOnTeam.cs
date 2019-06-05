using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	internal class ParticipantsOnTeam
	{
		internal static void Create(ParticipantOnTeam P) {
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "INSERT YACM.ParticipantOnTeam(participantID, teamName, startDate, endDate) VALUES (@participantID, @teamName, @startDate, @endDate)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", P.ParticipantID);
			cmd.Parameters.AddWithValue("@teamName", P.TeamName);
			cmd.Parameters.AddWithValue("@startDate", P.StartDate);
			cmd.Parameters.AddWithValue("@endDate", P.EndDate);

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

		internal static ParticipantOnTeam Read(int participantID, string teamName) {
			Debug.Assert(participantID > -1 && teamName != null, "Participant ID or team name invalid. Can't Load Participant On Team");

			ParticipantOnTeam P = new ParticipantOnTeam();

			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.ParticipantOnTeam WHERE participantID = @participantID AND teamName = @teamName", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", participantID);
			cmd.Parameters.AddWithValue("@teamName", teamName);
			try {
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					P.ParticipantID = Convert.ToInt32(reader["participantID"].ToString());
					P.TeamName = reader["teamName"].ToString();
					P.StartDate = Convert.ToDateTime(reader["startDate"].ToString());
					P.EndDate = Convert.ToDateTime(reader["endDate"].ToString());
				}
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to read from database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
			return P;
		}

		internal static void Update(ParticipantOnTeam P) {
			int rows = 0;

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE YACM.ParticipantOnTeam SET startDate=@startDate, endDate=@endDate";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@startDate", P.StartDate);
			cmd.Parameters.AddWithValue("@endDate", P.EndDate);
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

		internal static void Delete(ParticipantOnTeam P) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.ParticipantOnTeam WHERE participantID=@participantID AND teamName=@teamName ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@participantID", P.ParticipantID);
			cmd.Parameters.AddWithValue("@teamName", P.TeamName);

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