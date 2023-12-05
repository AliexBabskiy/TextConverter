using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cl1
{
    internal class Menu
    {
        private int minStrelochka;
        private int maxStrelochka;

        public Menu(int min, int max)
        {
            minStrelochka = min;
            maxStrelochka = max;
        }
        public static int men(int minStrelochka, int maxStrelochka)
        {
            int post = 1;
            ConsoleKeyInfo info;
            Console.CursorVisible = false;
            do
            {
                Console.SetCursorPosition(0, post);
                Console.WriteLine("->");

                info = Console.ReadKey();

                Console.SetCursorPosition(0, post);
                Console.WriteLine("  ");

                if (info.Key == ConsoleKey.UpArrow && post != minStrelochka)
                {
                    post--;
                }
                else if (info.Key == ConsoleKey.DownArrow && post != maxStrelochka)
                {
                    post++;
                }

            }
            while (info.Key != ConsoleKey.Enter);
            return post;
        }
    }
}