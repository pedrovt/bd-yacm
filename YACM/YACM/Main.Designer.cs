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
			this.Statistics = new System.Windows.Forms.TabPage();
			this.Equipment = new System.Windows.Forms.TabPage();
			this.equipmentList = new System.Windows.Forms.ListView();
			this.equipamentActions = new System.Windows.Forms.MenuStrip();
			this.addEquipment = new System.Windows.Forms.ToolStripMenuItem();
			this.editEquipment = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshEquipment = new System.Windows.Forms.ToolStripMenuItem();
			this.Participants = new System.Windows.Forms.TabPage();
			this.participantsList = new System.Windows.Forms.ListView();
			this.participantsActions = new System.Windows.Forms.MenuStrip();
			this.addParticipants = new System.Windows.Forms.ToolStripMenuItem();
			this.editParticipants = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshParticipants = new System.Windows.Forms.ToolStripMenuItem();
			this.Prizes = new System.Windows.Forms.TabPage();
			this.prizesList = new System.Windows.Forms.ListView();
			this.prizeActions = new System.Windows.Forms.MenuStrip();
			this.addPrizes = new System.Windows.Forms.ToolStripMenuItem();
			this.editPrizes = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshPrizes = new System.Windows.Forms.ToolStripMenuItem();
			this.Sponsors = new System.Windows.Forms.TabPage();
			this.sponsorsList = new System.Windows.Forms.ListView();
			this.sponsorsActions = new System.Windows.Forms.MenuStrip();
			this.addSponsors = new System.Windows.Forms.ToolStripMenuItem();
			this.editSponsors = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshSponsors = new System.Windows.Forms.ToolStripMenuItem();
			this.Stages = new System.Windows.Forms.TabPage();
			this.stagesList = new System.Windows.Forms.ListView();
			this.stagesActions = new System.Windows.Forms.MenuStrip();
			this.addStages = new System.Windows.Forms.ToolStripMenuItem();
			this.editStages = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshStages = new System.Windows.Forms.ToolStripMenuItem();
			this.Teams = new System.Windows.Forms.TabPage();
			this.teamsList = new System.Windows.Forms.ListView();
			this.teamActions = new System.Windows.Forms.MenuStrip();
			this.addTeams = new System.Windows.Forms.ToolStripMenuItem();
			this.editTeams = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshTeams = new System.Windows.Forms.ToolStripMenuItem();
			this.Documents = new System.Windows.Forms.TabPage();
			this.documentsList = new System.Windows.Forms.ListView();
			this.documentsActions = new System.Windows.Forms.MenuStrip();
			this.addDocuments = new System.Windows.Forms.ToolStripMenuItem();
			this.editDocuments = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshDocuments = new System.Windows.Forms.ToolStripMenuItem();
			this.eventsActions = new System.Windows.Forms.MenuStrip();
			this.addEvent = new System.Windows.Forms.ToolStripMenuItem();
			this.editEvent = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshEvent = new System.Windows.Forms.ToolStripMenuItem();
			this.logout = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPageParticipant = new System.Windows.Forms.TabPage();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.debugInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.copyrightInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.StagesParticipants = new System.Windows.Forms.TabPage();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.addStagesParticipations = new System.Windows.Forms.ToolStripMenuItem();
			this.editStagesParticipations = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshStagesParticipations = new System.Windows.Forms.ToolStripMenuItem();
			this.stagesParticipationsList = new System.Windows.Forms.ListView();
			this.tabControl1.SuspendLayout();
			this.tabPageManager.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.eventManagement.SuspendLayout();
			this.Equipment.SuspendLayout();
			this.equipamentActions.SuspendLayout();
			this.Participants.SuspendLayout();
			this.participantsActions.SuspendLayout();
			this.Prizes.SuspendLayout();
			this.prizeActions.SuspendLayout();
			this.Sponsors.SuspendLayout();
			this.sponsorsActions.SuspendLayout();
			this.Stages.SuspendLayout();
			this.stagesActions.SuspendLayout();
			this.Teams.SuspendLayout();
			this.teamActions.SuspendLayout();
			this.Documents.SuspendLayout();
			this.documentsActions.SuspendLayout();
			this.eventsActions.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.StagesParticipants.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageManager);
			this.tabControl1.Controls.Add(this.tabPageParticipant);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 71);
			this.tabControl1.Multiline = true;
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
			this.tabPageManager.Location = new System.Drawing.Point(4, 22);
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
			this.eventManagement.Controls.Add(this.Statistics);
			this.eventManagement.Controls.Add(this.Equipment);
			this.eventManagement.Controls.Add(this.Participants);
			this.eventManagement.Controls.Add(this.Prizes);
			this.eventManagement.Controls.Add(this.Sponsors);
			this.eventManagement.Controls.Add(this.Stages);
			this.eventManagement.Controls.Add(this.StagesParticipants);
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
			// Statistics
			// 
			this.Statistics.Location = new System.Drawing.Point(4, 22);
			this.Statistics.Name = "Statistics";
			this.Statistics.Padding = new System.Windows.Forms.Padding(3);
			this.Statistics.Size = new System.Drawing.Size(708, 543);
			this.Statistics.TabIndex = 8;
			this.Statistics.Text = "Statistics";
			this.Statistics.UseVisualStyleBackColor = true;
			// 
			// Equipment
			// 
			this.Equipment.Controls.Add(this.equipmentList);
			this.Equipment.Controls.Add(this.equipamentActions);
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
			// equipamentActions
			// 
			this.equipamentActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEquipment,
            this.editEquipment,
            this.refreshEquipment});
			this.equipamentActions.Location = new System.Drawing.Point(3, 3);
			this.equipamentActions.Name = "equipamentActions";
			this.equipamentActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.equipamentActions.Size = new System.Drawing.Size(702, 24);
			this.equipamentActions.TabIndex = 5;
			this.equipamentActions.Text = "menuStrip2";
			// 
			// addEquipment
			// 
			this.addEquipment.Image = global::YACM.Properties.Resources.ic_add;
			this.addEquipment.Name = "addEquipment";
			this.addEquipment.Size = new System.Drawing.Size(57, 20);
			this.addEquipment.Text = "Add";
			this.addEquipment.Click += new System.EventHandler(this.AddEquipment_Click);
			// 
			// editEquipment
			// 
			this.editEquipment.Image = global::YACM.Properties.Resources.ic_edit;
			this.editEquipment.Name = "editEquipment";
			this.editEquipment.Size = new System.Drawing.Size(55, 20);
			this.editEquipment.Text = "Edit";
			this.editEquipment.Click += new System.EventHandler(this.EditEquipment_Click);
			// 
			// refreshEquipment
			// 
			this.refreshEquipment.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshEquipment.Name = "refreshEquipment";
			this.refreshEquipment.Size = new System.Drawing.Size(73, 20);
			this.refreshEquipment.Text = "Update";
			this.refreshEquipment.Click += new System.EventHandler(this.RefreshEquipment_Click);
			// 
			// Participants
			// 
			this.Participants.Controls.Add(this.participantsList);
			this.Participants.Controls.Add(this.participantsActions);
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
			// participantsActions
			// 
			this.participantsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addParticipants,
            this.editParticipants,
            this.refreshParticipants});
			this.participantsActions.Location = new System.Drawing.Point(0, 0);
			this.participantsActions.Name = "participantsActions";
			this.participantsActions.Size = new System.Drawing.Size(708, 24);
			this.participantsActions.TabIndex = 7;
			this.participantsActions.Text = "menuStrip3";
			// 
			// addParticipants
			// 
			this.addParticipants.Image = global::YACM.Properties.Resources.ic_add;
			this.addParticipants.Name = "addParticipants";
			this.addParticipants.Size = new System.Drawing.Size(57, 20);
			this.addParticipants.Text = "Add";
			this.addParticipants.Click += new System.EventHandler(this.AddParticipants_Click);
			// 
			// editParticipants
			// 
			this.editParticipants.Image = global::YACM.Properties.Resources.ic_edit;
			this.editParticipants.Name = "editParticipants";
			this.editParticipants.Size = new System.Drawing.Size(55, 20);
			this.editParticipants.Text = "Edit";
			this.editParticipants.Click += new System.EventHandler(this.EditParticipants_Click);
			// 
			// refreshParticipants
			// 
			this.refreshParticipants.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshParticipants.Name = "refreshParticipants";
			this.refreshParticipants.Size = new System.Drawing.Size(73, 20);
			this.refreshParticipants.Text = "Update";
			this.refreshParticipants.Click += new System.EventHandler(this.RefreshParticipants_Click);
			// 
			// Prizes
			// 
			this.Prizes.Controls.Add(this.prizesList);
			this.Prizes.Controls.Add(this.prizeActions);
			this.Prizes.Location = new System.Drawing.Point(4, 22);
			this.Prizes.Name = "Prizes";
			this.Prizes.Size = new System.Drawing.Size(708, 543);
			this.Prizes.TabIndex = 3;
			this.Prizes.Text = "Prize";
			this.Prizes.UseVisualStyleBackColor = true;
			// 
			// prizesList
			// 
			this.prizesList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.prizesList.Location = new System.Drawing.Point(0, 24);
			this.prizesList.Name = "prizesList";
			this.prizesList.Size = new System.Drawing.Size(708, 519);
			this.prizesList.TabIndex = 6;
			this.prizesList.UseCompatibleStateImageBehavior = false;
			this.prizesList.View = System.Windows.Forms.View.Details;
			// 
			// prizeActions
			// 
			this.prizeActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPrizes,
            this.editPrizes,
            this.refreshPrizes});
			this.prizeActions.Location = new System.Drawing.Point(0, 0);
			this.prizeActions.Name = "prizeActions";
			this.prizeActions.Size = new System.Drawing.Size(708, 24);
			this.prizeActions.TabIndex = 7;
			this.prizeActions.Text = "menuStrip4";
			// 
			// addPrizes
			// 
			this.addPrizes.Image = global::YACM.Properties.Resources.ic_add;
			this.addPrizes.Name = "addPrizes";
			this.addPrizes.Size = new System.Drawing.Size(57, 20);
			this.addPrizes.Text = "Add";
			this.addPrizes.Click += new System.EventHandler(this.AddPrizes_Click);
			// 
			// editPrizes
			// 
			this.editPrizes.Image = global::YACM.Properties.Resources.ic_edit;
			this.editPrizes.Name = "editPrizes";
			this.editPrizes.Size = new System.Drawing.Size(55, 20);
			this.editPrizes.Text = "Edit";
			this.editPrizes.Click += new System.EventHandler(this.EditPrizes_Click);
			// 
			// refreshPrizes
			// 
			this.refreshPrizes.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshPrizes.Name = "refreshPrizes";
			this.refreshPrizes.Size = new System.Drawing.Size(73, 20);
			this.refreshPrizes.Text = "Update";
			this.refreshPrizes.Click += new System.EventHandler(this.RefreshPrizes_Click);
			// 
			// Sponsors
			// 
			this.Sponsors.Controls.Add(this.sponsorsList);
			this.Sponsors.Controls.Add(this.sponsorsActions);
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
			// sponsorsActions
			// 
			this.sponsorsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSponsors,
            this.editSponsors,
            this.refreshSponsors});
			this.sponsorsActions.Location = new System.Drawing.Point(0, 0);
			this.sponsorsActions.Name = "sponsorsActions";
			this.sponsorsActions.Size = new System.Drawing.Size(708, 24);
			this.sponsorsActions.TabIndex = 7;
			this.sponsorsActions.Text = "menuStrip5";
			// 
			// addSponsors
			// 
			this.addSponsors.Image = global::YACM.Properties.Resources.ic_add;
			this.addSponsors.Name = "addSponsors";
			this.addSponsors.Size = new System.Drawing.Size(57, 20);
			this.addSponsors.Text = "Add";
			this.addSponsors.Click += new System.EventHandler(this.AddSponsors_Click);
			// 
			// editSponsors
			// 
			this.editSponsors.Image = global::YACM.Properties.Resources.ic_edit;
			this.editSponsors.Name = "editSponsors";
			this.editSponsors.Size = new System.Drawing.Size(55, 20);
			this.editSponsors.Text = "Edit";
			this.editSponsors.Click += new System.EventHandler(this.EditSponsors_Click);
			// 
			// refreshSponsors
			// 
			this.refreshSponsors.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshSponsors.Name = "refreshSponsors";
			this.refreshSponsors.Size = new System.Drawing.Size(73, 20);
			this.refreshSponsors.Text = "Update";
			this.refreshSponsors.Click += new System.EventHandler(this.RefreshSponsors_Click);
			// 
			// Stages
			// 
			this.Stages.Controls.Add(this.stagesList);
			this.Stages.Controls.Add(this.stagesActions);
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
			// stagesActions
			// 
			this.stagesActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStages,
            this.editStages,
            this.refreshStages});
			this.stagesActions.Location = new System.Drawing.Point(0, 0);
			this.stagesActions.Name = "stagesActions";
			this.stagesActions.Size = new System.Drawing.Size(708, 24);
			this.stagesActions.TabIndex = 7;
			this.stagesActions.Text = "menuStrip6";
			// 
			// addStages
			// 
			this.addStages.Image = global::YACM.Properties.Resources.ic_add;
			this.addStages.Name = "addStages";
			this.addStages.Size = new System.Drawing.Size(57, 20);
			this.addStages.Text = "Add";
			this.addStages.Click += new System.EventHandler(this.AddStages_Click);
			// 
			// editStages
			// 
			this.editStages.Image = global::YACM.Properties.Resources.ic_edit;
			this.editStages.Name = "editStages";
			this.editStages.Size = new System.Drawing.Size(55, 20);
			this.editStages.Text = "Edit";
			this.editStages.Click += new System.EventHandler(this.EditStages_Click);
			// 
			// refreshStages
			// 
			this.refreshStages.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshStages.Name = "refreshStages";
			this.refreshStages.Size = new System.Drawing.Size(73, 20);
			this.refreshStages.Text = "Update";
			this.refreshStages.Click += new System.EventHandler(this.RefreshStages_Click);
			// 
			// Teams
			// 
			this.Teams.Controls.Add(this.teamsList);
			this.Teams.Controls.Add(this.teamActions);
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
			// teamActions
			// 
			this.teamActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTeams,
            this.editTeams,
            this.refreshTeams});
			this.teamActions.Location = new System.Drawing.Point(0, 0);
			this.teamActions.Name = "teamActions";
			this.teamActions.Size = new System.Drawing.Size(708, 24);
			this.teamActions.TabIndex = 7;
			this.teamActions.Text = "menuStrip7";
			// 
			// addTeams
			// 
			this.addTeams.Image = global::YACM.Properties.Resources.ic_add;
			this.addTeams.Name = "addTeams";
			this.addTeams.Size = new System.Drawing.Size(57, 20);
			this.addTeams.Text = "Add";
			this.addTeams.Click += new System.EventHandler(this.AddTeams_Click);
			// 
			// editTeams
			// 
			this.editTeams.Image = global::YACM.Properties.Resources.ic_edit;
			this.editTeams.Name = "editTeams";
			this.editTeams.Size = new System.Drawing.Size(55, 20);
			this.editTeams.Text = "Edit";
			this.editTeams.Click += new System.EventHandler(this.EditTeams_Click);
			// 
			// refreshTeams
			// 
			this.refreshTeams.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshTeams.Name = "refreshTeams";
			this.refreshTeams.Size = new System.Drawing.Size(73, 20);
			this.refreshTeams.Text = "Update";
			this.refreshTeams.Click += new System.EventHandler(this.RefreshTeams_Click);
			// 
			// Documents
			// 
			this.Documents.Controls.Add(this.documentsList);
			this.Documents.Controls.Add(this.documentsActions);
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
			// documentsActions
			// 
			this.documentsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDocuments,
            this.editDocuments,
            this.refreshDocuments});
			this.documentsActions.Location = new System.Drawing.Point(0, 0);
			this.documentsActions.Name = "documentsActions";
			this.documentsActions.Size = new System.Drawing.Size(708, 24);
			this.documentsActions.TabIndex = 7;
			this.documentsActions.Text = "menuStrip8";
			// 
			// addDocuments
			// 
			this.addDocuments.Image = global::YACM.Properties.Resources.ic_add;
			this.addDocuments.Name = "addDocuments";
			this.addDocuments.Size = new System.Drawing.Size(57, 20);
			this.addDocuments.Text = "Add";
			this.addDocuments.Click += new System.EventHandler(this.AddDocuments_Click);
			// 
			// editDocuments
			// 
			this.editDocuments.Image = global::YACM.Properties.Resources.ic_edit;
			this.editDocuments.Name = "editDocuments";
			this.editDocuments.Size = new System.Drawing.Size(55, 20);
			this.editDocuments.Text = "Edit";
			this.editDocuments.Click += new System.EventHandler(this.EditDocuments_Click);
			// 
			// refreshDocuments
			// 
			this.refreshDocuments.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshDocuments.Name = "refreshDocuments";
			this.refreshDocuments.Size = new System.Drawing.Size(73, 20);
			this.refreshDocuments.Text = "Update";
			this.refreshDocuments.Click += new System.EventHandler(this.RefreshDocuments_Click);
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
			this.tabPageParticipant.Location = new System.Drawing.Point(4, 22);
			this.tabPageParticipant.Name = "tabPageParticipant";
			this.tabPageParticipant.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageParticipant.Size = new System.Drawing.Size(1431, 599);
			this.tabPageParticipant.TabIndex = 1;
			this.tabPageParticipant.Text = "Other Events";
			this.tabPageParticipant.UseVisualStyleBackColor = true;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugInfo,
            this.copyrightInfo});
			this.statusStrip.Location = new System.Drawing.Point(0, 720);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1445, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
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
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.BalloonTipText = "Welcome to YACM!";
			this.notifyIcon.BalloonTipTitle = "YACM";
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "YACM";
			this.notifyIcon.Visible = true;
			// 
			// StagesParticipants
			// 
			this.StagesParticipants.Controls.Add(this.stagesParticipationsList);
			this.StagesParticipants.Controls.Add(this.menuStrip1);
			this.StagesParticipants.Location = new System.Drawing.Point(4, 22);
			this.StagesParticipants.Name = "StagesParticipants";
			this.StagesParticipants.Padding = new System.Windows.Forms.Padding(3);
			this.StagesParticipants.Size = new System.Drawing.Size(708, 543);
			this.StagesParticipants.TabIndex = 9;
			this.StagesParticipants.Text = "Stages Participants";
			this.StagesParticipants.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStagesParticipations,
            this.editStagesParticipations,
            this.refreshStagesParticipations});
			this.menuStrip1.Location = new System.Drawing.Point(3, 3);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(702, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip6";
			// 
			// addStagesParticipations
			// 
			this.addStagesParticipations.Image = global::YACM.Properties.Resources.ic_add;
			this.addStagesParticipations.Name = "addStagesParticipations";
			this.addStagesParticipations.Size = new System.Drawing.Size(57, 20);
			this.addStagesParticipations.Text = "Add";
			this.addStagesParticipations.Click += new System.EventHandler(this.AddStagesParticipations_Click);
			// 
			// editStagesParticipations
			// 
			this.editStagesParticipations.Image = global::YACM.Properties.Resources.ic_edit;
			this.editStagesParticipations.Name = "editStagesParticipations";
			this.editStagesParticipations.Size = new System.Drawing.Size(55, 20);
			this.editStagesParticipations.Text = "Edit";
			this.editStagesParticipations.Click += new System.EventHandler(this.EditStagesParticipations_Click);
			// 
			// refreshStagesParticipations
			// 
			this.refreshStagesParticipations.Image = global::YACM.Properties.Resources.ic_refresh;
			this.refreshStagesParticipations.Name = "refreshStagesParticipations";
			this.refreshStagesParticipations.Size = new System.Drawing.Size(73, 20);
			this.refreshStagesParticipations.Text = "Update";
			this.refreshStagesParticipations.Click += new System.EventHandler(this.RefreshStagesParticipations_Click);
			// 
			// stagesParticipationsList
			// 
			this.stagesParticipationsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.stagesParticipationsList.Location = new System.Drawing.Point(3, 27);
			this.stagesParticipationsList.Name = "stagesParticipationsList";
			this.stagesParticipationsList.Size = new System.Drawing.Size(702, 513);
			this.stagesParticipationsList.TabIndex = 10;
			this.stagesParticipationsList.UseCompatibleStateImageBehavior = false;
			this.stagesParticipationsList.View = System.Windows.Forms.View.Details;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1445, 742);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip);
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
			this.Equipment.ResumeLayout(false);
			this.Equipment.PerformLayout();
			this.equipamentActions.ResumeLayout(false);
			this.equipamentActions.PerformLayout();
			this.Participants.ResumeLayout(false);
			this.Participants.PerformLayout();
			this.participantsActions.ResumeLayout(false);
			this.participantsActions.PerformLayout();
			this.Prizes.ResumeLayout(false);
			this.Prizes.PerformLayout();
			this.prizeActions.ResumeLayout(false);
			this.prizeActions.PerformLayout();
			this.Sponsors.ResumeLayout(false);
			this.Sponsors.PerformLayout();
			this.sponsorsActions.ResumeLayout(false);
			this.sponsorsActions.PerformLayout();
			this.Stages.ResumeLayout(false);
			this.Stages.PerformLayout();
			this.stagesActions.ResumeLayout(false);
			this.stagesActions.PerformLayout();
			this.Teams.ResumeLayout(false);
			this.Teams.PerformLayout();
			this.teamActions.ResumeLayout(false);
			this.teamActions.PerformLayout();
			this.Documents.ResumeLayout(false);
			this.Documents.PerformLayout();
			this.documentsActions.ResumeLayout(false);
			this.documentsActions.PerformLayout();
			this.eventsActions.ResumeLayout(false);
			this.eventsActions.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.StagesParticipants.ResumeLayout(false);
			this.StagesParticipants.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageManager;
		private System.Windows.Forms.TabPage tabPageParticipant;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel debugInfo;
		private System.Windows.Forms.ToolStripStatusLabel copyrightInfo;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
		private System.Windows.Forms.MenuStrip equipamentActions;
		private System.Windows.Forms.ToolStripMenuItem addEquipment;
		private System.Windows.Forms.ToolStripMenuItem editEquipment;
		private System.Windows.Forms.ToolStripMenuItem refreshEquipment;
		private System.Windows.Forms.TabPage Prizes;
		private System.Windows.Forms.TabPage Sponsors;
		private System.Windows.Forms.TabPage Stages;
		private System.Windows.Forms.TabPage Teams;
		private System.Windows.Forms.TabPage Documents;
		private System.Windows.Forms.TabPage Statistics;
		private System.Windows.Forms.ListView participantsList;
		private System.Windows.Forms.MenuStrip participantsActions;
		private System.Windows.Forms.ToolStripMenuItem addParticipants;
		private System.Windows.Forms.ToolStripMenuItem editParticipants;
		private System.Windows.Forms.ToolStripMenuItem refreshParticipants;
		private System.Windows.Forms.ListView prizesList;
		private System.Windows.Forms.MenuStrip prizeActions;
		private System.Windows.Forms.ToolStripMenuItem addPrizes;
		private System.Windows.Forms.ToolStripMenuItem editPrizes;
		private System.Windows.Forms.ToolStripMenuItem refreshPrizes;
		private System.Windows.Forms.ListView sponsorsList;
		private System.Windows.Forms.MenuStrip sponsorsActions;
		private System.Windows.Forms.ToolStripMenuItem addSponsors;
		private System.Windows.Forms.ToolStripMenuItem editSponsors;
		private System.Windows.Forms.ToolStripMenuItem refreshSponsors;
		private System.Windows.Forms.ListView stagesList;
		private System.Windows.Forms.MenuStrip stagesActions;
		private System.Windows.Forms.ToolStripMenuItem addStages;
		private System.Windows.Forms.ToolStripMenuItem editStages;
		private System.Windows.Forms.ToolStripMenuItem refreshStages;
		private System.Windows.Forms.ListView teamsList;
		private System.Windows.Forms.MenuStrip teamActions;
		private System.Windows.Forms.ToolStripMenuItem addTeams;
		private System.Windows.Forms.ToolStripMenuItem editTeams;
		private System.Windows.Forms.ToolStripMenuItem refreshTeams;
		private System.Windows.Forms.ListView documentsList;
		private System.Windows.Forms.MenuStrip documentsActions;
		private System.Windows.Forms.ToolStripMenuItem addDocuments;
		private System.Windows.Forms.ToolStripMenuItem editDocuments;
		private System.Windows.Forms.ToolStripMenuItem refreshDocuments;
		private System.Windows.Forms.ToolStripMenuItem logout;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.TabPage StagesParticipants;
		private System.Windows.Forms.ListView stagesParticipationsList;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addStagesParticipations;
		private System.Windows.Forms.ToolStripMenuItem editStagesParticipations;
		private System.Windows.Forms.ToolStripMenuItem refreshStagesParticipations;
	}
}