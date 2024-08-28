namespace Day7
{
    public class Hand
    {
        public string Card { get; set; }
        public int Rank { get; set;}

        public Hand(string line)
        {
            var parsedLine = line.Split(' ');
            Card = parsedLine[0];
            Rank = Int16.Parse(parsedLine[1]);
        }
    }
}
