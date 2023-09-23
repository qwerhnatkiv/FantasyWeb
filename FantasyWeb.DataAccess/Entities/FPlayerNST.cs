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
    [Table("f_players_nst", Schema = Constants.Database.CurrentSchema)]
    public class FPlayerNST
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("id_player")]
        public long? PlayerID { get; set; }

        [Column("toi")]
        public float? TOI { get; set; }

        [Column("g")]
        public int? G { get; set; }

        [Column("a")]
        public int? A { get; set; }

        [Column("ipp")]
        public float? IPP { get; set; }

        [Column("shots")]
        public int? Shots { get; set; }

        [Column("ixg")]
        public float? ixG { get; set; }

        [Column("icf")]
        public int? iCF { get; set; }

        [Column("iff")]
        public int? iFF { get; set; }

        [Column("iscf")]
        public int? iSCF { get; set; }

        [Column("ihdcf")]
        public int? iHDCF { get; set; }

        [Column("rush_attempts")]
        public int? RushAttempts { get; set; }

        [Column("rebounds_created")]
        public int? ReboundsCreated { get; set; }

        [Column("pim")]
        public int? PIM { get; set; }

        [Column("penalties_total")]
        public int? PenaltiesTotal { get; set; }

        [Column("minor")]
        public int? Minor { get; set; }

        [Column("major")]
        public int? Major { get; set; }

        [Column("misconduct")]
        public int? Misconduct { get; set; }

        [Column("penalties_drawn")]
        public int? PenaltiesDrawn { get; set; }

        [Column("giveaways")]
        public int? Giveaways { get; set; }

        [Column("takeaways")]
        public int? Takeaways { get; set; }

        [Column("hits")]
        public int? Hits { get; set; }

        [Column("hits_taken")]
        public int? HitsTaken { get; set; }

        [Column("shots_blocked")]
        public int? ShotsBlocked { get; set; }

        [Column("faceoffs_won")]
        public int? FaceoffsWon { get; set; }

        [Column("faceoffs_lost")]
        public int? FaceoffsLost { get; set; }

        [Column("cf_ice")]
        public int? CfIce { get; set; }

        [Column("ca_ice")]
        public int? CaIce { get; set; }

        [Column("pc_cf_ice")]
        public float? PcCfIce { get; set; }

        [Column("ff_ice")]
        public int? FfIce { get; set; }

        [Column("fa_ice")]
        public int? FaIce { get; set; }

        [Column("pc_ff_ice")]
        public float? PcFfIce { get; set; }

        [Column("sf_ice")]
        public int? SfIce { get; set; }

        [Column("sa_ice")]
        public int? SaIce { get; set; }

        [Column("pc_sf_ice")]
        public float? PcSfIce { get; set; }

        [Column("gf_ice")]
        public int? GfIce { get; set; }

        [Column("ga_ice")]
        public int? GaIce { get; set; }

        [Column("pc_gf_ice")]
        public float? PcGfIce { get; set; }

        [Column("xgf_ice")]
        public float? XGfIce { get; set; }

        [Column("xga_ice")]
        public float? XGaIce { get; set; }

        [Column("pc_xgf_ice")]
        public float? Pc_xgf_ice { get; set; }

        [Column("scf_ice")]
        public int? ScfIce { get; set; }

        [Column("sca_ice")]
        public int? ScaIce { get; set; }

        [Column("pc_scf_ice")]
        public float? PcScfIce { get; set; }

        [Column("hdcf_ice")]
        public int? HdcfIce { get; set; }

        [Column("hdca_ice")]
        public int? HdcaIce { get; set; }

        [Column("pc_hdcf_ice")]
        public float? PcHdcfIce { get; set; }

        [Column("hdgf_ice")]
        public int? HdgfIce { get; set; }

        [Column("hdga_ice")]
        public int? HdgaIce { get; set; }

        [Column("pc_hdgf_ice")]
        public float? PcHdgfIce { get; set; }

        [Column("pc_sh_ice")]
        public float? PcShIce { get; set; }

        [Column("pc_sv_ice")]
        public float? PcSvIce { get; set; }

        [Column("pdo_ice")]
        public float? PdoIce { get; set; }

        [Column("off_zone_starts_ice")]
        public int? OffZoneStartsIce { get; set; }

        [Column("neu_zone_starts_ice")]
        public int? NeuZoneStartsIce { get; set; }

        [Column("def_zone_starts_ice")]
        public int? DefZoneStartsIce { get; set; }

        [Column("on_fly_starts_ice")]
        public int? OnFlyStartsIce { get; set; }

        [Column("pc_off_zone_start_ice")]
        public float? PcOffZoneStartsIce { get; set; }

        [Column("off_zone_faceoffs_ice")]
        public int? OffZoneFaceoffsIce { get; set; }

        [Column("neu_zone_faceoffs_ice")]
        public int? NeuZoneFaceoffsIce { get; set; }

        [Column("def_zone_faceoffs_ice")]
        public int? DefZoneFaceoffsIce { get; set; }

        [Column("pc_off_zone_faceoff_ice")]
        public float? PcOffZoneFaceoffIce { get; set; }

        [Column("id_game")]
        public int? GameID { get; set; }

        [Column("pp_toi")]
        public float? ToiPP { get; set; }

        [Column("name_player")]
        public string? PlayerName { get; set; }

        [Column("is_parser")]
        public bool IsParser { get; set; }

        [Column("plus_minus")]
        public short? PlusMinus { get; set; }

        [ForeignKey(nameof(GameID))]
        public DGame DGame { get; set; } = null!;

        [ForeignKey(nameof(PlayerID))]
        public DPlayer DPlayer { get; set; } = null!;

    }
}
