namespace Day3
{
    public class Schema
    {
        public string[] EngineSchematic { get; set; }

        public int SchemaXLength { get; set; }
        public int SchemaYLemgth { get; set; }

        public Dictionary<string, List<int>> Gears { get; set; } = new Dictionary<string, List<int>>();

        public Schema(string[] schema)
        {
            EngineSchematic = schema;
            SchemaXLength = schema[0].Length;
            SchemaYLemgth = schema.Length;
        }

        public int GetSum()
        {
            var result = 0;
            for (int i = 0; i < SchemaYLemgth; i++)
            {
                var row = EngineSchematic[i];
                var numberDots = new List<Dot>();
                for (int j = 0; j < SchemaXLength; j++) 
                {
                    var dot = new Dot(row[j], j, i);
                    if (!dot.IsDigit && numberDots.Count == 0)
                    {
                        continue;
                    }
                    if (!dot.IsDigit)
                    {
                        if (CheckIsEngineAndUpdateForPart2(numberDots))
                        {
                            var numberString = string.Join(string.Empty, numberDots.Select(d => row[d.PositionX]).ToArray());
                            var number = Int32.Parse(numberString);
                            result += number;
                        }
                        numberDots.Clear();
                        continue;
                    }
                    numberDots.Add(dot);
                    if (j == row.Length - 1)
                    {
                        if (CheckIsEngineAndUpdateForPart2(numberDots))
                        {
                            var number = Int32.Parse(string.Join(string.Empty, numberDots.Select(d => row[d.PositionX]).ToArray()));
                            result += number;
                        }
                        numberDots.Clear();
                    }
                }
            }
            return result;
        }

        public int GetGears()
        {
            return Gears.Where(g => g.Value.Count == 2).Select(g => g.Value[0] * g.Value[1]).Sum();
        }

        private bool CheckIsEngineAndUpdateForPart2 (List<Dot> numberDots)
        {
            var result = false;
            var firstDot = numberDots.FirstOrDefault();
            var lastDot = numberDots.Last();

            var isFirstRow = firstDot.PositionY == 0;
            var isLastRow = firstDot.PositionY == SchemaYLemgth - 1;
            var number = Int32.Parse(string.Join(string.Empty, numberDots.Select(d => EngineSchematic[firstDot.PositionY][d.PositionX]).ToArray()));

            var dotBeforeFirst = firstDot.PositionX > 0 ? new Dot(EngineSchematic[firstDot.PositionY][firstDot.PositionX - 1], firstDot.PositionX - 1, firstDot.PositionY) : null;
            var dotAfterLast = lastDot.PositionX < SchemaXLength-1 ? new Dot(EngineSchematic[lastDot.PositionY][lastDot.PositionX + 1], lastDot.PositionX + 1, lastDot.PositionY) : null;

            if ((dotBeforeFirst != null && dotBeforeFirst.IsSymbol) || (dotAfterLast != null && dotAfterLast.IsSymbol))
            {
                if (dotBeforeFirst !=null) UpdateGearsWithDot(number, dotBeforeFirst);
                if (dotAfterLast != null) UpdateGearsWithDot(number, dotAfterLast);
                result = true;
            }

            if (!isFirstRow) {
                var rowBefore = EngineSchematic[firstDot.PositionY - 1];
                var dotBeforeFirstRowBefore = firstDot.PositionX > 0 ? new Dot(rowBefore[firstDot.PositionX - 1], firstDot.PositionX - 1, firstDot.PositionY-1) : null;
                var dotAfterLastRowBefore = lastDot.PositionX < SchemaXLength-1 ? new Dot(rowBefore[lastDot.PositionX + 1], lastDot.PositionX + 1, lastDot.PositionY-1) : null;
                if ((dotBeforeFirstRowBefore != null && dotBeforeFirstRowBefore.IsSymbol) || (dotAfterLastRowBefore != null && dotAfterLastRowBefore.IsSymbol))
                {
                    if (dotBeforeFirstRowBefore != null) UpdateGearsWithDot(number, dotBeforeFirstRowBefore);
                    if (dotAfterLastRowBefore != null) UpdateGearsWithDot(number, dotAfterLastRowBefore);
                    result = true;
                }

                foreach ( var dot in numberDots) {
                    var newDot = new Dot(rowBefore[dot.PositionX], dot.PositionX, dot.PositionY - 1);
                    if (newDot.IsSymbol) {
                        UpdateGearsWithDot(number, newDot);
                        result = true;
                    }
                }
            }

            if (!isLastRow)
            {
                var rowAfter = EngineSchematic[firstDot.PositionY + 1];
                var dotBeforeFirstRowAfter = firstDot.PositionX > 0 ? new Dot(rowAfter[firstDot.PositionX - 1], firstDot.PositionX - 1, firstDot.PositionY+1) : null;
                var dotAfterLastRowAfter = lastDot.PositionX < SchemaXLength-1 ? new Dot(rowAfter[lastDot.PositionX + 1], lastDot.PositionX + 1, lastDot.PositionY+1) : null;
                if ((dotBeforeFirstRowAfter != null && dotBeforeFirstRowAfter.IsSymbol) || (dotAfterLastRowAfter != null && dotAfterLastRowAfter.IsSymbol))
                {
                    if (dotBeforeFirstRowAfter != null) UpdateGearsWithDot(number, dotBeforeFirstRowAfter);
                    if (dotAfterLastRowAfter != null) UpdateGearsWithDot(number, dotAfterLastRowAfter);
                    result = true;
                }

                foreach (var dot in numberDots)
                {
                        var newDot = new Dot(rowAfter[dot.PositionX], dot.PositionX, dot.PositionY + 1);
                        if (newDot.IsSymbol)
                        {
                            UpdateGearsWithDot(number, newDot);
                            result = true;
                        }
                }
            }
            return result;
        }

        private void UpdateGearsWithDot(int number, Dot dotForCheck)
        {
            if (dotForCheck.IsGear)
            {
                if (Gears.TryGetValue(dotForCheck.Id, out var gear))
                {
                    gear.Add(number);
                }
                else
                {
                    Gears.Add(dotForCheck.Id, new List<int>() { number });
                }
            }
        }
    }
}
