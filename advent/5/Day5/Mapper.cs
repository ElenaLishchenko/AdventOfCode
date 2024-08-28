namespace Day5
{
    public class Mapper
    {
        public HashSet<MapItem> CreateSetForMapping(List<string> lines)
        {
            var result = new HashSet<MapItem>();
            foreach (var line in lines)
            {
                result.Add(new MapItem(line));
            }
            return result;
        }

        public List<Range> FindCorrespondingValue(HashSet<MapItem> correspondingSet, Range range)
        {
            var items = correspondingSet.Where(map => map.RangeContains(range));
            if (items.Any())
            {
                var rangesToMap = new List<Range>() { range };
                var mappedRanges = new List<Range>();
                foreach (var item in items)
                {
                    var newRangesToMap = new List<Range>();
                    foreach (var rangeToMap in rangesToMap)
                    {
                        newRangesToMap = MapRanges(mappedRanges, item, newRangesToMap, rangeToMap);
                    }
                    rangesToMap.Clear();
                    rangesToMap = rangesToMap.Concat(newRangesToMap).ToList();
                }
                return mappedRanges.Concat(rangesToMap).ToList();
            }
            return new List<Range> { range };
        }

        private List<Range> MapRanges(List<Range> mappedRanges, MapItem? item, List<Range> newRangesToMap, Range rangeToMap)
        {
            var splitedRange = item.SplitRange(rangeToMap);
            if (splitedRange.MappedRange != null)
            {
                mappedRanges.Add(splitedRange.MappedRange);
            }
            if (splitedRange.NotMappedRanges.Any())
            {
                newRangesToMap = newRangesToMap.Concat(splitedRange.NotMappedRanges).ToList();
            }

            return newRangesToMap;
        }
    }
}
