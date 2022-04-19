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
    public partial class RGB_View : ContentPage
    {
        Slider sldre, sldgree, sldblu;
        Frame fr;
        Label tere, tegree, teblu;
        Label nadpis;
        int reint = 0;
        int greeint = 0;
        int bluint = 0;
        Button randombtn;
        Random rnd = new Random();

        public RGB_View()
        {
            nadpis = new Label
            {
                Text = "Värv: ",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
                Padding = 20,
            };
            tere = new Label
            {
                Text = "R = " + reint,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
                Padding = 20,
            };

            tegree = new Label
            {
                Text = "G = " + greeint,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
                Padding = 20,
            };

            teblu = new Label
            {
                Text = "B = " + bluint,
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)),
                TextColor = Color.Black,
                Padding = 20,
        };
            fr = new Frame
            {

                BorderColor = Color.Black,
                CornerRadius = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            sldre = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
                //Margin = 20
            };
            sldre.ValueChanged += Sldre_ValueChanged;
            sldgree = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
                //Margin = 20
            };
            sldgree.ValueChanged += Sldgree_ValueChanged;
            sldblu = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Red,
                //Margin = 20
            }; 
            sldblu.ValueChanged += Sldblu_ValueChanged;

            randombtn = new Button
            {
                Text = "Random Color",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Tomato,
                TextColor = Color.Black
            };
            randombtn.Clicked += Randombtn_Clicked;
            StackLayout st = new StackLayout
            {
                Children = { fr, tere, sldre, tegree, sldgree, teblu, sldblu, randombtn }
            };
            Content = st;
            st.BackgroundColor = Color.PeachPuff;

        }

        private void Randombtn_Clicked(object sender, EventArgs e)
        {
            int rernd = rnd.Next(0, 255);
            int greernd = rnd.Next(0, 255);
            int blurnd = rnd.Next(0, 255);

            sldre.Value = rernd;
            sldgree.Value = greernd;
            sldblu.Value = blurnd;

            
            fr.BackgroundColor = Color.FromRgb(rernd, greernd, blurnd);
        }

        private void Sldblu_ValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == sldre)
            {
                tere.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldgree)
            {
                tegree.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldblu)
            {
                teblu.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }
            fr.BackgroundColor = Color.FromRgb((int)sldre.Value, (int)sldgree.Value, (int)sldblu.Value);
        }

        private void Sldgree_ValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == sldre)
            {
                tere.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldgree)
            {
                tegree.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldblu)
            {
                teblu.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }
            fr.BackgroundColor = Color.FromRgb((int)sldre.Value, (int)sldgree.Value, (int)sldblu.Value);
        }

        private void Sldre_ValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender == sldre)
            {
                tere.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldgree)
            {
                tegree.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldblu)
            {
                teblu.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
                //nadpis.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }
            fr.BackgroundColor = Color.FromRgb((int)sldre.Value, (int)sldgree.Value, (int)sldblu.Value);

            /*String textre = sldre.Value.ToString();
            String textgree = sldgree.Value.ToString();
            String textblu = (2525).ToString();*/
        }
    }
}
