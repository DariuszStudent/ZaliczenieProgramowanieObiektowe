using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessCard
{
    public class UserService
    {
        protected List<User> Users { get; set; }

        private string _fileName = @"../../../users.txt";

        public UserService()
        {
            Users = new List<User>();

            if (!File.Exists(_fileName)) return;

            var fileLines = File.ReadAllLines(_fileName);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');
                if (int.TryParse(lineItems[0], out var id) &&
                    int.TryParse(lineItems[4], out var phoneNumber))
                {
                    AddUser(id, lineItems[1], lineItems[2], 
                        lineItems[3], phoneNumber, false);
                }
            }
        }

        public void AddUser(int id, string firsName, string lastName, 
            string email, int phoneNumber, bool shouldToSave = true)
        {
            var user = new User(id, firsName, lastName, email, phoneNumber);
            Users.Add(user);

            if (shouldToSave) File.AppendAllLines(_fileName, new List<string> { user.ToString() });
        }

        public List<string> ShowUsers()
        {
            var result = new List<string>();
            foreach (var item in Users)
            {
                result.Add($"{item.Id} | {item.FirstName} | {item.LastName} | {item.Email} | {item.PhoneNumber}");
            }
            return result;
        }

        public void RemoveUser(int id)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (id == Users[i].Id)
                {
                    Users.Remove(Users[i]);
                }
            }

            var newUsers = new List<string>();
            foreach (var user in Users)
            {
                newUsers.Add(user.ToString());
            }

            File.Delete(_fileName);
            File.WriteAllLines(_fileName, newUsers);
        }

        public int GetId()
        {
            var id = 1;
            var sortedList = Users.OrderBy(o => o.Id).ToList();

            foreach (var user in sortedList)
            {
                if (user.Id == id) id++;
                else return id;
            }
            return id;
        }

        public void SortListById()
        {
            Users = Users.OrderBy(x => x.Id).ToList();
        }
    }
}
