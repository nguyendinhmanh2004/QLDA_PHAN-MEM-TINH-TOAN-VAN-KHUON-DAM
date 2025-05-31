
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class TinhToanTai
    {
        private readonly DuLieuTai _duLieu;
        private double khoangCachDam_m;

        public TinhToanTai(DuLieuTai duLieu)
        {
            _duLieu = duLieu;
        }

        public double KhoangCachDam_m
        {
            get { return khoangCachDam_m; }
            set { khoangCachDam_m = value; }
        }

        public double TinhTaiTruyenLenDam_kN_m()
        {
            return _duLieu.TinhTaiTrongToanPhan() * khoangCachDam_m;
        }
    }
}