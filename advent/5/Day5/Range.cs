using System;

namespace Day5
{
    public class Range
    {
        public UInt32 Start {  get; set; }
        public UInt32 End => Start + Length - 1;
        public UInt32 Length { get; set; }
        public void Line(string name) => Console.WriteLine($"{name} : {Start} {Length}");

    public Range(UInt32 start, UInt32 length)
    {
            Start = start;
            Length = length;
        }

        public static uint GetLength(uint start, uint end)
        {
            return end - start + 1;
        }
    }
}
