using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FriendOrganize.Model;
using FriendOrganize.UI.ViewModels;
using Prism.Common;

namespace FriendOrganize.UI.Wrapper
{
    public class FriendWrapper :  ModelWrapper<Friend>
	{
        public FriendWrapper(Friend model) : base(model)

        {
            
        }

		public int Id
		{
			get { return Model.Id; }
		}

		public string FirstName
        {
            get { return GetValue<string>(); }
			set
			{
				SetValue(value);
				ValidateProperty(nameof(FirstName));
			}
		}

       
        private void ValidateProperty(string propName)
		{
			ClearError(propName);
			switch (propName)
			{
				case nameof(FirstName):
					if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
					{
						AddError(propName, "Robots are not valid");
					}

					break;
			}
		}

		public string LastName
		{
			get { return GetValue<string>(); }
			set
			{
				SetValue(value);
				OnPropertyChanged();
			}
		}


		public string Email
		{
			get { return GetValue<string>(); }
			set
			{
				SetValue(value);
				OnPropertyChanged();
			}
		}


	}

    public class NotifyDataErrorInfoBase : ViewModelBase,INotifyDataErrorInfo
    {

        private Dictionary<string, List<string>> _errorsByPropName = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropName.ContainsKey(propertyName) ? _errorsByPropName[propertyName] : null;
        }

        public bool HasErrors => _errorsByPropName.Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        protected virtual void OnErrorsChanged(string propName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propName));
        }

        protected void AddError(string propName, string error)
        {
            if (!_errorsByPropName.ContainsKey(propName))
            {
                _errorsByPropName[propName] = new List<string>();
            }

            if (!_errorsByPropName[propName].Contains(error))
            {
                _errorsByPropName[propName].Add(error);
                OnErrorsChanged(propName);
            }
        }


        protected void ClearError(string propName)
        {
            if (_errorsByPropName.ContainsKey(propName))
            {
                _errorsByPropName.Remove(propName);
                OnErrorsChanged(propName);
            }
        }
    }
}