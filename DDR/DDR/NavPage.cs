using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace DDR
{
    public class NavPage : NavigationPage
    {
        public NavPage()
        {
               PushAsync(new Home());
        }
    }
}
