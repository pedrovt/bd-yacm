using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
    class Participants
    {

        #region CRUD methods
        internal static void Create(Participant P)
        {
            // TODO Stored procedure to insert, depending of the type, in the appropriated tables

            // Insertion into User Table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.User (id, email, name, password) VALUES (@id, @email, @name, @password)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", P.ID);
            cmd.Parameters.AddWithValue("@email", P.Email);
            cmd.Parameters.AddWithValue("@name", P.Name);
            cmd.Parameters.AddWithValue("@password", P.Password);
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

            // Insertion into Participant Table
            cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.Sponsor (id) VALUES (@id)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", P.ID);
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

		internal static Participant Read(int id)
        {
            Debug.Assert(id > -1, "Prize Index Invalid. Can't Load Prize");

            Participant P = new Participant();

            SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.User WHERE id = @id", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    P.ID = Convert.ToInt32(reader["id"].ToString());
                    P.Email = reader["email"].ToString();
                    P.Name = reader["name"].ToString();
                    P.Password = reader["password"].ToString();
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
            Program.db.Close();
            return P;
        }

        internal static void Update(Participant P)
        {
            int rows = 0;

            // Update User Table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE YACM.User SET email=@email, name=@name, password=@password WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", P.ID);
            cmd.Parameters.AddWithValue("@email", P.Email);
            cmd.Parameters.AddWithValue("@name", P.Name);
            cmd.Parameters.AddWithValue("@password", P.Password);
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

        internal static void Delete(Participant P)
        {
            SqlCommand cmd = new SqlCommand();

            // Deletion is performed only on Table User
            // Triggers will do the rest
            cmd.CommandText = "DELETE YACM.User WHERE id=@id ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", P.ID);
            cmd.Connection = Program.db.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete user in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }
        }
		#endregion

		#region DropOut 
		internal static void DropOutDelete(User U, Event E) {
			SqlCommand cmd = new SqlCommand();

			// Deletion is performed only on Table User
			// Triggers will do the rest
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

		internal static void DropOutCreate(User U, Event E) {
			// Insertion into User Table
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

		internal static void DropOutUpdate(User U, Event E) {
			int rows = 0;

			// Update User Table
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE YACM.ParticipantDropOut SET participantID=@id, eventNumber=@eventID";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", U.ID);
			cmd.Parameters.AddWithValue("@eventID", E.Number);
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
		#endregion

	}
}