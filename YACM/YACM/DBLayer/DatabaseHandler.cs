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
	class DatabaseHandler
	{
		#region Instance Fields
		private SqlConnection cn { get; set; }
		private readonly String SQL_SERVER_INSTANCE_CHOICE; 
		#endregion

		#region CTOR
		public DatabaseHandler(String SQL_SERVER_INSTANCE_CHOICE) {
			this.SQL_SERVER_INSTANCE_CHOICE = SQL_SERVER_INSTANCE_CHOICE;
			cn = GetSQLServerConnection();
			VerifySQLServerConnection();
		}

		#endregion

		#region Methods
		public SqlConnection Open() {
			Debug.Assert(cn != null && cn.State == ConnectionState.Closed, "Database connection must be closed to be opened");
			cn.Open();
			return cn;
		}

		public void Close() {
			Debug.Assert(cn != null && cn.State == ConnectionState.Open, "Database connection must be opened to be closed");
			cn.Close();
		}

		#endregion

		#region Auxiliar Methods
		private SqlConnection GetSQLServerConnection() {
			Debug.Assert(SQL_SERVER_INSTANCE_CHOICE != null);

			// IF NEEDED CHANGE HERE
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder() {
				DataSource = "MY SERVER",
				InitialCatalog = "YACM",
				UserID = "MY USERNAME",
				Password = "MY PASSWORD"
			};

			switch (SQL_SERVER_INSTANCE_CHOICE) {
				case "Class Server":
					builder = new SqlConnectionStringBuilder() {
						DataSource = "tcp:mednat.ieeta.pt\\SQLSERVER,8101",
						InitialCatalog = "YACM",
						UserID = "p2g10",
						Password = "UbuntuAndMacSucks24/7"
					};
					break;
				case "Pedro's Server":
					builder = new SqlConnectionStringBuilder() {
						DataSource = "THINKPAD-13\\SQLEXPRESS",
						InitialCatalog = "YACM",
						IntegratedSecurity = true
					};
					break;
					
				case "Paulo's Server":
					builder = new SqlConnectionStringBuilder() {
						DataSource = "DESKTOP-GQQU4N5",			
						InitialCatalog = "YACM",
						IntegratedSecurity = true
					};
					break;
				case "Other":
					// Ignore
					break;
			}
			

			return new SqlConnection(builder.ConnectionString);
		}

		private void VerifySQLServerConnection() {
			if (cn == null)
				cn = GetSQLServerConnection();

			if (cn.State != ConnectionState.Open) {
				try {
					cn.Open();
					cn.Close();
				}
				catch (Exception e) {
					MessageBox.Show("Error connecting to Database: " + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Console.WriteLine("Error connecting to Database: " + e);
					Application.Exit();		//Critical error
				}
			}
		}

		#endregion



	}
}
