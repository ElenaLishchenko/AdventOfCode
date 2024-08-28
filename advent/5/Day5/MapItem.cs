namespace Day5
{
    public class MapItem
    {
        private uint _destinationRangeStart;
        private uint _sourceRangeStart;
        private uint _sourceRangeEnd;
        private uint _rangeLength;

        public MapItem(string line)
        {
            var rangeInformation = line
                .Split(" ")
                .Where(number => !string.IsNullOrWhiteSpace(number))
                .Select(number => UInt32.Parse(number.Trim()))
                .ToArray();
            if (rangeInformation.Length > 3)
            {
                throw new Exception();
            }
            _destinationRangeStart = rangeInformation[0];
            _sourceRangeStart = rangeInformation[1];
            _rangeLength = rangeInformation[2];
            _sourceRangeEnd = _sourceRangeStart + _rangeLength - 1;
        }

        public bool RangeContains(Range range) {
            if (_sourceRangeEnd < range.Start || _sourceRangeStart > range.End)
            {
                return false;
            }
            return true;
        }

        public SplitedRange SplitRange(Range range)
        {
            if (range.Start >= _sourceRangeStart && range.End <= _sourceRangeEnd) 
            {
                var mappedRange = new Range(GetNewValueWithGap(range.Start), range.Length);
                return new SplitedRange
                {
                    MappedRange = mappedRange,
                }; 
            }
            if (range.Start >= _sourceRangeStart)
            {
                var mappedRange = new Range(GetNewValueWithGap(range.Start), Range.GetLength(range.Start, _sourceRangeEnd));
                var notMappedRange = new Range(_sourceRangeEnd + 1, Range.GetLength(_sourceRangeEnd + 1, range.End));
                if ((mappedRange.Length + notMappedRange.Length) != range.Length)
                {
                    throw new InvalidOperationException();
                }
                return new SplitedRange
                {
                    MappedRange = mappedRange,
                    NotMappedRanges = new List<Range> { notMappedRange }
                };
            }
            if (_sourceRangeStart < range.End && range.End <= _sourceRangeEnd)
            {
                var notMappedRange = new Range(range.Start, Range.GetLength(range.Start, _sourceRangeStart - 1));
                var mappedRange = new Range(GetNewValueWithGap(_sourceRangeStart), Range.GetLength(_sourceRangeStart, range.End));
                if ((mappedRange.Length + notMappedRange.Length) != range.Length)
                {
                    throw new InvalidOperationException();
                }
                return new SplitedRange
                {
                    MappedRange = mappedRange,
                    NotMappedRanges = new List<Range> { notMappedRange }
                };
            }
            if (_sourceRangeStart > range.Start && range.End > _sourceRangeEnd)
            {
                var notMappedRangeBefore = new Range(range.Start, Range.GetLength(range.Start, _sourceRangeStart - 1));
                var notMappedRangeAfter = new Range(_sourceRangeEnd + 1, Range.GetLength(_sourceRangeEnd + 1, range.End));

                var mappedRange = new Range(GetNewValueWithGap(_sourceRangeStart), _rangeLength);
                if ((mappedRange.Length + notMappedRangeBefore.Length + notMappedRangeAfter.Length) != range.Length)
                {
                    throw new InvalidOperationException();
                }
                return new SplitedRange
                {
                    MappedRange = mappedRange,
                    NotMappedRanges = new List<Range> { notMappedRangeBefore, notMappedRangeAfter }
                };
            }
            return new SplitedRange
            {
                NotMappedRanges = new List<Range> { range }
            };
        }

        private uint GetNewValueWithGap(uint value)
        {
            if (_sourceRangeStart > _destinationRangeStart && (_sourceRangeStart - _destinationRangeStart) > value)
            {
                throw new InvalidOperationException();
            }
            return value + _destinationRangeStart - _sourceRangeStart;
        }
    }
}
