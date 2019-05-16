namespace YACM
{
	partial class DialogEvents
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogEvents));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.panelInfo = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtBudget = new System.Windows.Forms.TextBox();
			this.txtManager = new System.Windows.Forms.TextBox();
			this.txtBeginDate = new System.Windows.Forms.DateTimePicker();
			this.txtVisibility = new System.Windows.Forms.CheckBox();
			this.txtEndDate = new System.Windows.Forms.DateTimePicker();
			this.txtName = new System.Windows.Forms.TextBox();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.bttnDelete = new System.Windows.Forms.Button();
			this.bttnOK = new System.Windows.Forms.Button();
			this.bttnEdit = new System.Windows.Forms.Button();
			this.bttnCancel = new System.Windows.Forms.Button();
			this.txtID = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel.SuspendLayout();
			this.panelInfo.SuspendLayout();
			this.panelButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.panelInfo, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.panelButtons, 0, 2);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.8265F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.1735F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(690, 342);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(684, 39);
			this.labelTitle.TabIndex = 212;
			this.labelTitle.Text = "Event Details";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelInfo
			// 
			this.panelInfo.Controls.Add(this.label4);
			this.panelInfo.Controls.Add(this.label8);
			this.panelInfo.Controls.Add(this.Label11);
			this.panelInfo.Controls.Add(this.Label5);
			this.panelInfo.Controls.Add(this.Label3);
			this.panelInfo.Controls.Add(this.Label2);
			this.panelInfo.Controls.Add(this.Label1);
			this.panelInfo.Controls.Add(this.txtID);
			this.panelInfo.Controls.Add(this.txtBudget);
			this.panelInfo.Controls.Add(this.txtManager);
			this.panelInfo.Controls.Add(this.txtBeginDate);
			this.panelInfo.Controls.Add(this.txtVisibility);
			this.panelInfo.Controls.Add(this.txtEndDate);
			this.panelInfo.Controls.Add(this.txtName);
			this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelInfo.Location = new System.Drawing.Point(3, 46);
			this.panelInfo.Name = "panelInfo";
			this.panelInfo.Size = new System.Drawing.Size(684, 243);
			this.panelInfo.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label4.Location = new System.Drawing.Point(169, 118);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 214;
			this.label4.Text = "Manager";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label8.Location = new System.Drawing.Point(351, 72);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 16);
			this.label8.TabIndex = 210;
			this.label8.Text = "&End Date";
			// 
			// Label11
			// 
			this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label11.Location = new System.Drawing.Point(169, 22);
			this.Label11.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(72, 16);
			this.Label11.TabIndex = 208;
			this.Label11.Text = "ID";
			// 
			// Label5
			// 
			this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label5.Location = new System.Drawing.Point(169, 164);
			this.Label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(72, 16);
			this.Label5.TabIndex = 201;
			this.Label5.Text = "Budget";
			// 
			// Label3
			// 
			this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label3.Location = new System.Drawing.Point(351, 118);
			this.Label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(72, 16);
			this.Label3.TabIndex = 199;
			this.Label3.Text = "&Visibility";
			// 
			// Label2
			// 
			this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label2.Location = new System.Drawing.Point(169, 72);
			this.Label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(104, 16);
			this.Label2.TabIndex = 197;
			this.Label2.Text = "&Begin Date";
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label1.Location = new System.Drawing.Point(279, 22);
			this.Label1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(72, 16);
			this.Label1.TabIndex = 195;
			this.Label1.Text = "&Name";
			// 
			// txtBudget
			// 
			this.txtBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBudget.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtBudget.Location = new System.Drawing.Point(171, 180);
			this.txtBudget.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtBudget.Name = "txtBudget";
			this.txtBudget.ReadOnly = true;
			this.txtBudget.Size = new System.Drawing.Size(161, 22);
			this.txtBudget.TabIndex = 202;
			// 
			// txtManager
			// 
			this.txtManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtManager.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtManager.Location = new System.Drawing.Point(171, 136);
			this.txtManager.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtManager.Name = "txtManager";
			this.txtManager.ReadOnly = true;
			this.txtManager.Size = new System.Drawing.Size(161, 22);
			this.txtManager.TabIndex = 215;
			// 
			// txtBeginDate
			// 
			this.txtBeginDate.Location = new System.Drawing.Point(171, 92);
			this.txtBeginDate.Name = "txtBeginDate";
			this.txtBeginDate.Size = new System.Drawing.Size(161, 20);
			this.txtBeginDate.TabIndex = 212;
			// 
			// txtVisibility
			// 
			this.txtVisibility.AutoSize = true;
			this.txtVisibility.Location = new System.Drawing.Point(354, 139);
			this.txtVisibility.Name = "txtVisibility";
			this.txtVisibility.Size = new System.Drawing.Size(55, 17);
			this.txtVisibility.TabIndex = 216;
			this.txtVisibility.Text = "Public";
			this.txtVisibility.UseVisualStyleBackColor = true;
			// 
			// txtEndDate
			// 
			this.txtEndDate.Location = new System.Drawing.Point(354, 92);
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(161, 20);
			this.txtEndDate.TabIndex = 213;
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtName.Location = new System.Drawing.Point(281, 44);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(234, 22);
			this.txtName.TabIndex = 196;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.bttnDelete);
			this.panelButtons.Controls.Add(this.bttnOK);
			this.panelButtons.Controls.Add(this.bttnEdit);
			this.panelButtons.Controls.Add(this.bttnCancel);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelButtons.Location = new System.Drawing.Point(3, 295);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(684, 44);
			this.panelButtons.TabIndex = 1;
			// 
			// bttnDelete
			// 
			this.bttnDelete.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnDelete.Location = new System.Drawing.Point(354, 7);
			this.bttnDelete.Name = "bttnDelete";
			this.bttnDelete.Size = new System.Drawing.Size(96, 32);
			this.bttnDelete.TabIndex = 212;
			this.bttnDelete.Text = "Delete";
			this.bttnDelete.Click += new System.EventHandler(this.BttnDelete_Click);
			// 
			// bttnOK
			// 
			this.bttnOK.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnOK.Location = new System.Drawing.Point(145, 7);
			this.bttnOK.Name = "bttnOK";
			this.bttnOK.Size = new System.Drawing.Size(96, 32);
			this.bttnOK.TabIndex = 211;
			this.bttnOK.Text = "OK";
			this.bttnOK.Visible = false;
			this.bttnOK.Click += new System.EventHandler(this.BttnOK_Click);
			// 
			// bttnEdit
			// 
			this.bttnEdit.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnEdit.Location = new System.Drawing.Point(250, 7);
			this.bttnEdit.Name = "bttnEdit";
			this.bttnEdit.Size = new System.Drawing.Size(96, 32);
			this.bttnEdit.TabIndex = 209;
			this.bttnEdit.Text = "Edit";
			this.bttnEdit.Click += new System.EventHandler(this.BttnEdit_Click);
			// 
			// bttnCancel
			// 
			this.bttnCancel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.bttnCancel.Location = new System.Drawing.Point(456, 7);
			this.bttnCancel.Name = "bttnCancel";
			this.bttnCancel.Size = new System.Drawing.Size(96, 32);
			this.bttnCancel.TabIndex = 210;
			this.bttnCancel.Text = "Cancel";
			this.bttnCancel.Visible = false;
			this.bttnCancel.Click += new System.EventHandler(this.BttnCancel_Click);
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(172, 44);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(101, 20);
			this.txtID.TabIndex = 217;
			// 
			// DialogEvents
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(690, 342);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DialogEvents";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Entry";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.panelInfo.ResumeLayout(false);
			this.panelInfo.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Panel panelInfo;
		internal System.Windows.Forms.Label label8;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtBudget;
		internal System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Panel panelButtons;
		internal System.Windows.Forms.Button bttnOK;
		internal System.Windows.Forms.Button bttnEdit;
		internal System.Windows.Forms.Button bttnCancel;
		private System.Windows.Forms.Button bttnDelete;
		private System.Windows.Forms.DateTimePicker txtBeginDate;
		private System.Windows.Forms.DateTimePicker txtEndDate;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.TextBox txtManager;
		private System.Windows.Forms.CheckBox txtVisibility;
		private System.Windows.Forms.NumericUpDown txtID;
	}
}