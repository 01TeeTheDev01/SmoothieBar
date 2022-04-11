using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmoothieBar
{
    public partial class App : Application
    { 
        public App()
        {
            InitializeComponent();

            MainPage = new Views.Master();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
