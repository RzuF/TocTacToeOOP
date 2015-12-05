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

            for (;;) // niekończąca się pętla for
            {
                nowaGra.Losuj(); // ruch komputera
                nowaGra.rysuj();
                if(nowaGra.checkIfWin()) break; // sprawdzamy czy ktoś wygrał, jeśli tak to wychodzimy z petli
                
                    int a = 0;
                    int b = 0;
                    do // nasz ruch
                    {
                        Console.Write("Podaj numer wiersza: ");
                        if (!int.TryParse(Console.ReadLine(), out a)) continue; // zamianiamy string z ReadLine() na inta, jeśli metoda TryParse zwróci false (czyli że dane były błędne) wymuszamy kolejne przejście pętli ('continue') żeby jeszcze raz móc wczytać dane
                        Console.WriteLine();
                        Console.Write("Podaj numer kolumny: ");
                        if (!int.TryParse(Console.ReadLine(), out b)) continue;
                        Console.WriteLine();
                    }
                    while (!nowaGra.Add(new Krzyzyk(), a, b));  // pytamy usera o wiersz i kolumne dopóki dopóty nie poda dobrych danych, mechanizm jak w Losuj()
                               
                nowaGra.rysuj();

                if (nowaGra.checkIfWin()) break;

            }

            Console.ReadKey();
        }
    }
}
