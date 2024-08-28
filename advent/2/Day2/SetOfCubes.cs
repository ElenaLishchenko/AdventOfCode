namespace Day2
{
    public class SetOfCubes
    {
        private int _blue = 0;
        private int _green = 0;
        private int _red = 0;

        public int Blue
        {
            get { return _blue; }
            set { if (_blue < value)
                {
                    _blue = value;
                }
            }
        }

        public int Green
        { get { return _green; }
            set {  if (_green < value)
                {
                    _green = value;
                }
            }
        }

        public int Red
        { get { return _red; } set {  if (_red < value)
                {
                    _red = value;
                }
            }
        }

        public SetOfCubes(string[] parsedGameLines)
        {
            foreach (var setOfCubeLine in parsedGameLines)
            {
                var setValues = setOfCubeLine.Split(", ");
                foreach (var cubesColor in setValues)
                {
                    SetColorValue(cubesColor);
                }
            }
        }

        private void SetColorValue(string cube)
        {
            if (cube.Contains("blue"))
            {
                var cubeValue = cube.Replace(" blue", "");
                Blue = int.Parse(cubeValue);
            }
            if (cube.Contains("red"))
            {
                var cubeValue = cube.Replace(" red", "");
                Red = int.Parse(cubeValue);
            }
            if (cube.Contains("green"))
            {
                var cubeValue = cube.Replace(" green", "");
                Green = int.Parse(cubeValue);
            }
        }
    }
}
