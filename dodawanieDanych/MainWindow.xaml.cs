using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dodawanieDanych
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string plikDoWczytania = "C:\\Users\\zosta\\source\\repos\\sem4\\progr\\kontrolkiTest\\dodawanieDanych\\dane.txt";
        Pilkarz tenSamPilkarz = null;

        public MainWindow()
        {
            TextBoxWithErrorProvider.BrushForAll = Brushes.Red;
            InitializeComponent();
            //textBoxWEPImie.SetFocus();
        }

        /*
        Poniższy przykład pozwala na zgłaszanie błędu pustego pola poprzez
        wywołanie metody void SerError(string s), która dla pustego string
        zgłasza błąd, a dla niepustego włącza obsługę błędu i wypisuje ten
        string w toolTip'ie.
        */

        private bool isNoEmpty(TextBoxWithErrorProvider tb)
        {
            if (tb.Text.Trim() == "")
            {
                tb.SetError("Pole nie może być puste!");
                return false;
            }
            tb.SetError("");
            return true;
        }

        private void ButtonEdytuj_Click(object sender, RoutedEventArgs e)
        {
            //var button = (Button)sender;
            //MessageBox.Show($"Wywolal mnie {button.Content.ToString()}");
            if (isNoEmpty(textBoxWEPImie) & isNoEmpty(textBoxWEPNazwisko))
            {
                var nowyPilkarz = new Pilkarz(textBoxWEPImie.Text.Trim(), textBoxWEPNazwisko.Text.Trim(),
                    (uint)wiekSlider.Value, (uint)wagaSlider.Value);

                if (czyPilkarzJestJuzNaLiscie())
                {
                    var dialog = MessageBox.Show($"{listBoxPilkarze.SelectedItem.ToString()} już jest na liście", "Uwaga");
                }
                else
                {
                    var dialogResult = MessageBox.Show($"Czy na pewno chcesz zmienić dane {Environment.NewLine}" +
                        $"{listBoxPilkarze.SelectedItem}?", "Edycja", MessageBoxButton.YesNo);

                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        //zmiana referencji do piłkarza edytowanego
                        //zrobić tak aby była zmiana obiektu
                        //listBoxPilkarze.Items[listBoxPilkarze.SelectedIndex] = biezacyPilkarz;
                        var biezacyPilkarz = (Pilkarz)listBoxPilkarze.SelectedItem;
                        biezacyPilkarz.Imie = nowyPilkarz.Imie;
                        biezacyPilkarz.Nazwisko = nowyPilkarz.Nazwisko;
                        biezacyPilkarz.Wiek = nowyPilkarz.Wiek;
                        biezacyPilkarz.Waga = nowyPilkarz.Waga;
                        listBoxPilkarze.Items.Refresh();

                    }
                    Clear();
                    listBoxPilkarze.SelectedIndex = -1;
                }
                
            }
        }

        //gdybym dała && nie wyswietlilby bledu w przypadku 2 operandu, a w tylko w 1
        //& wyznacza obydwa operandy i liczy wynik
        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (isNoEmpty(textBoxWEPImie) & isNoEmpty(textBoxWEPNazwisko))
            {
                //MessageBox.Show($"Wywolal mnie {button.Content.ToString()}");
                if (czyPilkarzJestJuzNaLiscie())
                {
                    var dialog = MessageBox.Show($"{tenSamPilkarz.ToString()} już jest na liście {Environment.NewLine}Czy wyczyścić formularz?", "Uwaga", MessageBoxButton.OKCancel);
                    if (dialog == MessageBoxResult.OK)
                    {
                        Clear();
                    }
                }
                else
                {
                    var noweImie = textBoxWEPImie.Text.Trim();
                    var noweNazwisko = textBoxWEPNazwisko.Text.Trim();
                    var nowyWiek = (uint)wiekSlider.Value;
                    var nowaWaga = (uint)wagaSlider.Value;

                    var nowyPilkarz = new Pilkarz(noweImie, noweNazwisko, nowyWiek, nowaWaga);
                    listBoxPilkarze.Items.Add(nowyPilkarz);
                    Clear();
                }

                
            }
            
        }

        private void Clear()
        {
            textBoxWEPImie.Text = "";
            textBoxWEPNazwisko.Text = "";
            wiekSlider.Value = 5;
            wagaSlider.Value = 10;
            buttonEdytuj.IsEnabled = false;
            buttonUsun.IsEnabled = false;

            //odznaczenie listy
            listBoxPilkarze.SelectedIndex = -1;
            textBoxWEPImie.Focus();
        }

        private void Wiek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            wiek.Content = $"Wiek: {Math.Floor(e.NewValue)} lat";
        }

        private void Waga_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            waga.Content = $"Waga: {Math.Floor(e.NewValue)} kg";
        }

        private void ButtonUsun_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = MessageBox.Show($"Czy na pewno chcesz usunąć obiekt {Environment.NewLine}" +
                $"{listBoxPilkarze.SelectedItem}?", "Uwaga", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                listBoxPilkarze.Items.Remove(listBoxPilkarze.SelectedItem);
                listBoxPilkarze.Items.Refresh();
            }

            
        }

        //zmiana zaznaczenia na liście piłkarzy
        //brak zaznaczenia również wywołuje to zdarzenie i wówczas indeks zaznaczonego
        //piłkarza wynosi -1
        private void ListBoxPilkarze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxPilkarze.SelectedIndex > -1)
            {
                LoadPlayer((Pilkarz)listBoxPilkarze.SelectedItem);
            }
        }

        private void LoadPlayer(Pilkarz pilkarz)
        {
            textBoxWEPImie.Text = pilkarz.Imie;
            textBoxWEPNazwisko.Text = pilkarz.Nazwisko;
            wiekSlider.Value = pilkarz.Wiek;
            wagaSlider.Value = pilkarz.Waga;

            buttonEdytuj.IsEnabled = true;
            buttonUsun.IsEnabled = true;
            //textBoxWEPImie.SetFocus();
        }

        //metoda wykonana po załadowaniu okna
        //ładujemy zawartość pliku z zapisanymi piłkarzami jeśli istnieje
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var pilkarze = Plik.wczytaniePilkarzyZPliku(plikDoWczytania);
            if (pilkarze != null)
            {
                foreach (Pilkarz gracz in pilkarze)
                    listBoxPilkarze.Items.Add(gracz);
            }
        }

        //nadpisanie pliku z nowymi danymi
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Pilkarz[] pilkarze = null;
            int n = listBoxPilkarze.Items.Count;

            if (n > 0)
            {
                pilkarze = new Pilkarz[n];
                int index = 0;

                foreach (var gracz in listBoxPilkarze.Items)
                {
                    pilkarze[index] = gracz as Pilkarz;
                    index++;
                }
                Plik.zapisDoPliku(plikDoWczytania, pilkarze);
            }
        }

        private bool czyPilkarzJestJuzNaLiscie()
        {
            //var biezacyPilkarz = (Pilkarz)listBoxPilkarze.SelectedItem;
            //if (biezacyPilkarz.Imie == textBoxWEPImie.Text && biezacyPilkarz.Nazwisko == textBoxWEPNazwisko.Text &&
            //    biezacyPilkarz.Wiek == wiekSlider.Value && biezacyPilkarz.Waga == wagaSlider.Value)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            bool juzJest = false;
            

            foreach (Pilkarz gracz in listBoxPilkarze.Items)
            {
                if (gracz.Imie == textBoxWEPImie.Text && gracz.Nazwisko == textBoxWEPNazwisko.Text &&
                    gracz.Wiek == Math.Floor(wiekSlider.Value) && gracz.Waga == Math.Floor(wagaSlider.Value))
                {
                    juzJest = true;
                    tenSamPilkarz = gracz;
                }
            }
            if (juzJest)
                return true;
            else
                return false;
        }
    }
}
