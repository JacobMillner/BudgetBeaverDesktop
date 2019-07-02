using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetBeaverDesktop
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
			// create the database if it doesnt exist
			if (!File.Exists("Database.sqlite"))
			{
				Database.SetupDatabase();
			}
			Application.Run(new Form1());
		}
	}
}
