using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmoothieBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterFlyout : ContentPage
    {
        public ListView ListView;

        public MasterFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterFlyoutViewModel();
            
            ListView = MenuItemsListView;
        }

        private class MasterFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterFlyoutMenuItem> MenuItems { get; set; }

            public MasterFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterFlyoutMenuItem>(new[]
                {
                    new MasterFlyoutMenuItem { Id = 0, Title = "Home", IconSource="home_48px.png", TargetType = typeof(Login) },
                    new MasterFlyoutMenuItem { Id = 1, Title = "Search" , IconSource = "search_48px.png", TargetType = typeof(MainPage)},
                    new MasterFlyoutMenuItem { Id = 1, Title = "Motivation" , IconSource = "applause_48px.png", TargetType = typeof(MessagesPage)}
                });
            }



            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}