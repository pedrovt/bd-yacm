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

			// TODO use userType
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

		internal static Tuple<bool, String, String> Read(String email, String password) {
			Debug.Assert(!email.Equals("") && !password.Equals(""), "Invalid email or password");
			
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.[User] WHERE email = @email AND password = @password", Program.db.Open());

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@password", password);

			SqlDataReader reader = cmd.ExecuteReader();

			Boolean canLogin = false;
			String userName = "error";
			String userType = "none";
			while (reader.Read()) {
				userName = Convert.ToString(reader["name"]);
				canLogin = true;
			}

			Program.db.Close();

			return new Tuple<bool, String, String>(canLogin, userName, userType);
		}

	}
}
