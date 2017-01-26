using System.Windows;
using System.Windows.Controls;
using Autofac;
using Gevlee.WinRadioTray.Core.ViewModel;
using Hardcodet.Wpf.TaskbarNotification;

namespace Gevlee.WinRadioTray
{
	public class Bootstrapper
	{
		private TaskbarIcon sysTrayIcon;
		private ILifetimeScope scope;
		public Bootstrapper()
		{
			Configure();
			Application.Current.Startup += OnStartup;
			Application.Current.Exit += OnExit;
		}

		private void OnExit(object sender, ExitEventArgs exitEventArgs)
		{
			sysTrayIcon.Dispose();
			scope.Disposer.Dispose();
		}

		private void OnStartup(object sender, StartupEventArgs startupEventArgs)
		{
			App theApp = sender as App;
			sysTrayIcon = (TaskbarIcon)theApp.FindResource("TrayIcon");
			sysTrayIcon.DataContext = scope.Resolve<ITrayIconViewModel>();
		}


		private void LoadDependencyModules(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterModule<DefaultModule>();
		}

		protected void Configure()
		{
			var containerBuilder = new ContainerBuilder();
			LoadDependencyModules(containerBuilder);
			scope = containerBuilder.Build().BeginLifetimeScope();
		}
	}
}