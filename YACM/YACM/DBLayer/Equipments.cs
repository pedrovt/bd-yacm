using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	class Equipments
	{

		#region CRUD methods
		internal static void Create(Equipment EQ) {
			// TODO Stored procedure to insert, depending of the type, in the appropriated tables

			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "INSERT YACM.Equipment (id, participantID, category, description) VALUES (@id, @participantID, @category, @description)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", EQ.ID);
			cmd.Parameters.AddWithValue("@participantID", EQ.ParticipantID);
			cmd.Parameters.AddWithValue("@category", EQ.Category);
			cmd.Parameters.AddWithValue("@description", EQ.Description);
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

		internal static Equipment Read(int id) {
			Debug.Assert(id > -1, "Equipment Index Invalid. Can't Load Equipment");

			Equipment EQ = new Equipment();
			
			// Stored Procedure to based on the id, retrieve either the file or the otherfile
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Equipment WHERE id = @id", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EQ.ID = Convert.ToInt32(reader["id"].ToString());
                    EQ.ParticipantID = Convert.ToInt32(reader["participantID"].ToString());
                    EQ.Category = reader["category"].ToString();
                    EQ.Description = reader["description"].ToString();
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
			return EQ;
		}

		internal static void Update(Equipment EQ) {
			int rows = 0;
            
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "UPDATE YACM.Equipment SET participantID = @participantID, category = @category, description = @description WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", EQ.ID);
            cmd.Parameters.AddWithValue("@participantID", EQ.ParticipantID);
            cmd.Parameters.AddWithValue("@category", EQ.Category);
            cmd.Parameters.AddWithValue("@description", EQ.Description);
            cmd.Connection = Program.db.Open();
			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update equipment in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

				Program.db.Close();
			}
		}

		internal static void Delete(Equipment EQ) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.Equipment WHERE id=@id ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", EQ.ID);
			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete equipment in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}

		#endregion

		#region Statistics
		#endregion
	}
}
