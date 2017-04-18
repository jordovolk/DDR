using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DDR
{
    class SongSelection : ContentPage
    {


        public SongSelection()
        {
            Label playername = new Label { Text = "Player Name: ", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), TextColor = Color.Green, VerticalOptions = LayoutOptions.Start, Margin = new Thickness(0, 0, 0, 80), HorizontalTextAlignment = TextAlignment.Center };

            Button btnPlaySong = new Button
            {
                Text = "Play Song",
                VerticalOptions = LayoutOptions.Center
            };

            btnPlaySong.Clicked += btnPlaySongClick;
            var stackLayout1 = new StackLayout
            {
                // HorizontalOptions = LayoutOptions.CenterAndExpand,



                Spacing = 5.00,
                Orientation = StackOrientation.Vertical,
                Children =
                {



                   new Label {Text="ArduiDDR Song Selection", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), TextColor = Color.Green, VerticalOptions = LayoutOptions.Start, Margin = new Thickness(0,0,0,80), HorizontalTextAlignment = TextAlignment.Center },
                   playername,
                   btnPlaySong
                   

                
                }


            };

            Content = stackLayout1;

        }

        private void btnPlaySongClick (object sender, EventArgs e)
        {
            
        }


    }

        


    }

