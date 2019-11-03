using System.Windows;
using System.Windows.Threading;
using Autofac;
using FriendOrganize.UI.Data;
using FriendOrganize.UI.ViewModels;

namespace FriendOrganize.UI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_StartUp(object sender, StartupEventArgs e)
		{
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
			

			mainWindow.Show();
		}


		private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{

			MessageBox.Show("Unexpected error occured " + e.Exception.Message);
			e.Handled = true;
		}
	}
}
