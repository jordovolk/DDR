using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DDR
{
    public class Leaderboard : ContentPage
    {
        public Leaderboard()
        {


            StackLayout layout = new StackLayout
            {
                BackgroundColor = Color.Black,
                Children =
                {
                    new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.Blue,
                        Text = "LeaderBoard"
                    
                    },
                    new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.Blue,
                        Text = "Name: Caleb     Rank: 1st     Score: Infinity motherfucker"
                    },
                    new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        TextColor = Color.Blue,
                        Text = "Name: Jordan    Rank: Last  Score: - 1,000,000"
                    }
                }
            };
            Content = layout;
        }
    }
}
