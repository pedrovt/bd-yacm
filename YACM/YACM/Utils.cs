﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YACM
{
	class Utils
	{

		/// <summary>
		/// Deprecated
		/// </summary>
		/// <param name="query"></param>
		/// <param name="list"></param>
		public static void ReadToListView (String query, ListView list) {
			SqlCommand cmd = new SqlCommand(query, Program.db.Open());
			SqlDataReader reader = cmd.ExecuteReader();


			// Creating the columns in the List View
			int numFields = reader.FieldCount;
			String field;
			list.Columns.Clear();      // clear previous columns, if needed
			for (int i = 0; i < numFields; i++) {
				field = reader.GetName(i);

				list.Columns.Add(field);
			}

			// Loading the data
			list.Items.Clear();        // clear previous items, if needed
			while (reader.Read()) {
				ListViewItem item = list.Items.Add(reader[0].ToString());
				for (int i = 1; i < numFields; i++) {
					item.SubItems.Add(reader[i].ToString().TrimEnd());
				}
			}

			reader.Close();

			// Adjusting the columns width
			for (int i = 0; i < numFields; i++) {
				list.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
			}

			Program.db.Close();
		}

		public static void ReadToListView(SqlCommand cmd, ListView list) {
			try {
				SqlDataReader reader = cmd.ExecuteReader();

				// Creating the columns in the List View
				int numFields = reader.FieldCount;
				String field;
				list.Columns.Clear();      // clear previous columns, if needed
				for (int i = 0; i < numFields; i++) {
					field = reader.GetName(i);

					list.Columns.Add(field);
				}

				// Loading the data
				list.Items.Clear();        // clear previous items, if needed
				while (reader.Read()) {
					ListViewItem item = list.Items.Add(reader[0].ToString());
					for (int i = 1; i < numFields; i++) {
						item.SubItems.Add(reader[i].ToString().TrimEnd());
					}
					Console.WriteLine("Adding " + reader[0].ToString());

				}

				reader.Close();

				// Adjusting the columns width
				for (int i = 0; i < numFields; i++) {
					list.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
				}
			}
			catch (Exception ex) {
				MessageBox.Show("Failed to read from database. \n Error message: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static void HideColumn (int index, ListView list) {
			int totalItems = list.Items.Count;
			for (int i = 0; i < totalItems; i++) {
				// Column B is at index 1
				list.Items[i].SubItems[index].Text = string.Empty;
			}

			list.Columns.RemoveAt(index);
		}
	}
}
