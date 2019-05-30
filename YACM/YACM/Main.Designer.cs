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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageManager = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.eventsList = new System.Windows.Forms.ListView();
			this.eventManagement = new System.Windows.Forms.TabControl();
			this.About = new System.Windows.Forms.TabPage();
			this.eventName = new System.Windows.Forms.Label();
			this.Equipment = new System.Windows.Forms.TabPage();
			this.equipmentList = new System.Windows.Forms.ListView();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.Participants = new System.Windows.Forms.TabPage();
			this.participantsList = new System.Windows.Forms.ListView();
			this.menuStrip3 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.Prizes = new System.Windows.Forms.TabPage();
			this.prizesLIst = new System.Windows.Forms.ListView();
			this.menuStrip4 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			this.Sponsors = new System.Windows.Forms.TabPage();
			this.sponsorsList = new System.Windows.Forms.ListView();
			this.menuStrip5 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
			this.Stages = new System.Windows.Forms.TabPage();
			this.stagesList = new System.Windows.Forms.ListView();
			this.menuStrip6 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
			this.Teams = new System.Windows.Forms.TabPage();
			this.teamsList = new System.Windows.Forms.ListView();
			this.menuStrip7 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
			this.Documents = new System.Windows.Forms.TabPage();
			this.documentsList = new System.Windows.Forms.ListView();
			this.menuStrip8 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
			this.eventsActions = new System.Windows.Forms.MenuStrip();
			this.addEvent = new System.Windows.Forms.ToolStripMenuItem();
			this.editEvent = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshEvent = new System.Windows.Forms.ToolStripMenuItem();
			this.logout = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageParticipant = new System.Windows.Forms.TabPage();
			this.tabPageSponsor = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.debugInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.copyrightInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPageManager.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.eventManagement.SuspendLayout();
			this.About.SuspendLayout();
			this.Equipment.SuspendLayout();
			this.menuStrip2.SuspendLayout();
			this.Participants.SuspendLayout();
			this.menuStrip3.SuspendLayout();
			this.Prizes.SuspendLayout();
			this.menuStrip4.SuspendLayout();
			this.Sponsors.SuspendLayout();
			this.menuStrip5.SuspendLayout();
			this.Stages.SuspendLayout();
			this.menuStrip6.SuspendLayout();
			this.Teams.SuspendLayout();
			this.menuStrip7.SuspendLayout();
			this.Documents.SuspendLayout();
			this.menuStrip8.SuspendLayout();
			this.eventsActions.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControl1.Controls.Add(this.tabPageManager);
			this.tabControl1.Controls.Add(this.tabPageParticipant);
			this.tabControl1.Controls.Add(this.tabPageSponsor);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 71);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1439, 625);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageManager
			// 
			this.tabPageManager.Controls.Add(this.splitContainer1);
			this.tabPageManager.Controls.Add(this.eventsActions);
			this.tabPageManager.Location = new System.Drawing.Point(4, 4);
			this.tabPageManager.Name = "tabPageManager";
			this.tabPageManager.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageManager.Size = new System.Drawing.Size(1431, 599);
			this.tabPageManager.TabIndex = 0;
			this.tabPageManager.Text = "Events I\'m Managing";
			this.tabPageManager.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 27);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.eventsList);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.eventManagement);
			this.splitContainer1.Size = new System.Drawing.Size(1425, 569);
			this.splitContainer1.SplitterDistance = 705;
			this.splitContainer1.TabIndex = 5;
			// 
			// eventsList
			// 
			this.eventsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventsList.Location = new System.Drawing.Point(0, 0);
			this.eventsList.Name = "eventsList";
			this.eventsList.Size = new System.Drawing.Size(705, 569);
			this.eventsList.TabIndex = 1;
			this.eventsList.UseCompatibleStateImageBehavior = false;
			this.eventsList.View = System.Windows.Forms.View.Details;
			this.eventsList.SelectedIndexChanged += new System.EventHandler(this.EventsList_SelectedIndexChanged);
			// 
			// eventManagement
			// 
			this.eventManagement.Controls.Add(this.About);
			this.eventManagement.Controls.Add(this.Equipment);
			this.eventManagement.Controls.Add(this.Participants);
			this.eventManagement.Controls.Add(this.Prizes);
			this.eventManagement.Controls.Add(this.Sponsors);
			this.eventManagement.Controls.Add(this.Stages);
			this.eventManagement.Controls.Add(this.Teams);
			this.eventManagement.Controls.Add(this.Documents);
			this.eventManagement.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventManagement.Location = new System.Drawing.Point(0, 0);
			this.eventManagement.Multiline = true;
			this.eventManagement.Name = "eventManagement";
			this.eventManagement.SelectedIndex = 0;
			this.eventManagement.Size = new System.Drawing.Size(716, 569);
			this.eventManagement.TabIndex = 4;
			this.eventManagement.SelectedIndexChanged += new System.EventHandler(this.EventManagement_SelectedIndexChanged);
			// 
			// About
			// 
			this.About.Controls.Add(this.eventName);
			this.About.Location = new System.Drawing.Point(4, 22);
			this.About.Name = "About";
			this.About.Padding = new System.Windows.Forms.Padding(3);
			this.About.Size = new System.Drawing.Size(708, 543);
			this.About.TabIndex = 8;
			this.About.Text = "About";
			this.About.UseVisualStyleBackColor = true;
			// 
			// eventName
			// 
			this.eventName.AutoSize = true;
			this.eventName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.eventName.Location = new System.Drawing.Point(160, 3);
			this.eventName.Name = "eventName";
			this.eventName.Size = new System.Drawing.Size(187, 26);
			this.eventName.TabIndex = 5;
			this.eventName.Text = "About <eventName>";
			this.eventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Equipment
			// 
			this.Equipment.Controls.Add(this.equipmentList);
			this.Equipment.Controls.Add(this.menuStrip2);
			this.Equipment.Location = new System.Drawing.Point(4, 22);
			this.Equipment.Name = "Equipment";
			this.Equipment.Padding = new System.Windows.Forms.Padding(3);
			this.Equipment.Size = new System.Drawing.Size(708, 543);
			this.Equipment.TabIndex = 1;
			this.Equipment.Text = "Equipment";
			this.Equipment.UseVisualStyleBackColor = true;
			// 
			// equipmentList
			// 
			this.equipmentList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.equipmentList.Location = new System.Drawing.Point(3, 27);
			this.equipmentList.Name = "equipmentList";
			this.equipmentList.Size = new System.Drawing.Size(702, 513);
			this.equipmentList.TabIndex = 4;
			this.equipmentList.UseCompatibleStateImageBehavior = false;
			this.equipmentList.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip2
			// 
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
			this.menuStrip2.Location = new System.Drawing.Point(3, 3);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip2.Size = new System.Drawing.Size(702, 24);
			this.menuStrip2.TabIndex = 5;
			this.menuStrip2.Text = "menuStrip2";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem1.Text = "Add";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem2.Text = "Edit";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem3.Text = "Update";
			// 
			// Participants
			// 
			this.Participants.Controls.Add(this.participantsList);
			this.Participants.Controls.Add(this.menuStrip3);
			this.Participants.Location = new System.Drawing.Point(4, 22);
			this.Participants.Name = "Participants";
			this.Participants.Size = new System.Drawing.Size(708, 543);
			this.Participants.TabIndex = 2;
			this.Participants.Text = "Participants";
			this.Participants.UseVisualStyleBackColor = true;
			// 
			// participantsList
			// 
			this.participantsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.participantsList.Location = new System.Drawing.Point(0, 24);
			this.participantsList.Name = "participantsList";
			this.participantsList.Size = new System.Drawing.Size(708, 519);
			this.participantsList.TabIndex = 6;
			this.participantsList.UseCompatibleStateImageBehavior = false;
			this.participantsList.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip3
			// 
			this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
			this.menuStrip3.Location = new System.Drawing.Point(0, 0);
			this.menuStrip3.Name = "menuStrip3";
			this.menuStrip3.Size = new System.Drawing.Size(708, 24);
			this.menuStrip3.TabIndex = 7;
			this.menuStrip3.Text = "menuStrip3";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem4.Text = "Add";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem5.Text = "Edit";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem5_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem6.Text = "Update";
			this.toolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItem6_Click);
			// 
			// Prizes
			// 
			this.Prizes.Controls.Add(this.prizesLIst);
			this.Prizes.Controls.Add(this.menuStrip4);
			this.Prizes.Location = new System.Drawing.Point(4, 22);
			this.Prizes.Name = "Prizes";
			this.Prizes.Size = new System.Drawing.Size(708, 543);
			this.Prizes.TabIndex = 3;
			this.Prizes.Text = "Prize";
			this.Prizes.UseVisualStyleBackColor = true;
			// 
			// prizesLIst
			// 
			this.prizesLIst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.prizesLIst.Location = new System.Drawing.Point(0, 24);
			this.prizesLIst.Name = "prizesLIst";
			this.prizesLIst.Size = new System.Drawing.Size(708, 519);
			this.prizesLIst.TabIndex = 6;
			this.prizesLIst.UseCompatibleStateImageBehavior = false;
			this.prizesLIst.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip4
			// 
			this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
			this.menuStrip4.Location = new System.Drawing.Point(0, 0);
			this.menuStrip4.Name = "menuStrip4";
			this.menuStrip4.Size = new System.Drawing.Size(708, 24);
			this.menuStrip4.TabIndex = 7;
			this.menuStrip4.Text = "menuStrip4";
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem7.Text = "Add";
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem8.Text = "Edit";
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem9.Text = "Update";
			// 
			// Sponsors
			// 
			this.Sponsors.Controls.Add(this.sponsorsList);
			this.Sponsors.Controls.Add(this.menuStrip5);
			this.Sponsors.Location = new System.Drawing.Point(4, 22);
			this.Sponsors.Name = "Sponsors";
			this.Sponsors.Size = new System.Drawing.Size(708, 543);
			this.Sponsors.TabIndex = 4;
			this.Sponsors.Text = "Sponsors";
			this.Sponsors.UseVisualStyleBackColor = true;
			// 
			// sponsorsList
			// 
			this.sponsorsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sponsorsList.Location = new System.Drawing.Point(0, 24);
			this.sponsorsList.Name = "sponsorsList";
			this.sponsorsList.Size = new System.Drawing.Size(708, 519);
			this.sponsorsList.TabIndex = 6;
			this.sponsorsList.UseCompatibleStateImageBehavior = false;
			this.sponsorsList.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip5
			// 
			this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
			this.menuStrip5.Location = new System.Drawing.Point(0, 0);
			this.menuStrip5.Name = "menuStrip5";
			this.menuStrip5.Size = new System.Drawing.Size(708, 24);
			this.menuStrip5.TabIndex = 7;
			this.menuStrip5.Text = "menuStrip5";
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem10.Text = "Add";
			// 
			// toolStripMenuItem11
			// 
			this.toolStripMenuItem11.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem11.Name = "toolStripMenuItem11";
			this.toolStripMenuItem11.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem11.Text = "Edit";
			// 
			// toolStripMenuItem12
			// 
			this.toolStripMenuItem12.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem12.Name = "toolStripMenuItem12";
			this.toolStripMenuItem12.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem12.Text = "Update";
			// 
			// Stages
			// 
			this.Stages.Controls.Add(this.stagesList);
			this.Stages.Controls.Add(this.menuStrip6);
			this.Stages.Location = new System.Drawing.Point(4, 22);
			this.Stages.Name = "Stages";
			this.Stages.Size = new System.Drawing.Size(708, 543);
			this.Stages.TabIndex = 5;
			this.Stages.Text = "Stages";
			this.Stages.UseVisualStyleBackColor = true;
			// 
			// stagesList
			// 
			this.stagesList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.stagesList.Location = new System.Drawing.Point(0, 24);
			this.stagesList.Name = "stagesList";
			this.stagesList.Size = new System.Drawing.Size(708, 519);
			this.stagesList.TabIndex = 6;
			this.stagesList.UseCompatibleStateImageBehavior = false;
			this.stagesList.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip6
			// 
			this.menuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
			this.menuStrip6.Location = new System.Drawing.Point(0, 0);
			this.menuStrip6.Name = "menuStrip6";
			this.menuStrip6.Size = new System.Drawing.Size(708, 24);
			this.menuStrip6.TabIndex = 7;
			this.menuStrip6.Text = "menuStrip6";
			// 
			// toolStripMenuItem13
			// 
			this.toolStripMenuItem13.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem13.Name = "toolStripMenuItem13";
			this.toolStripMenuItem13.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem13.Text = "Add";
			// 
			// toolStripMenuItem14
			// 
			this.toolStripMenuItem14.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem14.Name = "toolStripMenuItem14";
			this.toolStripMenuItem14.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem14.Text = "Edit";
			// 
			// toolStripMenuItem15
			// 
			this.toolStripMenuItem15.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem15.Name = "toolStripMenuItem15";
			this.toolStripMenuItem15.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem15.Text = "Update";
			// 
			// Teams
			// 
			this.Teams.Controls.Add(this.teamsList);
			this.Teams.Controls.Add(this.menuStrip7);
			this.Teams.Location = new System.Drawing.Point(4, 22);
			this.Teams.Name = "Teams";
			this.Teams.Size = new System.Drawing.Size(708, 543);
			this.Teams.TabIndex = 6;
			this.Teams.Text = "Teams";
			this.Teams.UseVisualStyleBackColor = true;
			// 
			// teamsList
			// 
			this.teamsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.teamsList.Location = new System.Drawing.Point(0, 24);
			this.teamsList.Name = "teamsList";
			this.teamsList.Size = new System.Drawing.Size(708, 519);
			this.teamsList.TabIndex = 6;
			this.teamsList.UseCompatibleStateImageBehavior = false;
			this.teamsList.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip7
			// 
			this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem17,
            this.toolStripMenuItem18});
			this.menuStrip7.Location = new System.Drawing.Point(0, 0);
			this.menuStrip7.Name = "menuStrip7";
			this.menuStrip7.Size = new System.Drawing.Size(708, 24);
			this.menuStrip7.TabIndex = 7;
			this.menuStrip7.Text = "menuStrip7";
			// 
			// toolStripMenuItem16
			// 
			this.toolStripMenuItem16.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem16.Name = "toolStripMenuItem16";
			this.toolStripMenuItem16.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem16.Text = "Add";
			// 
			// toolStripMenuItem17
			// 
			this.toolStripMenuItem17.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem17.Name = "toolStripMenuItem17";
			this.toolStripMenuItem17.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem17.Text = "Edit";
			// 
			// toolStripMenuItem18
			// 
			this.toolStripMenuItem18.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem18.Name = "toolStripMenuItem18";
			this.toolStripMenuItem18.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem18.Text = "Update";
			// 
			// Documents
			// 
			this.Documents.Controls.Add(this.documentsList);
			this.Documents.Controls.Add(this.menuStrip8);
			this.Documents.Location = new System.Drawing.Point(4, 22);
			this.Documents.Name = "Documents";
			this.Documents.Size = new System.Drawing.Size(708, 543);
			this.Documents.TabIndex = 7;
			this.Documents.Text = "Documents";
			this.Documents.UseVisualStyleBackColor = true;
			// 
			// documentsList
			// 
			this.documentsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.documentsList.Location = new System.Drawing.Point(0, 24);
			this.documentsList.Name = "documentsList";
			this.documentsList.Size = new System.Drawing.Size(708, 519);
			this.documentsList.TabIndex = 6;
			this.documentsList.UseCompatibleStateImageBehavior = false;
			this.documentsList.View = System.Windows.Forms.View.Details;
			// 
			// menuStrip8
			// 
			this.menuStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem19,
            this.toolStripMenuItem20,
            this.toolStripMenuItem21});
			this.menuStrip8.Location = new System.Drawing.Point(0, 0);
			this.menuStrip8.Name = "menuStrip8";
			this.menuStrip8.Size = new System.Drawing.Size(708, 24);
			this.menuStrip8.TabIndex = 7;
			this.menuStrip8.Text = "menuStrip8";
			// 
			// toolStripMenuItem19
			// 
			this.toolStripMenuItem19.Image = global::YACM.Properties.Resources.ic_add;
			this.toolStripMenuItem19.Name = "toolStripMenuItem19";
			this.toolStripMenuItem19.Size = new System.Drawing.Size(57, 20);
			this.toolStripMenuItem19.Text = "Add";
			// 
			// toolStripMenuItem20
			// 
			this.toolStripMenuItem20.Image = global::YACM.Properties.Resources.ic_edit;
			this.toolStripMenuItem20.Name = "toolStripMenuItem20";
			this.toolStripMenuItem20.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem20.Text = "Edit";
			// 
			// toolStripMenuItem21
			// 
			this.toolStripMenuItem21.Image = global::YACM.Properties.Resources.ic_refresh;
			this.toolStripMenuItem21.Name = "toolStripMenuItem21";
			this.toolStripMenuItem21.Size = new System.Drawing.Size(73, 20);
			this.toolStripMenuItem21.Text = "Update";
			// 
			// eventsActions
			// 
			this.eventsActions.BackColor = System.Drawing.Color.Transparent;
			this.eventsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEvent,
            this.editEvent,
            this.refreshEvent,
            this.logout});
			this.eventsActions.Location = new System.Drawing.Point(3, 3);
			this.eventsActions.Name = "eventsActions";
			this.eventsActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.eventsActions.Size = new System.Drawing.Size(1425, 24);
			this.eventsActions.TabIndex = 3;
			this.eventsActions.Text = "menuStrip1";
			// 
			// addEvent
			// 
			this.addEvent.Image = global::YACM.Properties.Resources.ic_add;
			this.addEvent.Name = "addEvent";
			this.addEvent.Size = new System.Drawing.Size(89, 20);
			this.addEvent.Text = "Add Event";
			this.addEvent.Click += new System.EventHandler(this.AddEvent_Click);
			// 
			// editEvent
			// 
			this.editEvent.Image = global::YACM.Properties.Resources.ic_edit;
			this.editEvent.Name = "editEvent";
			this.editEvent.Size = new System.Drawing.Size(87, 20);
			this.editEvent.Text = "Edit Event";
			this.editEvent.Click += new System.EventHandler(this.EditEvent_Click);
			// 
			// refreshEvent
			// 
			this.refreshEvent.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshEvent.Name = "refreshEvent";
			this.refreshEvent.Size = new System.Drawing.Size(73, 20);
			this.refreshEvent.Text = "Update";
			this.refreshEvent.Click += new System.EventHandler(this.RefreshEvents_Click);
			// 
			// logout
			// 
			this.logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.logout.Image = global::YACM.Properties.Resources.ic_exit_to_app;
			this.logout.Name = "logout";
			this.logout.Size = new System.Drawing.Size(73, 20);
			this.logout.Text = "Logout";
			this.logout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.logout.Click += new System.EventHandler(this.Logout_Click);
			// 
			// tabPageParticipant
			// 
			this.tabPageParticipant.Location = new System.Drawing.Point(4, 4);
			this.tabPageParticipant.Name = "tabPageParticipant";
			this.tabPageParticipant.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageParticipant.Size = new System.Drawing.Size(1431, 599);
			this.tabPageParticipant.TabIndex = 1;
			this.tabPageParticipant.Text = "Events I\'m Participating";
			this.tabPageParticipant.UseVisualStyleBackColor = true;
			// 
			// tabPageSponsor
			// 
			this.tabPageSponsor.Location = new System.Drawing.Point(4, 4);
			this.tabPageSponsor.Name = "tabPageSponsor";
			this.tabPageSponsor.Size = new System.Drawing.Size(1431, 599);
			this.tabPageSponsor.TabIndex = 2;
			this.tabPageSponsor.Text = "Events I\'m Sponsoring";
			this.tabPageSponsor.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugInfo,
            this.copyrightInfo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 720);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1445, 22);
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
			this.copyrightInfo.Size = new System.Drawing.Size(1391, 17);
			this.copyrightInfo.Spring = true;
			this.copyrightInfo.Text = "© Paulo, Pedro 2019";
			this.copyrightInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(1439, 68);
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
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.827586F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.17242F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1445, 720);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.BalloonTipText = "Welcome to YACM!";
			this.notifyIcon1.BalloonTipTitle = "YACM";
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "YACM";
			this.notifyIcon1.Visible = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1445, 742);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.eventsActions;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "YACM | Main";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPageManager.ResumeLayout(false);
			this.tabPageManager.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.eventManagement.ResumeLayout(false);
			this.About.ResumeLayout(false);
			this.About.PerformLayout();
			this.Equipment.ResumeLayout(false);
			this.Equipment.PerformLayout();
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.Participants.ResumeLayout(false);
			this.Participants.PerformLayout();
			this.menuStrip3.ResumeLayout(false);
			this.menuStrip3.PerformLayout();
			this.Prizes.ResumeLayout(false);
			this.Prizes.PerformLayout();
			this.menuStrip4.ResumeLayout(false);
			this.menuStrip4.PerformLayout();
			this.Sponsors.ResumeLayout(false);
			this.Sponsors.PerformLayout();
			this.menuStrip5.ResumeLayout(false);
			this.menuStrip5.PerformLayout();
			this.Stages.ResumeLayout(false);
			this.Stages.PerformLayout();
			this.menuStrip6.ResumeLayout(false);
			this.menuStrip6.PerformLayout();
			this.Teams.ResumeLayout(false);
			this.Teams.PerformLayout();
			this.menuStrip7.ResumeLayout(false);
			this.menuStrip7.PerformLayout();
			this.Documents.ResumeLayout(false);
			this.Documents.PerformLayout();
			this.menuStrip8.ResumeLayout(false);
			this.menuStrip8.PerformLayout();
			this.eventsActions.ResumeLayout(false);
			this.eventsActions.PerformLayout();
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
		private System.Windows.Forms.ListView eventsList;
		private System.Windows.Forms.MenuStrip eventsActions;
		private System.Windows.Forms.ToolStripMenuItem addEvent;
		private System.Windows.Forms.ToolStripMenuItem editEvent;
		private System.Windows.Forms.ToolStripMenuItem refreshEvent;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl eventManagement;
		private System.Windows.Forms.TabPage Participants;
		private System.Windows.Forms.TabPage Equipment;
		private System.Windows.Forms.ListView equipmentList;
		private System.Windows.Forms.MenuStrip menuStrip2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.TabPage Prizes;
		private System.Windows.Forms.TabPage Sponsors;
		private System.Windows.Forms.TabPage Stages;
		private System.Windows.Forms.TabPage Teams;
		private System.Windows.Forms.TabPage Documents;
		private System.Windows.Forms.TabPage About;
		private System.Windows.Forms.ListView participantsList;
		private System.Windows.Forms.MenuStrip menuStrip3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
		private System.Windows.Forms.ListView prizesLIst;
		private System.Windows.Forms.MenuStrip menuStrip4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ListView sponsorsList;
		private System.Windows.Forms.MenuStrip menuStrip5;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
		private System.Windows.Forms.ListView stagesList;
		private System.Windows.Forms.MenuStrip menuStrip6;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
		private System.Windows.Forms.ListView teamsList;
		private System.Windows.Forms.MenuStrip menuStrip7;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem18;
		private System.Windows.Forms.ListView documentsList;
		private System.Windows.Forms.MenuStrip menuStrip8;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem19;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem20;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem21;
		private System.Windows.Forms.ToolStripMenuItem logout;
		private System.Windows.Forms.Label eventName;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
	}
}