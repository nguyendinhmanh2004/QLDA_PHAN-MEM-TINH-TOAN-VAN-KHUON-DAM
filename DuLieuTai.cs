using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class DuLieuTai
    {
        private double chieuDaySan_mm;
        private double trongLuongBeTong_kN_m3;
        private double hoatTai_kPa;
        private double taiTrongThiCong_kPa;
        private double heSoTaiTrongTinh;
        private double heSoHoatTai;

        public double ChieuDaySan_mm
        {
            get { return chieuDaySan_mm; }
            set { chieuDaySan_mm = value; }
        }

        public double TrongLuongBeTong_kN_m3
        {
            get { return trongLuongBeTong_kN_m3; }
            set { trongLuongBeTong_kN_m3 = value; }
        }

        public double HoatTai_kPa
        {
            get { return hoatTai_kPa; }
            set { hoatTai_kPa = value; }
        }

        public double TaiTrongThiCong_kPa
        {
            get { return taiTrongThiCong_kPa; }
            set { taiTrongThiCong_kPa = value; }
        }

        public double HeSoTaiTrongTinh
        {
            get { return heSoTaiTrongTinh; }
            set { heSoTaiTrongTinh = value; }
        }

        public double HeSoHoatTai
        {
            get { return heSoHoatTai; }
            set { heSoHoatTai = value; }
        }

        public double TinhTaiTrongTinh_kPa()
        {
            return (chieuDaySan_mm / 1000.0) * trongLuongBeTong_kN_m3;
        }

        public double TinhTaiTrongToanPhan()
        {
            return heSoTaiTrongTinh * TinhTaiTrongTinh_kPa() + heSoHoatTai * (hoatTai_kPa + taiTrongThiCong_kPa);
        }
    }
}