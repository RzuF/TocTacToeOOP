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

        public TablicaFigur()
        {
            for (int i = 0; i < 3; i++)
            {
                poziom.Add(new List<Figura>());
                for (int j = 0; j < 3; j++)
                {
                    poziom[i].Add(new Figura());
                }
            }

        }

        public bool Add(Figura nFigura, int x, int y)
        {
            if (poziom[x][y] != null && poziom[x][y].val == 0 /*&& poziom[x][y].val != 2 && poziom[x][y].val != 1*/)
            {
                poziom[x][y] = nFigura;
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
            Console.Clear();

            foreach(var i in poziom)
            {
                foreach(var j in i)
                {
                    
                    
                        j.rysuj();
                        Console.Write(" * ");
                    
                }
                Console.WriteLine("**" + "***" + "***" + "***" + "***" + "***" + "**");
            }
        }

        public bool checkIfWin()
        {
            foreach(var i in poziom) // Sprawdzanie wierszy
            {
                if (i[0].val != 0 && (i[0].val == i[1].val) && (i[0].val == i[2].val))
                {
                    Console.WriteLine(((i[0].val == 1) ? "Wygral komputer" : "Wygral gracz"));
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

            return false;
        }

        public void Losuj()
        {
            //Kolko tmp = new Kolko();

            Random rand = new Random();

            int a = 0;
            int b = 0;

            do
            {
                a = rand.Next(0, 3);
                b = rand.Next(0, 3);
            }

            while (!Add(new Kolko(), a, b));
        }

    }
}
