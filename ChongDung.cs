using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class ChongDung
    {
        private double lucDocTruyen_kN;
        private double tietDien_mm2;
        private double ungSuatChoPhep_MPa;

        public double LucDocTruyen_kN
        {
            get { return lucDocTruyen_kN; }
            set { lucDocTruyen_kN = value; }
        }

        public double TietDien_mm2
        {
            get { return tietDien_mm2; }
            set { tietDien_mm2 = value; }
        }

        public double UngSuatChoPhep_MPa
        {
            get { return ungSuatChoPhep_MPa; }
            set { ungSuatChoPhep_MPa = value; }
        }

        public double TinhUngSuatThucTe_MPa()
        {
            return (lucDocTruyen_kN * 1000) / tietDien_mm2;
        }

        public bool KiemTraChongDung()
        {
            return TinhUngSuatThucTe_MPa() <= ungSuatChoPhep_MPa;
        }
    }
}