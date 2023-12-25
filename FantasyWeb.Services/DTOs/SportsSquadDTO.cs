namespace FantasyWeb.Services.DTOs
{
    public class SportsSquadDTO
    {
        public IEnumerable<SportsSquadPlayerDTO>? Players { get; set; }

        public int Balance { get; set; }

        public int Substitutions { get; set; }
    }
}
