using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Image_page : ContentPage
    {
        Switch sw;
        Image img;
        public Image_page()
        {
            img = new Image { Source = "cat.jpg" };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;
            img.GestureRecognizers.Add(tap);
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = { img, sw } };
        }
        int tapid;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            tapid++;
            var imagesender = (Image)sender;
            if (tapid % 2 == 0)
            {
                img.Source = "cat2.jpg";
            }
            else { img.Source = "cat.jpg"; }
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}