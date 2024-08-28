using System.Runtime.Serialization.Formatters;

namespace Day4
{
    public class Card
    {
        private HashSet<int> _winNumbers = new HashSet<int>();
        private List<int> _numbers = new List<int>();
        private int _winNumbersCount = 0;
        public int CardNumber { get; set; }
        public int WinNumbersCount {  get { return _winNumbersCount; } }

        public HashSet<int> Copies = new HashSet<int>();

        public Card(string cardText)
        {
            var cardTextParts = cardText.Split('|');
            CardNumber = Int32.Parse(cardTextParts[0].Split(":")[0].Remove(0,4).Trim());
            _winNumbers = new HashSet<int>(cardTextParts[0]
                .Split(":")[1].Trim()
                .Split(" ")
                .Where(n=> n!=String.Empty)
                .Select(n => Int32.Parse(n.Trim())));
            _numbers = cardTextParts[1].Trim().Split(" ")
                .Where(n => n != String.Empty)
                .Select(n => Int32.Parse(n.Trim())).ToList();
        }

        public int GetWinSum()
        {
            double sum = 0;

            double winNumbersCount = 0;
            foreach (var number in _numbers) 
            {
                if (_winNumbers.Contains(number))
                {
                    sum = Math.Pow(2, winNumbersCount);
                    winNumbersCount++;
                }
            }
            _winNumbersCount = (int)winNumbersCount;
            return (int)sum;
        }
    }
}
;