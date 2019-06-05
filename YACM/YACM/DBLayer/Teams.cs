using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	class Teams
	{
		internal static void Create(Team T) {
			SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.Team (name) VALUES (@name)";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", T.Name);
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

		internal static Team Read(string name) {

			Team T = new Team();
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Team WHERE name=@name", Program.db.Open());

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", name);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T.Name = reader["name"].ToString();
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
			return T;
		}

		// Update doesn't make sense in this context

		internal static void Delete(Team T) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.Team WHERE name=@name ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@name", T.Name);
			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete team from database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}
	}
}