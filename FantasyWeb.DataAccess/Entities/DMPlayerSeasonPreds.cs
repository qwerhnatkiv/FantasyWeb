using FantasyWeb.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("dm_players_season_preds", Schema = Constants.Database.CurrentSchema)]
    public class DMPlayerSeasonPreds
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("gp")]
        public float? GP { get; set; }

        [Column("g")]
        public float? G { get; set; }

        [Column("a")]
        public float? A { get; set; }

        [Column("plus_minus")]
        public float? PlusMinus { get; set; }

        [Column("pim")]
        public float? PIM { get; set; }

        [Column("id_player")]
        public long PlayerID { get; set; }

        [Column("cs")]
        public float? CS { get; set; }

        [Column("wins")]
        public float? Wins { get; set; }

        [Column("otl")]
        public float? Otl { get; set; }

        [Column("id_season")]
        public int? IdSeason { get; set; }

        [ForeignKey(nameof(PlayerID))]
        public DPlayer DPlayer { get; set; } = null!;

    }
}
