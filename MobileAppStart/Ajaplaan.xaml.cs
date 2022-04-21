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
    public partial class Ajaplaan : ContentPage
    {
        Label nazvanie;
        TimePicker vremja;
        Image kartinka;
        Grid grid2x1;
        string[] komp = new string[] { "У тебя все получится!", "Не сдавайся!", "Ты сможешь!" };
        Random rnd = new Random();
        public Ajaplaan()
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
            vremja = new TimePicker { };
            vremja.PropertyChanged += Vremja_PropertyChanged;
            //string a = rnd.ToString();
            nazvanie = new Label {
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };
            kartinka = new Image
            {
                Source = "cat.jpg"
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;
            kartinka.GestureRecognizers.Add(tap);

            StackLayout verticalx2 = new StackLayout
            {
                Children = { vremja, nazvanie },
            };
            grid2x1.Children.Add(verticalx2, 0, 0);
            grid2x1.Children.Add(kartinka, 0, 1);
            Content = grid2x1;
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {

            bool answer = await DisplayAlert("Вопрос", "Хотите ли вы получить комплимент", "Да", "Нет");
            if (answer == true)
            {
                DisplayAlert("Комплимент", "У тебя все получится!", "Спасибо!");
            }
            else
            {

            }

        }

        private void Vremja_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var time = vremja.Time.Hours;
            if (time>=0 && time<3)
            {
                nazvanie.Text = "Ночь, уже спать надо!";
                kartinka.Source = "noc.jpg";
            }
            else if (time == 3)
            {
                nazvanie.Text = "Глубокая ночь!";
                kartinka.Source = "glubnoc.jpg";
                //kartinka = new Image { Source = "cat2.jpg" };
            }
            else if (time >= 4 && time < 6)
            {
                nazvanie.Text = "Раннее утро!";
                kartinka.Source = "raneeutro.jpg";
            }
            else if (time >= 6 && time < 8)
            {
                nazvanie.Text = "Доброе утро!";
                kartinka.Source = "utro.jpg";
            }
            else if (time >= 8 && time < 10)
            {
                nazvanie.Text = "Утро, в школе должен быть уже!";
                kartinka.Source = "utrosko.jpeg";
            }
            else if (time >= 10 && time < 12)
            {
                nazvanie.Text = " Утро!";
                kartinka.Source = "utronov.jpg";
            }
            else if (time >= 12 && time < 14)
            {
                nazvanie.Text = "Полдень!";
                kartinka.Source = "polden.jpg";
            }
            else if (time >= 14 && time < 16)
            {
                nazvanie.Text = "День!";
                kartinka.Source = "den.jpg";
            }
            else if (time >= 16 && time < 18)
            {
                nazvanie.Text = "Почти вечер!";
                kartinka.Source = "poctivexer.jpg";
            }
            else if (time >= 18 && time < 21)
            {
                nazvanie.Text = "Вечер!";
                kartinka.Source = "vecer.jpg";
            }
            else if (time >= 21 && time < 23)
            {
                nazvanie.Text = "Уже почти ночь, пора спать!";
                kartinka.Source = "poctinoc.jpg";
            }
            else if (time == 23)
            {
                nazvanie.Text = "Ночь!";
                kartinka.Source = "noca.jpg";
            }
        }
    }
}