using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMMAUI.ViewModels
{
    internal class CounterViewModel : INotifyPropertyChanged
    {
        private int count;

        #region Props
        public event PropertyChangedEventHandler PropertyChanged;

        public int Count
        {
            get => this.count;
            set
            {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Log"));
            }
        }
        public string Log
        {
            get => $"Log:{DateTime.Now.ToString("yyyy/MM/dd hh:MM:ss")}";
        }
        #endregion
        public CounterViewModel()
        {
            UpdateCount = new Command(OnCounterClicked);
        }

        #region Methods
        private void OnCounterClicked()
        {
            Count++;

            if (Count > 9) DisplayMsg();
        }

        public void DisplayMsg()
        {
            var confirm = Application.Current.MainPage.DisplayAlert(
                "Info",
                "Se llego al maximo...",
                "OK");

            Count = 0;
        }
        #endregion
        public ICommand UpdateCount { private set; get; }
    }
}
