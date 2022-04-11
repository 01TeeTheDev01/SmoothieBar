using SmoothieBar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmoothieBar
{
    public partial class MainPage : ContentPage
    {
        private readonly List<Fruit> fruitCollection;
        public MainPage()
        {
            InitializeComponent();

            fruitCollection = new List<Fruit>();

            GetData();

            FruitListView.SeparatorColor = Color.LightGray;
        }

        private void SearchBtn_Clicked(object sender, EventArgs e)
        {
            FruitSearch.Text = string.Empty;

            FruitListView.ItemsSource = null;

            FruitPicBox.Source = null;

            GetData();

            //DisplayData();
        }

        private async void SearchFruit(string fruit)
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(fruit))
                {
                    try
                    {
                        FruitListView.Dispatcher.BeginInvokeOnMainThread(() =>
                        {
                            FruitListView.ItemsSource = null;

                            FruitPicBox.Source = null;

                            var result = fruitCollection.Where(f => f.FruitName == fruit);


                            if (result != null)
                            {
                                FruitListView.ItemsSource = result;

                                FruitListView.ItemSelected += FruitListView_ItemSelected;
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("Error", ex.Message, "Okay");
                    }
                }
            });
        }

        private async void GetData()
        {
            await Task.Run(() =>
            {
                var result = ReadFile(@"https://gist.githubusercontent.com/lasagnaphil/7667eaeddb6ed0c565f0cb653d756942/raw/e05dbc73062aa1679b733e8f9f9b32e003c59d0e/fruits.txt");

                try
                {
                    using (var txt = new StreamReader(result.Result))
                    {
                        fruitCollection.Clear();

                        while (txt.Peek() > 0)
                        {
                            var fr = txt.ReadLineAsync().Result.Trim().ToUpper();

                            fruitCollection.Add(new Fruit { FruitName = fr });
                        }
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "Okay");
                }
            });
        }

        //private void DisplayData()
        //{
        //    FruitListView.Dispatcher.BeginInvokeOnMainThread(() =>
        //    {
        //        FruitListView.ItemsSource = null;

        //        FruitListView.ItemsSource = fruitCollection;
        //    });
        //}

        private Task<Stream> ReadFile(string path)
        {
            try
            {
                return new WebClient().OpenReadTaskAsync(new Uri(path));
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }

            return null;
        }

        private void FruitSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (FruitSearch.Text.Length)
            {
                case 0:
                    GetData();
                    break;

                default:
                    SearchFruit(FruitSearch.Text.ToUpper());
                    break;
            }                
        }

        private async void FetchImage()
        {
            await Task.Run(() =>
            {
                FruitPicBox.Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    FruitPicBox.Source = null;

                    FruitPicBox.Source = ImageSource.FromFile("no_image_to_show_.webp");
                });
            });
        }

        private void FruitListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //FruitListView.BackgroundColor = Color.White;

            try
            {
                System.Diagnostics.Debug.WriteLine(FruitListView.SelectedItem);

                var result = fruitCollection.Exists(f => f.FruitName == FruitListView.SelectedItem.ToString());

                if (result)
                    FetchImage();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }
}
