using ConsoleApp1;

Console.WriteLine("Hello, World!");
string path = "input.txt";
var result = 0;

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        result += Replacer.CountAndReplace(line);
    }
}
Console.WriteLine(result);
Console.ReadKey();
