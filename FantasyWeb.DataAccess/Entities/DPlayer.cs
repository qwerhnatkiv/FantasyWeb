using FantasyWeb.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("d_players", Schema = Constants.Database.CurrentSchema)]
    public class DPlayer
    {
        [Key]
        [Column("id")]
        public long ID { get; set; }

        [Column("id_team")]
        public int? TeamID { get; set; }

        [Column("name_sports")]
        public string? NameSports { get; set; }

        [Column("name_espn")]
        public string? NameESPN { get; set; }

        [Column("name_dfo")]
        public string? NameDFO { get; set; }

        [Column("name_nhlcom")]
        public string? NameNHLCom { get; set; }

        [Column("id_position")]
        public short? IdPosition { get; set; }

        [Column("name_yura")]
        public string? NameYura { get; set; }

        [Column("name_nst_season")]
        public string? NameNSTSeason { get; set; }

        [Column("name_nst_games")]
        public string? NameNSTGames { get; set; }

        [ForeignKey(nameof(TeamID))]
        public DTeam DTeam { get; set; } = null!;

        [ForeignKey(nameof(IdPosition))]
        public DPosition DPosition { get; set; } = null!;

        public DMPlayerSeasonPreds? SeasonPrediction { get; set; }

        public ICollection<FPlayerNST> PlayerStats { get; } = new List<FPlayerNST>();

    }
}
