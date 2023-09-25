namespace FantasyWeb.Common.Models
{
    public class PlayerExpectedFantasyPointsStats
    {
        public long PlayerID { get; set; }

        public int TeamID { get; set; }

        public int GameID { get; set; }

        public double PlayerExpectedFantasyPoints { get; set; }
    }
}
