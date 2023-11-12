namespace FantasyWeb.Common.Models
{
    public class PlayerStats
    {
        public long PlayerID { get; set; }

        public long PlayerIdSports { get; set; }

        public string PlayerName { get; set; }

        public int TeamID { get; set; }

        public string Position { get; set; }

        public short Price { get; set; }

        public long FormGamesPlayed { get; set; }

        public long FormGoals { get; set; }

        public long FormAssists { get; set; }

        public long FormPlusMinus { get; set; }

        public long FormPIM { get; set; }
        public double FormPowerPlayTime { get; set; }

        public int FormPowerPlayTeamPosition { get; set; }

        public int FormPowerPlayNumber { get; set; }

        public double FormTOI { get; set; }

        public long FormShotsOnGoal { get; set; }

        public float FormIxG { get; set; }

        public long FormICF { get; set; }

        public long FormIHDCF { get; set; }

        public float? ForecastGamesPlayed { get; set; }

        public float? ForecastGoals { get; set; }

        public float? ForecastAssists { get; set; }

        public float? ForecastPIM { get; set; }

        public float? ForecastPlusMinus { get; set; }

        public string ForecastSources { get; set; } = string.Empty;
    }
}
