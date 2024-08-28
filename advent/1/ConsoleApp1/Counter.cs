namespace ConsoleApp1
{
    public static class Counter
    {
        public static int Count(string dataForCount)
        {
            var data = dataForCount.Where(Char.IsDigit).ToArray();
            return Int32.Parse(data[0].ToString() + data[data.Length - 1].ToString());
        }
    }
}
