using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM
{
    /// <summary>
    /// Yet Another Cycling Manager (YACM)
    /// Databases Final Project
    /// Paulo Vasconcelos	paulobvasconcelos@ua.pt
    /// Pedro Teixeira		pedro.teix@ua.pt
    /// 09-May-2019
    /// </summary>
    class EventHandler
    {
        internal static void GetManagerEvents(String managerEmail)
        {

            // TODO Verify if exists
            SqlCommand cmd = new SqlCommand();

            // NECESSÁRIO CORRIGIR PARA EVITAR SQL INJECTION
            cmd.CommandText = "EXEC dbo.p_GetManagerEvents @managerEmail="+managerEmail+";";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@email", managerEmail);

            // TODO use userType
            cmd.Connection = Program.db.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }

        }


        internal static void GetOtherEvents(String managerEmail)
        {

            // TODO Verify if exists
            SqlCommand cmd = new SqlCommand();

            // NECESSÁRIO CORRIGIR PARA EVITAR SQL INJECTION
            cmd.CommandText = "EXEC dbo.p_GetOtherEvents @managerEmail=" + managerEmail + ";";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@email", managerEmail);

            // TODO use userType
            cmd.Connection = Program.db.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }

        }


        internal static void GetOtherVisibleEvents(String managerEmail)
        {

            // TODO Verify if exists
            SqlCommand cmd = new SqlCommand();

            // NECESSÁRIO CORRIGIR PARA EVITAR SQL INJECTION
            cmd.CommandText = "EXEC dbo.p_GetOtherVisibleEvents @managerEmail=" + managerEmail + ";";
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@email", managerEmail);

            // TODO use userType
            cmd.Connection = Program.db.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update in database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.db.Close();
            }

        }
    }
}
