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
        Button btnUp;
        Button btnDown;
        Button btnLeft;
        Button btnRight;
        Label lblScore;

        // ********** Catch Arrows **********
        Image arwUp;
        Image arwDown;
        Image arwLeft;
        Image arwRight;

        // ********* Other *********
        public int tickCounter;
        public int arrowCounter;
        public int catchCounter;
        Arrow[] arrows;
        Arrow nextArrow;
        Arrow nextCatch;
        public int arrowsHit;
        public int arrowsTotal;
        bool gameStarted,
            arwUpHit,
            arwDownHit,
            arwRightHit,
            arwLeftHit;

        string playerMove;



        public PlaySong()
        {
            
            
            gameStarted = false;
           
            

            //arrows = new String[] { "up", "left", "right", "down", "up", "left", "right", "down" };
            


            // ********** Initiate Controls **********
            btnStart = new Button
            {
                Text = "Start Game",
                BackgroundColor = Color.Silver
            };

            btnUp = new Button
            {
                Text = "^",
                BackgroundColor = Color.Silver
            };

            btnDown = new Button
            {
                Text = "V",
                BackgroundColor = Color.Silver
            };

            btnLeft = new Button
            {
                Text = "<",
                BackgroundColor = Color.Silver
            };

            btnRight = new Button
            {
                Text = ">",
                BackgroundColor = Color.Silver
            };

            btnStart.Clicked += onBtnStartClick;
            btnUp.Clicked += onBtnUpClick;
            btnDown.Clicked += onBtnDownClick;
            btnLeft.Clicked += onBtnLeftClick;
            btnRight.Clicked += onBtnRightClick;

            lblScore = new Label
            {
                Text = "0/0",
                BackgroundColor = Color.Red,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            controlLayout = new StackLayout

            {
                Orientation = StackOrientation.Horizontal,

                Children =
                {

                    btnUp, btnDown, btnLeft, btnRight
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
                    controlLayout, laneContainer, lblScore
                }

            };

            Content = mainLayout;




        }

        void onBtnStartClick(object sender, EventArgs e)
        {
            beginGame();
        }

        void onBtnUpClick(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                beginGame();
            }
            else
            {
                //arwUpHit = true;
                playerMove = "up";
            }
        }
        void onBtnDownClick(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                beginGame();
            }
            else
            {
                //arwDownHit = true;
                playerMove = "down";
            }
        }
        void onBtnLeftClick(object sender, EventArgs e)
        {
            if(!gameStarted)
            {
                beginGame();
            }
            else
            {
                //arwLeftHit = true;
                playerMove = "left";
            }
        }
        void onBtnRightClick(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                beginGame();
            }
            else
            {
                //arwRightHit = true;
                playerMove = "right";
            }
        }

        void beginGame()
        {
            gameStarted = true;
            tickCounter = 0;
            arrowCounter = 0;
            catchCounter = 0;
            arrowsHit = 0;
            arrowsTotal = 0;
            //arwUpHit = false;
            //arwDownHit = false;
            //arwLeftHit = false;
            //arwRightHit = false;
            playerMove = "";
            arrows = new Arrow[]
            {
                new Arrow("up", 2),
                new Arrow("down", 4),
                new Arrow("left", 6),
                new Arrow("right", 8),
                new Arrow("up", 14),
                new Arrow("down", 16),
                new Arrow("left", 18),
                new Arrow("right", 20)

            };
            nextArrow = arrows[arrowCounter];
            nextCatch = arrows[catchCounter];

            Device.StartTimer(TimeSpan.FromMilliseconds(250), arwScriptStart);
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

        //bool arwScriptStart()
        //{
        //    if (counter < arrows.Length)
        //    {
        //        throwArrow(arrows[counter]);
        //        counter++;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

            bool arwScriptStart()
        {
            if(tickCounter >= nextCatch.EndTickLower && tickCounter <= nextCatch.EndTickUpper)
            {
                if(playerMove == nextCatch.Direction)
                {
                    arrowsHit++;
                    arrowsTotal++;
                    catchCounter++;
                    if (catchCounter < arrows.Length)
                    {
                        nextCatch = arrows[catchCounter];
                    }

                } else if(tickCounter == nextCatch.EndTickUpper)
                {

                    arrowsTotal++;
                    catchCounter++;
                    if (catchCounter < arrows.Length)
                    {
                        nextCatch = arrows[catchCounter];
                    }


                }
                updateScore();
            }

            if(nextArrow.StartTick == tickCounter)
            {
                throwArrow(nextArrow.Direction);
                arrowCounter++;
                if(arrowCounter < arrows.Length)
                {
                    nextArrow = arrows[arrowCounter];
                } else
                {
                    //No more arrows to throw
                }
            }
            tickCounter++;
            //arwUpHit = false;
            //arwDownHit = false;
            //arwLeftHit = false;
            //arwRightHit = false;
            return true;
        }

        public void updateScore()
        {
            lblScore.Text = arrowsHit.ToString() + "/" + arrowsTotal.ToString();
        }

        class Arrow
        {

            public String Direction
            {
                get;set;
            }
            public int StartTick
            {
                get;set;
            }

            public int EndTickLower
            {
                get;set;
            }

            public int EndTickUpper
            {
                get;set;
            }

            public Arrow(String dir, int startTick)
            {
                Direction = dir;
                StartTick = startTick;
                EndTickLower = startTick + 9;
                EndTickUpper = startTick + 11;
            }
        }
    }
}

