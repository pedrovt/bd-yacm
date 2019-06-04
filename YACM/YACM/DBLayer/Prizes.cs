using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	class Prizes
	{

		#region CRUD methods
		internal static void Create(Prize P) {
			// TODO Stored procedure to insert, depending of the type, in the appropriated tables

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "INSERT YACM.Prize (id, sponsorID, eventNumber, receiverID, value) VALUES (@id, @sponsorID, @eventNumber, @receiverID, @value)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", P.ID);
			cmd.Parameters.AddWithValue("@sponsorID", P.SponsorID);
			cmd.Parameters.AddWithValue("@eventNumber", P.EventNumber);
			cmd.Parameters.AddWithValue("@receiverID", P.ReceiverID);
            cmd.Parameters.AddWithValue("@value", P.Value);
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

		internal static Prize Read(int id) {
			Debug.Assert(id > -1, "Prize Index Invalid. Can't Load Prize");

			Prize P = new Prize();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Prize WHERE id = @id", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    P.ID = Convert.ToInt32(reader["id"].ToString());
                    P.SponsorID = Convert.ToInt32(reader["sponsorID"].ToString());
                    P.EventNumber = Convert.ToInt32(reader["eventNumber"].ToString());
                    P.ReceiverID = Convert.ToInt32(reader["receiverID"].ToString());
                    P.Value = Convert.ToDouble(reader["value"].ToString());
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
            return P;
		}

		internal static void Update(Prize P) {
            int rows = 0;

            // Update Prize table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE YACM.Prize SET sponsorID=@sponsorID, eventNumber=@eventNumber, receiverID=@receiverID, value=@value WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", P.ID);
            cmd.Parameters.AddWithValue("@sponsorID", P.SponsorID);
            cmd.Parameters.AddWithValue("@eventNumber", P.EventNumber);
            cmd.Parameters.AddWithValue("@receiverID", P.ReceiverID);
            cmd.Parameters.AddWithValue("@value", P.Value);
            cmd.Connection = Program.db.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update prize in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		internal static void Delete(Prize P) {
			SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE YACM.Prize WHERE id=@id ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", P.ID);
            cmd.Connection = Program.db.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete prize from database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }
        }

		#endregion

	}
}