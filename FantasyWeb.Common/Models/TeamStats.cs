namespace FantasyWeb.Common.Models
{
    public class TeamStats
    {
        public int TeamID { get; set; }
        public decimal TeamGoalsForm { get; set; }
        public decimal TeamGoalsAwayForm { get; set; }
        public string TeamForm { get; set; } = string.Empty;
    }
}
