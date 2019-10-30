using System.Windows;
using FriendOrganize.UI.ViewModels;

namespace FriendOrganize.UI
{
	/// <summary>
	///   Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainViewModel _viewModel;

		public MainWindow(MainViewModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
			_viewModel = viewModel;
			Loaded += MainWindow_Loaded;
		}


		private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			await  _viewModel.LoadAsync();
		}
	}
}