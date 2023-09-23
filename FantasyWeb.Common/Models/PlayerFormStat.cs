namespace FantasyWeb.Common.Models
{
    public class PlayerFormStat
    {
        public int GamesPlayed { get; set; }

        public int Goals { get; set; }

        public int Assits { get; set; }

        public int PlusMinus { get; set; }

        public int PIM { get; set; }
        public float PowerPlayTime { get; set; }

        public int PowerPlayTeamPosition { get; set; }

        public int? PowerPlayNumber { get; set; } = null;

        public float TOI { get; set; }

        public int ShotsOnGoal { get; set; }

        public float IxG { get; set; }

        public int ICF { get; set; }

        public int IHDCF { get; set; }
    }
}
