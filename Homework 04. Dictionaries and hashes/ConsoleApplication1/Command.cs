namespace Bots
{
    public class Command
    {
        public Command(string nameToSeachFor, string town)
        {
            this.NameToSeachFor = nameToSeachFor;
            this.Town = town;
        }

        public string NameToSeachFor { get; set; }

        public string Town { get; private set; }
    }
}
