using System.Text.RegularExpressions;

namespace Day7
{
    public static class HandTypeChecker
    {
        public static Dictionary<char, int> LabelValue = new Dictionary<char, int>
        {
            { '2', 1 },
            { '3', 2 },
            { '4', 3 },
            { '5', 4 },
            { '6', 5 },
            { '7', 6 },
            { '8', 7 },
            { '9', 8 },
            { 'T', 9 },
            { 'J', 10 },
            { 'Q', 11 },
            { 'K', 12 },
            { 'A', 13 },
        };

        public static Dictionary<char, int> Task2LabelValue = new Dictionary<char, int>
        {
            { '2', 1 },
            { '3', 2 },
            { '4', 3 },
            { '5', 4 },
            { '6', 5 },
            { '7', 6 },
            { '8', 7 },
            { '9', 8 },
            { 'T', 9 },
            { 'Q', 10 },
            { 'K', 11 },
            { 'A', 12 },
            { 'J', 0 },
        };

        public static HandType GetType(string card)
        {
            var resultString = "";
            var checkedSymbols = "";
            var countOfJokers = 0;
            foreach(var label in card)
            {
                if (label == 'J')
                {
                    countOfJokers++;
                    continue;
                }
                var numberOfRepetitions = Regex.Matches(card, label.ToString()).Count;
                if(numberOfRepetitions > 1 && !checkedSymbols.Contains(label))
                {
                    resultString = $"{resultString}{numberOfRepetitions}";
                    checkedSymbols = checkedSymbols + label.ToString();
                }
            }

            switch (resultString)
            {
                case "2":
                    {
                        switch (countOfJokers)
                        {
                            case 0: return HandType.OnePair;
                            case 1: return HandType.Three;
                            case 2: return HandType.Four;
                            default: return HandType.Five;
                        }
                    }
                case "22": return countOfJokers == 0 ? HandType.TwoPair : HandType.FullHouse;
                case "3": return countOfJokers == 0 ? HandType.Three : (HandType)(4 + countOfJokers);
                case "23":
                case "32": return HandType.FullHouse;
                case "4": return countOfJokers == 0 ? HandType.Four : HandType.Five;
                case "5": return HandType.Five;
                default:
                    {
                        if (countOfJokers == 0) return HandType.HighCard;
                        
                        switch(countOfJokers)
                        {
                            case 1: return HandType.OnePair;
                            case 2: return HandType.Three;
                            case 3: return HandType.Four;
                            default: return HandType.Five;
                        }
                    }
            }
        }
    }
}
