namespace Bots
{
    internal class Person
    {
        public Person(string firstName, string town, string phoneNumber)
        {
            this.Name = firstName;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }

        public string Town { get; private set; }

        public string PhoneNumber { get; private set; }

        public override string ToString()
        {
            return "Name: " + this.Name + ". Town: " + this.Town + ". Phone number: " + this.PhoneNumber;
        }
    }
}
