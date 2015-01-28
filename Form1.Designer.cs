namespace PasswordVault
{
	partial class MainForm
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
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePassMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolButton = new System.Windows.Forms.ToolStripButton();
            this.openToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyUserToolButton = new System.Windows.Forms.ToolStripButton();
            this.copyPasswordToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.urlToolButton = new System.Windows.Forms.ToolStripButton();
            this.filenamePanel = new System.Windows.Forms.Panel();
            this.vaultLabel = new System.Windows.Forms.Label();
            this.informCreateLabel = new System.Windows.Forms.Label();
            this.verifyTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeImages = new System.Windows.Forms.ImageList(this.components);
            this.nameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.verifyLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.urlButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panelDescTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelAppTextBox = new System.Windows.Forms.TextBox();
            this.panelUrlTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPasswordTextBox = new System.Windows.Forms.TextBox();
            this.panelUserTextBox = new System.Windows.Forms.TextBox();
            this.panelGroupTextBox = new System.Windows.Forms.TextBox();
            this.panelNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.changePassLabel = new System.Windows.Forms.Label();
            this.changePassTextbox = new System.Windows.Forms.TextBox();
            this.changePassButton = new System.Windows.Forms.Button();
            this.cancelPassButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.passwordButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.filenamePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(427, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newMenuItem.Image")));
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newMenuItem.Text = "New";
            this.newMenuItem.Click += new System.EventHandler(this.newMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openMenuItem.Image")));
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMenuItem.Image")));
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsMenuItem.Text = "Save As...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePassMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editMenuItem.Text = "Edit";
            // 
            // changePassMenuItem
            // 
            this.changePassMenuItem.Name = "changePassMenuItem";
            this.changePassMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePassMenuItem.Text = "Change Password";
            this.changePassMenuItem.Click += new System.EventHandler(this.changePassMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolButton,
            this.openToolButton,
            this.toolStripSeparator3,
            this.saveToolButton,
            this.toolStripSeparator4,
            this.copyUserToolButton,
            this.copyPasswordToolButton,
            this.toolStripSeparator5,
            this.urlToolButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(427, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolButton
            // 
            this.newToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolButton.Image")));
            this.newToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolButton.Name = "newToolButton";
            this.newToolButton.Size = new System.Drawing.Size(23, 22);
            this.newToolButton.Text = "toolStripButton1";
            this.newToolButton.ToolTipText = "Create a new password vault";
            this.newToolButton.Click += new System.EventHandler(this.newToolButton_Click);
            // 
            // openToolButton
            // 
            this.openToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolButton.Image")));
            this.openToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolButton.Name = "openToolButton";
            this.openToolButton.Size = new System.Drawing.Size(23, 22);
            this.openToolButton.Text = "toolStripButton1";
            this.openToolButton.ToolTipText = "Open an existing password vault";
            this.openToolButton.Click += new System.EventHandler(this.openToolButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolButton
            // 
            this.saveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolButton.Image")));
            this.saveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolButton.Name = "saveToolButton";
            this.saveToolButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolButton.Text = "toolStripButton2";
            this.saveToolButton.ToolTipText = "Save your current password vault";
            this.saveToolButton.Click += new System.EventHandler(this.saveToolButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // copyUserToolButton
            // 
            this.copyUserToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyUserToolButton.Image = ((System.Drawing.Image)(resources.GetObject("copyUserToolButton.Image")));
            this.copyUserToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyUserToolButton.Name = "copyUserToolButton";
            this.copyUserToolButton.Size = new System.Drawing.Size(23, 22);
            this.copyUserToolButton.ToolTipText = "Copies the selected user name to the clipboard for pasting";
            this.copyUserToolButton.Click += new System.EventHandler(this.copyUserToolButton_Click);
            // 
            // copyPasswordToolButton
            // 
            this.copyPasswordToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyPasswordToolButton.Image = ((System.Drawing.Image)(resources.GetObject("copyPasswordToolButton.Image")));
            this.copyPasswordToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyPasswordToolButton.Name = "copyPasswordToolButton";
            this.copyPasswordToolButton.Size = new System.Drawing.Size(23, 22);
            this.copyPasswordToolButton.ToolTipText = "Copies the selected password to the clipboard for pasting";
            this.copyPasswordToolButton.Click += new System.EventHandler(this.copyPasswordToolButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // urlToolButton
            // 
            this.urlToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.urlToolButton.Image = ((System.Drawing.Image)(resources.GetObject("urlToolButton.Image")));
            this.urlToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.urlToolButton.Name = "urlToolButton";
            this.urlToolButton.Size = new System.Drawing.Size(23, 22);
            this.urlToolButton.ToolTipText = "Launches firefox with the selected url";
            this.urlToolButton.Click += new System.EventHandler(this.urlToolButton_Click);
            // 
            // filenamePanel
            // 
            this.filenamePanel.BackColor = System.Drawing.Color.Silver;
            this.filenamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filenamePanel.Controls.Add(this.vaultLabel);
            this.filenamePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filenamePanel.Location = new System.Drawing.Point(0, 348);
            this.filenamePanel.Name = "filenamePanel";
            this.filenamePanel.Size = new System.Drawing.Size(427, 25);
            this.filenamePanel.TabIndex = 2;
            // 
            // vaultLabel
            // 
            this.vaultLabel.Location = new System.Drawing.Point(4, 4);
            this.vaultLabel.Name = "vaultLabel";
            this.vaultLabel.Size = new System.Drawing.Size(416, 17);
            this.vaultLabel.TabIndex = 0;
            this.vaultLabel.Text = "No password vault loaded.";
            // 
            // informCreateLabel
            // 
            this.informCreateLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.informCreateLabel.Location = new System.Drawing.Point(110, 75);
            this.informCreateLabel.Name = "informCreateLabel";
            this.informCreateLabel.Size = new System.Drawing.Size(200, 56);
            this.informCreateLabel.TabIndex = 3;
            this.informCreateLabel.Text = "Create a new password vault or load an existing vault from the menu";
            this.informCreateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.informCreateLabel.Visible = false;
            // 
            // verifyTextbox
            // 
            this.verifyTextbox.Location = new System.Drawing.Point(110, 130);
            this.verifyTextbox.MaxLength = 32;
            this.verifyTextbox.Name = "verifyTextbox";
            this.verifyTextbox.PasswordChar = '*';
            this.verifyTextbox.Size = new System.Drawing.Size(200, 20);
            this.verifyTextbox.TabIndex = 11;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(110, 104);
            this.passwordTextbox.MaxLength = 32;
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(200, 20);
            this.passwordTextbox.TabIndex = 10;
            this.passwordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextbox_KeyPress);
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(110, 75);
            this.nameTextbox.MaxLength = 32;
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(200, 20);
            this.nameTextbox.TabIndex = 9;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(326, 89);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(89, 47);
            this.createButton.TabIndex = 10;
            this.createButton.TabStop = false;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // treeView
            // 
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeImages;
            this.treeView.Location = new System.Drawing.Point(238, 55);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(184, 287);
            this.treeView.TabIndex = 11;
            this.treeView.TabStop = false;
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // treeImages
            // 
            this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
            this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImages.Images.SetKeyName(0, "book_reportHS.png");
            this.treeImages.Images.SetKeyName(1, "GoToNextHS.png");
            // 
            // nameLabel
            // 
            this.nameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nameLabel.Location = new System.Drawing.Point(12, 75);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(92, 19);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordLabel
            // 
            this.passwordLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.passwordLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.passwordLabel.Location = new System.Drawing.Point(12, 103);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(92, 19);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // verifyLabel
            // 
            this.verifyLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verifyLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.verifyLabel.Location = new System.Drawing.Point(12, 131);
            this.verifyLabel.Name = "verifyLabel";
            this.verifyLabel.Size = new System.Drawing.Size(92, 19);
            this.verifyLabel.TabIndex = 6;
            this.verifyLabel.Text = "Verify Password";
            this.verifyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.passwordButton);
            this.mainPanel.Controls.Add(this.urlButton);
            this.mainPanel.Controls.Add(this.cancelButton);
            this.mainPanel.Controls.Add(this.submitButton);
            this.mainPanel.Controls.Add(this.label7);
            this.mainPanel.Controls.Add(this.panelDescTextBox);
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.panelAppTextBox);
            this.mainPanel.Controls.Add(this.panelUrlTextBox);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.panelPasswordTextBox);
            this.mainPanel.Controls.Add(this.panelUserTextBox);
            this.mainPanel.Controls.Add(this.panelGroupTextBox);
            this.mainPanel.Controls.Add(this.panelNameTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Location = new System.Drawing.Point(5, 85);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(227, 257);
            this.mainPanel.TabIndex = 12;
            // 
            // urlButton
            // 
            this.urlButton.Location = new System.Drawing.Point(5, 110);
            this.urlButton.Name = "urlButton";
            this.urlButton.Size = new System.Drawing.Size(62, 20);
            this.urlButton.TabIndex = 16;
            this.urlButton.Text = "URL";
            this.urlButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.urlButton.UseVisualStyleBackColor = true;
            this.urlButton.Click += new System.EventHandler(this.urlButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(113, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.TabStop = false;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(5, 225);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(105, 23);
            this.submitButton.TabIndex = 14;
            this.submitButton.TabStop = false;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Description";
            // 
            // panelDescTextBox
            // 
            this.panelDescTextBox.Location = new System.Drawing.Point(71, 162);
            this.panelDescTextBox.Multiline = true;
            this.panelDescTextBox.Name = "panelDescTextBox";
            this.panelDescTextBox.Size = new System.Drawing.Size(149, 57);
            this.panelDescTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Application";
            // 
            // panelAppTextBox
            // 
            this.panelAppTextBox.Location = new System.Drawing.Point(71, 136);
            this.panelAppTextBox.Name = "panelAppTextBox";
            this.panelAppTextBox.Size = new System.Drawing.Size(149, 20);
            this.panelAppTextBox.TabIndex = 9;
            // 
            // panelUrlTextBox
            // 
            this.panelUrlTextBox.Location = new System.Drawing.Point(71, 110);
            this.panelUrlTextBox.Name = "panelUrlTextBox";
            this.panelUrlTextBox.Size = new System.Drawing.Size(149, 20);
            this.panelUrlTextBox.TabIndex = 8;
            this.panelUrlTextBox.TextChanged += new System.EventHandler(this.panelUrlTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User-Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Group";
            // 
            // panelPasswordTextBox
            // 
            this.panelPasswordTextBox.Location = new System.Drawing.Point(71, 84);
            this.panelPasswordTextBox.Name = "panelPasswordTextBox";
            this.panelPasswordTextBox.Size = new System.Drawing.Size(149, 20);
            this.panelPasswordTextBox.TabIndex = 4;
            this.panelPasswordTextBox.TextChanged += new System.EventHandler(this.panelPasswordTextBox_TextChanged);
            // 
            // panelUserTextBox
            // 
            this.panelUserTextBox.Location = new System.Drawing.Point(71, 58);
            this.panelUserTextBox.Name = "panelUserTextBox";
            this.panelUserTextBox.Size = new System.Drawing.Size(149, 20);
            this.panelUserTextBox.TabIndex = 3;
            this.panelUserTextBox.TextChanged += new System.EventHandler(this.panelUserTextBox_TextChanged);
            // 
            // panelGroupTextBox
            // 
            this.panelGroupTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.panelGroupTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.panelGroupTextBox.Location = new System.Drawing.Point(71, 32);
            this.panelGroupTextBox.Name = "panelGroupTextBox";
            this.panelGroupTextBox.Size = new System.Drawing.Size(149, 20);
            this.panelGroupTextBox.TabIndex = 2;
            // 
            // panelNameTextBox
            // 
            this.panelNameTextBox.Location = new System.Drawing.Point(71, 6);
            this.panelNameTextBox.Name = "panelNameTextBox";
            this.panelNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.panelNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(5, 55);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(69, 24);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(163, 55);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(69, 24);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(84, 55);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(69, 24);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(326, 89);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(89, 47);
            this.loadButton.TabIndex = 13;
            this.loadButton.TabStop = false;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // changePassLabel
            // 
            this.changePassLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.changePassLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePassLabel.Location = new System.Drawing.Point(12, 75);
            this.changePassLabel.Name = "changePassLabel";
            this.changePassLabel.Size = new System.Drawing.Size(92, 19);
            this.changePassLabel.TabIndex = 14;
            this.changePassLabel.Text = "Old Password";
            this.changePassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changePassTextbox
            // 
            this.changePassTextbox.Location = new System.Drawing.Point(110, 75);
            this.changePassTextbox.MaxLength = 32;
            this.changePassTextbox.Name = "changePassTextbox";
            this.changePassTextbox.PasswordChar = '*';
            this.changePassTextbox.Size = new System.Drawing.Size(200, 20);
            this.changePassTextbox.TabIndex = 15;
            // 
            // changePassButton
            // 
            this.changePassButton.Location = new System.Drawing.Point(326, 75);
            this.changePassButton.Name = "changePassButton";
            this.changePassButton.Size = new System.Drawing.Size(89, 46);
            this.changePassButton.TabIndex = 16;
            this.changePassButton.TabStop = false;
            this.changePassButton.Text = "Apply";
            this.changePassButton.UseVisualStyleBackColor = true;
            this.changePassButton.Click += new System.EventHandler(this.changePassButton_Click);
            // 
            // cancelPassButton
            // 
            this.cancelPassButton.Location = new System.Drawing.Point(326, 126);
            this.cancelPassButton.Name = "cancelPassButton";
            this.cancelPassButton.Size = new System.Drawing.Size(89, 24);
            this.cancelPassButton.TabIndex = 17;
            this.cancelPassButton.TabStop = false;
            this.cancelPassButton.Text = "Cancel";
            this.cancelPassButton.UseVisualStyleBackColor = true;
            this.cancelPassButton.Click += new System.EventHandler(this.cancelPassButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AcceptsReturn = true;
            this.searchTextBox.Location = new System.Drawing.Point(238, 29);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(184, 20);
            this.searchTextBox.TabIndex = 18;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(182, 32);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(50, 13);
            this.searchLabel.TabIndex = 19;
            this.searchLabel.Text = "Search...";
            // 
            // passwordButton
            // 
            this.passwordButton.Location = new System.Drawing.Point(5, 84);
            this.passwordButton.Name = "passwordButton";
            this.passwordButton.Size = new System.Drawing.Size(62, 20);
            this.passwordButton.TabIndex = 17;
            this.passwordButton.Text = "Password";
            this.passwordButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.passwordButton.UseVisualStyleBackColor = true;
            this.passwordButton.Click += new System.EventHandler(this.passwordButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 373);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.cancelPassButton);
            this.Controls.Add(this.changePassButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.informCreateLabel);
            this.Controls.Add(this.verifyTextbox);
            this.Controls.Add(this.verifyLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.filenamePanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.changePassLabel);
            this.Controls.Add(this.changePassTextbox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Password Vault";
            this.TopMost = true;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.filenamePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton newToolButton;
		private System.Windows.Forms.Panel filenamePanel;
		private System.Windows.Forms.Label informCreateLabel;
		private System.Windows.Forms.Label vaultLabel;
		private System.Windows.Forms.TextBox verifyTextbox;
		private System.Windows.Forms.TextBox passwordTextbox;
		private System.Windows.Forms.TextBox nameTextbox;
		private System.Windows.Forms.Button createButton;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Label verifyLabel;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox panelPasswordTextBox;
		private System.Windows.Forms.TextBox panelUserTextBox;
		private System.Windows.Forms.TextBox panelGroupTextBox;
		private System.Windows.Forms.TextBox panelNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox panelAppTextBox;
        private System.Windows.Forms.TextBox panelUrlTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox panelDescTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button loadButton;
		private System.Windows.Forms.ToolStripButton openToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton saveToolButton;
		private System.Windows.Forms.ImageList treeImages;
		private System.Windows.Forms.Button urlButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton copyUserToolButton;
		private System.Windows.Forms.ToolStripButton copyPasswordToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton urlToolButton;
		private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePassMenuItem;
        private System.Windows.Forms.Label changePassLabel;
        private System.Windows.Forms.TextBox changePassTextbox;
        private System.Windows.Forms.Button changePassButton;
        private System.Windows.Forms.Button cancelPassButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button passwordButton;
	}
}

