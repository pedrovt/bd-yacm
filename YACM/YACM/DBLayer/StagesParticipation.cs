using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	internal class StagesParticipation
	{
        internal static void Create(StageParticipation S) {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.StageParticipation (participantID, eventNumber, stageDate, stageStartLocation, stageEndLocation, result) VALUES (@participantID, @eventNumber, @stageDate, @stageStartLocation, @stageEndLocation, @result)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@participantID", S.ParticipantID);
            cmd.Parameters.AddWithValue("@eventNumber", S.EventNumber);
            cmd.Parameters.AddWithValue("@stageDate", S.StageDate);
            cmd.Parameters.AddWithValue("@stageStartLocation", S.StageStartLocation);
            cmd.Parameters.AddWithValue("@stageEndLocation", S.StageEndLocation);
            cmd.Parameters.AddWithValue("@result", S.Result);
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

        internal static StageParticipation Read(int participantID, int eventNumber, DateTime stageDate, string stageStartLocation, string stageEndLocation) {
            StageParticipation S = new StageParticipation();

            SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.StageParticipation WHERE participantID=@participantID AND eventNumber=@eventNumber AND stageDate=@stageDate AND stageStartLocation=@stageStartLocation AND stageEndLocation=@stageEndLocation", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@participantID", participantID);
            cmd.Parameters.AddWithValue("@eventNumber", eventNumber);
            cmd.Parameters.AddWithValue("@stageDate", stageDate);
            cmd.Parameters.AddWithValue("@stageStartLocation", stageStartLocation);
            cmd.Parameters.AddWithValue("@stageEndLocation", stageEndLocation);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    S.ParticipantID = Convert.ToInt32(reader["participantID"].ToString());
                    S.EventNumber = Convert.ToInt32(reader["eventNumber"].ToString());
                    S.StageDate = Convert.ToDateTime(reader["stageDate"].ToString());
                    S.StageStartLocation = reader["stageStartLocation"].ToString());
                    S.StageEndLocation = reader["stageEndLocation"].ToString());
                    S.Result = reader["result"].ToString();
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

		internal static void Update(StageParticipation S) {
            int rows = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE YACM.StageParticipation SET result=@result WHERE participantID=@participantID AND eventNumber=@eventNumber AND stageDate=@stageDate AND stageStartLocation=@stageStartLocation AND stageEndLocation=@stageEndLocation";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@participantID", S.ParticipantID);
            cmd.Parameters.AddWithValue("@eventNumber", S.EventNumber);
            cmd.Parameters.AddWithValue("@stageDate", S.StageDate);
            cmd.Parameters.AddWithValue("@stageStartLocation", S.StageStartLocation);
            cmd.Parameters.AddWithValue("@stageEndLocation", S.StageEndLocation);
            cmd.Parameters.AddWithValue("@result", S.Result);
            cmd.Connection = Program.db.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update stage in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		internal static void Delete(StageParticipation S)
        {
            SqlCommand cmd = new SqlCommand("DELETE YACM.StageParticipation WHERE participantID=@participantID AND eventNumber=@eventNumber AND stageDate=@stageDate AND stageStartLocation=@stageStartLocation AND stageEndLocation=@stageEndLocation", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@participantID", S.ParticipantID);
            cmd.Parameters.AddWithValue("@eventNumber", S.EventNumber);
            cmd.Parameters.AddWithValue("@stageDate", S.StageDate);
            cmd.Parameters.AddWithValue("@stageStartLocation", S.StageStartLocation);
            cmd.Parameters.AddWithValue("@stageEndLocation", S.StageEndLocation);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete stage from database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }
        }

		
	}
}