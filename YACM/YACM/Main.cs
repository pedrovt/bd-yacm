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
	public partial class Main : Form
	{
		public Main(String user) {
			InitializeComponent();

			labelTitle.Text = "Welcome back, " + user;
		}

		private void Panel3_Paint(object sender, PaintEventArgs e) {

		}
	}
}
