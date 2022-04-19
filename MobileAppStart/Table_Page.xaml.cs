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
    public partial class Table_Page : ContentPage
    {
        TableView tabelview;
        SwitchCell sc;
        ImageCell ic;
        TableSection fotosection;
        public Table_Page()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("cat.jpg"),
                Text = "Foto Nimetus",
                Detail = "Foto kirjeldus"
            };
            fotosection = new TableSection();
            tabelview = new TableView
            {
                Intent = TableIntent.Form, //могут быть ещё Menu, Data, Settings
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Sisesta oma sõbra nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label="Telefon",
                            Placeholder="Sisesta tel. number",
                            Keyboard=Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label="Email",
                            Placeholder="Sisesta email",
                            Keyboard=Keyboard.Email
                        },
                        sc
                    },
                    fotosection
                }
            };
            Content = tabelview;
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto:";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }
        }
    }
}