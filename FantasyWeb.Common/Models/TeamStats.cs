namespace FantasyWeb.Common.Models
{
    public class TeamStats
    {
        public int TeamID { get; set; }
        public double TeamGoalsForm { get; set; }
        public double TeamGoalsAwayForm { get; set; }
        public string TeamForm { get; set; } = string.Empty;
    }
}
