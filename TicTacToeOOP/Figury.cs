using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    class Figura : IMultilineDrawable
    {
        protected int _val = 0;
        public int val
        {
            get
            {
                return _val;
            }
        }

        virtual public void rysujMulti(int line)
        {
            switch (line)
            {
                case 0:
                    Console.Write("   ");
                    break;
                case 1:
                    Console.Write("   ");
                    break;
                case 2:
                    Console.Write("   ");
                    break;
            }
        }

        virtual public void rysuj()
        {
            Console.WriteLine("   ");
        }

    }

    class Kolko : Figura, IMultilineDrawable
    {
        public Kolko()
        {
            base._val = 1;
        }

        public override void rysujMulti(int line)
        {
            switch (line)
            {
                case 0:
                    Console.Write("OOO");
                    break;
                case 1:
                    Console.Write("O O");
                    break;
                case 2:
                    Console.Write("OOO");
                    break;
            }
        }

        public override void rysuj()
        {
            Console.WriteLine(" O ");
        }

        
    }

    class Krzyzyk : Figura, IMultilineDrawable
    {
        public Krzyzyk()
        {
            base._val = 2;
        }

        public override void rysujMulti(int line)
        {
            switch (line)
            {
                case 0:
                    Console.Write("X X");
                    break;
                case 1:
                    Console.Write(" X ");
                    break;
                case 2:
                    Console.Write("X X");
                    break;
            }
        }

        public override void rysuj()
        {
            Console.WriteLine(" X ");
        }
    }
}
