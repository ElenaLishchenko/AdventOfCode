using Day2;

Console.WriteLine("Hello, World!");
string path = "input.txt";

var result = 0;
var power = 0;
var blueCubesCount = 14;
var redCubesCount = 12;
var greenCubesCount = 13;

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        var gameParser = new GameParser();
        var gameNumber = gameParser.GetGameNumber(line);
        var maxSetOfCubesValues = new SetOfCubes(gameParser.ParseGame(line));
        if (maxSetOfCubesValues.Red<=redCubesCount && maxSetOfCubesValues.Blue<=blueCubesCount && maxSetOfCubesValues.Green<=greenCubesCount)
        {
            result = result + gameNumber;
        }
        var gamePower = maxSetOfCubesValues.Green*maxSetOfCubesValues.Blue*maxSetOfCubesValues.Red;
        power += gamePower;
    }
}

Console.WriteLine(result);
Console.WriteLine(power);
Console.ReadKey();

