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

	
		public Login() {
			InitializeComponent();

			// Default values
			email.Text = "user@ua.pt";
			password.Text = "user";
			userType.SelectedIndex = 0;
			instance.SelectedIndex = 1;

		}

		/// <summary>
		/// Handler for Login Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginButton_Click(object sender, EventArgs e) {
			if (userType.SelectedIndex == -1 || instance.SelectedIndex == -1 || email.Text == "" || password.Text == "") {
				MessageBox.Show("Please fill out all the information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			
			// Connect to Database
			Console.WriteLine("Chosen Database: " + instance.Text);
			Program.db = new DatabaseHandler(instance.Text);

			login();
		}

		/// <summary>
		/// Handler for Signup Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SignupButton_Click(object sender, EventArgs e) {
			if (userType.SelectedIndex == -1 || instance.SelectedIndex == -1 || email.Text == "" || password.Text == "") {
				MessageBox.Show("Please fill out all the information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Connect to Database
			Console.WriteLine("Chosen Database: " + instance.Text);
			Program.db = new DatabaseHandler(instance.Text);

			// Login
			DBLayer.Login.Create(email.Text, name.Text, password.Text, userType.Text);
			login();
		}

		private void OpenMainForm(int id, String username, String privileges) {
			// Run the Main Form
			Main main = new Main(id, username);
			this.Hide();
			main.ShowDialog();
			this.Close();
			
		}

		private void login() {
			// Login
			Tuple<int, bool, String, String> loginInfo = DBLayer.Login.Read(email.Text, password.Text);
			if (!loginInfo.Item2) {
				MessageBox.Show("Login Error. Please verify your credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			OpenMainForm(loginInfo.Item1, loginInfo.Item3, loginInfo.Item4);
		}
		
	}
}
