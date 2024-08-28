namespace Day3
{
    public class Dot
    {
        public char DotChar { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Dot(char dotChar, int positionX, int positionY)
        {
            DotChar = dotChar;
            PositionX = positionX;
            PositionY = positionY;
        }

        public bool IsSymbol
        {
            get
            {
                return DotChar != '.';
            }
        }

        public bool IsGear
        {
            get
            {
                return DotChar == '*';
            }
        }

        public string Id
        {
            get
            {
               return $"{PositionY}-{PositionX}";
            }
        }

        public bool IsDigit
        {
            get
            {
                return Char.IsDigit(DotChar);
            }
        }
    }
}
