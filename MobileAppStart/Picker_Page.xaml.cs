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
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Grid grid2x1;
        //TableView tabelview;
        Button prinat;
        Entry entry;
        string newUrl = "";
        string[] lehed = new string[5] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "https://www.youtube.com/watch?v=JZ12O0g86rI" };
        public Picker_Page()
        {
            grid2x1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.DarkGray,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
            };

            picker = new Picker
            {
                Title = "Webilehed"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Youtube");
            picker.Items.Add("Relax music");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView
            { };

            entry = new Entry { Text = "Url" };
            entry.Completed += Entry_Completed;

            /*tabelview = new TableView
            {
                Intent = TableIntent.Form, //могут быть ещё Menu, Data, Settings
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Link:")
                    {
                        new EntryCell
                        {
                            Label="Link:",
                            Placeholder="https" + "",
                            Keyboard=Keyboard.Default
                        }
                    },
                }
            };*/

            prinat = new Button()
            {
                Text="Test"
            };


            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            webView.GestureRecognizers.Add(swipe);
            st = new StackLayout 
            { 
                Children = { }
            };
            StackLayout verticalne = new StackLayout
            {
                Children = { picker, entry },
            };
            grid2x1.Children.Add(st, 0, 1);
            grid2x1.Children.Add(verticalne, 0, 0);
            Content = grid2x1;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            
            newUrl = entry.Text;
            //lehed = new string[6] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "https://www.youtube.com/watch?v=JZ12O0g86rI", newUrl };

            WebLoading();
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[5] };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebLoadinga();
        }
        ///


        public void WebLoadinga()
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }

        public void WebLoading()
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = newUrl },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }


        //GoBack()
        //GoForward()
    }
}