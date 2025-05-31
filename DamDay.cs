using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class DamDay
    {
        private double nhipDam_m;
        private double taiTruyenLenDam_kN_m;
        private double moMenKhang_cm3;
        private double modunDanHoi_MPa;
        private double ungSuatChoPhep_MPa;

        public double NhipDam_m
        {
            get { return nhipDam_m; }
            set { nhipDam_m = value; }
        }

        public double TaiTruyenLenDam_kN_m
        {
            get { return taiTruyenLenDam_kN_m; }
            set { taiTruyenLenDam_kN_m = value; }
        }

        public double MoMenKhang_cm3
        {
            get { return moMenKhang_cm3; }
            set { moMenKhang_cm3 = value; }
        }

        public double ModunDanHoi_MPa
        {
            get { return modunDanHoi_MPa; }
            set { modunDanHoi_MPa = value; }
        }

        public double UngSuatChoPhep_MPa
        {
            get { return ungSuatChoPhep_MPa; }
            set { ungSuatChoPhep_MPa = value; }
        }

        public double TinhMoMen_Ultimate_kNm()
        {
            return taiTruyenLenDam_kN_m * Math.Pow(nhipDam_m, 2) / 8;
        }

        public double TinhUngSuat_MPa()
        {
            double MoMen_Nmm = TinhMoMen_Ultimate_kNm() * 1_000_000;
            double MoMenKhang_mm3 = moMenKhang_cm3 * 1000;
            return MoMen_Nmm / MoMenKhang_mm3;
        }

        public bool KiemTraDamDatUngSuat()
        {
            return TinhUngSuat_MPa() <= ungSuatChoPhep_MPa;
        }
    }
}