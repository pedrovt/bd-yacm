namespace YACM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of E method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			E.panel1 = new System.Windows.Forms.Panel();
			E.menuStrip1 = new System.Windows.Forms.MenuStrip();
			E.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			E.loadCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			E.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			E.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			E.menuStrip1.SuspendLayout();
			E.SuspendLayout();
			// 
			// panel1
			// 
			E.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			E.panel1.Location = new System.Drawing.Point(0, 24);
			E.panel1.Name = "panel1";
			E.panel1.Size = new System.Drawing.Size(783, 432);
			E.panel1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			E.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
			E.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            E.fileToolStripMenuItem});
			E.menuStrip1.Location = new System.Drawing.Point(0, 0);
			E.menuStrip1.Name = "menuStrip1";
			E.menuStrip1.Size = new System.Drawing.Size(783, 24);
			E.menuStrip1.TabIndex = 1;
			E.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			E.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            E.loadCustomersToolStripMenuItem,
            E.toolStripSeparator1,
            E.exitToolStripMenuItem});
			E.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			E.fileToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
			E.fileToolStripMenuItem.Text = "File";
			// 
			// loadCustomersToolStripMenuItem
			// 
			E.loadCustomersToolStripMenuItem.Name = "loadCustomersToolStripMenuItem";
			E.loadCustomersToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			E.loadCustomersToolStripMenuItem.Text = "Load Customers";
			E.loadCustomersToolStripMenuItem.Click += new System.EventHandler(E.loadCustomersToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			E.toolStripSeparator1.Name = "toolStripSeparator1";
			E.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
			// 
			// exitToolStripMenuItem
			// 
			E.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			E.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			E.exitToolStripMenuItem.Text = "Exit";
			E.exitToolStripMenuItem.Click += new System.EventHandler(E.exitToolStripMenuItem_Click);
			// 
			// Form1
			// 
			E.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			E.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			E.ClientSize = new System.Drawing.Size(783, 456);
			E.Controls.Add(E.panel1);
			E.Controls.Add(E.menuStrip1);
			E.Icon = ((System.Drawing.Icon)(resources.GetObject("$E.Icon")));
			E.MainMenuStrip = E.menuStrip1;
			E.Name = "Form1";
			E.Text = "YACM";
			E.Load += new System.EventHandler(E.Form1_Load);
			E.menuStrip1.ResumeLayout(false);
			E.menuStrip1.PerformLayout();
			E.ResumeLayout(false);
			E.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

