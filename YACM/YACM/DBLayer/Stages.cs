using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
	class Stages
	{

		#region CRUD methods
		internal static void Create(Stage S) {
			// TODO Stored procedure to insert, depending of the type, in the appropriated tables

			SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.Stage (date, startLocation, endLocation, eventNumber, distance) VALUES (@date, @startLocation, @endLocation, @eventNumber, @distance)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", S.Date);
            cmd.Parameters.AddWithValue("@startLocation", S.StartLocation);
            cmd.Parameters.AddWithValue("@endLocation", S.EndLocation);
            cmd.Parameters.AddWithValue("@eventNumber", S.EventID);
            cmd.Parameters.AddWithValue("@distance", S.Distance);
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

		internal static Stage Read(DateTime date, String startLocation, String endLocation) {

			Stage S = new Stage();
            
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Stage WHERE date=@date AND startLocation=@startLocation AND endLocation=@endLocation", Program.db.Open());
			cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@startLocation", startLocation);
            cmd.Parameters.AddWithValue("@endLocation", endLocation);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
			    while (reader.Read()) {
				    S.Date = Convert.ToDateTime(reader["date"].ToString());
				    S.StartLocation = reader["startLocation"].ToString();
				    S.EndLocation = reader["endLocation"].ToString();
				    S.EventID = Convert.ToInt32(reader["eventID"].ToString());
				    S.Distance = Convert.ToInt32(reader["distance"].ToString());
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

		internal static void Update(Stage S) {
			int rows = 0;
            
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE YACM.Stage SET eventNumber=@eventNumber, distance=@distance WHERE date=@date AND startLocation=@startLocation AND endLocation=@endLocation";
            cmd.CommandText = "INSERT YACM.Stage (date, startLocation, endLocation, eventNumber, distance) VALUES (@date, @startLocation, @endLocation, @eventNumber, @distance)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", S.Date);
            cmd.Parameters.AddWithValue("@startLocation", S.StartLocation);
            cmd.Parameters.AddWithValue("@endLocation", S.EndLocation);
            cmd.Parameters.AddWithValue("@eventNumber", S.EventID);
            cmd.Parameters.AddWithValue("@distance", S.Distance);
            cmd.Connection = Program.db.Open();
			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update stage in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

				Program.db.Close();
			}
		}

		internal static void Delete(Stage S) {
            SqlCommand cmd = new SqlCommand("DELETE YACM.Stage WHERE date=@date AND startLocation=@startLocation AND endLocation=@endLocation", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@date", S.Date);
            cmd.Parameters.AddWithValue("@startLocation", S.StartLocation);
            cmd.Parameters.AddWithValue("@endLocation", S.EndLocation);

            try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete stage from database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}

		#endregion

	}
}