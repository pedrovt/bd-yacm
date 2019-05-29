using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	class Events
	{

		#region CRUD methods
		internal static void Create(Event E) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "INSERT YACM.Event (number, name, beginningDate, endDate, visibility, managerID) " + "VALUES (@number, @name, @beginningDate, @endDate, @visibility, @managerID) ";
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

		}

		internal static Event Read(int eventNumber) {
			Debug.Assert(eventNumber > -1, "Event Index Invalid. Can't Load Event");

			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Event WHERE number = @eventIndex", Program.db.Open());

			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@eventIndex", eventNumber);

			SqlDataReader reader = cmd.ExecuteReader();

			Event E = new Event();
			while (reader.Read()) {
				E.Number = Convert.ToInt32(reader["number"].ToString());
				E.Name = reader["name"].ToString();
				E.BeginningDate = Convert.ToDateTime(reader["beginningDate"].ToString());
				E.EndDate = Convert.ToDateTime(reader["endDate"].ToString());
				E.Visibility = Convert.ToBoolean(reader["visibility"].ToString());
				E.ManagerID = Convert.ToInt32(reader["managerID"].ToString());
			}

			Program.db.Close();

			return E;
		}

		internal static void Update(Event E) {
			int rows = 0;


			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "UPDATE YACM.Event " + "SET number = @number, " + "    name = @name, " + "    beginningDate = @beginningDate, " + "    endDate = @endDate, " + "    visibility = @visibility, " + "    managerID = @managerID " + "WHERE number = @number";
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
		}

		internal static void Delete(Event E) {
			SqlCommand cmd = new SqlCommand();

			cmd.CommandText = "DELETE YACM.Event WHERE number=@number ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@number", E.Number);
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

		#region Statistics
		#endregion
	}
}
