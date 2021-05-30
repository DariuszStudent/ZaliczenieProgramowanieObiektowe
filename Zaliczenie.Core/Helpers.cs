using System;

namespace BusinessCard
{
    public static class Helpers
    {
        public static int JustInts()
        {
            var userNumber = default(int);
            while (!int.TryParse(Console.ReadLine(), out userNumber))
            {
                Console.WriteLine("Musisz podać liczbę!");
            }
            return userNumber;
        }
    }
}
