using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using System.IO;

namespace inft2051_ass2
{
    public partial class SearchPage : ContentPage
    {

        //Create a list to store attraction data
        public IList<Attraction> Attraction_list { get; private set; }

        //when this page is being displayed, it will run.
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this.FindByName<ListView>("listView").ItemsSource = await App.Database.GetCityAsync();
            BindingContext = this;
        }


        public SearchPage()
        {
            Title = "Search Page";
            InitializeComponent();

        }

        //Result is used to store the name of the city the user wants to search.
        public static string result = "";
        //city_id is used to store the id of the city the user wants to search。
        public static int city_id;

        private void Search(object sender, EventArgs e)
        {
            result = this.FindByName<Entry>("selection").Text;
            city selectedCity = App.db.Query<city>("SELECT * FROM city WHERE Name= ?", new object[] { result }).FirstOrDefault() as city;
            if (selectedCity == null)
            {
                //If you can't find the city you want to search for
                DisplayAlert("Alert", "Ooops,no result.Please check the City's name(with Upper case)", "OK");
            }
            else
            {
                
                city_id = selectedCity.id;
                result = selectedCity.Name;
                Navigation.PushAsync(new CityPage());
            }
        }

        //When the user selects the city directly in the list
        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            city selectedItem = e.SelectedItem as city;
            result = selectedItem.Name;
            city_id = selectedItem.id;
            Navigation.PushAsync(new CityPage());

        }
    }
}
