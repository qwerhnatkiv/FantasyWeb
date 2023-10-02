namespace FantasyWeb.Common.Models
{
    public class PlayerExpectedFantasyPointsStats
    {
        public long PlayerID { get; set; }

        public int TeamID { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public int GameID { get; set; }

        public double PlayerExpectedFantasyPoints { get; set; }
    }
}
