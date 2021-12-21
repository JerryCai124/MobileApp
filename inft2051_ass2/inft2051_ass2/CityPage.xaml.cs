using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using System.IO;
using System.Collections;

namespace inft2051_ass2
{
    public partial class CityPage : ContentPage
    {
        //Create a list to store attraction data
        public IList<Attraction> Attraction_list { get; private set; }

        public static int attraction_id;
        public static string attraction_name;



        public CityPage()
        {
            Title = SearchPage.result;
            InitializeComponent();
            Attraction_list = new List<Attraction>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Attraction_list = await App.Database.GetAttractionAsync(SearchPage.city_id);
            BindingContext = this;
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Attraction selectedItem = e.SelectedItem as Attraction;
            attraction_id = selectedItem.id;
            attraction_name = selectedItem.Name;
            Navigation.PushAsync(new AttractionPage());

        }
    }
}