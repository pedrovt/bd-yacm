using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace YACM
{
	class DatabaseHandler
	{
		#region Instance Fields
		private SqlConnection cn { get; set; }
		private readonly String sqlServer; 
		#endregion

		#region CTOR
		public DatabaseHandler(String sqlServer) {
			this.sqlServer = sqlServer;
			cn = GetSGBDConnection();
			VerifySGBDConnection();
		}

		#endregion

		#region Getters
		public SqlConnection Connection() {
			if (!VerifySGBDConnection())
				//throw Exception;
				return null;
			return cn;
		}

		#endregion
		#region Private Methods
		private SqlConnection GetSGBDConnection() {
			Debug.Assert(sqlServer != null);
			return new SqlConnection("data source="+sqlServer+";integrated security=true;initial catalog=YACM");
		}

		private bool VerifySGBDConnection() {
			if (cn == null)
				cn = GetSGBDConnection();

			if (cn.State != ConnectionState.Open)
				cn.Open();

			return cn.State == ConnectionState.Open;
		}

		#endregion



	}
}
