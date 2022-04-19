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
    public partial class Blank_ttt : ContentPage
    {

        /*Frame pole;
        Label lbl;
        Grid kvadrat;
        Button newgame, vebor;*/
        Grid grid2x1, grid3x3;
        //BoxView b;
        Image b;
        Frame pokazatel;
        Button uus_mang, pravila, temapilti, pole, zvuk;
        public bool esimene;
        public bool razmerepole;
        int tulemus = 0;
        int[,] Tulemused = new int[4, 4];//int[,] Tulemused = new int[3, 3];
        int[,] Nicja = new int[4, 4];//int[,] Tulemused = new int[3, 3];
        string[] krest = {"krest.png", "xred.jpg" };
        string[] nolik = { "nolik.png", "ored.png" };
        int arazmerpole = 0;
        int chet = 0;
        int kartinkasmena = 0;
        //string x = "X";
        //string o = "O";
        public Blank_ttt()
        {
            DependencyService.Get<IAudio>().PlayAudioFile("muzekaigraofficial.wav");
            grid2x1 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.DarkGray,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                }
            };
            Pole_Clicked();

            
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            pravila = new Button()
            {
                Text = "Reegel"
            };
            temapilti = new Button()
            {
                Text = "Välimus"
            };
            pole = new Button()
            {
                Text = "Välja suurus"
            };
            zvuk = new Button()
            {
                Text = "Audio"
            };
            pokazatel = new Frame()
            {
                BackgroundColor = Color.DarkGray,
                //Content = new Image { Source = krest[1] },
                WidthRequest = 30,
                HeightRequest = 30,
            };
            StackLayout kto = new StackLayout
            {
                Children = { pokazatel },
                HorizontalOptions = LayoutOptions.Center,
            };
            StackLayout knopki2 = new StackLayout
            {
                Children = { uus_mang, pravila, temapilti},
            };
            StackLayout knopki3 = new StackLayout
            {
                Children = { pole, zvuk},
            };
            FlexLayout knopki = new FlexLayout
            {
                Children = { kto, knopki2, knopki3 },
                JustifyContent = FlexJustify.SpaceEvenly
            };
            grid2x1.Children.Add(knopki, 0, 1);
            uus_mang.Clicked += Uus_mang_Clicked;
            pravila.Clicked += Pravila_Clicked;
            temapilti.Clicked += Temapilti_Clicked;
            pole.Clicked += Pole_Clicked1;
            zvuk.Clicked += Zvuk_Clicked;
            Content = grid2x1;
            
        }

        int vklvekl = 0;
        private void Zvuk_Clicked(object sender, EventArgs e)
        {
            
            if (vklvekl == 0)
            {
                DependencyService.Get<IAudio>().Stop("muzekaigraofficial.wav");
                vklvekl++;
            }
            else if (vklvekl == 1)
            {
                DependencyService.Get<IAudio>().PlayAudioFile("muzekaigraofficial.wav");
                vklvekl = 0;
            }
        }

        public async void Pole_Clicked1(object sender, EventArgs e)
        {
            string razmerpole = await DisplayPromptAsync("Välja suurus", "Tee valiku 3x3 - 1 või 4x4 - 2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (razmerpole == "1")
            {
                razmerepole = true;
                
            }
            else if (razmerpole == "2")
            {
                razmerepole = false;
            }
            else
            {
                razmerepole = true;
            }
        }
        public async void Pole_Clicked()
        {
            string razmerpole = await DisplayPromptAsync("Välja suurus", "Tee valiku 3x3 - 1 või 4x4 - 2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (razmerpole == "1")
            {
                razmerepole = true;
               
                Uus_mang();
            }
            else if(razmerpole == "2")
            {
                razmerepole = false;
                
                Uus_mang();
            }
            else
            {
                Pole_Clicked();
            }
        }       
        private void Temapilti_Clicked(object sender, EventArgs e)
        {

            if (chet==0)
            {
                pokazatel.BackgroundColor = Color.Peru;
                grid2x1.BackgroundColor = Color.Peru;
                //grid3x3.BackgroundColor = Color.SandyBrown;
                chet++;
                kartinkasmena = 1;

            }
            else if (chet==1)
            {
                pokazatel.BackgroundColor = Color.DarkGray;
                grid2x1.BackgroundColor = Color.Silver;
                //grid3x3.BackgroundColor = Color.Black;
                chet = 0;
                kartinkasmena = 0;
            }
            
        }
        private void Pravila_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Reegel", "3x3 - \nMängijad kordamööda panna vaba lahtrid valdkonnas 3 core 3 märgid(üks on alati ristid, teine on alati null). Võidab esimene, " +
                "kes rivistab 3 oma tükki vertikaalselt, horisontaalselt või diagonaalselt. Esimese käigu teeb mängija, kes paneb risti.\n" +
                "4x4 - \nTänu suuruse suurenemisele ilmub palju uusi käike ja siis muutub duell pingelisemaks. Reeglid jäävad samaks – on kaks külge, üks saab " +
                "joonistada ainult riste ja teine ringe. On vaja teha rida neljast identsest märgist horisontaalselt, diagonaalselt või vertikaalselt.", "Ok");
        }
        public async void Kes_on_Esimene()
        {
            string esimine = await DisplayPromptAsync("Kes on esimene?", "Tee valiku X - 1 või O - 2", initialValue:"1", maxLength:1, keyboard:Keyboard.Numeric);
            if (esimine == "1")
            {
                esimene = true;
                pokazatel.Content = new Image { Source = krest[0] };
            }
            else if(esimine == "2")
            {
                esimene = false;
                pokazatel.Content = new Image { Source = nolik[0] };
            }
            else
            {
                Kes_on_Esimene();
                /*esimene = true;
                pokazatel.Content = new Image { Source = krest[0] };*/
            }
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();
            temapilti.IsEnabled = true;
            
            grid3x3.IsEnabled = true;
            
        }
        public async void Uus_mang()
        {
            /*using (var soundPlayer = new SoundPlayer(@"../../sound/muzekaigraofficial.wav"))
            {
                //igrasound = 0;
                soundPlayer.Play();
            }*/
            bool uus =await DisplayAlert("Uus mäng", "Kas tõesti tahad uus mäng?", "Tahan küll!", "Ei taha!");
            if (uus)
            {
                Kes_on_Esimene();
                /*if (chet == 0)
                {
                    grid2x1.BackgroundColor = Color.Peru;
                    grid3x3.BackgroundColor = Color.SandyBrown;

                }
                else if (chet == 1)
                {
                    grid2x1.BackgroundColor = Color.Silver;
                    grid3x3.BackgroundColor = Color.Black;
                }*/
                tulemus = -2;
                if (razmerepole==true)
                {
                    Tulemused = new int[3, 3];
                    Nicja = new int[3, 3];
                    arazmerpole = 3;
                }
                else
                {
                    Tulemused = new int[4, 4];
                    Nicja = new int[4, 4];
                    arazmerpole = 4;
                }
                //Tulemused = new int[3, 3];
                grid3x3 = new Grid
                {
                        BackgroundColor = Color.Black,
                    
                };
                for (int i = 0; i < arazmerpole; i++)//for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < arazmerpole; j++)//for (int j = 0; j < 3; j++)
                    {
                        b = new Image { Source = "belej.jpg" };
                        grid3x3.Children.Add(b, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        b.GestureRecognizers.Add(tap);
                    }
                }
                grid2x1.Children.Add(grid3x3, 0, 0);
            }           
        }
        //List<string> voit = new List<string> { "001020", "011121", "021222", "000102", "101112", "202122", "001122", "021120" };       
        public int Kontroll()
        {
            //--------------------------Proverka dlja krestika------------------------
            if (Tulemused[0,0]==1 && Tulemused[1,0]==1 && Tulemused[2,0]==1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && 
                Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            //--------------------------Proverka dlja nolika------------------------
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[1, 2] == 2|| Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[2, 0] == 2)
            {
                tulemus = 2;
            }
            //--------------------------Nicja--------------------------
            else if (Tulemused[0, 0] == 4 && Tulemused[1, 0] == 4 && Tulemused[2, 0] == 4 && Tulemused[0, 1] == 4 && Tulemused[1, 1] == 4 &&
                Tulemused[2, 1] == 4 && Tulemused[0, 2] == 4 && Tulemused[1, 2] == 4 && Tulemused[2, 2] == 4)
            {
                tulemus = -3;
            }
            /*else
            {
                tulemus = -3;
            }*/
            return tulemus;
        }
        public int Kontroll4na4()
        {
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 && Tulemused[3, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[2, 1] == 1 && Tulemused[3, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1 && Tulemused[3, 2] == 1 || Tulemused[0, 3] == 1 && Tulemused[1, 3] == 1 && Tulemused[2, 3] == 1 && Tulemused[3, 3] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 && Tulemused[0, 3] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 &&
                Tulemused[1, 2] == 1 && Tulemused[1, 3] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1 && Tulemused[2, 3] == 1 || Tulemused[3, 0] == 1 && Tulemused[3, 1] == 1 && Tulemused[3, 2] == 1 && Tulemused[3, 3] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 && Tulemused[3, 3] == 1 || Tulemused[0, 3] == 1 && Tulemused[1, 2] == 1 &&
                Tulemused[2, 1] == 1 && Tulemused[3, 0] == 1)
            {
                tulemus = 1;
            }        
            //--------------------------Proverka dlja nolika------------------------
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 && Tulemused[3, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[2, 1] == 2 && Tulemused[3, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2 && Tulemused[3, 2] == 2 || Tulemused[0, 3] == 2 && Tulemused[1, 3] == 2 && Tulemused[2, 3] == 2 && Tulemused[3, 3] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 && Tulemused[0, 3] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 &&
                Tulemused[1, 2] == 2 && Tulemused[1, 3] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2 && Tulemused[2, 3] == 2 || Tulemused[3, 0] == 2 && Tulemused[3, 1] == 2 && Tulemused[3, 2] == 2 && Tulemused[3, 3] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 && Tulemused[3, 3] == 2 || Tulemused[0, 3] == 2 && Tulemused[1, 2] == 2 &&
                Tulemused[2, 1] == 2 && Tulemused[3, 0] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 4 && Tulemused[1, 0] == 4 && Tulemused[2, 0] == 4 && Tulemused[3, 0] == 4 && Tulemused[0, 1] == 4 && Tulemused[1, 1] == 4 &&
                Tulemused[2, 1] == 4 && Tulemused[3, 1] == 4 && Tulemused[0, 2] == 4 && Tulemused[1, 2] == 4 && Tulemused[2, 2] == 4 && Tulemused[3, 2] == 4 && Tulemused[0, 3] == 4 && Tulemused[1, 3] == 4 && Tulemused[2, 3] == 4 && Tulemused[3, 3] == 4)
            {
                tulemus = -3;
            }
            /*else
            {
                tulemus = -3;
            }*/
            return tulemus;
        }
        public void Lopp()
        {
            if (razmerepole == true)
            {
                tulemus = Kontroll();
            }
            else if((razmerepole == false))
            {
                tulemus = Kontroll4na4();
            }
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "X on võitja!", "Ok");
                grid3x3.IsEnabled = false;
                pole.IsEnabled = true;
            }
            else if (tulemus == 2)
            {
                DisplayAlert("Võit", "O on võitja!", "Ok");
                grid3x3.IsEnabled = false;
                pole.IsEnabled = true;
            }
            /*if (tulemus == -3)
            {
                DisplayAlert("Võit", "Viik!", "Ok");
            }*/

            else if (tulemus == -3)
            {
                DisplayAlert("Võit", "Nicja", "Ok");
            }
        }
        public void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (Image)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);

            if (esimene==true)
            {
                b = new Image { Source = krest[kartinkasmena] };
                pokazatel.Content = new Image { Source = nolik[0] };
                esimene = false;
                Tulemused[r, c] = 1;
                Nicja[r, c] = 4;
                temapilti.IsEnabled = false;
                pole.IsEnabled = false;
            }
            else
            {
                b = new Image { Source = nolik[kartinkasmena] };
                pokazatel.Content = new Image { Source = krest[0] };
                esimene = true;
                Tulemused[r, c] = 2;
                Nicja[r, c] = 4;
                temapilti.IsEnabled = false;
                pole.IsEnabled = false;
            }           
            grid3x3.Children.Add(b, c, r);
            Lopp();
        }
    }
}