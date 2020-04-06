using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CovidAlert.ViewModels
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(
            ref T backingStore, 
            T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            
            RaisePropertyChanged(propertyName);
            
            return true;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (null == propertyName)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            var changed = PropertyChanged;

            if (null == changed)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}