using System.Xml.Linq;

namespace Day5
{
    public class SeedMap
    {
        private HashSet<MapItem> _seedToSoilMap;
        private HashSet<MapItem> _soilToFertilizerMap;
        private HashSet<MapItem> _fertilizerToWaterMap;
        private HashSet<MapItem> _waterToLightMap;
        private HashSet<MapItem> _lightToTemperatureMap;
        private HashSet<MapItem> _temperatureToHumidityMap;
        private HashSet<MapItem> _humidityToLocationMap;
        private Mapper _mapper = new Mapper();

        public SeedMap(
            List<string> seedToSoilMap,
            List<string> soilToFertilizerMap,
            List<string> fertilizerToWaterMap,
            List<string> waterToLightMap,
            List<string> lightToTemperatureMap,
            List<string> temperatureToHumidityMap,
            List<string> humidityToLocationMap
            )
        {
            _seedToSoilMap = _mapper.CreateSetForMapping(seedToSoilMap);
            _soilToFertilizerMap = _mapper.CreateSetForMapping(soilToFertilizerMap);
            _fertilizerToWaterMap = _mapper.CreateSetForMapping(fertilizerToWaterMap);
            _waterToLightMap = _mapper.CreateSetForMapping(waterToLightMap);
            _lightToTemperatureMap = _mapper.CreateSetForMapping(lightToTemperatureMap);
            _temperatureToHumidityMap = _mapper.CreateSetForMapping(temperatureToHumidityMap);
            _humidityToLocationMap = _mapper.CreateSetForMapping(humidityToLocationMap);
        }

        public UInt32 GetLocation(Range range)
        {
            var seedToSoil = _mapper.FindCorrespondingValue(_seedToSoilMap, range);
            var soilToFertilizer = seedToSoil.SelectMany(soil => _mapper.FindCorrespondingValue(_soilToFertilizerMap, soil)).ToList();
            var fertilizerToWater = soilToFertilizer.SelectMany(fertilizer => _mapper.FindCorrespondingValue(_fertilizerToWaterMap, fertilizer)).ToList();
            var waterToLight = fertilizerToWater.SelectMany(water => _mapper.FindCorrespondingValue(_waterToLightMap, water)).ToList();
            var lightToTemperature = waterToLight.SelectMany(light => _mapper.FindCorrespondingValue(_lightToTemperatureMap, light)).ToList();
            var temperatureToHumidity = lightToTemperature.SelectMany(temperature => _mapper.FindCorrespondingValue(_temperatureToHumidityMap, temperature)).ToList();
            var locations = temperatureToHumidity.SelectMany(humidity => _mapper.FindCorrespondingValue(_humidityToLocationMap, humidity)).ToList();
            var result = locations.Select(location => location.Start).Min();

            Console.WriteLine($"Range : {range.Start} {range.Length}");
            seedToSoil.ForEach(range => range.Line("Soil"));
            soilToFertilizer.ForEach(range => range.Line("Fertilizer"));
            fertilizerToWater.ForEach(range => range.Line("Water"));
            waterToLight.ForEach(range => range.Line("Light"));
            lightToTemperature.ForEach(range => range.Line("Temperature"));
            temperatureToHumidity.ForEach(range => range.Line("Humidity"));
            locations.ForEach(range => range.Line("Location"));

            return result;
        }
    }
}
