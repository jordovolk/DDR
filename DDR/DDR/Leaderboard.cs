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
                Children =
                {
                    new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "LeaderBoard"
                    
                    },
                    new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        Text = "Name: Caleb     Rank: 1st     Score: Infinity motherfucker"
                    },
                    new Label
                    {
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        Text = "Name: Jordan    Rank: Last  Score: - 1,000,000"
                    }
                }
            };
            Content = layout;
        }
    }
}
