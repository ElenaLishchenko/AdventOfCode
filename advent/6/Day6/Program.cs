using Day6;

Console.WriteLine("Hello, World!");

//string path = "input.txt";

//var parsedLines = new List<int[]>();

//using (StreamReader reader = new StreamReader(path))
//{
//    string? line;
//    while ((line = await reader.ReadLineAsync()) != null)
//    {
//        var lineParts = line.Split(":");
//        var numbers = lineParts[1]
//            .Split(" ")
//            .Where(number => !string.IsNullOrWhiteSpace(number))
//            .Select(number => Int32.Parse(number.Trim()))
//            .ToArray();
//        parsedLines.Add(numbers);
//    }
//}
var races = new List<Race>();
//for (int i = 0; i < parsedLines[0].Length; i++)
//{
//    races.Add(new Race(parsedLines[0][i], parsedLines[1][i]));
//}

var result = 1;
races = new List<Race>
{
    new Race(40817772, 219101213651089),
};
foreach (var r in races)
{
    var count = r.GetCountOfCases();
    result = result * count;
}

Console.WriteLine(result);
Console.ReadKey();