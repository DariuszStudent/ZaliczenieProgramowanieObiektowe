using System;
using System.Collections.Generic;
using System.IO;

namespace BusinessCard
{
    public class BusinessCardCreate : UserService
    {
        private List<string> UserToPrint { get; set; }

        private string _fileNameCard = @"../../../wizytowka.txt";
        private int _tableWidth;

        public User CheckIdForCreate(int userInputId)
        {
            foreach (var user in Users)
            {
                if (userInputId == user.Id) return user;
            }

            return null;
        }

        public void CreateTable(User user)
        {
            UserToPrint = new List<string>();
            _tableWidth = TableWidth(user);

            UserToPrint.Add(PrintLine());
            UserToPrint.Add(PrintRow(user.FirstName));
            UserToPrint.Add(PrintRow(user.LastName));
            UserToPrint.Add(PrintRow(user.Email));
            UserToPrint.Add(PrintRow(user.PhoneNumber.ToString()));
            UserToPrint.Add(PrintLine());
            SaveTextToNewFile();
        }

        public void ShowTable(User user)
        {
            Console.WriteLine((PrintLine()));
            Console.WriteLine((PrintRow(user.FirstName)));
            Console.WriteLine((PrintRow(user.LastName)));
            Console.WriteLine((PrintRow(user.Email)));
            Console.WriteLine((PrintRow(user.PhoneNumber.ToString())));
            Console.WriteLine((PrintLine()));
        }

        public string PrintLine()
        {
            return (new string('*', _tableWidth + 2));
        }

        public string PrintRow(string userInfo)
        {
            string row = "*";

            row += AlignCentre(userInfo) + "*";

            return (row);
        }

        public string AlignCentre(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', _tableWidth);
            }
            else
            {
                return text.PadRight(_tableWidth - (_tableWidth - text.Length) / 2).PadLeft(_tableWidth);
            }
        }

        public int TableWidth(User user)
        {
            var users = user.ToString();
            var usersRow = users.Split(';');
            var result = 0;
            foreach (var item in usersRow)
            {
                if (item.Length > result) result = item.Length;
            }

            return result + 4;
        }

        public void SaveTextToNewFile()
        {
            File.Delete(_fileNameCard);
            File.AppendAllLines(_fileNameCard , UserToPrint);
        }
    }
}
