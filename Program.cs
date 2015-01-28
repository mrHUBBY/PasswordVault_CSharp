using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordVault
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm mainForm = new MainForm();
			Application.Run(mainForm);

			// Prompt the user to save when they close the app
            Clipboard.Clear();
		}
	}
}