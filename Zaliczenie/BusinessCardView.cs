using System;

namespace BusinessCard
{
    public static class BusinessCardView
    {
        public static void Introduction()
        {
            Console.WriteLine("Witaj w programie, który tworzy wizytówkę w pliku *.txt");
        }

        public static void Menu()
        {
            Console.WriteLine("Główne Menu: ");
            Console.WriteLine("1. Utwórz użytkownika.");
            Console.WriteLine("2. Wyświetl użytkowników.");
            Console.WriteLine("3. Usuń użytkownika.");
            Console.WriteLine("4. Stwórz wizytówkę.");
            Console.WriteLine("9. Wyjdź.");
        }
    }
}
