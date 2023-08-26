using FantasyWeb.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("d_teams", Schema = Constants.Database.CurrentSchema)]
    public class DTeam
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name_team")]
        public string? NameTeam { get; set; }

        [Column("acronym_team_nst")]
        public string? AcronymTeamNst { get; set; }

        [Column("acronym_team_wolski")]
        public string? AcronymTeamWolski { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("acronym_team_five_thirty_eight")]
        public string? AcronymTeamFiveThirtyEight { get; set; }

        [Column("name_team_checkbestodds")]
        public string? NameTeamCheckBestOdds { get; set; }
    }
}
