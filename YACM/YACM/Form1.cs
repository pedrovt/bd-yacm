using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YACM
{
	public partial class Form1 : Form
	{
		


		


		private void bttnAdd_Click(object sender, EventArgs e)
		{
			adding = true;
			ClearFields();
			HideButtons();
			listBox1.Enabled = false;
		}

		

		private void bttnEdit_Click(object sender, EventArgs e)
		{
			currentContact = listBox1.SelectedIndex;
			if (currentContact < 0)
			{
				MessageBox.Show("Please select a contact to edit");
				return;
			}
			adding = false;
			HideButtons();
			listBox1.Enabled = false;
		}

		private void bttnOK_Click(object sender, EventArgs e)
		{
			try
			{
				SaveContact();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			listBox1.Enabled = true;
			int idx = listBox1.FindString(txtID.Text);
			listBox1.SelectedIndex = idx;
			ShowButtons();
		}

		private void bttnDelete_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex > -1)
			{
				try
				{
					RemoveContact(((Contact)listBox1.SelectedItem).CustomerID);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
				if (currentContact == listBox1.Items.Count)
					currentContact = listBox1.Items.Count - 1;
				if (currentContact == -1)
				{
					ClearFields();
					MessageBox.Show("There are no more contacts");
				}
				else
				{
					ShowContact();
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

  


	}
}
