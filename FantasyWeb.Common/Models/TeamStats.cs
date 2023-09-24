namespace FantasyWeb.Common.Models
{
    public class TeamStats
    {
        public int TeamID { get; set; }
        public string TeamAcronym { get; set; } = string.Empty;
        public decimal TeamGoalsForm { get; set; }
        public decimal TeamGoalsAwayForm { get; set; }

        public int TeamFormWinPercentage { get; set; }
        public string TeamForm { get; set; } = string.Empty;
    }
}
