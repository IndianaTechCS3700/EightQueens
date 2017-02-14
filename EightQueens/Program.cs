using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve();

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }

        public static void Solve()
        {

            var queens = BuildBoard(4);

            queens[Queen.BoardSize - 1].Solve();

            DisplayResults(queens);
        }

        private static Queen[] BuildBoard(int size)
        {
            Queen.BoardSize = size;

            var queens = new Queen[Queen.BoardSize];

            queens[0] = new Queen(null, 1);
            for (var i = 1; i < Queen.BoardSize; i++)
            {
                queens[i] = new Queen(queens[i - 1], i + 1);
            }

            return queens;
        }

        private static void DisplayResults(Queen[] queens)
        {
            foreach (var queen in queens)
            {
                Console.WriteLine($"({queen._column}, {queen.Row})");
            }
        }
    }
}
