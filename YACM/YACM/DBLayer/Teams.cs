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

		#region CRUD methods
		internal static void Create(Team P) {
			// TODO Stored procedure to insert, depending of the type, in the appropriated tables
			/* 
			SqlCommand cmd = new SqlCommand();


			cmd.CommandText = "INSERT YACM.Team (number, name, beginningDate, endDate, visibility, managerID) " + "VALUES (@number, @name, @beginningDate, @endDate, @visibility, @managerID) ";
			cmd.Parameters.Clear();

			cmd.Parameters.AddWithValue("@number", E.Number);
			cmd.Parameters.AddWithValue("@name", E.Name);
			cmd.Parameters.AddWithValue("@beginningDate", E.BeginningDate);
			cmd.Parameters.AddWithValue("@endDate", E.EndDate);
			cmd.Parameters.AddWithValue("@visibility", E.Visibility);
			cmd.Parameters.AddWithValue("@managerID", E.ManagerID);

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

			*/

		}

		internal static Team Read(int id) {
			Debug.Assert(id > -1, "Team Index Invalid. Can't Load Team");

			Team P = new Team();

			// Stored Procedure to based on the id, retrieve either the file or the otherfile
			/* 
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Team WHERE id = @id", Program.db.Open());

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read()) {
				D.Number = Convert.ToInt32(reader["number"].ToString());
				E.Name = reader["name"].ToString();
				E.BeginningDate = Convert.ToDateTime(reader["beginningDate"].ToString());
				E.EndDate = Convert.ToDateTime(reader["endDate"].ToString());
				E.Visibility = Convert.ToBoolean(reader["visibility"].ToString());
				E.ManagerID = Convert.ToInt32(reader["managerID"].ToString());
			}

			Program.db.Close();
			*/
			return P;
		}

		internal static void Update(Team P) {
			int rows = 0;

			/*
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "UPDATE YACM.Team " + "SET number = @number, " + "    name = @name, " + "    beginningDate = @beginningDate, " + "    endDate = @endDate, " + "    visibility = @visibility, " + "    managerID = @managerID " + "WHERE number = @number";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@number", E.Number);
			cmd.Parameters.AddWithValue("@name", E.Name);
			cmd.Parameters.AddWithValue("@beginningDate", E.BeginningDate);
			cmd.Parameters.AddWithValue("@endDate", E.EndDate);
			cmd.Parameters.AddWithValue("@visibility", E.Visibility);
			cmd.Parameters.AddWithValue("@managerID", E.ManagerID);

			cmd.Connection = Program.db.Open();


			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update event in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

				Program.db.Close();
			}
			*/
		}

		internal static void Delete(Team P) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.Team WHERE number=@number ";
			cmd.Parameters.Clear();
			//cmd.Parameters.AddWithValue("@number", D.Id);
			cmd.Connection = Program.db.Open();

			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete event in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}

		#endregion

	}
}