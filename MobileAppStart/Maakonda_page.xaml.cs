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
    public partial class Maakonda_page : ContentPage
    {
        Picker uezde;
        Picker stolicauezd;
        Grid grid2x1;
        Image kartinki;
        Label proverka;
        Entry entry;
        Label opisanie;
        string okmaa = "";
        string[] pilti = new string[15] { "Harju.jpg", "Hiiu.png", "idaviruuma.png", "jogeva.png", "jarva.png", "laanema.png", "laanevirumaa.png", "polvamaa.png", "parnu.png", "rapla.png", "saare.png", "tartu.png", "valga.png", "viljandi.png", "voru.png"};
        string[] texti = new string[15] { "Harju maakond\n Maakonnalinn: Tallinn", "Hiiu maakond\n Maakonnalinn: Kärdla ", "Ida-Viru maakond\n Maakonnalinn: Jõhvi",
            "Jõgeva maakond\n Maakonnalinn: Jõgeva", "Järva maakond\n Maakonnalinn: Paide", "Lääne maakond\n Maakonnalinn: Haapsalu", "Lääne-Viru maakond\n Maakonnalinn: Rakvere",
            "Põlva maakond\n Maakonnalinn: Põlva", "Pärnu maakond\n Maakonnalinn: Pärnu", "Rapla maakond\n Maakonnalinn: Rapla", "Saare maakond\n Maakonnalinn: Saaremaa",
            "Tartu maakond\n Maakonnalinn: Tartu", "Valga maakond\n Maakonnalinn: Valga", "Viljandi maakond\n Maakonnalinn: Viljandi", "Võru maakond\n Maakonnalinn: Võru" };
        string[] votetonado = new string[15] { "Harju maakond", "Hiiu maakond", "Ida-Viru maakond", "Jõgeva maakond", "Järva maakond", "Lääne maakond", "Lääne-Viru maakond", "Põlva maakond", "Pärnu maakond", "Rapla maakond", "Saare maakond", "Tartu maakond", "Valga maakond", "Viljandi maakond", "Võru maakond" };
        int j;
        int a = 1;
        public Maakonda_page()
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

            /*proverka = new Label
            {
                Text = "Hehe"
            };*/
            uezde = new Picker()
            {
                Title = "Maakonnad"
            };
            uezde.Items.Add("Harju maakond");
            uezde.Items.Add("Hiiu maakond");
            uezde.Items.Add("Ida-Viru maakond");
            uezde.Items.Add("Jõgeva maakond");
            uezde.Items.Add("Järva maakond");
            uezde.Items.Add("Lääne maakond");
            uezde.Items.Add("Lääne-Viru maakond");
            uezde.Items.Add("Põlva maakond");
            uezde.Items.Add("Pärnu maakond");
            uezde.Items.Add("Rapla maakond");
            uezde.Items.Add("Saare maakond");
            uezde.Items.Add("Tartu maakond");
            uezde.Items.Add("Valga maakond");
            uezde.Items.Add("Viljandi maakond");
            uezde.Items.Add("Võru maakond");
            uezde.SelectedIndexChanged += Uezde_SelectedIndexChanged;

            stolicauezd = new Picker()
            {
                Title = "Linn"
            };
            stolicauezd.Items.Add("Tallinn");
            stolicauezd.Items.Add("Kärdla");
            stolicauezd.Items.Add("Jõhvi");
            stolicauezd.Items.Add("Jõgeva");
            stolicauezd.Items.Add("Paide");
            stolicauezd.Items.Add("Haapsalu");
            stolicauezd.Items.Add("Rakvere");
            stolicauezd.Items.Add("Põlva");
            stolicauezd.Items.Add("Pärnu");
            stolicauezd.Items.Add("Rapla");
            stolicauezd.Items.Add("Saaremaa");
            stolicauezd.Items.Add("Tartu");
            stolicauezd.Items.Add("Valga");
            stolicauezd.Items.Add("Viljandi");
            stolicauezd.Items.Add("Võru");
            stolicauezd.SelectedIndexChanged += Stolicauezd_SelectedIndexChanged;

            kartinki = new Image { };
            kartinki.IsVisible = false;

            //FlexLayout horizontal = new FlexLayout
            //{
            //    Children = { uezde},
            //    JustifyContent = FlexJustify.SpaceEvenly
            //};

            entry = new Entry 
            { 
                Placeholder ="Kirjuta Maakond"
            };
            entry.Completed += Entry_Completed;
            opisanie = new Label
            {
                Text = "Maakond",
                TextColor = Color.Black,
                FontSize = 20
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;
            opisanie.GestureRecognizers.Add(tap);

            StackLayout vertical = new StackLayout
            {
                Children = { uezde, stolicauezd, entry, opisanie },
            };

            grid2x1.Children.Add(vertical, 0, 0);
            grid2x1.Children.Add(kartinki, 0, 1);
            Content = grid2x1;

            
        }
        public async void Test()
        {
            
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            okmaa = entry.Text;
            a = 1;
            int c = 0;          
            for (int i = 0; i < votetonado.Length; i++)
            {
                for ( j = 0; j < votetonado.Length; j++)
                {
                    if (okmaa == votetonado[j])
                    {
                        /*bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                        if (answer == true)
                        {
                            kartinki.Source = pilti[j];
                            opisanie.Text = texti[j];
                            kartinki.IsVisible = true;

                        }*/

                        kartinki.Source = pilti[j];
                        opisanie.Text = texti[j];
                        kartinki.IsVisible = true;

                        /*if (a == 1)
                        {
                            Test();
                            a++;
                        }
                        else
                        {

                        }  */
                        //break;
                    }
                }
            }
            if(okmaa == "")
            {
                DisplayAlert("Tähelepanu", "Sellist maakonda pole, kontrollige, kas olete Maakonna õigesti kirjutanud", "Hästi");
            }
            /*int a = int.Parse(Console.ReadLine());
            int[] slova = { 1, 2, 3 };
            bool check = false;
            for (int i = 1; i <= slova.Length; i++)
            {
                if (i == okmaa)
                {
                    check = true;
                    break;
                }
            }
            if (check)
                Console.WriteLine("правильно");
            else
                Console.WriteLine("не правильно");
            */
            /*if (okmaa == "Harju maakond" || okmaa == "harju maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");  
                if (answer ==  true)
                {
                    kartinki.Source = pilti[0];
                    opisanie.Text = texti[0];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Hiiu maakond" || okmaa == "Hiiu maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[1];
                    opisanie.Text = texti[1];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Ida-Viru maakond" || okmaa == "Ida-Viru maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[2];
                    opisanie.Text = texti[2];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Jõgeva maakond" || okmaa == "Jõgeva maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[3];
                    opisanie.Text = texti[3];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Järva maakond" || okmaa == "Järva maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[4];
                    opisanie.Text = texti[4];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Lääne maakond" || okmaa == "Lääne maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[5];
                    opisanie.Text = texti[5];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Lääne-Viru maakond" || okmaa == "Lääne-Viru maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[6];
                    opisanie.Text = texti[6];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Põlva maakond" || okmaa == "Põlva maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[7];
                    opisanie.Text = texti[7];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Pärnu maakond" || okmaa == "Pärnu maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[8];
                    opisanie.Text = texti[8];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Rapla maakond" || okmaa == "Rapla maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[9];
                    opisanie.Text = texti[9];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Saare maakond" || okmaa == "Saare maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[10];
                    opisanie.Text = texti[10];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Tartu maakond" || okmaa == "Tartu maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[11];
                    opisanie.Text = texti[11];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Valga maakond" || okmaa == "Valga maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[12];
                    opisanie.Text = texti[12];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Viljandi maakond" || okmaa == "Viljandi maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[13];
                    opisanie.Text = texti[13];
                    kartinki.IsVisible = true;
                }
            }
            else if (okmaa == "Võru maakond" || okmaa == "Võru maakond")
            {
                bool answer = await DisplayAlert("Küsimus", "Kas soovite rohkem teavet?", "Jah", "Ei");
                if (answer == true)
                {
                    kartinki.Source = pilti[14];
                    opisanie.Text = texti[14];
                    kartinki.IsVisible = true;
                }
            }*/

        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            //kartinki.IsVisible = true;
        }

        private void Uezde_SelectedIndexChanged(object sender, EventArgs e)
        {
            stolicauezd.SelectedIndex = uezde.SelectedIndex;
            //proverka.Text = uezde.SelectedIndex.ToString();
            kartinki.Source = pilti[uezde.SelectedIndex];
            opisanie.Text = texti[uezde.SelectedIndex];
            kartinki.IsVisible = true;
        }
        private void Stolicauezd_SelectedIndexChanged(object sender, EventArgs e)
        {
            uezde.SelectedIndex = stolicauezd.SelectedIndex;
        }


    }
}