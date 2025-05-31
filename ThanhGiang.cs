using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TINHTOANVANKHUONDAM.Class
{
    public class ThanhGiang
    {
        private double apLucBeTong_kN_m2;
        private double khoangCach_m;
        private double lucChiuKeoToiDa_kN;

        public double ApLucBeTong_kN_m2
        {
            get { return apLucBeTong_kN_m2; }
            set { apLucBeTong_kN_m2 = value; }
        }

        public double KhoangCach_m
        {
            get { return khoangCach_m; }
            set { khoangCach_m = value; }
        }

        public double LucChiuKeoToiDa_kN
        {
            get { return lucChiuKeoToiDa_kN; }
            set { lucChiuKeoToiDa_kN = value; }
        }

        public double TinhLucThanhGiang()
        {
            return apLucBeTong_kN_m2 * khoangCach_m;
        }

        public bool KiemTraThanhGiang()
        {
            return TinhLucThanhGiang() <= lucChiuKeoToiDa_kN;
        }
    }
}