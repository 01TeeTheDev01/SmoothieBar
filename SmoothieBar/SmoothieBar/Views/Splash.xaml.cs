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

            for (int i = 0; i < 5; i++)
            {
                
                await imgLogo.FadeTo(1, 1200, Easing.CubicInOut);

                if (i > 3)
                    LoadingText.Text = "";

                await imgLogo.FadeTo(0, 1200, Easing.CubicInOut); 
            }

            //await Task.Delay(3000);

            Application.Current.MainPage = new Master();
        }
    }
}