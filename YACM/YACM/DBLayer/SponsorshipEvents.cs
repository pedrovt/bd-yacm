using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	internal class SponsorshipEvents
	{
		internal static void Create(SponsorshipEvent E) {
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "INSERT YACM.SponsorshipEvent(sponsorID, eventNumber, monetaryValue) VALUES (@sponsorID, @eventNumber, @monetaryValue)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@sponsorID", E.SponsorID);
			cmd.Parameters.AddWithValue("@eventNumber", E.EventNumber);
			cmd.Parameters.AddWithValue("@monetaryValue", E.MonetaryValue);

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

		internal static SponsorshipEvent Read(int sponsorID, int eventNumber) {
			Debug.Assert(sponsorID > -1 && eventNumber > -1, "Sponsor ID or event Number Index Invalid. Can't Load Sponsorship Event");

			SponsorshipEvent S = new SponsorshipEvent();

			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.SponsorshipEvent WHERE sponsorID = @sponsorID AND eventNumber = @eventNumber", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@sponsorID", sponsorID);
			cmd.Parameters.AddWithValue("@eventNumber", eventNumber);
			try {
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					S.SponsorID = Convert.ToInt32(reader["sponsorID"].ToString());
					S.EventNumber = Convert.ToInt32(reader["eventNumber"].ToString());
					S.MonetaryValue = Convert.ToDouble(reader["monetaryValue"].ToString());
				}
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to read from database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
			Program.db.Close();
			return S; 
		}

		internal static void Update(SponsorshipEvent E) {
			int rows = 0;

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE YACM.SponsorshipEvent SET monetaryValue=@monetaryValue WHERE sponsorID=@sponsorID AND eventNumber=@eventNumber";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@sponsorID", E.SponsorID);
			cmd.Parameters.AddWithValue("@eventNumber", E.EventNumber);
			cmd.Parameters.AddWithValue("@monetaryValue", E.MonetaryValue);
			cmd.Connection = Program.db.Open();
			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update sponsorship event in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

				Program.db.Close();
			}
		}

		internal static void Delete(SponsorshipEvent E) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.SponsorshipEvent WHERE sponsorID = @sponsorID AND eventNumber = @eventNumber";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@sponsorID", E.SponsorID);
			cmd.Parameters.AddWithValue("@eventNumber", E.EventNumber);

			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete sponsorship event in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			};
		}
	}
}