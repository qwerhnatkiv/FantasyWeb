using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyWeb.DataAccess.Entities
{
    public class FPlayerNST
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public float TOI { get; set; }
        public int G { get; set; }
        public int A { get; set; }
        public float IPP { get; set; }
        public int Shots { get; set; }
        public float ixG { get; set; }
        public int iCF { get; set; }
        public int iFF { get; set; }
        public int iSCF { get; set; }
        public int iHDCF { get; set; }
        public int RushAttempts { get; set; }
        public int ReboundsCreated { get; set; }
        public int PIM { get; set; }
        public int PenaltiesTotal { get; set; }
        public int Minor { get; set; }
        public int Major { get; set; }
        public int Misconduct { get; set; }
        public int PenaltiesDrawn { get; set; }
        public int Giveaways { get; set; }
        public int Takeaways { get; set; }
        public int Hits { get; set; }
        public int HitsTaken { get; set; }
        public int ShotsBlocked { get; set; }
        public int FaceoffsWon { get; set; }
        public int FaceoffsLost { get; set; }
        public int CfIce { get; set; }
        public int CaIce { get; set; }
        public float PcCfIce { get; set; }
        public int FfIce { get; set; }
        public int FaIce { get; set; }
        public float PcFfIce { get; set; }
        public int SfIce { get; set; }
        public int SaIce { get; set; }
        public float PcSfIce { get; set; }
        public int GfIce { get; set; }
        public int GaIce { get; set; }
        public float PcGfIce { get; set; }
        public float XGfIce { get; set; }
        public float XGaIce { get; set; }
        public float Pc_xgf_ice { get; set; }
        public int scf_ice { get; set; }
        public int sca_ice { get; set; }
        public float pc_scf_ice { get; set; }
        public int hdcf_ice { get; set; }
        public int hdca_ice { get; set; }
        public float pc_hdcf_ice { get; set; }
        public int hdgf_ice { get; set; }
        public int hdga_ice { get; set; }
        public float pc_hdgf_ice { get; set; }
        public float pc_sh_ice { get; set; }
        public float pc_sv_ice { get; set; }
        public float pdo_ice { get; set; }
        public int off_zone_starts_ice { get; set; }
        public int neu_zone_starts_ice { get; set; }
        public int def_zone_starts_ice { get; set; }
        public int on_fly_starts_ice { get; set; }
        public float pc_off_zone_start_ice { get; set; }
        public int off_zone_faceoffs_ice { get; set; }
        public int neu_zone_faceoffs_ice { get; set; }
        public int def_zone_faceoffs_ice { get; set; }
        public float pc_off_zone_faceoff_ice { get; set; }
        public int GameID { get; set; }
        public float ToiPP { get; set; }
        public string PlayerName { get; set; }
        public bool IsParser { get; set; }
        public short PlusMinus { get; set; }

    }
}
