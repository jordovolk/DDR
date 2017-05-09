using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DDR
{
    class Home : ContentPage
    {
        public Home()
        {
            Button btnPlayGame = new Button
            {
                Text = "Play Game",
                VerticalOptions = LayoutOptions.Center,
                BorderColor = Color.Blue,
                BackgroundColor = Color.Blue,
                Font = Font.SystemFontOfSize(NamedSize.Large)
              .WithAttributes(FontAttributes.Bold),
                TextColor = Color.White
            };

            Button btnLeaderboard = new Button
            {
                Text = "Leaderboard",
                VerticalOptions = LayoutOptions.Center,
                BorderColor = Color.Blue,
                BackgroundColor = Color.Blue,
                Font = Font.SystemFontOfSize(NamedSize.Large)
              .WithAttributes(FontAttributes.Bold),
                TextColor = Color.White
            };

            btnLeaderboard.Clicked += btnLeaderboardClick;
            btnPlayGame.Clicked += btnPlayClick;


            var stackLayout = new StackLayout
            {
                // HorizontalOptions = LayoutOptions.CenterAndExpand,


                BackgroundColor = Color.Black,
                Spacing = 5.00,
                Orientation = StackOrientation.Vertical,
                Children =
                {



                   new Label {Text="ArduiDDR", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), TextColor = Color.White, VerticalOptions = LayoutOptions.Start, Margin = new Thickness(0,0,0,80), HorizontalTextAlignment = TextAlignment.Center },
                   btnPlayGame, 
                   btnLeaderboard

                  // new Button {Text="Play Game", VerticalOptions = LayoutOptions.Center },

                  // new Button {Text="Leaderboard", VerticalOptions = LayoutOptions.Center }

                }

                

            };

            Content = stackLayout;

        }

        private void btnPlayClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SongSelection());
        }

        private void btnLeaderboardClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Leaderboard());
        }




    }
}
