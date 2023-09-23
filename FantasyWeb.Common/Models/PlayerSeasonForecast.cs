namespace FantasyWeb.Common.Models
{
    public class PlayerSeasonForecast
    {
        public int GamesPlayed { get; set; }        public int Goals { get; set; }        public int Assists { get; set; }        public int PIM { get; set; }        public int PlusMinus { get; set; }        public string ForecaseSources { get; set; } = string.Empty;    }
}
