namespace BusinessCard
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public User(int id, string firsName, string lastName, string email, int phoneNumber)
        {
            Id = id;
            FirstName = firsName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Id};{FirstName};{LastName};{Email};{PhoneNumber.ToString()}";
        }
    }
}
