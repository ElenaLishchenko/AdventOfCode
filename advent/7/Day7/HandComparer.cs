using System.Xml.Linq;

namespace Day7
{
    public class HandComparer : IComparer<Hand>
    {
        public int Compare(Hand? x, Hand? y)
        {
            if (x == null && y == null) return 0;
            var xType = HandTypeChecker.GetType(x.Card);
            var yType = HandTypeChecker.GetType(y.Card);
            if (xType > yType)
            {
                return 1;
            }
            if (xType < yType)
            {
                return -1;
            }
            for (var i = 0;i<5; i++)
            {
                if (x.Card[i] != y.Card[i])
                {
                    if (HandTypeChecker.Task2LabelValue[x.Card[i]] > HandTypeChecker.Task2LabelValue[y.Card[i]])
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
