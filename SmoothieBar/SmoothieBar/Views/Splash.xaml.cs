using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmoothieBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();

            LoadSplash();
        }

        private async void LoadSplash()
        {
            await LogoAnimation();
        }

        public async Task LogoAnimation()
        {
            imgLogo.Opacity = 0;

            await imgLogo.FadeTo(1, 6500, Easing.CubicInOut);

            Application.Current.MainPage = new Master();
        }
    }
}