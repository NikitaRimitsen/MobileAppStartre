using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppStart
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            //InitializeComponent();
            StackLayout st = new StackLayout();
            Button b = new Button() 
            {
                Text = "Open",
                BackgroundColor = Color.SandyBrown
            };
            Button timer_b = new Button()
            {
                Text = "Time",
                BackgroundColor = Color.SandyBrown
            };
            timer_b.Clicked += timer_b_Clicked;
            Button box_b = new Button()
            {
                Text = "Clicker",
                BackgroundColor = Color.SandyBrown
            };
            box_b.Clicked += box_b_Clicked;
            Button box_date = new Button()
            {
                Text = "Date/Time",
                BackgroundColor = Color.SandyBrown
            };
            box_date.Clicked += box_date_Clicked;
            Button box_ss = new Button()
            {
                Text = "Stepper/slider",
                BackgroundColor = Color.SandyBrown
            };
            box_ss.Clicked += box_ss_Clicked;
            Button framebtn = new Button()
            {
                Text = "Frame",
                BackgroundColor = Color.SandyBrown
            };
            framebtn.Clicked += framebtn_Clicked;
            Button imgbtn = new Button()
            {
                Text = "Image",
                BackgroundColor = Color.SandyBrown
            };
            imgbtn.Clicked += imgbtn_Clicked;
            Button trafficbtn = new Button()
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.SandyBrown
            };
            trafficbtn.Clicked += trafficbtn_Clicked;
            Button rgbbtn = new Button()
            {
                Text = "RGB",
                BackgroundColor = Color.SandyBrown
            };
            rgbbtn.Clicked += Rgbbtn_Clicked;
            Button ttt = new Button()
            {
                Text = "Trips traps trull",
                BackgroundColor = Color.SandyBrown
            };
            ttt.Clicked += Ttt_Clicked;
            Button pickerbtn = new Button()
            {
                Text = "Picker",
                BackgroundColor = Color.DarkKhaki
            };
            pickerbtn.Clicked += Pickerbtn_Clicked;
            Button tablebtn = new Button()
            {
                Text = "Table",
                BackgroundColor = Color.DarkKhaki
            };
            tablebtn.Clicked += Tablebtn_Clicked;
            Button maabtn = new Button()
            {
                Text = "Maakonnad",
                BackgroundColor = Color.DarkKhaki
            };
            maabtn.Clicked += Maabtn_Clicked;
            Button horosbtn = new Button()
            {
                Text = "Horoskop",
                BackgroundColor = Color.DarkKhaki
            };
            horosbtn.Clicked += Horosbtn_Clicked;
            Button ajabtn = new Button()
            {
                Text = "Ajaplaan",
                BackgroundColor = Color.DarkKhaki
            };
            ajabtn.Clicked += Ajabtn_Clicked; 

            //st = {b,timer}
            //st.Children.Add(b);
            //st.Children.Add(timer_b);
            st.Children.Add(box_b);
            st.Children.Add(box_date);
            //st.Children.Add(box_ss);
            //st.Children.Add(framebtn);
            st.Children.Add(imgbtn);
            st.Children.Add(trafficbtn);
            st.Children.Add(rgbbtn);
            st.Children.Add(ttt);
            st.Children.Add(pickerbtn);
            st.Children.Add(tablebtn);
            st.Children.Add(maabtn);
            st.Children.Add(horosbtn);
            st.Children.Add(ajabtn);
            st.BackgroundColor = Color.Cornsilk;
            Content = st;
            b.Clicked += B_Clicked;

            /*ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Children =
                {
                        Content
                    // More Label objects go here
                }
                }
            };*/
        }

        private async void Ajabtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ajaplaan());
        }

        private async void Horosbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Horoskop_Page());
        }

        private async void Maabtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Maakonda_page());
        }

        private async void Tablebtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Table_Page());
        }

        private async void Pickerbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Picker_Page());
        }

        private async void Ttt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Blank_ttt());
        }

        private async void Rgbbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RGB_View());
        }

        private async void trafficbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Svetofor());
        }
        private async void imgbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Image_page());
        }

        private async void framebtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FramePage());
        } 
        private async void box_ss_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SliderPage());
        }

        private async void box_date_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Date());
        }

        private async void box_b_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_View_Page());
        }

        private async void timer_b_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Timer());
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry_Page());
        }
    }
}
