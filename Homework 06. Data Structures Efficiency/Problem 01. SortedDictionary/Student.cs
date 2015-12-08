namespace Problem_01.SortedDictionary
{
    public class Student
    {

        public Student(string firstName, string lastName)
        {
            this.FrstName = firstName;
            this.LastName = lastName;
        }

        public string FrstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.FrstName + " " + this.LastName;
        }
    }
}
