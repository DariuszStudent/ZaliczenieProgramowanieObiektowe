using System;

namespace BusinessCard
{
    public class BusinessCardApp
    {
        UserService userService = new UserService();
        BusinessCardCreate businessCardCreate = new BusinessCardCreate();

        public void NewUser()
        {
            var id = userService.GetId();
            Console.WriteLine("Podaj imię: ");
            var userName = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Podaj e-mail: ");
            var email = Console.ReadLine();
            Console.WriteLine("Podaj numer telefonus: ");
            var phoneNumber = Helpers.JustInts();
            userService.AddUser(id, userName, lastName, email, phoneNumber);
        }

        public void ShowUsers()
        {
            var showUsers = userService.ShowUsers();
            foreach (var item in showUsers)
            {
                Console.WriteLine(item);
            }
        }

        public void RemoveUser()
        {
            ShowUsers();
            Console.WriteLine("Podaj id użytkownika którego chcesz usunąć: ");
            var id = Helpers.JustInts();
            userService.RemoveUser(id);
        }

        public void businessCreate()
        {
            ShowUsers();
            Console.WriteLine("Podaj ID użytkownika którego chcesz stworzyć wizytówkę: ");
            var id = Helpers.JustInts();
            businessCardCreate.CheckId(id);
        }
    }
}
