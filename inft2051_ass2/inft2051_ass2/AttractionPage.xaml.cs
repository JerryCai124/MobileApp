using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace inft2051_ass2
{
    public partial class AttractionPage : ContentPage
    {


        protected override void OnAppearing()
        {
            base.OnAppearing();
            Attraction selectedAttraction = App.db.Query<Attraction>("SELECT * FROM Attraction WHERE id= ?", new object[] { CityPage.attraction_id }).FirstOrDefault() as Attraction;
            this.FindByName<Image>("img1").Source = selectedAttraction.img_name;
            this.FindByName<Label>("name").Text = selectedAttraction.Name;
            this.FindByName<Label>("introduction").Text = selectedAttraction.introduction;

        }

        public AttractionPage()
        {
            Title = CityPage.attraction_name;
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            //var image = new Image { Source = "image2.jpg" };
            //this.FindByName<image>("image");
            Attraction selectedAttraction = App.db.Query<Attraction>("SELECT * FROM Attraction WHERE id= ?", new object[] { CityPage.attraction_id }).FirstOrDefault() as Attraction;

            string address = selectedAttraction.Name;

            var uri = new Uri("http://maps.google.com/maps?q=" + address.Replace(" ", ""));
            Device.OpenUri(uri);
        }
    }
}
