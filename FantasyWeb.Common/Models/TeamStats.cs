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


        public decimal TeamFormSF { get; set; }

        public decimal TeamFormSA { get; set; }

        public decimal TeamFormXGF { get; set; }

        public decimal TeamFormXGA { get; set; }

        public IEnumerable<TeamGameStat> TeamGameStats { get; set; }

    }
}
