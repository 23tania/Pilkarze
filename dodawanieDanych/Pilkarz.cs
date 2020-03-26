using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodawanieDanych
{
    class Pilkarz
    {
        //properties
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public uint Wiek { get; set; }
        public uint Waga { get; set; }

        public Pilkarz(string imie, string nazwisko, uint wiek, uint waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }

        public override string ToString()
        {
            return $"{Nazwisko} {Imie} lat: {Wiek} waga: {Waga} kg";
        }

        public string ToFileFormat()
        {
            return $"{Nazwisko}|{Imie}|{Wiek}|{Waga}";
        }

        public static Pilkarz CreateFromString(string pilkarz)
        {
            string imie, nazwisko;
            uint wiek, waga; //dodatnie
            var pola = pilkarz.Split('|');

            if (pola.Length == 4)
            {
                imie = pola[1];
                nazwisko = pola[0];
                wiek = uint.Parse(pola[2]);
                waga = uint.Parse(pola[3]);
                return new Pilkarz(imie, nazwisko, wiek, waga);
            }
            throw new Exception("Błędny format danych z pliku");
            //jeśli w pliku nie będą podane dane w formacie:
            //imie|nazwisko|wiek|waga to wywoła się błąd
        }
    }
}
