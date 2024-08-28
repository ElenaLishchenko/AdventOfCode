namespace Day2
{
    public class GameParser
    {
        public string[] ParseGame(string gameLine)
        {
            var gamesString = gameLine.Split(':')[1].Trim();
            var setsOfCubes = gamesString.Split(";").Select(s => s.Trim());
            return setsOfCubes.ToArray();
        }

        public int GetGameNumber(string gameLine)
        {
            var gameNumberString = gameLine.Split(':')[0].Remove(0,5);
            return int.Parse(gameNumberString);
        }
    }
}
