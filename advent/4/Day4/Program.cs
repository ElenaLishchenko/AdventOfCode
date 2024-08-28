using Day4;

Console.WriteLine("Hello, World!");
string path = "input.txt";

var resultSum = 0;
var cardCopies = new Dictionary<int, int>();

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        var card = new Card(line);
        var cardWinSum = card.GetWinSum();
        resultSum += cardWinSum;
        if (!cardCopies.ContainsKey(card.CardNumber))
        {
            cardCopies.Add(card.CardNumber, 1);
        }
        if (card.WinNumbersCount > 0)
        {
            UpdateCountForAnotherCardsCopies(cardCopies, card);
        }
    }
}

Console.WriteLine(resultSum);
Console.WriteLine(cardCopies.Values.Sum(x => x));
Console.ReadKey();

static void UpdateCountForAnotherCardsCopies(Dictionary<int, int> cardCopies, Card card)
{
    var count = cardCopies[card.CardNumber];
    for (int i = 1; i <= card.WinNumbersCount; i++)
    {
        var winCardNumber = card.CardNumber + i;
        if (cardCopies.TryGetValue(winCardNumber, out var copiesCount))
        {
            cardCopies[winCardNumber] = copiesCount + count;
        }
        else
        {
            cardCopies.Add(winCardNumber, count+1);
        }
    }
}