﻿namespace FantasyWeb.Common.Models
{
    public class TeamStats
    {
        public int TeamID { get; set; }
        public string TeamAcronym { get; set; } = string.Empty;
        public string TeamName { get; set; }
        public decimal TeamGoalsForm { get; set; }
        public decimal TeamGoalsAwayForm { get; set; }
        public int TeamFormWinPercentage { get; set; }
        public string TeamForm { get; set; } = string.Empty;
        public decimal TeamFormSF { get; set; }
        public decimal TeamFormSA { get; set; }
        public double TeamFormXGF { get; set; }
        public double TeamFormXGA { get; set; }
        public IEnumerable<TeamGameStat> TeamGameStats { get; set; }

    }
}
