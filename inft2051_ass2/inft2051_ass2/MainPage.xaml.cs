using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace inft2051_ass2
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

        }

        //Prevent events from being triggered multiple times in succession
        public int count = 0;
        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            count += 1;
            if (count == 1)
            {
                //go to next page
                await Navigation.PushAsync(new SearchPage());
                count = 0;
            }

        }
    }
}
