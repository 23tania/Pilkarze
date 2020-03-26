using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace dodawanieDanych
{
    class Plik
    {
        public static Pilkarz[] wczytaniePilkarzyZPliku(string plik)
        {
            Pilkarz[] pilkarze = null;

            if (File.Exists(plik))
            {
                //var jedenPilkarz = new Pilkarz();
                var wszyscyPilkarze = File.ReadAllLines(plik);
                var n = wszyscyPilkarze.Length;

                if (n>0)
                {
                    //deklaracja wielkości tablicy pilkarze
                    pilkarze = new Pilkarz[n];
                    for (int i=0; i<n; i++)
                    {
                        pilkarze[i] = Pilkarz.CreateFromString(wszyscyPilkarze[i]);
                    }
                    return pilkarze;
                }
            }

            return pilkarze;
            //gdy plik nie istnieje to zwraca null
        }

        public static void zapisDoPliku(string plik, Pilkarz[] pilkarze)
        {
            using (StreamWriter stream = new StreamWriter(plik))
            {
                foreach (var gracz in pilkarze)
                {
                    stream.WriteLine(gracz.ToFileFormat());
                }
                stream.Close();
            }
        }
    }
}
