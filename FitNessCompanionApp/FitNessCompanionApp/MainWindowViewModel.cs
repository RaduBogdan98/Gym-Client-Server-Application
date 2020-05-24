using FitNessCompanionApp.Pages;
using FitNessCompanionApp.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FitNessCompanionApp
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindowViewModel()
        {
            cartViewModel = CartViewModel.Instance;
        }

        #region Methods
        internal void NotifyCartItemsNumberChanged()
        {
            NotifyPropertyChanged("CartItemsNumber");
        }
        #endregion

        #region Properties
        public static MainWindowViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MainWindowViewModel();
                }

                return instance;
            }
        }

        public int CartItemsNumber
        {
            get
            {
                return cartViewModel.getProductsCount();
            }
        }

        public bool ShouldUserPageUpdate
        {
            get
            {
                return shouldUserPageUpdate;
            }
            set
            {
                shouldUserPageUpdate = value;
            }
        }

        public bool ShouldProductsPageUpdate
        {
            get
            {
                return shouldProductsPageUpdate;
            }
            set
            {
                shouldProductsPageUpdate = value;
            }
        }
        #endregion

        #region Fields
        private static MainWindowViewModel instance;
        private CartViewModel cartViewModel;
        private bool shouldUserPageUpdate = false;
        private bool shouldProductsPageUpdate = false;

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
