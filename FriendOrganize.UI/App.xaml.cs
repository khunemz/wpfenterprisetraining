using System.Windows;
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
			var mainWindow = new MainWindow(
				new MainViewModel(new FriendDataService()));

			mainWindow.Show();
		}
	}
}
