using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FantasyWeb.Common;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("d_positions", Schema = Constants.Database.CurrentSchema)]
    public class DPosition
    {
        [Key]
        [Column("id")]
        public short ID { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("short_name")]
        public string? ShortName { get; set; }

        [Column("short_eng_name")]
        public string? ShortNameENG { get; set; }

        public ICollection<DPlayer> Players { get; } = new List<DPlayer>();
    }
}
