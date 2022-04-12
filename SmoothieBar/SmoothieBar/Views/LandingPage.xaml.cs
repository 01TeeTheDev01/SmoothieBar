using SmoothieBar.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;

namespace SmoothieBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        private readonly List<Recipe> RecipesList;
        public EventCollection Events { get; set; }
        public CultureInfo Culture => new CultureInfo("en-ZA");


        public LandingPage()
        {
            InitializeComponent();

            RecipesList = new List<Recipe>();

            LoadList();

            EventsColl();
        }

        private async void LoadList()
        {
            await ListData();
        }

        private async Task ListData()
        {
            await Task.Run(() => 
            {
                var recipes = new string[] { "Apple smoothie", "Banana smoothie", "Blackberry smoothie", "Power Boost smoothie" };
                
                var desc = new string[] {   "Water\nPlain yoghurt\n1x Apple\n1x teaspoon of peanut butter",
                                            "Water\nPlain yoghurt\n1x Banana\n1x Teaspoon peanut butter",
                                            "Water\nPlain yoghurt\nBlackberries\n1x Teaspoon peanut butter",
                                            "Water\nPlain yoghurt\n1x Banana\nBlackberries\n1x Teaspoon peanut butter"};

                for (int index = 0; index < recipes.Length; index++)
                {
                    RecipesList.Add(new Recipe { RecipeName = recipes[index], RecipeDescription = desc[index]}); ;
                }

                RecipesListView.ItemsSource = RecipesList;
            });
        }

        private void EventsColl()
        {
            Events = new EventCollection();

            var currentDate = DateTime.Now;

            Events.Add(currentDate, new List<Recipe>() { new Recipe { RecipeName = "Event", RecipeDescription = "Description" },
                                                                 new Recipe { RecipeName = "Event", RecipeDescription = "Description" },
                                                                 new Recipe { RecipeName = "Event", RecipeDescription = "Description" } });
        }

        private void RecipesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var m = (ListView)sender;

            if (m != null)
            {
                
            }
        }
    }
}