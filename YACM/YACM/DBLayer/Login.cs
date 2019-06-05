using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	class Login
	{

		internal static void Create(String email, String name, String password, String userType) {

			// TODO Verify if exists
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "INSERT YACM.[User] (email, name, password) " + "VALUES (@email, @name, @password) ";
			cmd.Parameters.Clear();

			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@name", name);
			cmd.Parameters.AddWithValue("@password", password);
			cmd.Connection = Program.db.Open();

			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}

		}

		internal static User Read(String email, String password) {
			Debug.Assert(!email.Equals("") && !password.Equals(""), "Invalid email or password");
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Authenticate(@userEmail, @userPassword)", Program.db.Open());

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@userEmail", email);
			cmd.Parameters.AddWithValue("@userPassword", password);

			SqlDataReader reader = cmd.ExecuteReader();
			User U = new User();
			
			while (reader.Read()) {
				U.ID = Convert.ToInt32(reader["id"]);
				U.Name = Convert.ToString(reader["name"]);
				U.Email = Convert.ToString(reader["email"]);
				switch (Convert.ToString(reader["type"])) {
					case "Manager":
						U.Type = UserType.Manager;
						break;
					case "Participant":
						U.Type = UserType.Participant;
						break;
					case "Sponsor":
						U.Type = UserType.Sponsor;
						break;
					default:
						U.Type = UserType.Manager;
						break;
				}
				Program.db.Close();
				return U;
			}
			Program.db.Close();
			return null;	// No authentication
		}

	}
}
