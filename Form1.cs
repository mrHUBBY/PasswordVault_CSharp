using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace PasswordVault
{
	// Main form class that handles UI and interfacing to the vault
	public partial class MainForm : Form
	{
		// Compare function for tree sorting
		public class TreeViewComparer : System.Collections.IComparer
		{
			private SortMethodEnum _method;
			public SortMethodEnum Method
			{
				get { return _method; }
				set { _method = value; }
			}
			public enum SortMethodEnum
			{
				Ascending,
				Descending
			}

			// Compare function, in our case compares strings alphabetically
			public int Compare(object o1, object o2)
			{
				TreeNode n1 = o1 as TreeNode;
				TreeNode n2 = o2 as TreeNode;

				if (Method == SortMethodEnum.Ascending)
				{
					return n1.Text.CompareTo(n2.Text);
				}
				else
				{
					return n2.Text.CompareTo(n1.Text);
				}
			}
		};

		// Our vault class
		private Vault _vault;
		public Vault Vault
		{
			get { return _vault; }
			set { _vault = value; }
		}

		// Enum For various UI states
		private UIState _state;
		public enum UIState
		{
			InformOfNewLoad,
			CreateNew,
			VaultView,
			RequestVaultPassword,
            ChangeVaultPassword,
		}

		// Error states to handle
		public enum Error
		{
			InvalidName,
			InvalidPassword,
			VerifyPassword,
			InvalidItemName,
			InvalidItemGroup,
			UnexpectedError,
			VaultLoad,
			FileExists,
            OldPasswordMatch,
		}

		// Mode of data change
		private Mode _mode;
		public enum Mode
		{
			Add,
			RemoveItem,
			RemoveGroup,
			EditItem,
			EditGroup,
		}

		// Name returned by openfiledialog
		private String _vaultToLoad;
		private String _vaultToLoadShorthand;

		// The heights of our main form
		private int _normalHeight;
		private int _extendHeight;

		// Our item in question
		private TreeNode _nodeToEdit;

        // Used when searching for items
        private List<TreeNode> _searchResults = new List<TreeNode>();
        private string _searchString = "";

        // Xml config file
        public static String ConfigFile = "PasswordVaultConfig.xml";

		// Constructor
		public MainForm()
		{
			InitializeComponent();
			_normalHeight = 233;
			_extendHeight = 405;
			_vaultToLoad = null;
			_vaultToLoadShorthand = null;
			SetUIState(UIState.InformOfNewLoad);
			treeView.TreeViewNodeSorter = new TreeViewComparer();
			editButton.Enabled = false;
			removeButton.Enabled = false;
			copyPasswordToolButton.Enabled = false;
			copyUserToolButton.Enabled = false;
			urlToolButton.Enabled = false;
            changePassMenuItem.Enabled = false;

            // Try to load the last opened vault
            LoadConfigFile();

            // Catch the form exiting so we can prompt the user for saving
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            // start with the search textbox focused
            searchTextBox.Focus();
		}

        // prompt the user for saving
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !PromptForSave();
        }

		// New button from tool bar
		private void newToolButton_Click(object sender, EventArgs e)
		{
			NewVaultRequest();
		}

		// New button from file menu
		private void newMenuItem_Click(object sender, EventArgs e)
		{
			NewVaultRequest();
		}

		// Exit the application when exit is chosen from the file menu
		private void exitMenuItem_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		// Creates a new vault
		private void CreateVault(String name, String fullpath, String password)
		{
			// Init the vault
			Vault = new Vault();
			Vault.Name = name;
			Vault.FullPath = fullpath;
			Vault.Password = password;
			Vault.Form = this;
			Vault.StatusChange += new Vault.StatusChangeHandler(this.vault_status);
			Vault.Status = Vault.VaultStatus.Empty;

			// Set the vault name in the UI
			vaultLabel.Text = "Vault: " + Vault.Name;

			// Clear text on UI
			ClearVaultViewText();
		}

		// Shows/Hides certain UI elements
		private void SetUIState(UIState state)
		{
			// Affect the appearance of the UI based on state
			switch (state)
			{
				case UIState.InformOfNewLoad:
					passwordLabel.Visible = false;
					nameLabel.Visible = false;
					verifyLabel.Visible = false;
					passwordTextbox.Visible = false;
					nameTextbox.Visible = false;
					verifyTextbox.Visible = false;
					createButton.Visible = false;
					loadButton.Visible = false;
					informCreateLabel.Visible = true;
					treeView.Visible = false;
					mainPanel.Visible = false;
					addButton.Visible = false;
					removeButton.Visible = false;
					editButton.Visible = false;
					this.Height = _normalHeight;
					saveMenuItem.Enabled = false;
					saveAsMenuItem.Enabled = false;
					saveToolButton.Enabled = false;
                    changePassLabel.Visible = false;
                    changePassTextbox.Visible = false;
                    changePassButton.Visible = false;
                    cancelPassButton.Visible = false;
                    searchTextBox.Visible = false;
                    searchLabel.Visible = false;
					break;
				case UIState.CreateNew:
					passwordLabel.Visible = true;
					nameLabel.Visible = true;
					verifyLabel.Visible = true;
					passwordTextbox.Visible = true;
					nameTextbox.Visible = true;
					nameTextbox.Enabled = false;
					verifyTextbox.Visible = true;
					createButton.Visible = true;
					loadButton.Visible = false;
					informCreateLabel.Visible = false;
					passwordTextbox.Text = "";
					nameTextbox.Text = "";
					verifyTextbox.Text = "";
					treeView.Visible = false;
					mainPanel.Visible = false;
					addButton.Visible = false;
					removeButton.Visible = false;
					editButton.Visible = false;
					this.Height = _normalHeight;
					saveMenuItem.Enabled = false;
					saveAsMenuItem.Enabled = false;
					saveToolButton.Enabled = false;
                    changePassLabel.Visible = false;
                    changePassTextbox.Visible = false;
                    changePassMenuItem.Enabled = false;
                    changePassButton.Visible = false;
                    cancelPassButton.Visible = false;
                    searchTextBox.Visible = false;
                    searchLabel.Visible = false;
					break;
				case UIState.VaultView:
					passwordLabel.Visible = false;
					nameLabel.Visible = false;
					verifyLabel.Visible = false;
					passwordTextbox.Visible = false;
					nameTextbox.Visible = false;
					verifyTextbox.Visible = false;
					createButton.Visible = false;
					loadButton.Visible = false;
					informCreateLabel.Visible = false;
					treeView.Visible = true;
					mainPanel.Visible = true;
					addButton.Visible = true;
					removeButton.Visible = true;
					editButton.Visible = true;
					this.Height = _extendHeight;
					mainPanel.Enabled = false;
                    changePassLabel.Visible = false;
                    changePassTextbox.Visible = false;
                    changePassMenuItem.Enabled = true;
                    changePassButton.Visible = false;
                    cancelPassButton.Visible = false;
                    searchTextBox.Visible = true;
                    searchLabel.Visible = true;
                    searchTextBox.Focus();
					break;
				case UIState.RequestVaultPassword:
					passwordLabel.Visible = true;
					nameLabel.Visible = true;
					verifyLabel.Visible = false;
					passwordTextbox.Visible = true;
					nameTextbox.Visible = true;
					verifyTextbox.Visible = false;
					informCreateLabel.Visible = false;
					passwordTextbox.Text = "";
					nameTextbox.Text = _vaultToLoadShorthand;
					nameTextbox.Enabled = false;
					createButton.Visible = false;
					loadButton.Visible = true;
					treeView.Visible = false;
					mainPanel.Visible = false;
					addButton.Visible = false;
					removeButton.Visible = false;
					editButton.Visible = false;
					this.Height = _normalHeight;
					saveMenuItem.Enabled = false;
					saveAsMenuItem.Enabled = false;
					saveToolButton.Enabled = false;
                    changePassLabel.Visible = false;
                    changePassTextbox.Visible = false;
                    changePassMenuItem.Enabled = false;
                    changePassButton.Visible = false;
                    cancelPassButton.Visible = false;
                    searchTextBox.Visible = false;
                    searchLabel.Visible = false;
					break;
                case UIState.ChangeVaultPassword:
                    changePassLabel.Visible = true;
                    changePassTextbox.Visible = true;
                    passwordLabel.Visible = true;
                    nameLabel.Visible = false;
                    verifyLabel.Visible = false;
                    passwordTextbox.Visible = true;
                    nameTextbox.Visible = false;
                    verifyTextbox.Visible = false;
                    informCreateLabel.Visible = false;
                    changePassTextbox.Text = "";
                    passwordTextbox.Text = "";
                    createButton.Visible = false;
                    loadButton.Visible = false;
                    treeView.Visible = false;
                    mainPanel.Visible = false;
                    addButton.Visible = false;
                    removeButton.Visible = false;
                    editButton.Visible = false;
                    this.Height = _normalHeight;
                    saveMenuItem.Enabled = false;
                    saveAsMenuItem.Enabled = false;
                    saveToolButton.Enabled = false;
                    verifyLabel.Visible = true;
                    verifyTextbox.Visible = true;
                    verifyTextbox.Text = "";
                    changePassMenuItem.Enabled = false;
                    changePassButton.Visible = true;
                    cancelPassButton.Visible = true;
                    searchTextBox.Visible = false;
                    searchLabel.Visible = false;
                    break;
				default:
					return;
			}

			// Store our current state
			_state = state;
		}

		// Create the vault by gathering name info from text-edits
		private void createButton_Click(object sender, EventArgs e)
		{
			String name = nameTextbox.Text;
			String pass = passwordTextbox.Text;
			String verify = verifyTextbox.Text;

			// Too short of password
			if (pass.Length == 0)
			{
				ShowError(Error.InvalidPassword);
			}
			// The password and verify do not match each other
			else if (pass != verify)
			{
				ShowError(Error.VerifyPassword);
			}
			// All is good, Create our new vault
			else
			{
				CreateVault("", "", pass);
				SetUIState(UIState.VaultView);

				// Refresh the tree
				resetTreeView();
			}
		}

		// Brings up a message box informing the user of the problem
		public void ShowError(Error error)
		{
			String caption;
			String msg;

			// Handle the specific error
			switch (error)
			{
				case Error.InvalidName:
					msg = "Invalid name used!";
					caption = "Password Vault Error";
					break;
				case Error.InvalidPassword:
					msg = "Invalid password used!";
					caption = "Password Vault Error";
					break;
				case Error.VerifyPassword:
					msg = "The password does not match, please re-verify.";
					caption = "Password Vault Error";
					break;
				case Error.InvalidItemName:
					msg = "You must define a name for this entry!";
					caption = "Password Vault Error";
					break;
				case Error.InvalidItemGroup:
					msg = "You must define a group that the entry belongs to!";
					caption = "Password Vault Error";
					break;
				case Error.UnexpectedError:
					msg = "An unexpected error has occurred!?";
					caption = "Password Vault Error";
					break;
				case Error.VaultLoad:
					msg = "Unable to load the requested vault, make sure the password entered is correct.";
					caption = "Password Vault Error";
					break;
				case Error.FileExists:
					msg = "The file \"" + _vaultToLoad + "\" does not exist!";
					caption = "Password Vault Error";
					break;
                case Error.OldPasswordMatch:
                    msg = "The old password specified does not match the current password for Vault: \"" + Vault.Name + "\"";
                    caption = "Password Vault Error";
                    break;
				default:
					msg = "";
					caption = "";
					break;
			}

			// Show the error
			MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// This will present the user with UI for creating a new vault and
		// determine if they should making any updates to their current data
		private void NewVaultRequest()
		{
			// Should we save
			if(!PromptForSave())
			{
				return;
			}

			// Reset the vault and give UI
			Vault = null;
			vaultLabel.Text = "No password vault loaded.";
			SetUIState(UIState.CreateNew);
		}

		// Brings up a save dialog and returns whether or not we should continue
		public bool PromptForSave()
		{
			// Check for an unsaved vault currently
			if (Vault != null && Vault.Status == Vault.VaultStatus.Touched)
			{
				DialogResult result = MessageBox.Show("Do you want to save your current changes?",
					"Password Vault Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				switch (result)
				{
					// Save then bring up the UI
					case DialogResult.Yes:
						SaveVault(false);
						break;
					// don't save
					case DialogResult.No:
						break;
					// Nothing to do here, return
					case DialogResult.Cancel:
						return false;
				}
			}

			// Yes, continue what we are doing
			return true;
		}

		// Handles updating UI when the vault changes status
		public void vault_status(Vault.VaultStatus status)
		{
			switch(status)
			{
				case Vault.VaultStatus.Empty:
					saveMenuItem.Enabled = false;
					saveAsMenuItem.Enabled = false;
					saveToolButton.Enabled = false;
					break;
				case Vault.VaultStatus.Touched:
					saveMenuItem.Enabled = true;
					saveAsMenuItem.Enabled = true;
					saveToolButton.Enabled = true;
					break;
				case Vault.VaultStatus.UpToDate:
					saveMenuItem.Enabled = true;
					saveAsMenuItem.Enabled = true;
					saveToolButton.Enabled = true;
                    SaveConfigFile();
					break;
			}
		}

		// The user wants to add some a password to the vault
		private void addButton_Click(object sender, EventArgs e)
		{
			// Set the data mode we are in
			_mode = Mode.Add;

			// Enable/Disable the appropriate UI
			mainPanel.Enabled = true;
			addButton.Enabled = false;
			InvalidateTreeSelection();

			// Enable all panel item
			panelNameTextBox.Enabled = true;
			panelGroupTextBox.Enabled = true;
			panelUserTextBox.Enabled = true;
			panelPasswordTextBox.Enabled = true;
			panelUrlTextBox.Enabled = true;
			panelAppTextBox.Enabled = true;
			panelDescTextBox.Enabled = true;

			ClearVaultViewText();
		}

		// The user wants to submit his info for addition to the vault
		private void submitButton_Click(object sender, EventArgs e)
		{
			SubmitUserRequest();
		}

		// Cancel the submission
		private void cancelButton_Click(object sender, EventArgs e)
		{
			// Enable/Disable the appropriate UI
			mainPanel.Enabled = false;
			addButton.Enabled = true;
			treeView.Enabled = true;
			InvalidateTreeSelection();

			ClearVaultViewText();
		}

		// Validates the panelTextBox entries making sure the user data is allowed
		private bool ValidateSubmission()
		{
			switch (_mode)
			{
				case Mode.Add:
					if (panelNameTextBox.Text.Length == 0)
					{
						ShowError(Error.InvalidItemName);
						return false;
					}
					else if (panelGroupTextBox.Text.Length == 0)
					{
						ShowError(Error.InvalidItemGroup);
						return false;
					}
					return true;
				case Mode.EditItem:
					if (panelNameTextBox.Text.Length == 0)
					{
						ShowError(Error.InvalidItemName);
						return false;
					}
					else if (panelGroupTextBox.Text.Length == 0)
					{
						ShowError(Error.InvalidItemGroup);
						return false;
					}
					return true;
				case Mode.EditGroup:
					if (panelGroupTextBox.Text.Length == 0)
					{
						ShowError(Error.InvalidItemGroup);
						return false;
					}
					return true;
				case Mode.RemoveItem:
					return true;
				case Mode.RemoveGroup:
					return true;
			}

			// Invalid mode, should never happen
			return false;
		}

		// Edit the element highlighted
		private void editButton_Click(object sender, EventArgs e)
		{
			// Assumes that _nodeToEdit was set in the treeViewSelection callback
			if (_nodeToEdit == null)
			{
				return;
			}

			// Set the data mode we are in
			_mode = _nodeToEdit.Tag is VaultItem ? Mode.EditItem : Mode.EditGroup;
			bool enableItemUI = _mode == Mode.EditItem;

			// Enable/Disable the appropriate UI
			mainPanel.Enabled = true;
			addButton.Enabled = false;
			treeView.Enabled = false;
			InvalidateTreeSelection();

			// Enable all panel item
			panelNameTextBox.Enabled = enableItemUI;
			panelGroupTextBox.Enabled = true;
			panelUserTextBox.Enabled = enableItemUI;
			panelPasswordTextBox.Enabled = enableItemUI;
			panelUrlTextBox.Enabled = enableItemUI;
			panelAppTextBox.Enabled = enableItemUI;
			panelDescTextBox.Enabled = enableItemUI;
		}

		// Removes the selected item from the list
		private void removeButton_Click(object sender, EventArgs e)
		{
			// Assumes that _nodeToEdit was set in the treeViewSelection callback
			if (_nodeToEdit == null)
			{
				return;
			}

			// Set our mode
			_mode = _nodeToEdit.Tag is VaultItem ? Mode.RemoveItem : Mode.RemoveGroup;

			DialogResult result = DialogResult.None;
			String msg = null;

			// Remove an item
			if(_mode == Mode.RemoveItem)
			{
				// Inform the user of their action
				msg = "Are you sure you want to remove the entry \"" + (_nodeToEdit.Tag as VaultItem).Name + "\"?";
				
			}
			// Remove a group
			else if(_mode == Mode.RemoveGroup)
			{
				msg = "Are you sure you want to remove the group \"" + _nodeToEdit.Text + 
					"\"?\nAll passwords under this group will be lost";
			}

			// Show the dlg
			result = MessageBox.Show(msg, "Password Vault Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			// The user cancelled
			if (result != DialogResult.Yes)
			{
				InvalidateTreeSelection();
				return;
			}

			// Emulate that the click button was pressed
			SubmitUserRequest();
		}

		// Resets the tree and user selection to none
		private void InvalidateTreeSelection()
		{
			editButton.Enabled = false;
			removeButton.Enabled = false;
			treeView.SelectedNode = null;
			treeView.Invalidate();
		}

		// Runs through all items in the vault and inserts them into the tree control
		private void resetTreeView()
		{
			// There could be some optimization done to prevent the entire
			// tree from rebuilding, but in most cases, there will only be 
			// a hand full amount of passwords stored, and so rebuilding the
			// tree is probably a negligible thing

			// Disable drawing as data changes
			treeView.BeginUpdate();

			// Reset the tree
			treeView.Nodes.Clear();

			// Add all vault items to the tree
			foreach (VaultItem item in Vault.Items)
			{
				// Look for this group already existing in the tree
				TreeNode group = null;
				foreach (TreeNode n in treeView.Nodes)
				{
					// We have a node in the tree for group already
					if(n.Text == item.Group)
					{
						group = n;
						break;
					}
				}

				// Create the group if we didn't find one
				if(group == null)
				{
					group = new TreeNode();
					group.Name = "Group";
					group.Tag = null;
					group.Text = item.Group;
					group.ImageIndex = 0;
					group.SelectedImageIndex = 0;

					// Add the group to the tree root
					treeView.Nodes.Add(group);
				}

				// Create our item node
				TreeNode node = new TreeNode();
				node.Name = item.Name;
				node.Tag = item;
				node.Text = item.Name;
				node.ImageIndex = 1;
				node.SelectedImageIndex = 1;

				// Add to the group
				group.Nodes.Add(node);
			}

			// Sort our elements alphabetically
			treeView.Sort();
			treeView.ExpandAll();
			treeView.EndUpdate();
			treeView.Invalidate();

			// Add the group names as a source for auto-complete
			// within the textbox
			foreach (TreeNode n in treeView.Nodes)
			{
				panelGroupTextBox.AutoCompleteCustomSource.Add(n.Text);
			}

            // we also want to update an autocomplete source for the search bar
            updateTreeViewCollection();
		}

		// Only accept actions from the mouse
		void treeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
            resetTreeViewColors();

			if(e.Action == TreeViewAction.Unknown)
			{
				e.Cancel = true;
			}
		}

		// If we get here then we are in business for selecting a node to use
		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			_nodeToEdit = e.Node;
			editButton.Enabled = _nodeToEdit != null;
			removeButton.Enabled = _nodeToEdit != null;

			// Populate the panel text boxes with data
			if(_nodeToEdit != null)
			{
				VaultItem item = _nodeToEdit.Tag is VaultItem ? _nodeToEdit.Tag as VaultItem : null;
				panelNameTextBox.Text = item != null ? item.Name : "";
				panelGroupTextBox.Text = item != null ? item.Group : _nodeToEdit.Text;
				panelUserTextBox.Text = item != null ? item.User : "";
				panelPasswordTextBox.Text = item != null ? item.Password : "";
				panelUrlTextBox.Text = item != null ? item.Url : "";
				panelAppTextBox.Text = item != null ? item.App : "";
				panelDescTextBox.Text = item != null ? item.Desc : "";
			}
		}

		// Actually performs the updating on the vault based on the user input
		private void SubmitUserRequest()
		{
			// Validate
			if (!ValidateSubmission())
			{
				return;
			}

			// Make the updates
			switch (_mode)
			{
				// Create a new item and add to the vault
				case Mode.Add:
					{
						VaultItem item = new VaultItem();
						item.Name = panelNameTextBox.Text;
						item.Group = panelGroupTextBox.Text;
						item.User = panelUserTextBox.Text;
						item.Password = panelPasswordTextBox.Text;
						item.Url = panelUrlTextBox.Text;
						item.App = panelAppTextBox.Text;
						item.Desc = panelDescTextBox.Text;
						Vault.Items.Add(item);
					}
					break;
				// Update an existing item
				case Mode.EditItem:
					{
						VaultItem item = _nodeToEdit.Tag as VaultItem;
						item.Name = panelNameTextBox.Text;
						item.Group = panelGroupTextBox.Text;
						item.User = panelUserTextBox.Text;
						item.Password = panelPasswordTextBox.Text;
						item.Url = panelUrlTextBox.Text;
						item.App = panelAppTextBox.Text;
						item.Desc = panelDescTextBox.Text;
					}
					break;
				// Rename a group
				case Mode.EditGroup:
					{
						// find all items under the currently named group and
						// rename to textbox value
						foreach (VaultItem item in Vault.Items)
						{
							if(item.Group == _nodeToEdit.Text)
							{
								item.Group = panelGroupTextBox.Text;
							}
						}
					}
					break;
				// Remove an item
				case Mode.RemoveItem:
					{
						VaultItem item = _nodeToEdit.Tag as VaultItem;
						Vault.Items.Remove(item);
					}
					break;
				// Remove an entire group
				case Mode.RemoveGroup:
					{
						// Remove all items under this group
						int iCount = 0;
						while (iCount != Vault.Items.Count)
						{
							if (Vault.Items[iCount].Group == _nodeToEdit.Text)
							{
								Vault.Items.Remove(Vault.Items[iCount]);
								iCount = 0;
							}
							else
							{
								iCount++;
							}
						}
					}
					break;
			}

			// Inform that we have had an update made
			Vault.Status = Vault.Status = Vault.VaultStatus.Touched;

			// Enable/Disable the appropriate UI
			mainPanel.Enabled = false;
			addButton.Enabled = true;
			treeView.Enabled = true;

			// Update the tree
			InvalidateTreeSelection();
			resetTreeView();

			// Clear text values
			ClearVaultViewText();
		}

		// Save the vault
		private void saveMenuItem_Click(object sender, EventArgs e)
		{
			if(Vault != null)
			{
				SaveVault(false);
			}
		}

		// Save our vault, give user option of where to save
		private void saveAsMenuItem_Click(object sender, EventArgs e)
		{
			if (Vault != null)
			{
				SaveVault(true);
			}
		}

		// Open up a file browser to load any Vault files
		private void openMenuItem_Click(object sender, EventArgs e)
		{
			OpenVault();
		}

		// The user wants to load with there password
		private void loadButton_Click(object sender, EventArgs e)
		{
			// Verify we have this file ready
			if(!File.Exists(_vaultToLoad))
			{
				ShowError(Error.FileExists);
				SetUIState(UIState.CreateNew);
				return;
			}

			List<VaultItem> items = Vault.Load(_vaultToLoad, passwordTextbox.Text);

			// Bad password
			if (items == null)
			{
				ShowError(Error.VaultLoad);
			}
			else
			{
				CreateVault(_vaultToLoadShorthand, _vaultToLoad, passwordTextbox.Text);
				
				// Append all of the returned items to our new vault
				foreach(VaultItem item in items)
				{
					Vault.Items.Add(item);
				}

				// Inform that we are up to date
				Vault.Status = Vault.VaultStatus.UpToDate;

				// Refresh the tree
				resetTreeView();

				// Go to the Vault view for updates
				SetUIState(UIState.VaultView);
			}
		}

		// Open a password vault from the tool bar
		private void openToolButton_Click(object sender, EventArgs e)
		{
			OpenVault();
		}

		// Save a password vault from the tool bar
		private void saveToolButton_Click(object sender, EventArgs e)
		{
			if (Vault != null)
			{
				SaveVault(false);
			}
		}

		// Tries to open a vault from disk, and will prompt to save your current vault
		// if there are changes
		private void OpenVault()
		{
			// Should we save
			if (!PromptForSave())
			{
				return;
			}

			// Create our filter to select files on
			OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Vault Files (*" + Vault.VaultExt + ")|*" + Vault.VaultExt;
            dlg.Title = "Open Password Vault File";
			dlg.Multiselect = false;

			// Open the dialog
			DialogResult result = dlg.ShowDialog();

			// Either the user cancelled, or the was a problem
			if (result != DialogResult.OK)
			{
				return;
			}

            // Request Vault
            RequestVault(dlg.FileName);
		}

        // Sets vars and goes to password request
        private void RequestVault(String filename)
        {
            // Save the name
            _vaultToLoad = filename;

            // Save the shortname
            FileInfo info = new FileInfo(filename);
            _vaultToLoadShorthand = info.Name.Replace(Vault.VaultExt, "");

            // Get a password from the user
            SetUIState(UIState.RequestVaultPassword);
        }

		// Clears all entries in the vault view by setting text in textboxes
		private void ClearVaultViewText()
		{
			panelNameTextBox.Text = "";
			panelGroupTextBox.Text = "";
			panelUserTextBox.Text = "";
			panelPasswordTextBox.Text = "";
			panelUrlTextBox.Text = "";
			panelAppTextBox.Text = "";
			panelDescTextBox.Text = "";
		}

		// Launches firefox and takes you to the supplied web-page
		private void urlButton_Click(object sender, EventArgs e)
		{
			LaunchInternet();
		}

        // the user has clicked the password button, generate a random password
        private void passwordButton_Click(object sender, EventArgs e)
        {
            // create the password dialog
            PasswordGenerator pg = new PasswordGenerator();
            pg.StartPosition = FormStartPosition.CenterParent;
            pg.ShowDialog(this);
            
            // set the password to that which was generated by the generator
            if (pg.Password.Length > 0)
            {
                panelPasswordTextBox.Text = pg.Password;
            }
        }

		// Copy text from user-name
		private void copyUserToolButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(panelUserTextBox.Text, true);
		}

		// Copy text from user-password
		private void copyPasswordToolButton_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(panelPasswordTextBox.Text, true);
		}

		// Launches firefox and takes you to the supplied web-page
		private void urlToolButton_Click(object sender, EventArgs e)
		{
			LaunchInternet();
		}

		// Tries to launch firefox
        private void LaunchInternet()
        {
            // No URL to go to
            if (panelUrlTextBox.Text.Length == 0)
            {
                return;
            }

            // try running firefox
            // try running google chrome
            if (Utilities.isApplicationInstalled("Google Chrome", false))
            {
                Process.Start("chrome", panelUrlTextBox.Text);
            }
            else if (Utilities.isApplicationInstalled("Mozilla Firefox", false))
            {
                Process.Start("firefox", panelUrlTextBox.Text);
            }
            // try default browser
            else
            {
                Process.Start(panelUrlTextBox.Text);
            }
        }

		// Set user button enabled
		private void panelUserTextBox_TextChanged(object sender, EventArgs e)
		{
			copyUserToolButton.Enabled = panelUserTextBox.Text.Length > 0;
		}

		// Set copy pass button enabled
		private void panelPasswordTextBox_TextChanged(object sender, EventArgs e)
		{
			copyPasswordToolButton.Enabled = panelPasswordTextBox.Text.Length > 0;
		}

		// Set url button enabled
		private void panelUrlTextBox_TextChanged(object sender, EventArgs e)
		{
			urlToolButton.Enabled = panelUrlTextBox.Text.Length > 0;
			urlButton.Enabled = panelUrlTextBox.Text.Length > 0;
		}

        // Output the config file
        private void SaveConfigFile()
        {
            // No last vault to save
            if (Vault == null)
            {
                return;
            }

			try
			{
				// Path to config file
				String xmlFile = "C:\\Documents and Settings\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\My Documents\\";
				xmlFile += ConfigFile;

				// Create an xml doc
				XmlDocument xdoc = new XmlDocument();

				// Write some header info
				XmlTextWriter xwrite = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
				xwrite.Formatting = Formatting.Indented;
				xwrite.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
				xwrite.WriteStartElement("Config");
				xwrite.Close();

				// Load what we just saved out
				xdoc.Load(xmlFile);

				// Append to the doc root
				XmlElement root = xdoc.DocumentElement;

				// Write last loaded file
				XmlElement xch = xdoc.CreateElement("LastVault");
				root.AppendChild(xch);
				xch.SetAttribute("file", Vault.FullPath);

				// Save the xml
				xdoc.Save(xmlFile);
			}
			catch (Exception)
			{
			}
        }

        // Read in the config file
        private void LoadConfigFile()
        {
            try
            {
				// Path to config file
				String xmlFile = "C:\\Documents and Settings\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\My Documents\\";
				xmlFile += ConfigFile;

                XmlDocument xdoc = new XmlDocument();
				XmlTextReader xread = new XmlTextReader(xmlFile);
				xdoc.Load(xmlFile);
                xread.ReadStartElement("Config");

                // Request the last vault for opening
                xread.Read();
                RequestVault(xread.GetAttribute("file"));
                xread.Close();
            }
            catch (Exception)
            {
            }
        }

		// Save our vault, give user option of where to save
		private void SaveVault(bool saveAs)
		{
			// We are saving the file that has already been saved
			// no need for a dialog
			if(Vault.Name.Length > 0 && !saveAs)
			{
				Vault.Save(Vault.FullPath);
				return;
			}

			// Create our dialog
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.AddExtension = true;
			dlg.DefaultExt = Vault.VaultExt;
			dlg.OverwritePrompt = true;
			dlg.Title = "Save Password Vault";
			dlg.FileName = Vault.Name;
			dlg.Filter = "Vault Files (*" + Vault.VaultExt + ")|*" + Vault.VaultExt;

			// Get the location from the user
			DialogResult result = dlg.ShowDialog();

			// Save the vault
			if(result == DialogResult.OK)
			{
				Vault.Save(dlg.FileName);

				// Set the vault name in the UI
				vaultLabel.Text = "Vault: " + Vault.Name;
			}
		}

        // Go to the change password view
        private void changePassMenuItem_Click(object sender, EventArgs e)
        {
            SetUIState(UIState.ChangeVaultPassword);
        }

        // Apply the new password settings
        private void changePassButton_Click(object sender, EventArgs e)
        {
            if (Vault == null)
            {
                return;
            }

            // Old password does not match entry
            if (changePassTextbox.Text != Vault.Password)
            {
                ShowError(Error.OldPasswordMatch);
            }
            // Invalid new password
            else if (passwordTextbox.Text.Length == 0)
            {
                ShowError(Error.InvalidPassword);
            }
            // Verified password does not match
            else if (passwordTextbox.Text != verifyTextbox.Text)
            {
                ShowError(Error.VerifyPassword);
            }
            // Update the password and UI
            else
            {
                // Show the confirm
                MessageBox.Show("Your password has been updated", "Password Vault Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Vault.Password = passwordTextbox.Text;
                SetUIState(UIState.VaultView);

                // Notify that we should save
                Vault.Status = Vault.VaultStatus.Touched;
            }
        }

        // Abort changes to password
        private void cancelPassButton_Click(object sender, EventArgs e)
        {
            SetUIState(UIState.VaultView);
        }

		// When the user presses enter, load the vault
		void passwordTextbox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				loadButton.PerformClick();
			}
		}

        // Handle the user pressing a key
        void searchTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // When the user presses enter we want to perform the search
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                // Let others down the responder chain know that I've taken care of this message
                e.Handled = true;

                // Clear all highlights
                resetTreeViewColors();

                // Are we perofming the same search as we did last time?
                // If so, simply select the next matching node in the list if there is one
                // otherwise perform a new search...
                if (searchTextBox.Text.ToLower().Equals(_searchString) && _searchString.Length > 0)
                {
                    // remove the last result shown
                    if (_searchResults.Count > 0)
                    {
                        _searchResults.RemoveAt(0);
                    }

                    // if we have more results simply advance to the next one
                    if (_searchResults.Count > 0)
                    {
                        treeView.TopNode = _searchResults[0];

                        // Sometimes assigning the topnode a node that cannot be scrolled to
                        // results in a different node being assigned, handle that case here
                        if (_searchResults[0] != treeView.TopNode)
                        {
                            _searchResults[0].BackColor = Color.DodgerBlue;
                            _searchResults[0].ForeColor = Color.White;

                            // update the contents of the panel with the vault item contained in the node
                            if (_searchResults[0].Tag != null)
                            {
                                editButton.Enabled = true;
                                removeButton.Enabled = true;

                                // set the node to edit
                                _nodeToEdit = treeView.TopNode;

                                VaultItem item = _searchResults[0].Tag as VaultItem;
                                panelNameTextBox.Text = item != null ? item.Name : "";
                                panelGroupTextBox.Text = item != null ? item.Group : _nodeToEdit.Text;
                                panelUserTextBox.Text = item != null ? item.User : "";
                                panelPasswordTextBox.Text = item != null ? item.Password : "";
                                panelUrlTextBox.Text = item != null ? item.Url : "";
                                panelAppTextBox.Text = item != null ? item.App : "";
                                panelDescTextBox.Text = item != null ? item.Desc : "";
                            }
                        }
                        else
                        {
                            treeView.TopNode.BackColor = Color.DodgerBlue;
                            treeView.TopNode.ForeColor = Color.White;

                            // update the contents of the panel with the vault item contained in the node
                            if (treeView.TopNode.Tag != null)
                            {
                                editButton.Enabled = true;
                                removeButton.Enabled = true;

                                // set the node to edit
                                _nodeToEdit = treeView.TopNode;

                                VaultItem item = treeView.TopNode.Tag as VaultItem;
                                panelNameTextBox.Text = item != null ? item.Name : "";
                                panelGroupTextBox.Text = item != null ? item.Group : _nodeToEdit.Text;
                                panelUserTextBox.Text = item != null ? item.User : "";
                                panelPasswordTextBox.Text = item != null ? item.Password : "";
                                panelUrlTextBox.Text = item != null ? item.Url : "";
                                panelAppTextBox.Text = item != null ? item.App : "";
                                panelDescTextBox.Text = item != null ? item.Desc : "";
                            }
                        }

                        // break out of the search
                        return;
                    }
                }

                // if we get here, we are performing a brand new search and must clear
                // our results so that we don't have any bad matches from a previous search
                _searchResults.Clear();

                // Save the new current search string for future iterations
                _searchString = searchTextBox.Text.ToLower();

                // Only search if we have valid text to search with
                if (_searchString.Length > 0)
                {
                    foreach (TreeNode node in treeView.Nodes)
                    {
                        findTreeNode(_searchString, node, _searchResults);
                    }
                }

                // If we found any matches then scroll to the first entry found
                if (_searchResults.Count > 0)
                {
                    treeView.TopNode = _searchResults[0];

                    // Sometimes assigning the topnode a node that cannot be scrolled to
                    // results in a different node being assigned, handle that case here
                    if (_searchResults[0] != treeView.TopNode)
                    {
                        _searchResults[0].BackColor = Color.DodgerBlue;
                        _searchResults[0].ForeColor = Color.White;

                        // update the contents of the panel with the vault item contained in the node
                        if (_searchResults[0].Tag != null)
                        {
                            editButton.Enabled = true;
                            removeButton.Enabled = true;

                            // set the node to edit
                            _nodeToEdit = treeView.TopNode;

                            VaultItem item = _searchResults[0].Tag as VaultItem;
                            panelNameTextBox.Text = item != null ? item.Name : "";
                            panelGroupTextBox.Text = item != null ? item.Group : _nodeToEdit.Text;
                            panelUserTextBox.Text = item != null ? item.User : "";
                            panelPasswordTextBox.Text = item != null ? item.Password : "";
                            panelUrlTextBox.Text = item != null ? item.Url : "";
                            panelAppTextBox.Text = item != null ? item.App : "";
                            panelDescTextBox.Text = item != null ? item.Desc : "";
                        }
                    }
                    else
                    {
                        treeView.TopNode.BackColor = Color.DodgerBlue;
                        treeView.TopNode.ForeColor = Color.White;

                        // update the contents of the panel with the vault item contained in the node
                        if (treeView.TopNode.Tag != null)
                        {
                            editButton.Enabled = true;
                            removeButton.Enabled = true;

                            // set the node to edit
                            _nodeToEdit = treeView.TopNode;

                            VaultItem item = treeView.TopNode.Tag as VaultItem;
                            panelNameTextBox.Text = item != null ? item.Name : "";
                            panelGroupTextBox.Text = item != null ? item.Group : _nodeToEdit.Text;
                            panelUserTextBox.Text = item != null ? item.User : "";
                            panelPasswordTextBox.Text = item != null ? item.Password : "";
                            panelUrlTextBox.Text = item != null ? item.Url : "";
                            panelAppTextBox.Text = item != null ? item.App : "";
                            panelDescTextBox.Text = item != null ? item.Desc : "";
                        }
                    }
                }
            }
        }

        // Compiles a list of all VaultItem names and then
        // assigns that to the search textbox
        void updateTreeViewCollection()
        {
            // create the new collection to build on
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            // build a list of all of the items we currently have
            foreach (TreeNode node in treeView.Nodes)
            {
                updateTreeViewCollectionHelper(collection, node);
            }

            // assign the collection to the textbox
            searchTextBox.AutoCompleteCustomSource = collection;
            searchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        
        // Helper function for iterating over all tree nodes...
        void updateTreeViewCollectionHelper(AutoCompleteStringCollection collection, TreeNode node)
        {
            // Add the item names
            if (node.Tag != null)
            {
                collection.Add(((VaultItem)node.Tag).Name);
            }
            // Add the group names
            else
            {
                collection.Add(node.Text);
            }

            // iterate over all children nodes
            foreach (TreeNode childNode in node.Nodes)
            {
                // recurse until we have visited all the tree nodes
                updateTreeViewCollectionHelper(collection, childNode);
            }
        }

        // returns the tree node matching the string and not in the current list
        void findTreeNode(string text, TreeNode node, List<TreeNode> list)
        {
            // check for a match
            if (node.Tag != null && (node.Tag as VaultItem).Name.ToLower().StartsWith(text) && list.Contains(node) == false)
            {
                list.Add(node);
            }
            else if (node.Text.ToLower().StartsWith(text) && list.Contains(node) == false)
            {
                list.Add(node);
            }

            // iterate over all children
            foreach (TreeNode childNode in node.Nodes)
            {
                findTreeNode(text, childNode, list);
            }
        }

        // resets all the nodes colors in the tree view
        void resetTreeViewColors()
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                resetTreeViewColorsHelper(node);
            }
        }

        // helper function that iterates over all children
        void resetTreeViewColorsHelper(TreeNode node)
        {
            node.BackColor = Color.Transparent;
            node.ForeColor = Color.Black;

            foreach (TreeNode childNode in node.Nodes)
            {
                resetTreeViewColorsHelper(childNode);
            }
        }
	}
}