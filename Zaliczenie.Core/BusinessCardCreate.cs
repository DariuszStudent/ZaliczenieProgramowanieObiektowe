using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCard
{
    public class BusinessCardCreate : UserService
    {
        private string _fileNameCard = @"../../../wizytowka.txt";

        public void CheckId(int id)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (id == Users[i].Id)
                {
                    var userToPrint = Users[i];
                    MakeLabels(userToPrint);
                }
            }
        }

        public void MakeLabels(User user)
        {
            if (File.Exists(_fileNameCard)) File.Delete(_fileNameCard);

            var userToPrint = new List<string>();

            userToPrint.Add("******************");
            userToPrint.Add("*" + user.FirstName + "*");
            userToPrint.Add("*" + user.LastName + "*");
            userToPrint.Add("*" + user.Email + "*");
            userToPrint.Add("*" + user.PhoneNumber + "*");
            userToPrint.Add("*******************");

            for (int i = 0; i < userToPrint.Count; i++)
            {
                File.AppendAllLines(_fileNameCard, userToPrint[i]);
            }
        }
    }
}
