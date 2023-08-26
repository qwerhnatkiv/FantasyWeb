using FantasyWeb.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("f_game_odds", Schema = Constants.Database.CurrentSchema)]
    public class FGameOdd
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_game")]
        public int GameId { get; set; }

        [Column("home_win")]
        public float? HomeWinChance { get; set; }

        [Column("away_win")]
        public float? AwayWinChance { get; set; }

        [Column("draw")]
        public float? DrawChance { get; set; }

        [Column("home_total_over")]
        public float? HomeTotalOverChance { get; set; }

        [Column("away_total_over")]
        public float? AwayTotalOverChance { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [ForeignKey(nameof(GameId))]
        public DGame DGame { get; set; } = null!;
    }
}
