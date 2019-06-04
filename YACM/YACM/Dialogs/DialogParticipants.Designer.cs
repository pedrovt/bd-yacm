namespace YACM
{
	partial class DialogParticipants
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogParticipants));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.panelInfo = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.NumericUpDown();
			this.txtParticipantID = new System.Windows.Forms.TextBox();
			this.txtTeamName = new System.Windows.Forms.TextBox();
			this.txtDorsal = new System.Windows.Forms.TextBox();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.bttnEdit = new System.Windows.Forms.Button();
			this.bttnCancel = new System.Windows.Forms.Button();
			this.bttnDelete = new System.Windows.Forms.Button();
			this.bttnOK = new System.Windows.Forms.Button();
			this.type = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.start = new System.Windows.Forms.DateTimePicker();
			this.end = new System.Windows.Forms.DateTimePicker();
			this.tableLayoutPanel.SuspendLayout();
			this.panelInfo.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
			this.panelButtons.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.panelInfo, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.panelButtons, 0, 2);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.12329F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.87671F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(685, 336);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(679, 49);
			this.labelTitle.TabIndex = 212;
			this.labelTitle.Text = "Participant Entry";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelInfo
			// 
			this.panelInfo.Controls.Add(this.tableLayoutPanel2);
			this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelInfo.Location = new System.Drawing.Point(3, 52);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new System.Drawing.Size(679, 231);
			this.panelInfo.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.61933F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.38067F));
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.Label11, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.Label1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.Label2, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.txtID, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.txtParticipantID, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.txtDorsal, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.txtTeamName, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.type, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 5);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(683, 243);
			this.tableLayoutPanel2.TabIndex = 218;
			// 
			// Label11
			// 
			this.Label11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label11.Location = new System.Drawing.Point(3, 1);
			this.Label11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(128, 22);
			this.Label11.TabIndex = 208;
			this.Label11.Text = "ID";
			// 
			// Label1
			// 
			this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label1.Location = new System.Drawing.Point(3, 27);
			this.Label1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(128, 24);
			this.Label1.TabIndex = 195;
			this.Label1.Text = "Participant ID";
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label8.Location = new System.Drawing.Point(3, 84);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 46);
			this.label8.TabIndex = 210;
			this.label8.Text = "Team Name (On Team, Enrollment Only)";
			// 
			// Label2
			// 
			this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label2.Location = new System.Drawing.Point(3, 57);
			this.Label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(128, 23);
			this.Label2.TabIndex = 197;
			this.Label2.Text = "Type";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(137, 3);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(161, 20);
			this.txtID.TabIndex = 217;
			// 
			// txtParticipantID
			// 
			this.txtParticipantID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtParticipantID.Location = new System.Drawing.Point(137, 29);
			this.txtParticipantID.Name = "txtParticipantID";
			this.txtParticipantID.ReadOnly = true;
			this.txtParticipantID.Size = new System.Drawing.Size(370, 22);
			this.txtParticipantID.TabIndex = 196;
			// 
			// txtTeamName
			// 
			this.txtTeamName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtTeamName.Location = new System.Drawing.Point(137, 82);
			this.txtTeamName.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtTeamName.Name = "txtTeamName";
			this.txtTeamName.ReadOnly = true;
			this.txtTeamName.Size = new System.Drawing.Size(370, 22);
			this.txtTeamName.TabIndex = 215;
			// 
			// txtDorsal
			// 
			this.txtDorsal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtDorsal.Location = new System.Drawing.Point(137, 132);
			this.txtDorsal.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtDorsal.Name = "txtDorsal";
			this.txtDorsal.PasswordChar = '*';
			this.txtDorsal.ReadOnly = true;
			this.txtDorsal.Size = new System.Drawing.Size(370, 22);
			this.txtDorsal.TabIndex = 202;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.tableLayoutPanel1);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelButtons.Location = new System.Drawing.Point(3, 289);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(679, 44);
			this.panelButtons.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.bttnEdit, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.bttnCancel, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.bttnDelete, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.bttnOK, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(679, 44);
			this.tableLayoutPanel1.TabIndex = 213;
			// 
			// bttnEdit
			// 
			this.bttnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnEdit.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnEdit.Location = new System.Drawing.Point(172, 3);
			this.bttnEdit.Name = "bttnEdit";
			this.bttnEdit.Size = new System.Drawing.Size(163, 32);
			this.bttnEdit.TabIndex = 209;
			this.bttnEdit.Text = "Edit";
			this.bttnEdit.Click += new System.EventHandler(this.BttnEdit_Click);
			// 
			// bttnCancel
			// 
			this.bttnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnCancel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnCancel.Location = new System.Drawing.Point(510, 3);
			this.bttnCancel.Name = "bttnCancel";
			this.bttnCancel.Size = new System.Drawing.Size(166, 32);
			this.bttnCancel.TabIndex = 210;
			this.bttnCancel.Text = "Cancel";
			this.bttnCancel.Visible = false;
			this.bttnCancel.Click += new System.EventHandler(this.BttnCancel_Click);
			// 
			// bttnDelete
			// 
			this.bttnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnDelete.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnDelete.Location = new System.Drawing.Point(341, 3);
			this.bttnDelete.Name = "bttnDelete";
			this.bttnDelete.Size = new System.Drawing.Size(163, 32);
			this.bttnDelete.TabIndex = 212;
			this.bttnDelete.Text = "Delete";
			this.bttnDelete.Click += new System.EventHandler(this.BttnDelete_Click);
			// 
			// bttnOK
			// 
			this.bttnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnOK.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnOK.Location = new System.Drawing.Point(3, 3);
			this.bttnOK.Name = "bttnOK";
			this.bttnOK.Size = new System.Drawing.Size(163, 32);
			this.bttnOK.TabIndex = 211;
			this.bttnOK.Text = "OK";
			this.bttnOK.Visible = false;
			this.bttnOK.Click += new System.EventHandler(this.BttnOK_Click);
			// 
			// type
			// 
			this.type.FormattingEnabled = true;
			this.type.Items.AddRange(new object[] {
            "Drop Out",
            "Enrollment",
            "On Team"});
			this.type.Location = new System.Drawing.Point(137, 57);
			this.type.Name = "type";
			this.type.Size = new System.Drawing.Size(370, 21);
			this.type.TabIndex = 218;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label3.Location = new System.Drawing.Point(3, 134);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 46);
			this.label3.TabIndex = 219;
			this.label3.Text = "Dorsal (Enrollment Only)";
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label4.Location = new System.Drawing.Point(3, 184);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 58);
			this.label4.TabIndex = 220;
			this.label4.Text = "Start-End (On Team Only)";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.46225F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.53775F));
			this.tableLayoutPanel3.Controls.Add(this.start, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.end, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(137, 184);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(543, 56);
			this.tableLayoutPanel3.TabIndex = 221;
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(3, 3);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(200, 20);
			this.start.TabIndex = 0;
			// 
			// end
			// 
			this.end.Location = new System.Drawing.Point(238, 3);
			this.end.Name = "end";
			this.end.Size = new System.Drawing.Size(200, 20);
			this.end.TabIndex = 1;
			// 
			// DialogParticipants
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(685, 336);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DialogParticipants";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Entry";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.panelInfo.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
			this.panelButtons.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Panel panelInfo;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtDorsal;
		internal System.Windows.Forms.TextBox txtParticipantID;
		private System.Windows.Forms.Panel panelButtons;
		internal System.Windows.Forms.Button bttnOK;
		internal System.Windows.Forms.Button bttnEdit;
		internal System.Windows.Forms.Button bttnCancel;
		private System.Windows.Forms.Button bttnDelete;
		internal System.Windows.Forms.TextBox txtTeamName;
		private System.Windows.Forms.NumericUpDown txtID;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox type;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.DateTimePicker start;
		private System.Windows.Forms.DateTimePicker end;
	}
}