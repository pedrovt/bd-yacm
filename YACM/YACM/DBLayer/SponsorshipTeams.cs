using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	internal class SponsorshipTeams
	{
		internal static void Create(SponsorshipTeam S)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.SponsorshipTeam(sponsorID, teamName, monetaryValue) VALUES (@sponsorID, @teamName, @monetaryValue)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sponsorID", S.SponsorID);
            cmd.Parameters.AddWithValue("@teamName", S.TeamName);
            cmd.Parameters.AddWithValue("@monetaryValue", S.MonetaryValue);

            cmd.Connection = Program.db.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert into database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }
        }

		internal static SponsorshipTeam Read(int sponsorID, string teamName)
        {
            Debug.Assert(sponsorID > -1 && teamName != null, "Participant ID or team name invalid. Can't Load Participant On Team");

            SponsorshipTeam S = new SponsorshipTeam();

            SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.SponsorshipTeam WHERE participantID = @participantID AND teamName = @teamName", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sponsorID", sponsorID);
            cmd.Parameters.AddWithValue("@teamName", teamName);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    S.SponsorID = Convert.ToInt32(reader["sponsor"].ToString());
                    S.TeamName = reader["teamName"].ToString();
                    S.MonetaryValue = Convert.ToInt32(reader["monetaryValue"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to read from database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }
            return S;
        }

		internal static void Update(SponsorshipTeam S)
        {
            int rows = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE YACM.SponsorshipTeam SET monetaryValue=@monetaryValue WHERE sponsorID=@sponsorID AND teamName=@teamName";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sponsorID", S.SponsorID);
            cmd.Parameters.AddWithValue("@teamName", S.TeamName);
            cmd.Parameters.AddWithValue("@monetaryValue", S.MonetaryValue);
            cmd.Connection = Program.db.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update user in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rows == 1)
                    MessageBox.Show("Updated sucessfully");
                else
                    MessageBox.Show("Update not sucesfull");

                Program.db.Close();
            }
        }

		internal static void Delete(SponsorshipTeam S) {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE YACM.SponsorshipTeam WHERE sponsorID=@sponsorID AND teamName=@teamName";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sponsorID", S.SponsorID);
            cmd.Parameters.AddWithValue("@teamName", S.TeamName);

            cmd.Connection = Program.db.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete participant in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }
        }
	}
}