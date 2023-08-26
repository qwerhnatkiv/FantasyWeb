using FantasyWeb.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("d_games", Schema = Constants.Database.CurrentSchema)]
    public class DGame
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_home_team")]
        public int HomeTeamId { get; set; }

        [Column("id_away_team")]
        public int AwayTeamId { get; set; }

        [Column("game_date")]
        public DateTime GameDate { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("result")]
        public string? Result { get; set; }

        [Column("week_num")]
        public int? WeekNumber { get; set; }

        [ForeignKey(nameof(HomeTeamId))]
        public DTeam HomeTeam { get; set; } = null!;

        [ForeignKey(nameof(AwayTeamId))]
        public DTeam AwayTeam { get; set; } = null!;

        public ICollection<FGameOdd> FGameOdds { get; } = new List<FGameOdd>();
    }
}
