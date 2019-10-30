using System.Windows;
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
	}
}
