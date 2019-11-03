using System.Runtime.CompilerServices;

namespace FriendOrganize.UI.Wrapper
{
    public class ModelWrapper<T> : NotifyDataErrorInfoBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }
        public T Model { get; set; }

        protected virtual TValue GetValue<TValue>([CallerMemberName]string propName = null)
        {
            return (TValue) typeof(TValue).GetProperty(propName)?.GetValue(Model);
        }
        protected virtual void SetValue<TValue>(TValue value ,  [CallerMemberName]string propName = null)
        {
            typeof(TValue).GetProperty(propName)?.SetValue(Model, value);
            OnPropertyChanged(propName);
        }
    }
}