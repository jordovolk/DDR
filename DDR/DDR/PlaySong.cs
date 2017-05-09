using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DDR
{
    public class PlaySong : ContentPage
    {

        // ********** Layouts **********
        StackLayout mainLayout;
        StackLayout controlLayout;
        StackLayout laneContainer;
        StackLayout upLane;
        StackLayout downLane;
        StackLayout leftLane;
        StackLayout rightLane;

        // ********** Controls **********
        Button btnStart;

        // ********** Catch Arrows **********
        Image arwUp;
        Image arwDown;
        Image arwLeft;
        Image arwRight;

        // ********* Other *********
        public static int counter;
        String[] arrows;



        public PlaySong()
        {
            counter = 0;
            arrows = new String[] { "up", "left", "right", "down", "up", "left", "right", "down" };


            // ********** Initiate Controls **********
            btnStart = new Button
            {
                Text = "Start Game",
                BackgroundColor = Color.Silver
            };

            btnStart.Clicked += onBtnStartClick;

            controlLayout = new StackLayout
            {
                Children =
                {
                    btnStart
                }
            };

            // ********** Initiate Arrow Lanes **********

            arwUp = new Image();
            arwUp.Source = ImageSource.FromResource("DDR.arrow_up.png");
            arwUp.VerticalOptions = LayoutOptions.Start;

            arwDown = new Image();
            arwDown.Source = ImageSource.FromResource("DDR.arrow_down.png");
            arwDown.VerticalOptions = LayoutOptions.Start;


            arwLeft = new Image();
            arwLeft.Source = ImageSource.FromResource("DDR.arrow_left.png");
            arwLeft.VerticalOptions = LayoutOptions.Start;

            arwRight = new Image();
            arwRight.Source = ImageSource.FromResource("DDR.arrow_right.png");
            arwRight.VerticalOptions = LayoutOptions.Start;

            upLane = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    arwUp
                }
            };

            downLane = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Pink,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    arwDown
                }
            };

            leftLane = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Yellow,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    arwLeft
                }
            };

            rightLane = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    arwRight
                }
            };

            laneContainer = new StackLayout
            {
                BackgroundColor = Color.Lime,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    upLane, downLane, leftLane, rightLane
                }
            };

            // ********** Initiate Main Container/Page Content **********
            mainLayout = new StackLayout
            {
                BackgroundColor = Color.Maroon,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    controlLayout, laneContainer
                }

            };

            Content = mainLayout;




        }

        void onBtnStartClick(object sender, EventArgs e)
        {
            beginGame();
        }

        void beginGame()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(500), arwScriptStart);
        }

        void throwArrow(String dir)
        {

            double height = laneContainer.Height;

            Image arwNew = new Image
            {
                Source = ImageSource.FromResource("DDR.arrow_" + dir + ".png"),
                VerticalOptions = LayoutOptions.EndAndExpand
            };


            switch (dir)
            {
                case "up":
                    upLane.Children.Add(arwNew);
                    arwNew.TranslateTo(0, (-height + arwUp.Height), 2000);
                    break;

                case "down":
                    downLane.Children.Add(arwNew);
                    arwNew.TranslateTo(0, (-height + arwUp.Height), 2000);
                    break;

                case "left":
                    leftLane.Children.Add(arwNew);
                    arwNew.TranslateTo(0, (-height + arwUp.Height), 2000);
                    break;

                case "right":
                    rightLane.Children.Add(arwNew);
                    arwNew.TranslateTo(0, (-height + arwUp.Height), 2000);
                    break;

                default:
                    break;
            }

        }

        bool arwScriptStart()
        {
            if (counter < arrows.Length)
            {
                throwArrow(arrows[counter]);
                counter++;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

