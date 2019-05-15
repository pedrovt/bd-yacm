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
			this.listView1 = new System.Windows.Forms.ListView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.participantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageParticipant = new System.Windows.Forms.TabPage();
			this.tabPageSponsor = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.debugInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.copyrightInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPageManager.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
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
			this.tabPageManager.Controls.Add(this.listView1);
			this.tabPageManager.Controls.Add(this.menuStrip1);
			this.tabPageManager.Location = new System.Drawing.Point(4, 22);
			this.tabPageManager.Name = "tabPageManager";
			this.tabPageManager.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageManager.Size = new System.Drawing.Size(1048, 492);
			this.tabPageManager.TabIndex = 0;
			this.tabPageManager.Text = "Events I\'m Managing";
			this.tabPageManager.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(3, 27);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(1042, 462);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEventToolStripMenuItem,
            this.editEventToolStripMenuItem,
            this.participantsToolStripMenuItem,
            this.updateToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(3, 3);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1042, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// addEventToolStripMenuItem
			// 
			this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
			this.addEventToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.addEventToolStripMenuItem.Text = "Add Event";
			this.addEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventToolStripMenuItem_Click);
			// 
			// editEventToolStripMenuItem
			// 
			this.editEventToolStripMenuItem.Name = "editEventToolStripMenuItem";
			this.editEventToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.editEventToolStripMenuItem.Text = "Edit Event";
			this.editEventToolStripMenuItem.Click += new System.EventHandler(this.EditEventToolStripMenuItem_Click);
			// 
			// participantsToolStripMenuItem
			// 
			this.participantsToolStripMenuItem.Name = "participantsToolStripMenuItem";
			this.participantsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.participantsToolStripMenuItem.Text = "Participants";
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
			// tabPageSponsor
			// 
			this.tabPageSponsor.Location = new System.Drawing.Point(4, 22);
			this.tabPageSponsor.Name = "tabPageSponsor";
			this.tabPageSponsor.Size = new System.Drawing.Size(1048, 492);
			this.tabPageSponsor.TabIndex = 2;
			this.tabPageSponsor.Text = "Events I\'m Sponsoring";
			this.tabPageSponsor.UseVisualStyleBackColor = true;
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
			this.labelTitle.Text = "Welcome back, User";
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
			// updateToolStripMenuItem
			// 
			this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
			this.updateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.updateToolStripMenuItem.Text = "Update";
			this.updateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
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
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPageManager.ResumeLayout(false);
			this.tabPageManager.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
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
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editEventToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem participantsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
	}
}