// See https://aka.ms/new-console-template for more information
using Day7;

Console.WriteLine("Hello, World!");
string path = "input.txt";

var resultSum = 0;
var hands = new List<Hand>();

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        hands.Add(new Hand(line));
    }
}
hands.Sort(new HandComparer());

for (int i = 0; i < hands.Count; i++)
{
    resultSum = resultSum + hands[i].Rank * (i + 1);
}

Console.WriteLine(resultSum);
Console.ReadKey();