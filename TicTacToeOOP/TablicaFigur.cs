using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    class TablicaFigur
    {
        //List<Figura> pion = new List<Figura>();
        List<List<Figura>> poziom = new List<List<Figura>>();

        public TablicaFigur() // konstruktor
        {
            for (int i = 0; i < 3; i++) // bo mamy 3 wiersze
            {
                poziom.Add(new List<Figura>()); // Dla każdego wiersza tworzymy liste elementów dla danego poziomu, jak komórki w tabeli
                for (int j = 0; j < 3; j++) // znowu mamy 3 komórki dla których musimy wygenerować obiekt
                {
                    poziom[i].Add(new Figura()); // dodajemy nowy domyślny obiekt w każdej komórce
                }
            }

        }

        public bool Add(Figura nFigura, int x, int y) // funkcja dodająca
        {
            if (!(x < 3 && x > -1 && y < 3 && y > -1)) return false; // Sprawdzam czy elementy są wadliwe, '&&' sprawia, że jesli jakiś warunek jest nieprawdziwy nie jest sprawdzane dalesze wyrażenie (optymizacja!), 
                                                                     // żeby działało jak należy trzeba zanegować (bo sprawdzam czy dane są poprawne)

            if (poziom[x][y] != null && poziom[x][y].val == 0) // sprawdzam czy czasem obiekt nie jest nullem (żeby uniknąć NullReferenceExeption), nastepnie sprawdzam czy jego wartość 'val' to 0 (jeśli nie to coś tam już mieszka)
            {
                poziom[x][y] = nFigura; // przypisujemy do tego miejsca naszą podaną figurę
                return true;
            }
            else return false;
        }

        public void rysujMulti()
        {
            Console.Clear();

            foreach(var i in  poziom)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write("* ");
                    foreach (var j in i)
                    {
                        j.rysujMulti(k);
                        Console.Write(" * ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("**" + "***" + "***" + "***" + "***" + "***" + "**");
            }
        }

        public void rysuj()
        {
            Console.Clear(); // Czyścimy ekran

            foreach(var i in poziom) // pierwsza pętelka, która przejedzie nam przez wszystkie poziomy
            {
                foreach(var j in i) // dla każdego wiersza mamy listę, tutaj przechodzimy pętlą tą listę
                {
                    
                    
                        j.rysuj(); // rysujemy każdy element, korzystając z funkcji wirtualnej wywoła się metoda dla konkretnej klasy pochodnej (mimo, że traktujemy obiekt jako obiekt klasy bazowej!)
                        Console.Write(" * "); //  oddzielamy każdą figurę
                    
                }
                Console.WriteLine("");
                Console.WriteLine("**" + "***" + "***" + "***" + "***" + "***" + "**"); // na końcu każdego poziomu dodajemy gwiazdeczki do oddzielenia
            }
        }

        public bool checkIfWin()
        {
            foreach(var i in poziom) // Sprawdzanie wierszy
            {
                if (i[0].val != 0 && (i[0].val == i[1].val) && (i[0].val == i[2].val))
                {
                    Console.WriteLine(((i[0].val == 1) ? "Wygral komputer" : "Wygral gracz")); // To co zrobiłem w środku to taki inny 'if', jeśli nie wiecie co oznacza zachęcam do wygooglowania :)
                    return true;
                }
            }

            for (int i = 0; i < 3; i++) // Sprawdzanie kolumn
            {
                if (poziom[0][i].val != 0 && (poziom[0][i].val == poziom[1][i].val) && (poziom[0][i].val == poziom[2][i].val))
                {
                    Console.WriteLine(((poziom[0][i].val == 1) ? "Wygral komputer" : "Wygral gracz"));
                    return true;
                }
            }

            if (poziom[0][0].val != 0 && (poziom[0][0].val == poziom[1][1].val) && (poziom[0][0].val == poziom[2][2].val)) // Skos numer 1
            {
                Console.WriteLine(((poziom[0][0].val == 1) ? "Wygral komputer" : "Wygral gracz"));
                return true;
            }

            if (poziom[2][0].val != 0 &&  (poziom[2][0].val == poziom[1][1].val) && (poziom[2][0].val == poziom[0][2].val)) // Skos numer 2
            {
                Console.WriteLine(((poziom[2][0].val == 1) ? "Wygral komputer" : "Wygral gracz"));
                return true;
            }

            foreach(var i in poziom) // Sprawdzam czy czasem nie występuje remis
            {
                foreach (var j in i)
                    if (j.val == 0) return false; // Jeśli jest wolne miejsce znaczy, że nie ma remisu to kończymy całą metode i zwracamy false
            }

            Console.WriteLine("Remis"); // Jesli wcześniej metoda nic nie zwróciła, ze kazde miejsce jest różne od zera i jednocześnie nie ma zwycięzcy ergo jest remis
            return true;
        }

        public void Losuj()
        {
            //Kolko tmp = new Kolko();

            Random rand = new Random(); //  nowa instancja klasy Random

            int a = 0;
            int b = 0;

            do
            {
                a = rand.Next(0, 3); // losujemy liczbe od 0 do 2
                b = rand.Next(0, 3); 
            }

            while (!Add(new Kolko(), a, b)); // takie losowanie trwa dopóki dopóty nie uda się dodać figury, czyli wylosowane miejsce bedzie wolne
                                             // dopóki while otrzymuje prawdę to sie wykonuje, dlatego musimy zaprzeczyć, bo jak Add zwróci wprawdę chcemy żeby opuściło pętlę
        }

    }
}
