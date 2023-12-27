namespace FantasyWeb.Common.Models
{
    public class TeamGameStat
    {
        public int TeamId { get; set; }

        public DateTime GameDateTime { get; set; }

        public bool IsAway { get; set; }
        public decimal TeamGoals { get; set; }
        public decimal TeamGoalsAway { get; set; }

        public decimal TeamShots { get; set; }
        public decimal TeamShotsAway { get; set; }

        public decimal TeamHdcf { get; set; }
        public decimal TeamHdcfAway { get; set; }
    }
}
