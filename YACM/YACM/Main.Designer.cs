namespace YACM
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageManager = new System.Windows.Forms.TabPage();
			this.tabPageParticipant = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.debugInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.copyrightInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabPageSponsor = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.bttnOK = new System.Windows.Forms.Button();
			this.bttnEdit = new System.Windows.Forms.Button();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.bttnCancel = new System.Windows.Forms.Button();
			this.bttnAdd = new System.Windows.Forms.Button();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtAddress1 = new System.Windows.Forms.TextBox();
			this.txtContact = new System.Windows.Forms.TextBox();
			this.txtCompany = new System.Windows.Forms.TextBox();
			this.bttnDelete = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPageManager.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageManager);
			this.tabControl1.Controls.Add(this.tabPageParticipant);
			this.tabControl1.Controls.Add(this.tabPageSponsor);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 59);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1056, 518);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageManager
			// 
			this.tabPageManager.Controls.Add(this.splitContainer1);
			this.tabPageManager.Location = new System.Drawing.Point(4, 22);
			this.tabPageManager.Name = "tabPageManager";
			this.tabPageManager.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageManager.Size = new System.Drawing.Size(1048, 492);
			this.tabPageManager.TabIndex = 0;
			this.tabPageManager.Text = "Events I\'m Managing";
			this.tabPageManager.UseVisualStyleBackColor = true;
			// 
			// tabPageParticipant
			// 
			this.tabPageParticipant.Location = new System.Drawing.Point(4, 22);
			this.tabPageParticipant.Name = "tabPageParticipant";
			this.tabPageParticipant.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageParticipant.Size = new System.Drawing.Size(1048, 492);
			this.tabPageParticipant.TabIndex = 1;
			this.tabPageParticipant.Text = "Events I\'m Participating";
			this.tabPageParticipant.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugInfo,
            this.copyrightInfo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 580);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1062, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// debugInfo
			// 
			this.debugInfo.Name = "debugInfo";
			this.debugInfo.Size = new System.Drawing.Size(39, 17);
			this.debugInfo.Text = "Ready";
			// 
			// copyrightInfo
			// 
			this.copyrightInfo.Name = "copyrightInfo";
			this.copyrightInfo.Size = new System.Drawing.Size(1008, 17);
			this.copyrightInfo.Spring = true;
			this.copyrightInfo.Text = "© Paulo, Pedro 2019";
			this.copyrightInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(1056, 39);
			this.labelTitle.TabIndex = 4;
			this.labelTitle.Text = "Welcome back, ";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.827586F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.17242F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1062, 580);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// tabPageSponsor
			// 
			this.tabPageSponsor.Location = new System.Drawing.Point(4, 22);
			this.tabPageSponsor.Name = "tabPageSponsor";
			this.tabPageSponsor.Size = new System.Drawing.Size(1048, 492);
			this.tabPageSponsor.TabIndex = 2;
			this.tabPageSponsor.Text = "Events I\'m Sponsoring";
			this.tabPageSponsor.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Size = new System.Drawing.Size(1042, 486);
			this.splitContainer1.SplitterDistance = 342;
			this.splitContainer1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(342, 486);
			this.panel2.TabIndex = 0;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(342, 486);
			this.listBox1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.textBox1);
			this.panel3.Controls.Add(this.txtID);
			this.panel3.Controls.Add(this.Label11);
			this.panel3.Controls.Add(this.bttnOK);
			this.panel3.Controls.Add(this.bttnEdit);
			this.panel3.Controls.Add(this.Label5);
			this.panel3.Controls.Add(this.Label3);
			this.panel3.Controls.Add(this.Label2);
			this.panel3.Controls.Add(this.Label1);
			this.panel3.Controls.Add(this.bttnCancel);
			this.panel3.Controls.Add(this.bttnAdd);
			this.panel3.Controls.Add(this.txtCity);
			this.panel3.Controls.Add(this.txtAddress1);
			this.panel3.Controls.Add(this.txtContact);
			this.panel3.Controls.Add(this.txtCompany);
			this.panel3.Controls.Add(this.bttnDelete);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(696, 486);
			this.panel3.TabIndex = 0;
			this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label8.Location = new System.Drawing.Point(357, 178);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 158;
			this.label8.Text = "&End Date";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.textBox1.Location = new System.Drawing.Point(359, 196);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(161, 22);
			this.textBox1.TabIndex = 159;
			// 
			// txtID
			// 
			this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtID.Location = new System.Drawing.Point(178, 150);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(69, 22);
			this.txtID.TabIndex = 157;
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label11.Location = new System.Drawing.Point(175, 128);
			this.Label11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(72, 16);
			this.Label11.TabIndex = 156;
			this.Label11.Text = "ID";
			// 
			// bttnOK
			// 
			this.bttnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnOK.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnOK.Location = new System.Drawing.Point(377, 327);
			this.bttnOK.Name = "bttnOK";
			this.bttnOK.Size = new System.Drawing.Size(96, 32);
			this.bttnOK.TabIndex = 154;
			this.bttnOK.Text = "OK";
			this.bttnOK.Visible = false;
			// 
			// bttnEdit
			// 
			this.bttnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnEdit.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnEdit.Location = new System.Drawing.Point(301, 327);
			this.bttnEdit.Name = "bttnEdit";
			this.bttnEdit.Size = new System.Drawing.Size(96, 32);
			this.bttnEdit.TabIndex = 152;
			this.bttnEdit.Text = "Edit";
			// 
			// Label5
			// 
			this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label5.Location = new System.Drawing.Point(175, 268);
			this.Label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(72, 16);
			this.Label5.TabIndex = 149;
			this.Label5.Text = "Budget";
			// 
			// Label3
			// 
			this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label3.Location = new System.Drawing.Point(175, 223);
			this.Label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(72, 16);
			this.Label3.TabIndex = 147;
			this.Label3.Text = "&Visibility";
			// 
			// Label2
			// 
			this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label2.Location = new System.Drawing.Point(175, 178);
			this.Label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(104, 16);
			this.Label2.TabIndex = 145;
			this.Label2.Text = "&Begin Date";
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label1.Location = new System.Drawing.Point(253, 128);
			this.Label1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(72, 16);
			this.Label1.TabIndex = 143;
			this.Label1.Text = "&Name";
			// 
			// bttnCancel
			// 
			this.bttnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnCancel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnCancel.Location = new System.Drawing.Point(219, 327);
			this.bttnCancel.Name = "bttnCancel";
			this.bttnCancel.Size = new System.Drawing.Size(96, 32);
			this.bttnCancel.TabIndex = 153;
			this.bttnCancel.Text = "Cancel";
			this.bttnCancel.Visible = false;
			// 
			// bttnAdd
			// 
			this.bttnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnAdd.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnAdd.Location = new System.Drawing.Point(177, 327);
			this.bttnAdd.Name = "bttnAdd";
			this.bttnAdd.Size = new System.Drawing.Size(96, 32);
			this.bttnAdd.TabIndex = 151;
			this.bttnAdd.Text = "Add";
			// 
			// txtCity
			// 
			this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCity.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtCity.Location = new System.Drawing.Point(177, 286);
			this.txtCity.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtCity.Name = "txtCity";
			this.txtCity.ReadOnly = true;
			this.txtCity.Size = new System.Drawing.Size(146, 22);
			this.txtCity.TabIndex = 150;
			// 
			// txtAddress1
			// 
			this.txtAddress1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddress1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtAddress1.Location = new System.Drawing.Point(177, 241);
			this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtAddress1.Name = "txtAddress1";
			this.txtAddress1.ReadOnly = true;
			this.txtAddress1.Size = new System.Drawing.Size(344, 22);
			this.txtAddress1.TabIndex = 148;
			// 
			// txtContact
			// 
			this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtContact.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtContact.Location = new System.Drawing.Point(177, 196);
			this.txtContact.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtContact.Name = "txtContact";
			this.txtContact.ReadOnly = true;
			this.txtContact.Size = new System.Drawing.Size(161, 22);
			this.txtContact.TabIndex = 146;
			// 
			// txtCompany
			// 
			this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCompany.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtCompany.Location = new System.Drawing.Point(253, 150);
			this.txtCompany.Name = "txtCompany";
			this.txtCompany.ReadOnly = true;
			this.txtCompany.Size = new System.Drawing.Size(268, 22);
			this.txtCompany.TabIndex = 144;
			// 
			// bttnDelete
			// 
			this.bttnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bttnDelete.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnDelete.Location = new System.Drawing.Point(419, 327);
			this.bttnDelete.Name = "bttnDelete";
			this.bttnDelete.Size = new System.Drawing.Size(96, 32);
			this.bttnDelete.TabIndex = 155;
			this.bttnDelete.Text = "Delete";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1062, 602);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "Main";
			this.tabControl1.ResumeLayout(false);
			this.tabPageManager.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageManager;
		private System.Windows.Forms.TabPage tabPageParticipant;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel debugInfo;
		private System.Windows.Forms.ToolStripStatusLabel copyrightInfo;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabPage tabPageSponsor;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.TextBox textBox1;
		internal System.Windows.Forms.TextBox txtID;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Button bttnOK;
		internal System.Windows.Forms.Button bttnEdit;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button bttnCancel;
		internal System.Windows.Forms.Button bttnAdd;
		internal System.Windows.Forms.TextBox txtCity;
		internal System.Windows.Forms.TextBox txtAddress1;
		internal System.Windows.Forms.TextBox txtContact;
		internal System.Windows.Forms.TextBox txtCompany;
		private System.Windows.Forms.Button bttnDelete;
	}
}