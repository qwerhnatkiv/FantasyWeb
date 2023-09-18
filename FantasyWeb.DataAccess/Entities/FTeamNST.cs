using FantasyWeb.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyWeb.DataAccess.Entities
{
    [Table("f_teams_nst", Schema = Constants.Database.CurrentSchema)]
    public class FTeamNST
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("id_team")]
        public int? TeamID { get; set; }

        [Column("toi")]
        public int? TOI { get; set; }

        [Column("w")]
        public int? W { get; set; }

        [Column("l")]
        public int? L { get; set; }

        [Column("otl")]
        public int? OTL { get; set; }

        [Column("row")]
        public int? Row { get; set; }

        [Column("pts")]
        public int? Pts { get; set; }

        [Column("pc_pts")]
        public double? PcPts { get; set; }

        [Column("cf")]
        public int? CF { get; set; }

        [Column("ca")]
        public int? CA { get; set; }

        [Column("pc_cf")]
        public double? PcCF { get; set; }

        [Column("ff")]
        public int? FF { get; set; }

        [Column("fa")]
        public int? FA { get; set; }

        [Column("pc_ff")]
        public double? PcFF { get; set; }

        [Column("sf")]
        public int? SF { get; set; }

        [Column("sa")]
        public int? SA { get; set; }

        [Column("pc_sf")]
        public double? PcSF { get; set; }

        [Column("gf")]
        public int? GF { get; set; }

        [Column("ga")]
        public int? GA { get; set; }

        [Column("pc_gf")]
        public double? PcGF { get; set; }

        [Column("xgf")]
        public double? XGF { get; set; }

        [Column("xga")]
        public double? XGA { get; set; }

        [Column("pc_xgf")]
        public double? PcXGF { get; set; }

        [Column("scf")]
        public int? SCF { get; set; }

        [Column("sca")]
        public int? SCA { get; set; }

        [Column("pc_scf")]
        public double? PcSCF { get; set; }

        [Column("hdcf")]
        public int? HDCF { get; set; }

        [Column("hdca")]
        public int? HDCA { get; set; }

        [Column("pc_hdcf")]
        public double? PcHDCF { get; set; }

        [Column("hdgf")]
        public int? HDGF { get; set; }

        [Column("hdga")]
        public int? HDGA { get; set; }

        [Column("pc_hdgf")]
        public double? PcHDGF { get; set; }

        [Column("pc_hdsv")]
        public double? PcHDSV { get; set; }

        [Column("pc_hdsh")]
        public double? PcHDSH { get; set; }

        [Column("pc_sh")]
        public double? PcSH { get; set; }

        [Column("pc_sv")]
        public double? PcSV { get; set; }
        
        [Column("pdo")]
        public double? PDO { get; set; }

        [Column("id_game")]
        public int? GameID { get; set; }

        [ForeignKey(nameof(GameID))]
        public DGame DGame { get; set; } = null!;

        [ForeignKey(nameof(TeamID))]
        public DTeam DTeam { get; set; } = null!;
    }
}
