using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM
{
	/// <summary>
	/// Yet Another Cycling Manager (YACM)
	/// Databases Final Project
	/// Paulo Vasconcelos	<paulobvasconcelos@ua.pt>
	/// Pedro Teixeira	<pedro.teix@ua.pt>
	/// 09-May-2019
	/// </summary>
	public partial class Login : Form
	{

		private String user;

		public Login() {
			InitializeComponent();
		}

		/// <summary>
		/// Handler for Login Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginButton_Click(object sender, EventArgs e) {
			// TODO
			user = "User";
			OpenMainForm();
		}

		/// <summary>
		/// Handler for Signup Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SignupButton_Click(object sender, EventArgs e) {

		}

		private void OpenMainForm() {
			// Run the Main Form
			Main main = new Main(user);
			this.Hide();
			main.ShowDialog();
			this.Close();
		}

		
	}
}
