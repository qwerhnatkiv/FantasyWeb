﻿namespace FantasyWeb.Common.Models
{
    public class GamePrediction
    {
        public string HomeTeamName { get; set; }
        public string HomeTeamAcronym { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamAcronym { get; set; }
        public DateTime GameDate { get; set; }
        public float HomeTeamWinChance { get; set; }
        public float AwayTeamWinChance { get; set; }
        public float DrawChance { get; set; }
        public int WeekNumber { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}