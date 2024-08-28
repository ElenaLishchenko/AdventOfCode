using Day3;

Console.WriteLine("Hello, World!");
string path = "input.txt";

var schema = new List<string>();

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        schema.Add(line);
    }
}

var newSchema = new Schema(schema.ToArray());
Console.WriteLine(newSchema.GetSum());
Console.WriteLine(newSchema.GetGears());
Console.ReadKey();
