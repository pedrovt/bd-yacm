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
	class Documents
	{

        #region CRUD methods
        internal static void Create(Document D)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@eventID", D.EventID);
            if (D.Type==DocumentType.Other)
            {
                cmd.CommandText = "dbo.p_CreateTextFile";
                cmd.Parameters.AddWithValue("@content", D.Contents);
            }
            else
            {
                cmd.CommandText = "dbo.p_CreateOtherFile";
                cmd.Parameters.AddWithValue("@path", D.Path);
            }
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

        internal static Document Read(int id, DocumentType type) {
			Debug.Assert(id > -1, "Document Index Invalid. Can't Load Document");

			Document D = new Document();
			
			// Stored Procedure to based on the id, retrieve either the file or the otherfile
			
            // Retrieve data from Document Table
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Document WHERE id = @id", Program.db.Open());
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    D.ID = Convert.ToInt32(reader["id"].ToString());
                    D.EventID = Convert.ToInt32(reader["eventNumber"].ToString());
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

            // Retrieve data from both TextFile or OtherFile table
            // (only one will hit)
            // TextFile (content retrieval)
            cmd = new SqlCommand("SELECT * FROM YACM.TextFile WHERE id = @id", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    D.Contents = reader["content"].ToString();
                    D.Type = DocumentType.Text;
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
            // OtherFile (path retrieval)
            cmd = new SqlCommand("SELECT * FROM YACM.OtherFile WHERE id = @id", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    D.Contents = reader["path"].ToString();
                    D.Type = DocumentType.Other;
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

            return D;
		}

		internal static void Update(Document D) {
			int rows = 0;

            // Update Document table
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "UPDATE YACM.Document SET eventNumber = @eventNumber WHERE id = @id";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", D.ID);
			cmd.Parameters.AddWithValue("@eventNumber", D.EventID);
			cmd.Connection = Program.db.Open();
			try {
				rows = cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to update document in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				if (rows == 1)
					MessageBox.Show("Updated sucessfully");
				else
					MessageBox.Show("Update not sucesfull");

				Program.db.Close();
			}
            if (D.Type==DocumentType.Text)
            {
                // Update TextFile table
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE YACM.TextFile SET content = @content WHERE id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", D.ID);
                cmd.Parameters.AddWithValue("@content", D.Contents);
                cmd.Connection = Program.db.Open();
                try
                {
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update document in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                // Update OtherFile table
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE YACM.OtherFile SET path = @path WHERE id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", D.ID);
                cmd.Parameters.AddWithValue("@path", D.Path);
                cmd.Connection = Program.db.Open();
                try
                {
                    rows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update document in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

		internal static void Delete(Document D) {
			SqlCommand cmd = new SqlCommand();

            // Will only delete from Document Table
            // Deletion occurs in either TextFile or OtherFile Table via Trigger
			cmd.CommandText = "DELETE YACM.Document WHERE id=@id ";
			cmd.Parameters.Clear();
			cmd.Parameters.AddWithValue("@id", D.ID);
			cmd.Connection = Program.db.Open();
			try {
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to delete document in database. \n Error Message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				Program.db.Close();
			}
		}

		#endregion

	}
}
