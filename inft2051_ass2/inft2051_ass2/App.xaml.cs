using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using System.Linq;
using System.Collections.Generic;

namespace inft2051_ass2
{
    public partial class App : Application
    {
       
        public static SQLiteConnection db;
        static Database database;

        //make a database
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    //link to local database
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "city.db3"));
                    db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "city.db3"));

                    //if it is an empty database, write data to the database
                    if (db.Query<city>("SELECT id FROM city").FirstOrDefault() == null)
                    {
                        city Sydney = new city();
                        Sydney.Name = "Sydney";
                        Sydney.id = 1;
                        Database.SaveCityAsync(Sydney);

                        city Melbourne = new city();
                        Melbourne.Name = "Melbourne";
                        Melbourne.id = 2;
                        Database.SaveCityAsync(Melbourne);

                        Attraction Sydney1 = new Attraction();
                        Sydney1.id = 1;
                        Sydney1.Name = "Opera House";
                        Sydney1.belong_to_city = 1;
                       
                        Sydney1.img_name = "Opera_House.jpg";
                        Sydney1.introduction = "The Sydney Opera House is a multi-venue performing arts center at Sydney Harbour in Sydney, New South Wales, Australia. It is one of the 20th century's most famous and distinctive buildings.  Designed by Danish architect Jørn Upton, the building was formally opened on 20 October 1973 after a gestation beginning with Utzon's 1957 selection as winner of an international design competition. The building and its surrounds occupy the whole of Bennelong Point on Sydney Harbor, between Sydney Cove and Farm Cove, adjacent to the Sydney central business district and the Royal Botanic Gardens, and close by the Sydney Harbour Bridge. The building comprises multiple performance venues, which together host well over 1,500 performances annually, attended by more than 1.2 million people. Performances are presented by numerous performing artists, including three resident companies: Opera Australia, the Sydney Theatre Company and the Sydney Symphony Orchestra. As one of the most popular visitor attractions in Australia, the site is visited by more than eight million people annually, and approximately 350,000 visitors take a guided tour of the building each year.";
                        Database.SaveAttractionAsync(Sydney1);

                        Attraction Sydney2 = new Attraction();
                        Sydney2.id = 2;
                        Sydney2.Name = "Harbour Bridge";
                        Sydney2.belong_to_city = 1;
                        Sydney2.img_name = "Harbour_Bridge.jpg";
                        Sydney2.introduction = "The Sydney Harbour Bridge is a heritage-listed steel through arch bridge across Sydney Harbour that carries rail, vehicular, bicycle, and pedestrian traffic between the Sydney central business district (CBD) and the North Shore. The dramatic view of the bridge, the harbour, and the nearby Sydney Opera House is an iconic image of Sydney, and Australia itself. The bridge is nicknamed The Coathanger because of its arch-based design.";
                        Database.SaveAttractionAsync(Sydney2);

                        Attraction Sydney3 = new Attraction();
                        Sydney3.id = 3;
                        Sydney3.Name = "Darling Harbour";
                        Sydney3.belong_to_city = 1;
                        Sydney3.img_name = "Darling_Harbour.jpg";
                        Sydney3.introduction = "Darling Harbour is a harbour adjacent to the city centre of Sydney, New South Wales, Australia that is made up of a large recreational and pedestrian precinct that is situated on western outskirts of the Sydney central business district.Darling Harbour is named after Lieutenant-General Ralph Darling, who was Governor of New South Wales from 1825 to 1831. The area was originally known as Long Cove, but was generally referred to as Cockle Bay until 1826 when Governor Darling renamed it after himself. The name Cockle Bay has recently been restored in reference to the headwaters of the harbour. It was originally part of the commercial port of Sydney, including the Darling Harbour Railway Goods Yard. During the Great Depression, the eastern part of Darling Harbour (Barangaroo) became known as The Hungry Mile, a reference to the waterside workers searching for jobs along the wharves";
                        Database.SaveAttractionAsync(Sydney3);

                        Attraction Melbourne1 = new Attraction();
                        Melbourne1.id = 4;
                        Melbourne1.Name = "Hosier Lane";
                        Melbourne1.belong_to_city = 2;
                        Melbourne1.img_name = "Hosier_Lane.jpg";
                        Melbourne1.introduction = "Melbourne, Victoria, Australia, has the world's toughest anti-graffiti regulations. In order not to break the rules, young graffiti like to go to the alley to sway their inspiration. Adrian Doyle is the founder of Melbourne's graffiti art, an iconic figure and an accomplished artist.";
                        Database.SaveAttractionAsync(Melbourne1);

                        Attraction Melbourne2 = new Attraction();
                        Melbourne2.id = 5;
                        Melbourne2.Name = "St. Paul's Cathedral";
                        Melbourne2.belong_to_city = 2;
                        Melbourne2.img_name = "St_Paul_Cathedral.jpg";
                        Melbourne2.introduction = "St. Paul's Cathedral is the Anglican Cathedral in Melbourne, Victoria, Australia. It is the cathedral church of the Diocese of Melbourne and the seat of the Archbishop of Melbourne. It is also the Metropolitan Archbishop of Victoria. Since June 28, 2014, it is the current location of the Australian Archbishop";
                        Database.SaveAttractionAsync(Melbourne2);

                        Attraction Melbourne3 = new Attraction();
                        Melbourne3.id = 6;
                        Melbourne3.Name = "National Gallery of Victoria";
                        Melbourne3.belong_to_city = 2;
                        Melbourne3.img_name = "National_Gallery_of_Victoria.jpg";
                        Melbourne3.introduction = "The State Museum of Victoria is divided into the Australian Pavilion and the International Pavilion, the former on the Federal Square on the north bank of the Yarra River, which is located next to the Cultural and Art Center on the south bank of the Yarra River. If you want to know the art and culture of Australia, it is absolutely impossible to come here. The National Gallery in the centre of Ion Porter, Federal Square, houses more than 20,000 works from colonial to contemporary Australian art. The Australian Aboriginal paintings on the first floor are very interesting and seem to be very abstract, but when you understand the symbols used by some indigenous people, you can imagine what they mean in the paintings.";
                        Database.SaveAttractionAsync(Melbourne3);







                        //relink the database
                        database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "city.db3"));
                    }
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
