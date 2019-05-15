using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
	public partial class Main : Form
	{
		public Main(String user) {
			InitializeComponent();

			labelTitle.Text = "Welcome back, " + user;
		}

		private void Main_Load(object sender, EventArgs e) {
			//Program.db.getDBConnection().Open();

			ReadEvents();
		}

		private void ReadEvents() {
			SqlCommand cmd = new SqlCommand("SELECT * FROM YACM.Event", Program.db.getDBConnection());
			SqlDataReader reader = cmd.ExecuteReader();

			// Creating the columns in the List View
			int numFields = reader.FieldCount;
			String field;
			listView1.Columns.Clear();      // clear previous columns, if needed
			for (int i = 0; i < numFields; i++) {
				field = reader.GetName(i);

				listView1.Columns.Add(field);
			}

			// Loading the data
			listView1.Items.Clear();		// clear previous items, if needed
			while (reader.Read()) {
				ListViewItem item = listView1.Items.Add(reader[0].ToString());
				for (int i = 1; i < numFields; i++) {
					item.SubItems.Add(reader[i].ToString().TrimEnd());
				}
			}

			// Adjusting the columns width
			for (int i = 0; i < numFields; i++) {
				listView1.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			}

			Program.db.closeDBConnection();
		}

		int eventIndex = -1;

		private void ListView1_SelectedIndexChanged(object sender, EventArgs e) {
			
			if (listView1.SelectedItems != null) {
				ListViewItem firstSelectedItem = listView1.FocusedItem;
				eventIndex = Convert.ToInt32(firstSelectedItem.SubItems[0].Text.ToString());
				debugInfo.Text = "Selected Event ID is " + eventIndex;
			}
		}

		private void EditEventToolStripMenuItem_Click(object sender, EventArgs e) {
			if (eventIndex >= 0) {
				DialogEvents dialog = new DialogEvents(eventIndex, false);
				dialog.Show();
				ReadEvents();
			}
		}

		private void AddEventToolStripMenuItem_Click(object sender, EventArgs e) {
			DialogEvents dialog = new DialogEvents(eventIndex, true);
			dialog.Show();
			ReadEvents();
		}

		private void UpdateToolStripMenuItem_Click(object sender, EventArgs e) {
			ReadEvents();
		}
	}
}
