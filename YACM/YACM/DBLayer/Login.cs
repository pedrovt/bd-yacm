using System;
using System.Collections.Generic;
using System.Data;
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


			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Clear();

			SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar);
			SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar);
			SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar);

			emailParam.Value = email;
			nameParam.Value = name;
			passwordParam.Value = password;

			cmd.Parameters.Add(emailParam);
			cmd.Parameters.Add(nameParam);
			cmd.Parameters.Add(passwordParam);

			switch (userType) {
				case "Participant":
					cmd.CommandText = "dbo.p_CreateParticipant";
					break;
				case "Sponsor":
					cmd.CommandText = "dbo.p_CreateSponsor";
					break;
				default: //Manager
					cmd.CommandText = "dbo.p_CreateManager";
					break;
			}

			cmd.Connection = Program.db.Open();

			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to create user. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Program.db.Close();
				return;
			}
			finally {
				Program.db.Close();
			}

			MessageBox.Show(userType + " " + name + " created sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
