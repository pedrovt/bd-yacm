using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace YACM
{
	static class Program
	{

		#region Static Fields
		private static readonly string sqlServer = "THINKPAD-13\\SQLEXPRESS";
		internal  static DatabaseHandler db; 
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Connect to Database
			db = new DatabaseHandler(sqlServer);
			
			// Run Application
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
