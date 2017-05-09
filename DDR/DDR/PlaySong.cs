using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DDR
{
    public class PlaySong : ContentPage
    {
       
        // ********** Arrow Images **********
        Image arwMoving;
        Image arwUp;
        Image arwDown;
        Image arwLeft;
        Image arwRight;

        // ********** Layouts **********
        StackLayout mainLayout;
        StackLayout catchLayout;
        StackLayout throwLayout;

        Button btn;
        Image blank;

        public PlaySong()
        {
            BackgroundColor = Color.White;



            // ********** Images *******//
            arwUp = new Image();
            arwDown = new Image();
            arwLeft = new Image();
            arwRight = new Image();

            arwUp.Source = ImageSource.FromResource("DDR.arrow_up.png");
            arwUp.Aspect = Aspect.AspectFit;

            arwDown.Source = ImageSource.FromResource("DDR.arrow_down.png");
            arwDown.Aspect = Aspect.AspectFit;

            arwLeft.Source = ImageSource.FromResource("DDR.arrow_left.png");
            arwLeft.Aspect = Aspect.AspectFit;

            arwRight.Source = ImageSource.FromResource("DDR.arrow_right.png");
            arwRight.Aspect = Aspect.AspectFit;

            arwMoving = new Image();
            arwMoving.Aspect = Aspect.AspectFit;
            arwMoving.Source = ImageSource.FromResource("DDR.arrow_left.png");
            arwMoving.VerticalOptions = LayoutOptions.End;

            blank = new Image();
            blank.Aspect = Aspect.AspectFit;
            blank.Source = ImageSource.FromResource("DDR.blank.png");
            blank.VerticalOptions = LayoutOptions.End;


            // ********** BUtton Shit **********
            btn = new Button();
            btn.Text = "Start";
            btn.Clicked += onBtnClick;

            // ********** Layout shit **********

            throwLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Blue,
                Children =
                {
                }
            };

            catchLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Red,
                Spacing = 0,
                Children =
                {
                    arwUp, arwDown, arwLeft, arwRight
                }

            };

            mainLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Silver,
                Children =
                {
                    catchLayout, btn, throwLayout
                }
            };
            Content = mainLayout;




        }

        

        public void onBtnClick(object sender, EventArgs e)
        {
            double height = mainLayout.Height;
            double width = mainLayout.Width;
            double arwHeight = arwRight.Height;

            arwMoving = new Image();
            arwMoving.Aspect = Aspect.AspectFit;
            arwMoving.Source = ImageSource.FromResource("DDR.arrow_left.png");
            arwMoving.VerticalOptions = LayoutOptions.End;

          
            throwLayout.Children.Add(arwMoving);
           

            arwMoving.TranslateTo(0, (-height + arwHeight), 4000);
           
        }


    }
}
