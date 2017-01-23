using System;
using System.Windows;
using Caliburn.Micro;
using Hardcodet.Wpf.TaskbarNotification;

namespace Gevlee.WinRadioTray
{
	public class Bootstrapper : BootstrapperBase
	{
		private TaskbarIcon sysTrayIcon;

		public Bootstrapper()
		{
			Initialize();
		}

		protected override void OnStartup(object sender, StartupEventArgs e)
		{
			base.OnStartup(sender, e);
			App theApp = sender as App;
			sysTrayIcon = (TaskbarIcon)theApp.FindResource("MainSystemTrayIcon");
		}

		protected override void OnExit(object sender, EventArgs e)
		{
			sysTrayIcon.Dispose();
			base.OnExit(sender, e);
		}
	}
}