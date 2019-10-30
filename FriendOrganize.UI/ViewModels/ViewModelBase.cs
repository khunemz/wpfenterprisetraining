using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendOrganize.UI.ViewModels
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual  void  OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}