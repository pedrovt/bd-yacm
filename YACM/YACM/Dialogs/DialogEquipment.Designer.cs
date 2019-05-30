namespace YACM
{
	partial class DialogEquipment
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogEquipment));
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
			this.txtID = new System.Windows.Forms.NumericUpDown();
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel.SuspendLayout();
			this.panelInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
			this.panelButtons.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
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
			this.labelTitle.Text = "Event Entry";
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
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label4.Location = new System.Drawing.Point(3, 132);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 22);
			this.label4.TabIndex = 214;
			this.label4.Text = "Manager";
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.label8.Location = new System.Drawing.Point(3, 83);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(128, 22);
			this.label8.TabIndex = 210;
			this.label8.Text = "&End Date";
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
			// Label5
			// 
			this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label5.Location = new System.Drawing.Point(3, 158);
			this.Label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(128, 84);
			this.Label5.TabIndex = 201;
			this.Label5.Text = "Budget";
			// 
			// Label3
			// 
			this.Label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label3.Location = new System.Drawing.Point(3, 109);
			this.Label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(128, 19);
			this.Label3.TabIndex = 199;
			this.Label3.Text = "&Visibility";
			// 
			// Label2
			// 
			this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.Label2.Location = new System.Drawing.Point(3, 57);
			this.Label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(128, 22);
			this.Label2.TabIndex = 197;
			this.Label2.Text = "&Begin Date";
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
			this.Label1.Text = "&Name";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(137, 3);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(161, 20);
			this.txtID.TabIndex = 217;
			// 
			// txtBudget
			// 
			this.txtBudget.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtBudget.Location = new System.Drawing.Point(137, 156);
			this.txtBudget.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtBudget.Name = "txtBudget";
			this.txtBudget.ReadOnly = true;
			this.txtBudget.Size = new System.Drawing.Size(370, 22);
			this.txtBudget.TabIndex = 202;
			// 
			// txtManager
			// 
			this.txtManager.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtManager.Location = new System.Drawing.Point(137, 130);
			this.txtManager.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
			this.txtManager.Name = "txtManager";
			this.txtManager.ReadOnly = true;
			this.txtManager.Size = new System.Drawing.Size(370, 22);
			this.txtManager.TabIndex = 215;
			// 
			// txtBeginDate
			// 
			this.txtBeginDate.Location = new System.Drawing.Point(137, 57);
			this.txtBeginDate.Name = "txtBeginDate";
			this.txtBeginDate.Size = new System.Drawing.Size(161, 20);
			this.txtBeginDate.TabIndex = 212;
			// 
			// txtVisibility
			// 
			this.txtVisibility.AutoSize = true;
			this.txtVisibility.Location = new System.Drawing.Point(137, 109);
			this.txtVisibility.Name = "txtVisibility";
			this.txtVisibility.Size = new System.Drawing.Size(55, 17);
			this.txtVisibility.TabIndex = 216;
			this.txtVisibility.Text = "Public";
			this.txtVisibility.UseVisualStyleBackColor = true;
			// 
			// txtEndDate
			// 
			this.txtEndDate.Location = new System.Drawing.Point(137, 83);
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.Size = new System.Drawing.Size(161, 20);
			this.txtEndDate.TabIndex = 213;
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.txtName.Location = new System.Drawing.Point(137, 29);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(370, 22);
			this.txtName.TabIndex = 196;
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
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.61933F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.38067F));
			this.tableLayoutPanel2.Controls.Add(this.Label11, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 5);
			this.tableLayoutPanel2.Controls.Add(this.Label1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.Label5, 0, 6);
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.Label3, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.Label2, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.txtManager, 1, 5);
			this.tableLayoutPanel2.Controls.Add(this.txtID, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.txtVisibility, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.txtName, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.txtBeginDate, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.txtEndDate, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.txtBudget, 1, 6);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 7;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(683, 243);
			this.tableLayoutPanel2.TabIndex = 218;
			// 
			// DialogEquipment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(685, 336);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DialogEquipment";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Entry";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.panelInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
			this.panelButtons.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	}
}