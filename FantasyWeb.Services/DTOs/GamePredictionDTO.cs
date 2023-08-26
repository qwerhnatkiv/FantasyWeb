namespace FantasyWeb.Services.DTOs
{
    public class GamePredictionDTO
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
    }
}
