using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FitNessCompanionApp
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Methods
        internal void GoToHome()
        {
            onHome = true;
            onProducts = false;
            NotifyPropertyChanged("OnHome");
            NotifyPropertyChanged("OnProducts");
        }

        internal void GoToProducts()
        {
            onProducts = true;
            onHome = false;
            NotifyPropertyChanged("OnHome");
            NotifyPropertyChanged("OnProducts");
        }

        internal void GoToContact()
        {

        }

        internal void GoToOther()
        {

        }
        #endregion

        #region Properties
        public Visibility OnHome
        {
            get
            {
                if (true == onHome)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

        public Visibility OnProducts
        {
            get
            {
                if (true == onProducts)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        #endregion

        #region Fields
        private bool onHome = true;
        private bool onProducts = false;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region PropertyChangedImplementation
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
