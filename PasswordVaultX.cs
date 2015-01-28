using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StudioComponentX;

namespace PasswordVault
{
    public class PasswordVaultX : IComponentX
    {
        private MainForm _mainForm = null;

        public override string Name { get { return "PasswordVaultX"; } }
        public override Form Form { get { return _mainForm; } }
        public override ComponentStyle Style { get { return ComponentStyle.Form; } }
        public override Icon SmallIcon { get { return Form.Icon; } }
        public override bool IsUpToDate { get { if (_mainForm.Vault != null) return _mainForm.Vault.Status == Vault.VaultStatus.UpToDate; else return true; } }
        public override String FileExtension { get { return Vault.VaultExt; } }
        public override String ActiveFileName { get { if (_mainForm.Vault != null) return _mainForm.Vault.Name; else return "";} }

        // constructor
        public PasswordVaultX(ComponentLoaderX loader) : base(loader)
        {
            _mainForm = new MainForm();
            _mainForm.setToolStripVisible(false);
        }

        // interface implementation
        override public void OnCommand(StudioComponentX.CommandType cmd, object obj)
        {
            switch (cmd)
            {
                case StudioComponentX.CommandType.FillToolStrip:
                    ToolStrip ts = obj as ToolStrip;
                    MainForm mform = Form as MainForm;
                    ts.Items.Add(mform.getNewToolButton());
                    ts.Items.Add(mform.getOpenToolButton());
                    ts.Items.Add(new ToolStripSeparator());
                    ts.Items.Add(mform.getSaveToolButton());
                    ts.Items.Add(new ToolStripSeparator());
                    ts.Items.Add(mform.getCopyUserToolButton());
                    ts.Items.Add(mform.getCopyPasswordToolButton());
                    ts.Items.Add(new ToolStripSeparator());
                    ts.Items.Add(mform.getUrlToolButton());
                    break;
                case StudioComponentX.CommandType.Show:
                    break;
                case StudioComponentX.CommandType.Hide:
                    break;
                case StudioComponentX.CommandType.SaveFile:
                    (Form as MainForm).saveVaultExternal(false);
                    break;
                case StudioComponentX.CommandType.OpenFile:
                    break;
            }
        }	
    }
}
