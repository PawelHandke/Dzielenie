using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dzielenie
{
    class Dzielenie : iDzielenie
    {
        private string dzielna;
        private string dzielnik;

        public string wynik { get; set; }

        public string plikRaport { get; set; }


        private bool czyWartoscUjemna = false;

        public Dzielenie(string pDzielna, string pDzielnik)
        {
            dzielna = pDzielna.Trim();
            dzielnik = pDzielnik.Trim();
        }

        public Dzielenie()
        { }

        private bool WalidacjaDanych() //tylko liczby całkowite
        {
            dzielna = dzielna.Trim();
            dzielnik = dzielnik.Trim();

            if (string.IsNullOrWhiteSpace(dzielna) | string.IsNullOrWhiteSpace(dzielnik))
            {
                wynik = "Nieprawidłowe dane.";
                return false;
            }

            if (dzielna[0] == '-')
            {
                czyWartoscUjemna = true;
                dzielna = dzielna.Remove(0, 1);
            }
            if (dzielnik[0] == '-')
            {
                czyWartoscUjemna = !czyWartoscUjemna;
                dzielnik = dzielnik.Remove(0, 1);
            }

            foreach (char znak in dzielna)
            {
                try
                {
                    int.Parse(znak.ToString());
                }
                catch 
                {
                    wynik = "Podana wartości dzielnej nie jest liczbą całkowitą.";
                    return false;
                }
            }

            foreach (char znak in dzielnik)
            {
                try
                {
                    int.Parse(znak.ToString());
                }
                catch
                {
                    wynik = "Podana wartości dzielnika nie jest liczbą całkowitą.";
                    return false;
                }
            }

            return true;
        }

        private string DajZnak(char znak, int ilosc)
        {
            string zwrot = "";
            for (int i = 0; i < ilosc; i++)
            {
                zwrot += znak;
            }
            return zwrot;
        }

        private string UsunZera(string liczba)
        {
            foreach (char item in liczba)
            {
                if (item == '0')
                {
                    try
                    {
                        if (liczba[1] != ',')
                        {
                            liczba = liczba.Remove(0, 1);
                        }
                    }
                    catch 
                    {
                        liczba = liczba.Remove(0, 1);
                    }
                }
                else 
                { 
                    break;
                }
            }
            return liczba;
        }

        private string[] ileRazSieMiesci(string pWynik, string pReszta, string pDoOdjecia)
        {
            string[] zwrot = new string[3] { pWynik, pReszta, pDoOdjecia };

            if(pReszta.Length >= dzielna.Length)
            {
                foreach (char cyfra in pReszta.Reverse<char>())
                {
                    //if()
                }
                pWynik = (Int32.Parse(pWynik) + 1).ToString();

                return ileRazSieMiesci(pWynik, pReszta, pDoOdjecia);
            }
            else
            {
                return zwrot;
            }
        }

        private bool CzyPierwszaJestWieksza(string x, string y) //lub równa
        {
            while (x.Length > y.Length)
            {
                y = "0" + y;
            }


            for (int i = 0; i < x.Length; i++)
            {
                if (int.Parse(x[i].ToString()) < int.Parse(y[i].ToString()))
                {
                    return false;
                }
                else if (int.Parse(x[i].ToString()) > int.Parse(y[i].ToString()))
                {
                    return true;
                }
            }
            return true;
        }

        private char[] Zmniejsz(char[] liczba, int ktoraPozycja)
        {
            char[] zwrot = liczba;

            for (int i = ktoraPozycja; i < zwrot.Length; i++)
            {
                if(Int32.Parse(zwrot[i].ToString()) > 0)
                {
                    zwrot[i] = (Int32.Parse(liczba[i].ToString()) - 1).ToString()[0];
                    return zwrot;
                }
                else
                {
                    zwrot[i] = '9';
                }
            }
            return zwrot;
        }
                            
        private string[] Odejmowanie(string pWynik, string pReszta) //, string pWartoscOdejmnika)
        {                             //0                 //234 
            string[] zwrot = new string[2];

            //pReszta = pReszta.Reverse<char>().ToString(); //432 było 234

            char[] doOdwrocenia = pReszta.ToCharArray();
            Array.Reverse(doOdwrocenia);
            pReszta = new string(doOdwrocenia);

            doOdwrocenia = dzielnik.ToCharArray();
            Array.Reverse(doOdwrocenia);
            string tempDzielnik = new string(doOdwrocenia);// dzielnik.Reverse<char>().ToString(); //87 było 78


            char[] tempReszta = pReszta.ToCharArray();

            string wynik = "";

            for (int i = 0; i < tempDzielnik.Length; i++)
            {
                try
                {
                    wynik = (int.Parse(("1" + tempReszta[i]).ToString()) - int.Parse(tempDzielnik[i].ToString())).ToString();
                }
                catch
                {
                    wynik = (int.Parse(tempReszta[i].ToString()) - int.Parse(tempDzielnik[i].ToString())).ToString();
                }

                tempReszta[i] = wynik.ToString()[wynik.ToString().Length - 1];

                if (wynik.ToString().Length> 1)
                {
                    tempReszta[i] = wynik.ToString()[wynik.ToString().Length - 1];
                    
                }
                else
                {
                    tempReszta[i] = wynik.ToString()[wynik.ToString().Length - 1];
                    tempReszta = Zmniejsz(tempReszta, i+1);
                }
            }

            doOdwrocenia = tempReszta;
            Array.Reverse(doOdwrocenia);
            pReszta = new string(doOdwrocenia);

            //pReszta = tempReszta.Reverse<char>().ToString();

            zwrot[0] = (int.Parse(pWynik) + 1).ToString(); //wynik
            zwrot[1] = pReszta;

            if(CzyPierwszaJestWieksza(pReszta, dzielnik))
            {
                return Odejmowanie(zwrot[0], zwrot[1]);
            }
                
            return zwrot;
        }

        private string Pomnoz(string wartosc, int ileRazy)
        {
            string wynik = "";

            char[] doOdwrocenia = wartosc.ToCharArray();
            Array.Reverse(doOdwrocenia);
            wartosc = new string(doOdwrocenia);

            int dodaj = 0;
            int temp = 0;

            foreach (char cyfra in wartosc)
            {
                temp = ((int.Parse(cyfra.ToString()) * ileRazy) + dodaj);
                dodaj = temp / 10;
                wynik += (temp % 10).ToString();
            }
            if (dodaj > 0)
                wynik += dodaj.ToString();

            doOdwrocenia = wynik.ToCharArray();
            Array.Reverse(doOdwrocenia);
            wynik = new string(doOdwrocenia);

            return wynik;
        }

        public void Oblicz()
        {
            if(!WalidacjaDanych())
            {
                return;
            }

            string nazwaPliku = Directory.GetCurrentDirectory() + @"\Iloraz_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(nazwaPliku, true))
                {
                    sw.WriteLine("");
                    sw.Close();
                }
            }
            catch { }

            string tempDzielna = "";
            string wynikDzielenia = "";
            string[] zwrotTablica = new string[2];

            int dodajPrzecinek = dzielna.Length;

            int licznik = 0;

            List<string> procesRozwiazywania = new List<string>();
            try
            {
                procesRozwiazywania.Add(DajZnak(' ', dzielnik.Length > dzielna.Length ? dzielna.Length : dzielnik.Length)); //wynik
                procesRozwiazywania.Add(" " + DajZnak('-', dzielna.Length + dzielnik.Length + 2));
                procesRozwiazywania.Add(" " + dzielna + ":" + dzielnik);
            }
            catch { }

            foreach (char kolejnyZnak in dzielna)
            {
                licznik++;
                tempDzielna += kolejnyZnak;

                if (tempDzielna.Length >= dzielnik.Length)
                {
                    if(CzyPierwszaJestWieksza(tempDzielna, dzielnik))
                    {
                        try
                        {
                            if (procesRozwiazywania.Count > 3)
                                procesRozwiazywania.Add(DajZnak(' ', licznik - tempDzielna.Length + 1) + tempDzielna.ToString());
                        }
                        catch { }

                        zwrotTablica = Odejmowanie("0", tempDzielna); //0 wynik, 1- reszta
                        wynikDzielenia += zwrotTablica[0];
                        tempDzielna = UsunZera(zwrotTablica[1]);

                        try
                        {
                            string doOdjecia = Pomnoz(dzielnik, int.Parse(zwrotTablica[0]));
                            procesRozwiazywania.Add(DajZnak(' ', licznik - doOdjecia.Length) + "-" + doOdjecia);
                            procesRozwiazywania.Add(DajZnak(' ', licznik - doOdjecia.Length) + DajZnak('-', doOdjecia.Length + 1));
                        }
                        catch { }

                    }
                    else
                    {
                        if (wynikDzielenia != "")
                            wynikDzielenia = wynikDzielenia + "0";
                        continue;
                    }
                }
                else
                {
                    if (wynikDzielenia != "")
                        wynikDzielenia += "0";
                }
            }

            int tempLicznik = licznik;

            if (wynikDzielenia == "")
                wynikDzielenia += "0";

            if (tempDzielna != "")
            {
                wynikDzielenia = wynikDzielenia + ",";
                while (tempDzielna != "")
                {
                    licznik++;

                    if (licznik > tempLicznik + 1000) break;

                    try //wynik w okresie
                    {
                        bool czyPrzerwac = false;
                        switch(dzielnik.Length)
                        {
                            case 1:
                                if (wynikDzielenia.Substring(wynikDzielenia.Length - 1, 1) == wynikDzielenia.Substring(wynikDzielenia.Length - 2, 1) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 1, 1) == wynikDzielenia.Substring(wynikDzielenia.Length - 3, 1) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 1, 1) == wynikDzielenia.Substring(wynikDzielenia.Length - 4, 1) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 1, 1) == wynikDzielenia.Substring(wynikDzielenia.Length - 5, 1) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 1, 1) == wynikDzielenia.Substring(wynikDzielenia.Length - 6, 1))
                                {

                                    wynikDzielenia = wynikDzielenia.Substring(0, wynikDzielenia.Length - 5);
                                    wynikDzielenia = wynikDzielenia.Insert(wynikDzielenia.Length - 1, "(");
                                    wynikDzielenia += ")";
                                    tempDzielna = "";
                                    czyPrzerwac = true;
                                }
                                break;

                            case 2:
                                if (wynikDzielenia.Substring(wynikDzielenia.Length - 2, 2) == wynikDzielenia.Substring(wynikDzielenia.Length - 4, 2) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 2, 2) == wynikDzielenia.Substring(wynikDzielenia.Length - 6, 2) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 2, 2) == wynikDzielenia.Substring(wynikDzielenia.Length - 8, 2) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 2, 2) == wynikDzielenia.Substring(wynikDzielenia.Length - 10, 2))
                                {

                                    wynikDzielenia = wynikDzielenia.Substring(0, wynikDzielenia.Length - 8);
                                    wynikDzielenia = wynikDzielenia.Insert(wynikDzielenia.Length - 2, "(");
                                    wynikDzielenia += ")";
                                    tempDzielna = "";
                                    czyPrzerwac = true;
                                }
                                break;
                            case 3:
                                if (wynikDzielenia.Substring(wynikDzielenia.Length - 3, 3) == wynikDzielenia.Substring(wynikDzielenia.Length - 6, 3) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 3, 3) == wynikDzielenia.Substring(wynikDzielenia.Length - 9, 3))
                                {
                                    wynikDzielenia = wynikDzielenia.Substring(0, wynikDzielenia.Length - 6);
                                    wynikDzielenia = wynikDzielenia.Insert(wynikDzielenia.Length - 3, "(");
                                    wynikDzielenia += ")";
                                    tempDzielna = "";
                                    czyPrzerwac = true;
                                }
                            break;

                            case 4:
                                if (wynikDzielenia.Substring(wynikDzielenia.Length - 4, 4) == wynikDzielenia.Substring(wynikDzielenia.Length - 8, 4) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 4, 4) == wynikDzielenia.Substring(wynikDzielenia.Length - 12, 4))
                                {
                                    wynikDzielenia = wynikDzielenia.Substring(0, wynikDzielenia.Length - 8);
                                    wynikDzielenia = wynikDzielenia.Insert(wynikDzielenia.Length - 4, "(");
                                    wynikDzielenia += ")";
                                    tempDzielna = "";
                                    czyPrzerwac = true;
                                }
                                break;

                            case 5:
                                if (wynikDzielenia.Substring(wynikDzielenia.Length - 5, 5) == wynikDzielenia.Substring(wynikDzielenia.Length - 10, 5) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 5, 5) == wynikDzielenia.Substring(wynikDzielenia.Length - 15, 5))
                                {
                                    wynikDzielenia = wynikDzielenia.Substring(0, wynikDzielenia.Length - 10);
                                    wynikDzielenia = wynikDzielenia.Insert(wynikDzielenia.Length - 5, "(");
                                    wynikDzielenia += ")";
                                    tempDzielna = "";
                                    czyPrzerwac = true;
                                }
                                break;

                            case 6:
                                if (wynikDzielenia.Substring(wynikDzielenia.Length - 6, 6) == wynikDzielenia.Substring(wynikDzielenia.Length - 12, 6) &&
                                    wynikDzielenia.Substring(wynikDzielenia.Length - 6, 6) == wynikDzielenia.Substring(wynikDzielenia.Length - 18, 6))
                                {
                                    wynikDzielenia = wynikDzielenia.Substring(0, wynikDzielenia.Length - 12);
                                    wynikDzielenia = wynikDzielenia.Insert(wynikDzielenia.Length - 6, "(");
                                    wynikDzielenia += ")";
                                    tempDzielna = "";
                                    czyPrzerwac = true;
                                }
                                break;

                            default:
                                break;
                        }

                        if (czyPrzerwac)
                            break;
                    }
                    catch { }

                    tempDzielna += "0";

                    if (tempDzielna.Length >= dzielnik.Length)
                    {
                        if (CzyPierwszaJestWieksza(tempDzielna, dzielnik))
                        {
                            try
                            {
                                if (procesRozwiazywania.Count > 3)
                                    procesRozwiazywania.Add(DajZnak(' ', licznik - tempDzielna.Length + 1) + tempDzielna.ToString());
                            }
                            catch { }

                            zwrotTablica = Odejmowanie("0", tempDzielna); //0 wynik, 1- reszta
                            wynikDzielenia += zwrotTablica[0];
                            tempDzielna = UsunZera(zwrotTablica[1]);

                            try
                            {
                                string doOdjecia = Pomnoz(dzielnik, int.Parse(zwrotTablica[0]));
                                procesRozwiazywania.Add(DajZnak(' ', licznik - doOdjecia.Length) + "-" + doOdjecia);
                                procesRozwiazywania.Add(DajZnak(' ', licznik - doOdjecia.Length) + DajZnak('-', doOdjecia.Length + 1));
                            }
                            catch { }
                        }
                        else
                        {
                            if (wynikDzielenia != "")
                                wynikDzielenia = wynikDzielenia + "0";
                            continue;
                        }
                    }
                    else
                    {
                        if (wynikDzielenia != "")
                            wynikDzielenia += "0";
                    }
                }
            }

            wynikDzielenia = czyWartoscUjemna ? "-" + wynikDzielenia : wynikDzielenia;

            try
            {
                procesRozwiazywania[0] += wynikDzielenia;

                using (StreamWriter sw = new StreamWriter(nazwaPliku, true))
                {
                    foreach (string item in procesRozwiazywania)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                }

                plikRaport = nazwaPliku;
            }
            catch { }

            wynik = "Wynik wynosi: \n" + wynikDzielenia;// + "\nReszta: \n" + tempDzielna;
        }

    }
}
