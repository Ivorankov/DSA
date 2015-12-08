namespace Problem_02_FriendsOfPesho
{
    public class Point
    {
        public Point(Node node, double distance)
        {
            this.Node = node;
            this.Distance = distance;
        }

        public Node Node { get; set; }

        public double Distance { get; set; }
    }
}
