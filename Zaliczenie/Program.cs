using System;

namespace BusinessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            var businessCardApp = new BusinessCardApp();
            var exit = false;


            while (!exit)
            {
                Console.Clear();
                BusinessCardView.Introduction();
                BusinessCardView.Menu();

                Console.Write("Wciśnij odpowiednią cyferkę: ");
                var userInput = Console.ReadKey();
                Console.WriteLine();

                switch (userInput.KeyChar)
                {
                    case '1':
                        businessCardApp.NewUser();
                        break;
                    case '2':
                        businessCardApp.ShowUsers();
                        Console.ReadKey();
                        break;
                    case '3':
                        businessCardApp.RemoveUser();
                        break;
                    case '4':
                        businessCardApp.businessCreate();
                        break;
                    case '5':
                        businessCardApp.SortList();
                        break;
                    case '9':
                        exit = true;
                        return;
                    default:
                        Console.WriteLine("Miss Click, operation failed.");
                        Console.ReadKey();
                        break;
                } 
            }

        }
    }
}
