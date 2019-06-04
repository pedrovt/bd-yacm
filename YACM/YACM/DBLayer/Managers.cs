using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM.DBLayer
{
    class Managers
    {

        #region CRUD methods
        internal static void Create(Manager M)
        {
            // TODO Stored procedure to insert, depending of the type, in the appropriated tables

            // Insertion into User Table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.User (id, email, name, password) VALUES (@id, @email, @name, @password)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", M.ID);
            cmd.Parameters.AddWithValue("@email", M.Email);
            cmd.Parameters.AddWithValue("@name", M.Name);
            cmd.Parameters.AddWithValue("@password", M.Password);
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

            // Insertion into Sponsor Table
            cmd = new SqlCommand();
            cmd.CommandText = "INSERT YACM.Manager (id) VALUES (@id)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", M.ID);
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

        internal static Manager Read(int id)
        {
            Debug.Assert(id > -1, "Prize Index Invalid. Can't Load Prize");

            Manager M = new Manager();

            SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.User WHERE id = @id", Program.db.Open());
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M.ID = Convert.ToInt32(reader["id"].ToString());
                    M.Email = reader["email"].ToString();
                    M.Name = reader["name"].ToString();
                    M.Password = reader["password"].ToString();
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
            return M;
        }

        internal static void Update(Manager M)
        {
            int rows = 0;

            // Update User Table
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE YACM.User SET email=@email, name=@name, password=@password WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", M.ID);
            cmd.Parameters.AddWithValue("@email", M.Email);
            cmd.Parameters.AddWithValue("@name", M.Name);
            cmd.Parameters.AddWithValue("@password", M.Password);
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

        internal static void Delete(Manager M)
        {
            SqlCommand cmd = new SqlCommand();

            // Deletion is performed only on Table User
            // Triggers will do the rest
            cmd.CommandText = "DELETE YACM.User WHERE id=@id ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", M.ID);
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

    }
}