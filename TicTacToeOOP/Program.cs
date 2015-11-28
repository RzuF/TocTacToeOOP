using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{   
    class Program
    {
        static void Main(string[] args)
        {
            var nowaGra = new TablicaFigur();

            //bool gOver = false;

            for (;;)
            {
                nowaGra.Losuj();
                nowaGra.rysujMulti();
                //gOver = nowaGra.checkIfWin();
                if(nowaGra.checkIfWin()) break;

                //if (!gOver)
                {

                    int a = 0;
                    int b = 0;
                    do
                    {
                        Console.Write("Podaj numer wiersza: ");
                        a = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Podaj numer kolumny: ");
                        b = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }
                    while (!nowaGra.Add(new Krzyzyk(), a, b));
                }
                nowaGra.rysujMulti();

                if (nowaGra.checkIfWin()) break;

            }

            Console.ReadKey();
        }
    }
}
