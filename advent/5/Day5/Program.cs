using Day5;
using Range = Day5.Range;

string path = "input.txt";

List<Range> seeds = new List<Range>();
var seedToSoilMap = new List<string>();
var soilToFertilizerMap = new List<string>();
var fertilizerToWaterMap = new List<string>();
var waterToLightMap = new List<string>();
var lightToTemperatureMap = new List<string>();
var temperatureToHumidityMap = new List<string>();
var humidityToLocationMap = new List<string>();

const string seedMap = "seed-to-soil map";
const string soilMap = "soil-to-fertilizer map";
const string fertilizerMap = "fertilizer-to-water map";
const string waterMap = "water-to-light map";
const string lightMap = "light-to-temperature map";
const string temperatureMap = "temperature-to-humidity map";
const string humidityMap = "humidity-to-location map";

List<string>? FindCurrentMap(string[] lineParts)
{
    switch (lineParts[0])
    {
        case seedMap:
            return seedToSoilMap;
        case soilMap:
            return soilToFertilizerMap;
        case fertilizerMap:
            return fertilizerToWaterMap;
        case waterMap:
            return waterToLightMap;
        case lightMap:
            return lightToTemperatureMap;
        case temperatureMap:
            return temperatureToHumidityMap;
        case humidityMap:
            return humidityToLocationMap;
        default: return null;
    }
}

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    List<string>? currentMap = null;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        if (string.IsNullOrWhiteSpace(line)) continue;
        if (!line.Contains(":"))
        {
            currentMap.Add(line);
            continue;
        }
        var lineParts = line.Split(":");
        if (lineParts[0] == "seeds")
        {
            AddSeedRanges(seeds, lineParts);
            continue;
        }
        currentMap = FindCurrentMap(lineParts);
    }
}

var map = new SeedMap(seedToSoilMap, soilToFertilizerMap, fertilizerToWaterMap, waterToLightMap, lightToTemperatureMap, temperatureToHumidityMap, humidityToLocationMap);

var result = seeds.Select(seed => map.GetLocation(seed)).Min();

seeds.ForEach(range => range.Line("Seed"));

Console.WriteLine(result);
Console.ReadKey();

static void AddSeedRanges(List<Range> seeds, string[] lineParts)
{
    var seedNumbers = lineParts[1]
        .Split(" ")
        .Where(number => !string.IsNullOrWhiteSpace(number))
        .Select(number => UInt32.Parse(number.Trim()))
        .ToArray();
    for (int i = 0; i < seedNumbers.Length; i += 2)
    {
        seeds.Add(new Range(seedNumbers[i], seedNumbers[i + 1]));
    }
}