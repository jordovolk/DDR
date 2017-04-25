using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DDR
{
    class PlaySong : ContentPage
    {
        public PlaySong()
        {
            Button btnStart = new Button
            {
                Text = "Start",
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0,  620, 0, 0),
                BorderColor = Color.Blue,
                BackgroundColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Fill,
                Font = Font.SystemFontOfSize(NamedSize.Large)
              .WithAttributes(FontAttributes.Bold),
                TextColor = Color.White
            };

            Button btnPause = new Button
            {
                Text = "Pause",
                VerticalOptions = LayoutOptions.Center,
                BorderColor = Color.Blue,
                BackgroundColor = Color.Blue,
                Font = Font.SystemFontOfSize(NamedSize.Large)
             .WithAttributes(FontAttributes.Bold),
                TextColor = Color.White
            };

            Button btnRestart = new Button
            {
                Text = "Restart",
                VerticalOptions = LayoutOptions.Center,
                BorderColor = Color.Blue,
                BackgroundColor = Color.Blue,
                Font = Font.SystemFontOfSize(NamedSize.Large)
        .WithAttributes(FontAttributes.Bold),
                TextColor = Color.White
            };


            StackLayout layout = new StackLayout
            {
                BackgroundColor = Color.Black,
                Children =
                {
                    new Label
                    {
                        FontSize =  Device.GetNamedSize(NamedSize.Large, typeof(Label)), Font = Font.SystemFontOfSize(NamedSize.Large)
              .WithAttributes(FontAttributes.Bold),
                        HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White,
                        Text = "Ready to dance???"

                    },
                  btnStart,
                  btnPause,
                  btnRestart
                    
                }
            };
            Content = layout;
        }
    }
}
