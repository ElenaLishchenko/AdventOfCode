namespace Day6
{
    public class Race
    {
        public int Time {  get; set; }
        public long Distance { get; set; }

        public Race(int time, long distance)
        {
            Time = time; Distance = distance;
        }

        public long GetTimeToFinish(int speed)
        {
            long time = Distance / speed;
            return time+1;
        }

        public bool IsWinCase(int time)
        {
            var timeToFinish = GetTimeToFinish(time);
            if (timeToFinish <= Time-time)
            {
                return true;
            }
            return false;
        }

        public int GetCountOfCases()
        {
            var result = 0;
            for (int i = 1; i< Time; i++)
            {
                if (IsWinCase(i))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
